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
    /// Interaction logic for SearchCode.xaml
    /// </summary>
    public partial class SearchCode : Window
    {
        private readonly SearchCodeViewModel viewModel;
        public SearchCode()
        {
            InitializeComponent();
            viewModel = new SearchCodeViewModel();
            DataContext = viewModel;
            viewModel.CloseAction ??= new Action(this.Close);

            LoadData();
        }

        private async void LoadData()
        {
            await viewModel.LoadCodesAsync();
        }
    }
}
