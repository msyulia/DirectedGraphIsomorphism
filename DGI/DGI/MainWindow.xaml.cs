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

        private static MainWindow _mainWindowInstance;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowInstance = this;

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

        private void AdjMatrixMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AdditionalWindows.TypingInAdjMatrixSize window = new AdditionalWindows.TypingInAdjMatrixSize();
            IsEnabled = false;
            int a = window.ReturnSizeOfMatrix(this);
            if(a > 0)
            {
                AdditionalWindows.AdjMtrx am = new AdditionalWindows.AdjMtrx(a);
                int[,] tab = am.ReturnAdjMatrix(this);

                GraphModel gm = new GraphModel(tab);
                graph_1 = Converters.GraphModelToMSAGLGraph(gm);

                viewer_1.Graph = graph_1;
                _mainWindowInstance.WFH1.Child = viewer_1;
            }

        }

        private void AdjListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AdditionalWindows.TypingInAdjMatrixSize window = new AdditionalWindows.TypingInAdjMatrixSize();
            IsEnabled = false;
            int a = window.ReturnSizeOfMatrix(this);
            AdditionalWindows.AdjList adl = new AdditionalWindows.AdjList(a);
            List<List<int>> lista = adl.ReturnAdjList(this);
        }
    }
}
