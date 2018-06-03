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

            /* GraphController gc1 = new GraphController(this, ExampleAdjacencyLists.lista4_5_a1);
             GraphController gc2 = new GraphController(this, ExampleAdjacencyLists.lista4_5_a2);

            GraphController gc3 = new GraphController(this, ExampleAdjacencyLists.lista4_6_a1);
            GraphController gc4 = new GraphController(this, ExampleAdjacencyLists.lista4_6_a2);
            GraphController gc5 = new GraphController(this, ExampleAdjacencyLists.lista4_6_b1);

            GraphController gc6 = new GraphController(this, ExampleAdjacencyLists.lista6_7_a1);
            GraphController gc7 = new GraphController(this, ExampleAdjacencyLists.lista6_7_a2);
            GraphController gc8 = new GraphController(this, ExampleAdjacencyLists.lista6_7_b1);

            GraphController gc9 = new GraphController(this, ExampleAdjacencyLists.lista9_9_a1);
            GraphController gc10 = new GraphController(this, ExampleAdjacencyLists.lista9_9_a2);
            System.Threading.Thread.Sleep(2000);*/

            List<List<int>> lista1 = new List<List<int>>();
            List<List<int>> lista2 = new List<List<int>>();
            Random rand = new Random();
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                lista1.Add(new List<int>());
                lista2.Add(new List<int>());
                for (int j = 0; j < 2; j++)
                {
                    lista1[i].Add(rand.Next(0, n));
                    lista2[i].Add(rand.Next(2, n )/2);
                }

            }
             gc1 = new GraphController(this, lista1);
            gc2 = new GraphController(this, lista2);
        }
        GraphController gc2, gc1;
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
