using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            //ServersList.ItemsSource = TestData.Servers; // Так можно, но НЕ НАДО!
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_OnClick(object sender, RoutedEventArgs e) =>
            MessageBox.Show("Рассыльщик почты", "О программе", MessageBoxButton.OK);

        private void Shedule_OnClick(object sender, RoutedEventArgs e)
        {
            TabItemiShedule.IsSelected = true;
            //tcMain.SelectedIndex = 1;
        }

        private void MailSend_OnClick(object Sender, RoutedEventArgs E)
        {
            if (tbMessageBody.Text == "")
            {
                MessageBox.Show("Письмо не заполнено", "Отправка почты", MessageBoxButton.OK);
                tcMain.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Тест: Типа почта отправлена\n" + "Сервер: " + Data.TestData.Servers[ServersList.SelectedIndex].Address + "\n" + 
                    "Порт: " + Data.TestData.Servers[ServersList.SelectedIndex].Port + "\n" +
                    "SSL: " + Data.TestData.Servers[ServersList.SelectedIndex].UseSSl, "Отправка почты", MessageBoxButton.OK);
            }
        }
    }
}
