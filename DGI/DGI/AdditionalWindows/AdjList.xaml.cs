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
    /// Interaction logic for AdjList.xaml
    /// </summary>
    public partial class AdjList : Window
    {
        int size;
        List<List<int>> _list;

        public AdjList(int size)
        {
            InitializeComponent();
            this.size = size;

            Height = size * 35 +100;
        }


        public List<List<int>> ReturnAdjList()
        {
            _list = new List<List<int>>();
            ListFramework();
            base.ShowDialog();
            return _list;
        }

        private void ListFramework()
        {
            for (int i = 0; i < size; i++)
            {
                Border b = new Border();
                SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                b.BorderBrush = scb;
                b.BorderThickness = new Thickness(0,0,0,0.5);
                Grid g = new Grid();
                b.Child = g;


                ColumnDefinition cd = new ColumnDefinition();
                cd.Name = "Column_" + i + "_0";
                cd.Width = new GridLength(50);
                g.ColumnDefinitions.Add(cd);
                cd = new ColumnDefinition();
                cd.Width = new GridLength(80);
                cd.Name = "Column_" + i + "_1";
                g.ColumnDefinitions.Add(cd);
                cd = new ColumnDefinition();
                cd.Name = "Column_" + i + "_2";
                g.ColumnDefinitions.Add(cd);

                TextBlock tb = new TextBlock();
                tb.Text = i + "";
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                g.Children.Add(tb);
                Grid.SetColumn(tb, 0);

                ComboBox combo = new ComboBox();
                combo.Name = "comboBox_" + i;
                combo.HorizontalContentAlignment = HorizontalAlignment.Center;
                combo.SelectionChanged += ComboBox_SelectionChanged;
                for (int j = 0; j <= size; j++) combo.Items.Add(j);
                combo.SelectedIndex = 0;
                g.Children.Add(combo);
                Grid.SetColumn(combo, 1);

                WrapPanel wp = new WrapPanel();
                wp.Name = "wrapPanel_" + i;
                g.Children.Add(wp);
                Grid.SetColumn(wp, 2);

                containerStackPanel.Children.Add(b);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox) sender;
            object selectedItem = combo.SelectedItem;
            int gridIndex = Convert.ToInt32(combo.Name.Split('_')[1]);
            int j = 0;
            Border b = new Border();
            foreach (var child in containerStackPanel.Children){if (j == gridIndex) { b = (Border)child; break; }j++;}

            Grid grid = (Grid) b.Child;
            if (grid == null) return;

            WrapPanel wrap = new WrapPanel();
            foreach (var item in grid.Children)
                if(item is WrapPanel)
                    wrap = (WrapPanel) item;

            wrap.Children.RemoveRange(0,wrap.Children.Count);
            for (int i = 0; i < (int) selectedItem; i++)
            {
                TextBox tb = new TextBox();
                tb.Name = "textBox_" + gridIndex + "_" + i;
                tb.Width = 22;
                tb.MaxLength = 2;
                tb.Margin = new Thickness(2, 2, 0, 0);
                wrap.Children.Add(tb);
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _list = null;
            this.Close();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            List<List<int>> toReturn = new List<List<int>>();
            int index = 0;
            foreach (Border border in containerStackPanel.Children)
            {
                toReturn.Add(new List<int>());
                Grid grid = (Grid)border.Child;
                WrapPanel wrapPanel = new WrapPanel();
                foreach (var item in grid.Children) if (item is WrapPanel) wrapPanel = (WrapPanel)item;

                foreach (TextBox textBox in wrapPanel.Children)
                {
                    string text = textBox.Text;
                    try
                    {
                        int val = Convert.ToInt32(text);
                        if (val >= size || val < 0) throw new Exception();
                        toReturn[index].Add( val);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Podano niedozwoloną wartość!");
                        _list = null;
                        return;
                    }
                }
                index++;
            }
            for (int i = 0; i < toReturn.Count; i++)
                toReturn[i] = toReturn[i].Distinct().ToList();

            _list = toReturn;
            Close();
        }
    }
}
