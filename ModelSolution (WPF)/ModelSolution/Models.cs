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
    public class Models : ObservableCollection<Model>
    {
        readonly string FileName = "models.xml";
        public Models()
        { }

        public void SaveToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Models));
            TextWriter writer = new StreamWriter(FileName);
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public void GetFromFile()
        {
            Models tempModels = new Models();
            XmlSerializer serializer = new XmlSerializer(typeof(Models));
            try
            {
                TextReader reader = new StreamReader(FileName);
                tempModels = (Models)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + "\nWill create '" + FileName + "' when saved.", "Could not open file", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Clear();
            foreach (Model model in tempModels)
            {
                Add(model);
            }
        }
    }
}
