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

namespace ModelSolution
{
    /// <summary>
    /// Interaction logic for AddTaskDialog.xaml
    /// </summary>
    public partial class AddTaskDialog : Window
    {
        public bool ShouldSave = false;
        public int DaysConv, RequiredConv = 0;
        public AddTaskDialog()
        {
            InitializeComponent();
            var hex = Properties.Resources.Background;
            Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
        }

        private void Add_Task_Click(object sender, RoutedEventArgs e)
        {
            //Check fields, first check is probably not necessary
            if ((Days.Text != null && !int.TryParse(Days.Text, out DaysConv)) || (Required.Text != null && !int.TryParse(Required.Text, out RequiredConv)))
            {
                MessageBox.Show("Could not convert", "Invalid amount", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Name.Text.Length < 2)
            {
                MessageBox.Show("Name cannot be less than two characters", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (StartDate.Text == null || StartDate.Text.Length < 2)
            {
                MessageBox.Show("Date cannot be less than two characters", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ShouldSave = true;
                this.Close();
            }
        }
    }
}
