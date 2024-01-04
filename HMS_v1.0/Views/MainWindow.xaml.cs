using HMS_v1._0.ViewModels;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Windows;
using System.Windows.Input;

namespace HMS_v1._0.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            LoadData();
        }

        private async void LoadData()
        {
            await viewModel.LoadAppointmentsAsync();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Forms forms = new();
            forms.ShowDialog();
        }

    }
 
}
