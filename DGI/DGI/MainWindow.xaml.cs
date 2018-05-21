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

        public MainWindow()
        {
            InitializeComponent();


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
    }
}
