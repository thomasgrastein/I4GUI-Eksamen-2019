using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace ModelSolution
{
    public class Tasks : ObservableCollection<Task>
    {
        readonly string FileName = "tasks.xml";

        public void SaveToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Tasks));
            TextWriter writer = new StreamWriter(FileName);
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public void GetFromFile()
        {
            Tasks tempTasks = new Tasks();
            XmlSerializer serializer = new XmlSerializer(typeof(Tasks));
            try
            {
                TextReader reader = new StreamReader(FileName);
                tempTasks = (Tasks)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + "\nWill create '" + FileName + "' when saved.", "Could not open file", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Clear();
            foreach (Task task in tempTasks)
            {
                Add(task);
            }
        }
    }
}
