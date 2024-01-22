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
using System.Windows.Shapes;

namespace HMS_v1._0.Views
{
    /// <summary>
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class AppointmentView : Window
    {
        private readonly AppointmentViewModel viewModel;
        public AppointmentView()
        {
            InitializeComponent();
            viewModel = new AppointmentViewModel();
            DataContext = viewModel;
            viewModel.CloseAction ??= new Action(this.Close);

            LoadDoctors();
        }

        private void LoadDoctors()
        {
            viewModel.LoadDoctorsAsync();
            viewModel.SearchForCodeDescription();
            viewModel.ShowLoggedWorker();
        }
    }
}
