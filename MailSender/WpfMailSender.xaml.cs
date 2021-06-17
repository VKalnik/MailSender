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
using MailSender.Data;

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
        }
    }
}
