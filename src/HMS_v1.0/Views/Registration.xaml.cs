using HMS_v1._0.Messages;
using HMS_v1._0.ViewModels;
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

namespace HMS_v1._0.Views
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private readonly RegistrationViewModel viewModel;
        public Registration()
        {
            InitializeComponent();
            viewModel = new RegistrationViewModel();
            DataContext = viewModel;
            viewModel.CloseAction ??= new Action(this.Close);

            
            Loaded += Load;

        }

        public void Load(object sender, RoutedEventArgs e)
        {
           viewModel.ShowLoggedWorker();
        }

        /*private void RegistrationWindow_Loaded()
        {
            // Update the label content when the window is opened
            ((RegistrationViewModel)DataContext).;
        }*/
    }
}
