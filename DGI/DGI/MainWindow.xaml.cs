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
            viewer_1 = new GViewer();
            viewer_2 = new GViewer();
            graphController_1 = new GraphController();
            graphController_2 = new GraphController();
            graph_1 = new Graph();
            graph_2 = new Graph();

            Setup_GraphViewers();
        }

        private void Setup_GraphViewers()
        {
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
            if (size > 30 || size < 1) { if (size > 30) { MessageBox.Show("Niestety, z powodów technicznych nie obsługujemy grafów większych niż 30 elementów, proszę wczytać graf z pliku"); } return null; }

            return new Tuple<int, int>(index, size);
        }

        /// <param name="WFHIndex">Index okna WFHI. 0 to pierwsze okno, 1 to po prawej, 
        ///         pobierane przez okno ChooseViewer.xaml</param>
        /// <param name="listOrMatrix">lista lub macierz sąsiedztwa</param>
        private void CommonOperations2(int WFHIndex, object listOrMatrix)
        {
            GViewer gViewerRef = WFHIndex == 0 ? viewer_1 : viewer_2;
            GraphController graphControllerReference = WFHIndex == 0 ? graphController_1 : graphController_2;

            if(listOrMatrix is int[,]) graphControllerReference = new GraphController(this, (int[,]) listOrMatrix);
            else graphControllerReference = new GraphController(this, (List<List<int>>)listOrMatrix);
            Thread.Sleep(1000);

            Graph graphRef = WFHIndex == 0 ? graph_1 : graph_2;
            graphRef = Converters.GraphModelToMSAGLGraph(graphControllerReference);
            gViewerRef.Graph = graphRef;
            WindowsFormsHost wfhReference = WFHIndex == 0 ? WFH1 : WFH1;
            wfhReference.IsEnabled = true;
            wfhReference.Child = gViewerRef;
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

        private void AdjListMenuItem_Click(object sender, RoutedEventArgs e)
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

        public static void ChangeProgresDupy(int val)
        {
            mainWindow.progresDupa.Value = val;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gc1 = new GraphController(this, ExampleAdjacencyLists.lista9_9_a1);
            gc2 = new GraphController(this, ExampleAdjacencyLists.lista9_9_a2);
            System.Threading.Thread.Sleep(1000);
            GraphCompare.AreBijective(gc1, gc2);
        }
    }
}
