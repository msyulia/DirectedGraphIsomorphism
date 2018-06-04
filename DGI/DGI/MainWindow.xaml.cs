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

            //GraphController gc1 = new GraphController(this, ExampleAdjacencyLists.lista4_5_a1);
            //GraphController gc2 = new GraphController(this, ExampleAdjacencyLists.lista4_5_a2);

            //GraphController gc3 = new GraphController(this, ExampleAdjacencyLists.lista4_6_a1);
            //GraphController gc4 = new GraphController(this, ExampleAdjacencyLists.lista4_6_a2);
            //GraphController gc5 = new GraphController(this, ExampleAdjacencyLists.lista4_6_b1);

            //GraphController gc6 = new GraphController(this, ExampleAdjacencyLists.lista6_7_a1);
            //GraphController gc7 = new GraphController(this, ExampleAdjacencyLists.lista6_7_a2);
            //GraphController gc8 = new GraphController(this, ExampleAdjacencyLists.lista6_7_b1);

            //GraphController gc9 = new GraphController(this, ExampleAdjacencyLists.lista9_9_a1);
            //GraphController gc10 = new GraphController(this, ExampleAdjacencyLists.lista9_9_a2);

            //    int a = 0; // ilość sprawdzonych kombinacji
            //    Dupa.Text += "Pierwszy zestaw: " + GraphOperation.IsBijective(gc1.Graph, gc2.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            //    Dupa.Text += "\nDrugi zestaw: " + GraphOperation.IsBijective(gc3.Graph, gc4.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            //    Dupa.Text += "\nZestaw niepoprawny 6 krawędzi: " + GraphOperation.IsBijective(gc4.Graph, gc5.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            //    Dupa.Text += "\nPomieszanie zestawów 1 i 2: " + GraphOperation.IsBijective(gc1.Graph, gc4.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            //    Dupa.Text += "\nWysłanie tego samego grafu: " + GraphOperation.IsBijective(gc1.Graph, gc1.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            //    Dupa.Text += "\nWysłanie 2 grafów z 6 wierz: " + GraphOperation.IsBijective(gc6.Graph, gc7.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            //    Dupa.Text += "\nWysłanie 2 grafów z 6 wierz wersja 2: " + GraphOperation.IsBijective(gc6.Graph, gc8.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            //    Dupa.Text += "\nGrafy z 9 wierzchołkami: " + GraphOperation.IsBijective(gc9.Graph, gc10.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
        }

        private void Setup_GraphViewers()
        {
            viewer_1 = new GViewer();
            viewer_2 = new GViewer();

            //Testowe grafy jak się zrobi tworzenie grafu z poziomu aplikacji to tu trzeba podmienić
            // graph_1 = Converters.GraphModelToMSAGLGraph(GraphModel.RandomGraph(10, 3));
            graph_2 = Converters.GraphModelToMSAGLGraph(GraphModel.RandomGraph(15, 5));

            viewer_2.Graph = graph_2;

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

        private void adjMatrixMenuItem_Click(object sender, RoutedEventArgs e)
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

        private void adjListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AdditionalWindows.TypingInAdjMatrixSize window = new AdditionalWindows.TypingInAdjMatrixSize();
            IsEnabled = false;
            int a = window.ReturnSizeOfMatrix(this);
            Console.WriteLine(a);
        }
    }
}
