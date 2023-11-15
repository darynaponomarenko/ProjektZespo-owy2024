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
        public AddNewPatient()
        {
            InitializeComponent();
           PeselTextBox.TextChanged += PeselTextBox_TextChanged;
        }

        private void PeselTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(PeselTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                PeselTextBox.Text = PeselTextBox.Text.Remove(PeselTextBox.Text.Length - 1);
                PeselTextBox.Select(PeselTextBox.Text.Length, 0);
            }

        }
    }
}
