using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Msagl;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Layout;
using Microsoft.Msagl.GraphViewerGdi;
using DGI.Controller;
using DGI.Model;
using DGI.CoreClasses;

namespace DGI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string REPO_URI = "https://github.com/KowalikJakub/DirectedGraphIsomorphism";

        private Grid graphViewerGrid = new Grid();
        private GViewer viewer_1 = new GViewer();
        private GViewer viewer_2 = new GViewer();

        private static MainWindow mainWindow;

        

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;

            GraphController gc1 = new GraphController(this, ExampleAdjacencyLists.lista4_5_a1);
            GraphController gc2 = new GraphController(this, ExampleAdjacencyLists.lista4_5_a2);

            GraphController gc3 = new GraphController(this, ExampleAdjacencyLists.lista4_6_a1);
            GraphController gc4 = new GraphController(this, ExampleAdjacencyLists.lista4_6_a2);
            GraphController gc5 = new GraphController(this, ExampleAdjacencyLists.lista4_6_b1);

            GraphController gc6 = new GraphController(this, ExampleAdjacencyLists.lista6_7_a1);
            GraphController gc7 = new GraphController(this, ExampleAdjacencyLists.lista6_7_a2);
            GraphController gc8 = new GraphController(this, ExampleAdjacencyLists.lista6_7_b1);

            GraphController gc9 = new GraphController(this, ExampleAdjacencyLists.lista9_9_a1);
            GraphController gc10 = new GraphController(this, ExampleAdjacencyLists.lista9_9_a2);

            System.Threading.Thread.Sleep(4000);
            int a = 0; // ilość sprawdzonych kombinacji
            Dupa.Text += "Pierwszy zestaw: " + GraphOperation.IsBijective(gc1.Graph, gc2.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            Dupa.Text += "\nDrugi zestaw: " + GraphOperation.IsBijective(gc3.Graph, gc4.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            Dupa.Text += "\nZestaw niepoprawny 6 krawędzi: " + GraphOperation.IsBijective(gc4.Graph, gc5.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            Dupa.Text += "\nPomieszanie zestawów 1 i 2: " + GraphOperation.IsBijective(gc1.Graph, gc4.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            Dupa.Text += "\nWysłanie tego samego grafu: " + GraphOperation.IsBijective(gc1.Graph, gc1.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            Dupa.Text += "\nWysłanie 2 grafów z 6 wierz: " + GraphOperation.IsBijective(gc6.Graph, gc7.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            Dupa.Text += "\nWysłanie 2 grafów z 6 wierz wersja 2: " + GraphOperation.IsBijective(gc6.Graph, gc8.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
            Dupa.Text += "\nGrafy z 9 wierzchołkami: " + GraphOperation.IsBijective(gc9.Graph, gc10.Graph,0, new bool[100], new List<int>(), ref a) +"\t\tIlość potencjalnych dopasowań: "+ a; a = 0;
        }
        private void Create_GraphView()
        {
            graphViewerGrid.ClipToBounds = true;

        }
        private void SourceCodeButton_Click(object sender, RoutedEventArgs e)
        {
            BrowserController bl = new BrowserController(REPO_URI);
            bl.OpenBrowser();
        }

        public static void ChangeProgress(int val)
        {
            mainWindow.progressBar.Value = val;
        }
    }
}
