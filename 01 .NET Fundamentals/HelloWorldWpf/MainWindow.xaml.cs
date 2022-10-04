using Logic;
using System.Windows;

namespace HelloWorldWpf
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = GetMessage();
            MessageBox.Show(message);
        }

        private string GetMessage()
        {
            var username = txtUsername.Text;
            return string.IsNullOrEmpty(username) ? "Not allowed empty username input" : FormatterMessage.HelloWorld(username);
        }
    }
}
