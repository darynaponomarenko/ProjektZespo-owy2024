using HMS_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Forms.xaml
    /// </summary>
    public partial class Forms : Window
    {
        private readonly FormsViewModel viewModel;
        public Forms()
        {
            InitializeComponent();
            viewModel = new FormsViewModel();
            DataContext = viewModel;

            Load();

        }

        public void Load()
        {
           
        }

       
    }


}
