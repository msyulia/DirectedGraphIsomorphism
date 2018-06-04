using System;
using System.Windows;


namespace DGI.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for TypingInAdjMatrixSize.xaml
    /// </summary>
    public partial class TypingInAdjMatrixSize : Window
    {
        int _sizeOfMtrx;

        public TypingInAdjMatrixSize()
        {
            InitializeComponent();
            _sizeOfMtrx = -1;
        }

        public int ReturnSizeOfMatrix()
        {
            base.ShowDialog();
            return _sizeOfMtrx;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            string val = sizeOfMatrixTextBox.Text;
            try
            {
                _sizeOfMtrx = Convert.ToInt32(val);
                this.Close();
            }
            catch (Exception)
            {
                sizeOfMatrixTextBox.Clear();
            }
        }
    }
}
