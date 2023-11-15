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

namespace HMS_v1._0.Views
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

        protected void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new();
            registration.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new();
            appointment.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Forms forms = new();
            forms.ShowDialog();
        }
    }
 
}
