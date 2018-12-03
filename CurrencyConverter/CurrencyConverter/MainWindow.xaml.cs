using System.Windows;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            var client = new ConverterServiceReference.ConverterServiceClient();
            lblResult.Content = client.GetData(txtInput.Text);
        }
    }
}
