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
using System.Windows.Shapes;

namespace DGI.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for ChooseViewer.xaml
    /// </summary>
    public partial class ChooseViewer : Window
    {
        int _choosen;
        public ChooseViewer()
        {
            InitializeComponent();
        }

        public int ReturnViewerIndex()
        {
            base.ShowDialog();
            return _choosen;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _choosen = -1;
            this.Close();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            _choosen = radioB1.IsChecked == true ? 0 : 1;
            Close();
        }
    }
}
