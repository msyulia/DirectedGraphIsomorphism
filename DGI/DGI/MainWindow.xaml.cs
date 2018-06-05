using System.Windows;
using System.Windows.Forms.Integration;
using Microsoft.Msagl.GraphViewerGdi;
using DGI.Controller;
using DGI.CoreClasses;
using Microsoft.Msagl.Drawing;
using System.Windows.Controls;
using DGI.Model;
using System.Threading;
using System;
using System.Collections.Generic;
using DGI.AdditionalWindows;

namespace DGI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static LogWindow ConsoleLog;


        private const string REPO_URI = "https://github.com/KowalikJakub/DirectedGraphIsomorphism";

        private GViewer viewer_1;
        private GViewer viewer_2;

        private Graph graph_1;
        private Graph graph_2;

        private GraphController graphController_1;
        private GraphController graphController_2;

        private static MainWindow _mainWindowInstance;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowInstance = this;

            Setup_GraphViewers();

            graphController_1 = new GraphController();
            graphController_2 = new GraphController();
        }

        private void Setup_GraphViewers()
        {
            graph_1 = new Graph();
            graph_2 = new Graph();
            viewer_1 = new GViewer
            {
                Graph = graph_1
            };

            viewer_2 = new GViewer
            {
                Graph = graph_2
            };
            _mainWindowInstance.WFH1.Child = viewer_1;
            _mainWindowInstance.WFH2.Child = viewer_2;
        }

        private void SourceCodeButton_Click(object sender, RoutedEventArgs e)
        {
            BrowserController bl = new BrowserController(REPO_URI);
            bl.OpenBrowser();
        }

        public static void ChangeProgress(int val)
        {
            _mainWindowInstance.progressBar.Value = val;
        }

        private void ShowLogWindow_Click(object sender, RoutedEventArgs e)
        {
            if (ConsoleLog != null)
            {
                if (!ConsoleLog.IsVisible)
                {
                    //Activate the window
                    ConsoleLog.Activate();
                }
            }
            else
            {
                ConsoleLog = new LogWindow();
                ConsoleLog.Show();
            }
        }

        private Tuple<int, int> CommonOperations1()
        {
            IsEnabled = false;
            ChooseViewer chv = new ChooseViewer();
            int index = chv.ReturnViewerIndex();
            if (index == -1) { return null; }

            TypingInAdjMatrixSize window = new TypingInAdjMatrixSize();
            int size = window.ReturnSizeOfMatrix();
            if (size > 30 || size < 1) { if (size > 30) { MessageBox.Show("Niestety, z powodów technicznych nie obsługujemy grafów większych niż 30 wierzchołków, proszę wczytać graf z pliku"); } return null; }

            return new Tuple<int, int>(index, size);
        }

        /// <param name="WFHIndex">Index okna WFHI. 0 to pierwsze okno, 1 to po prawej, 
        ///         pobierane przez okno ChooseViewer.xaml</param>
        /// <param name="listOrMatrix">lista lub macierz sąsiedztwa</param>
        private void CommonOperations2(int WFHIndex, object listOrMatrix)
        {
            GViewer gViewerRef = WFHIndex == 0 ? viewer_1 : viewer_2;
            GraphController graphControllerReference = new GraphController();

            if(listOrMatrix is int[,]) graphControllerReference = new GraphController(this, (int[,]) listOrMatrix);
            else graphControllerReference = new GraphController(this, (List<List<int>>)listOrMatrix);
            Thread.Sleep(1000);

            Graph graphRef = new Graph();
            graphRef = Converters.GraphModelToMSAGLGraph(graphControllerReference);
            gViewerRef.Graph = graphRef;
            WindowsFormsHost wfhReference = WFHIndex == 0 ? WFH1 : WFH2;
            wfhReference.IsEnabled = true;
            wfhReference.Child = gViewerRef;

            if(WFHIndex == 0) { graphController_1 = graphControllerReference; graph_1 = graphRef; }
            else { graphController_2 = graphControllerReference; graph_2 = graphRef; }

            IsEnabled = true;
        }

        private void adjMatrixMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Tuple<int, int> tuple = CommonOperations1();
            if(tuple == null) { IsEnabled = true; return; }
            int size = tuple.Item2;

            AdjMtrx adjacencyMatrix = new AdjMtrx(size);
            int[,] matrix = adjacencyMatrix.ReturnAdjMatrix();
            if (matrix == null) { IsEnabled = true; return; }

            CommonOperations2(tuple.Item1, matrix);
        }

        private void adjListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Tuple<int, int> tuple = CommonOperations1();
            if (tuple == null) { IsEnabled = true; return; }
            GViewer gViewerReference = tuple.Item1 == 0 ? viewer_1 : viewer_2;
            int size = tuple.Item2;

            AdjList adjacencyList = new AdjList(size);
            List<List<int>> list = adjacencyList.ReturnAdjList();
            if (list == null) { IsEnabled = true; return; }

            CommonOperations2(tuple.Item1, list);
        }

        private void LoadGraphItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".txt",
            };
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string fileName = dlg.FileName;
                List<List<int>> adjList = GraphController.LoadGraph(fileName);

                ChooseViewer viewer = new ChooseViewer();
                int index = viewer.ReturnViewerIndex();
                CommonOperations2(index, adjList);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nie można otworzyć pliku, nieznany błąd","Błąd",System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private async void SaveGraphItem_Click(object sender, RoutedEventArgs e)
        {
            ChooseViewer viewer = new ChooseViewer();
            int index = viewer.ReturnViewerIndex();
            GraphController gc = index == 0 ? graphController_1 : graphController_2;
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                await GraphController.SaveGraphAsync(gc.Graph, sfd.FileName);
            }
        }

        private void checkIsomorphismButton_Click(object sender, RoutedEventArgs e)
        {
            if (graphController_1.Graph != null && graphController_2.Graph != null)
            {
                bool result = GraphOperation.IsBijective(graphController_1.Graph, graphController_2.Graph, 0, new bool[graphController_2.Graph.VerticesCount], new List<int>());

                string message = "";

                if (result)
                    message = "Grafy są izomorficzne!";
                else message = "Niestety grafy nie są izomorficzne";
                MessageBox.Show(message, "Wynik", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void closeMeuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
