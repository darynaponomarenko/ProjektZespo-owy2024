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
    /// Interaction logic for AddNewPatient.xaml
    /// </summary>
    public partial class AddNewPatient : Window
    {
        private readonly NewPatientViewModel viewModel;
        public AddNewPatient()
        {
            InitializeComponent();
            viewModel = new NewPatientViewModel();
            DataContext = viewModel;
            viewModel.CloseAction ??= new Action(this.Close);
        }
    }
}
