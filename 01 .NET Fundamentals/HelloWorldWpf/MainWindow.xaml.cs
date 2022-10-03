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
            var username = txtUsername.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Not allowed empty username input");
            }
            else
            {
                MessageBox.Show(FormatterMessage.HelloWorld(username));
            }
        }
    }
}
