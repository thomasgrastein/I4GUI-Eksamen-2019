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
    /// Interaction logic for AddModelDialog.xaml
    /// </summary>
    public partial class AddModelDialog : Window
    {
        public bool ShouldSave = false;
        public int HeightConv, WeightConv = 0;
        public AddModelDialog()
        {
            InitializeComponent();
            var hex = Properties.Resources.Background;
            Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
        }

        private void Add_Model_Click(object sender, RoutedEventArgs e)
        {
            //Check fields, first check is probably not necessary
            if ((Height.Text != null && !int.TryParse(Height.Text, out HeightConv)) || (Weight.Text != null && !int.TryParse(Weight.Text, out WeightConv)))
            {
                MessageBox.Show("Could not convert", "Invalid amount", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Name.Text.Length < 2)
            {
                MessageBox.Show("Name cannot be less than two characters", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ShouldSave = true;
                this.Close();
            }
        }
    }
}
