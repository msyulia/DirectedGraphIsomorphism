using System;
using System.Windows;


namespace DGI.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for TypingInAdjMatrixSize.xaml
    /// </summary>
    public partial class TypingInAdjMatrixSize : Window
    {
        static MainWindow mainWindow;
        int _sizeOfMtrx;

        public TypingInAdjMatrixSize()
        {
            InitializeComponent();
            _sizeOfMtrx = -1;
        }

        public int ReturnSizeOfMatrix(MainWindow mw)
        {
            mainWindow = mw;
            base.ShowDialog();
            return _sizeOfMtrx;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.IsEnabled = true;
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
