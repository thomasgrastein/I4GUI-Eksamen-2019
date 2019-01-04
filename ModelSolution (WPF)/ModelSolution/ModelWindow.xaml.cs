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
    /// Interaction logic for ModelWindow.xaml
    /// </summary>
    public partial class ModelWindow : Window
    {
        public ModelWindow()
        {
            InitializeComponent();
            var hex = Properties.Resources.Background;
            Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
        }

        private void ModelList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var model = (Model) (sender as ListView).SelectedItem;
            if (model != null)
            {
                UpdateView(model);
            }
        }

        private void UpdateView(Model model)
        {
            Name.Content = model.Name;
            Phone.Content = model.Phone;
            Address.Content = model.Address;
            Height.Content = model.Height + " cm";
            Weight.Content = model.Weight + " kg";
            HairColor.Content = model.HairColor;
            Comment.Content = model.Comment;
        }

        private void Add_Model_Click(object sender, RoutedEventArgs e)
        {
            AddModelDialog addModelDialog = new AddModelDialog
            {
                Owner = this
            };
            addModelDialog.ShowDialog();
            if (addModelDialog.ShouldSave)
            {
                int id = 0; // hacky way of using low but unused id's
                foreach (Model m in ((MainWindow)Owner).Models)
                {
                    if (m.Id >= id)
                        id = m.Id + 1;
                }
                Model model = new Model
                {
                    Id = id,
                    Name = addModelDialog.Name.Text,
                    Phone = addModelDialog.Phone.Text,
                    Address = addModelDialog.Address.Text,
                    Height = addModelDialog.HeightConv,
                    Weight = addModelDialog.WeightConv,
                    HairColor = addModelDialog.HairColor.SelectedColorText,
                    Comment = addModelDialog.Comment.Text
                };
                ((MainWindow)Owner).Models.Add(model);
                UpdateView(model);
            } 
        }

        private void Edit_Model_Click(object sender, RoutedEventArgs e)
        {
            if (ModelList.SelectedItems.Count > 0)
            {
                var model = (Model)ModelList.SelectedItems[0];
                AddModelDialog addModelDialog = new AddModelDialog
                {
                    Owner = this
                };
                addModelDialog.Name.Text = model.Name;
                addModelDialog.Phone.Text = model.Phone;
                addModelDialog.Address.Text = model.Address;
                addModelDialog.Height.Text = model.Height.ToString();
                addModelDialog.Weight.Text = model.Weight.ToString();
                if (model.HairColor != null && model.HairColor.Length > 2)
                {
                    addModelDialog.HairColor.SelectedColor = (Color)ColorConverter.ConvertFromString(model.HairColor);
                }
                addModelDialog.Comment.Text = model.Comment;
                addModelDialog.Add_Model.Content = "Save Model";
                addModelDialog.ShowDialog();
                if (addModelDialog.ShouldSave)
                {
                    model.Name = addModelDialog.Name.Text;
                    model.Phone = addModelDialog.Phone.Text;
                    model.Address = addModelDialog.Address.Text;
                    model.Height = addModelDialog.HeightConv;
                    model.Weight = addModelDialog.WeightConv;
                    model.HairColor = addModelDialog.HairColor.SelectedColorText;
                    model.Comment = addModelDialog.Comment.Text;
                }
                UpdateView(model);
            }
        }

        private void Delete_Model_Click(object sender, RoutedEventArgs e)
        {
            if (ModelList.SelectedItems.Count > 0)
            {
                var model = (Model)ModelList.SelectedItems[0];
                MessageBoxResult delete = MessageBox.Show("Are you sure you wish to delete '" + model.Name + "?",
                                           "Confirmation",
                                           MessageBoxButton.YesNo,
                                           MessageBoxImage.Question);
                if (delete == MessageBoxResult.Yes)
                {
                    ((MainWindow)Owner).Models.Remove(model);
                    UpdateView(new Model
                    {
                        Name = "None selected"
                    });
                }
            }
        }
    }
}
