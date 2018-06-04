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
    /// Interaction logic for AdjMtrx.xaml
    /// </summary>
    public partial class AdjMtrx : Window
    {
        int size;
        int[,] _matrix;
        public AdjMtrx(int size)
        {
            InitializeComponent();
            this.size = size;
            if (size < 25)
            {
                Width = (size + 1) * 35;
                Height = (size + 1) * 43;
            }
            else
            {
                Width = 1;
                Height = 1;
            }

        }

        public int[,] ReturnAdjMatrix(MainWindow mw)
        {
            _matrix = new int[size, size];
            if (size > 25)
            {
                MessageBox.Show("Niestety, macierz o podanych rozmiarach możemy przetworzyć tylko z pliku, za utrudnienia przepraszamy!");
                this.Close();
                return null;
            }
            MatrixFramework();
            base.ShowDialog();
            return _matrix;
        }

        private void MatrixFramework()
        {
            //create the structure
            Grid g = new Grid();
            g.Name = "netGrid";
            g.ShowGridLines =false;
            g.Visibility = Visibility.Visible;
            g.HorizontalAlignment = HorizontalAlignment.Center;
            g.VerticalAlignment = VerticalAlignment.Center;

            for (int i = 0; i < size + 1; ++i)
            {
                RowDefinition rd = new RowDefinition();
                rd.Name = "Row" + i.ToString();
                g.RowDefinitions.Add(rd);
                ColumnDefinition cd = new ColumnDefinition();
                cd.Name = "Column" + i.ToString();
                cd.MinWidth = 30;
                g.ColumnDefinitions.Add(cd);
            }

            for (int i = 0; i < size + 1; i++)
            {
                for (int j = 0; j < size + 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    TextBlock tb = new TextBlock();
                    if (i == 0 || j == 0)
                    {
                        tb.Text = i == 0 ? j + "" : i + "";
                        tb.Background = Brushes.LightGray;
                    }
                    else
                    {
                        tb.Text = 0 + "";
                        tb.MouseLeftButtonDown += changeValue;
                    }
                    tb.Name = "textBox_" + i + "_" + j;

                    g.Children.Add(tb);
                    Grid.SetRow(tb, i);
                    Grid.SetColumn(tb, j);
                }
            }

            this.containerStackPanel.Children.Add(g);
        }

        private void changeValue(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            string[] tab = tb.Name.Split('_');
            int i = Convert.ToInt32(tab[1])-1;
            int j = Convert.ToInt32(tab[2])-1;
            int output = tb.Text == "0" ? 1 : 0;
            _matrix[i, j] = output;
            tb.Text = output+"";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _matrix = null;
            this.Close();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
