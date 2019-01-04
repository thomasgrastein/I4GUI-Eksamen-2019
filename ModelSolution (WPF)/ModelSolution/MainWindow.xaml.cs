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

namespace ModelSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models models;
        private Tasks tasks;
        private ModelWindow modelWindow;
        public MainWindow()
        {
            models = new Models();
            models.GetFromFile();
            tasks = new Tasks();
            tasks.GetFromFile();
            InitializeComponent();
            TaskList.ItemsSource = tasks;
            Closing += (sender, e) => SaveToFile(); //Hacky event binder to save
            var hex = Properties.Resources.Background;
            Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
        }

        internal Models Models { get => models; set => models = value; }
        internal Tasks Tasks { get => tasks; set => tasks = value; }

        private void View_models_Click(object sender, RoutedEventArgs e)
        {
            if (modelWindow == null)
            {
                modelWindow = new ModelWindow();
                modelWindow.ModelList.ItemsSource = models;
                modelWindow.Owner = Application.Current.MainWindow;
                modelWindow.Top = Top;
                modelWindow.Left = Left + Width; //Spawn window next to this
                modelWindow.Show();
                modelWindow.Closed += (a, b) => { this.Activate(); modelWindow = null; }; //https://stackoverflow.com/questions/10757625/why-does-closing-the-last-child-window-minimize-its-parent-window
            }
            else
            {
                modelWindow.Close();
                modelWindow = null;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile();
        }

        private void SaveToFile()
        {
            models.SaveToFile();
            tasks.SaveToFile();
        }

        private void Add_Task_Click(object sender, RoutedEventArgs e)
        {
            AddTaskDialog addTaskDialog = new AddTaskDialog
            {
                Owner = this,
            };
            addTaskDialog.Assigned.ItemsSource = models;
            addTaskDialog.ShowDialog();
            if (addTaskDialog.ShouldSave)
            {
                int id = 0; // hacky way of using low but unused id's
                foreach (Task t in Tasks)
                {
                    if (t.Id >= id)
                        id = t.Id + 1;
                }
                List<int> assigned = new List<int>();
                foreach (Model m in addTaskDialog.Assigned.SelectedItems)
                {
                    assigned.Add(m.Id);
                }
                Task task = new Task
                {
                    Id = id,
                    Customer = addTaskDialog.Name.Text,
                    StartDate = (DateTime) addTaskDialog.StartDate.Value,
                    Address = addTaskDialog.Address.Text,
                    Days = addTaskDialog.DaysConv,
                    Required = addTaskDialog.RequiredConv,
                    Comment = addTaskDialog.Comment.Text,
                    Assigned = assigned
                };
                if (task.Assigned.Count >= task.Required)
                {
                    task.Planned = true;
                }
                else
                {
                    task.Planned = false;
                }
                Tasks.Add(task);
                UpdateView(task);
            }
        }

        private void UpdateView(Task task)
        {
            Name.Content = task.Customer;
            Date.Content = task.StartDate.ToShortDateString();
            Address.Content = task.Address;
            Days.Content = task.Days + " days";
            Required.Content = task.Required + " required";
            Comment.Content = task.Comment;
            if (task.Assigned != null) // Her eksemplificeres lige hvordan threads kan aflaste UI-tråden
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    string assigned = "";
                    bool first = true;
                    foreach (int id in task.Assigned) //Again, stupid but works
                    {
                        foreach (Model m in models)
                        {
                            if (m.Id == id)
                            {
                                if (!first) assigned += ", ";
                                assigned += m.Name;
                                first = false;
                                break;
                            }
                        }
                    }
                    Assigned.Content = assigned;
                }));
            }
        }

        private void TaskList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var task = (Task)(sender as ListView).SelectedItem;
            if (task != null)
            {
                UpdateView(task);
            }
        }

        private void Edit_Task_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItems.Count > 0)
            {
                var task = (Task)TaskList.SelectedItems[0];
                AddTaskDialog addTaskDialog = new AddTaskDialog
                {
                    Owner = this
                };
                addTaskDialog.Name.Text = task.Customer;
                addTaskDialog.StartDate.Value = task.StartDate;
                addTaskDialog.Address.Text = task.Address;
                addTaskDialog.Days.Text = task.Days.ToString();
                addTaskDialog.Required.Text = task.Required.ToString();
                addTaskDialog.Comment.Text = task.Comment;
                addTaskDialog.Assigned.ItemsSource = models;

                foreach (int Id in task.Assigned) //This is stupid but it works
                {
                    foreach (Model m in addTaskDialog.Assigned.Items)
                    {
                        if (Id == m.Id)
                        {
                            addTaskDialog.Assigned.SelectedItems.Add(m);
                            break;
                        }
                    }
                }

                addTaskDialog.Add_Task.Content = "Save Task";
                addTaskDialog.ShowDialog();
                List<int> assigned = new List<int>();
                foreach (Model m in addTaskDialog.Assigned.SelectedItems)
                {
                    assigned.Add(m.Id);
                }
                if (addTaskDialog.ShouldSave)
                {
                    task.Customer = addTaskDialog.Name.Text;
                    task.StartDate = (DateTime)addTaskDialog.StartDate.Value;
                    task.Address = addTaskDialog.Address.Text;
                    task.Days = addTaskDialog.DaysConv;
                    task.Required = addTaskDialog.RequiredConv;
                    task.Comment = addTaskDialog.Comment.Text;
                    task.Assigned = assigned;
                    if (task.Assigned.Count >= task.Required)
                    {
                        task.Planned = true;
                    }
                    else
                    {
                        task.Planned = false;
                    }
                }
                UpdateView(task);
            }
        }

        private void Delete_Task_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItems.Count > 0)
            {
                var task = (Task)TaskList.SelectedItems[0];
                MessageBoxResult delete = MessageBox.Show("Are you sure you wish to delete '" + task.Customer + "?",
                                           "Confirmation",
                                           MessageBoxButton.YesNo,
                                           MessageBoxImage.Question);
                if (delete == MessageBoxResult.Yes)
                {
                    Tasks.Remove(task);
                    UpdateView(new Task
                    {
                        Customer = "None selected"
                    });
                }
            }
        }
    }
}
