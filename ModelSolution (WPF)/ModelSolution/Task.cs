using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelSolution
{
    [Serializable]
    public class Task : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string customer;
        public string Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged("StartTime");
            }
        }

        private int days;
        public int Days
        {
            get => days;
            set
            {
                days = value;
                OnPropertyChanged("Days");
            }
        }

        private string address;
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private int required;
        public int Required
        {
            get => required;
            set
            {
                required = value;
                OnPropertyChanged("Required");
            }
        }

        private string comment;
        public string Comment
        {
            get => comment;
            set
            {
                comment = value;
                OnPropertyChanged("Comment");
            }
        }

        private List<int> assigned;
        public List<int> Assigned
        {
            get => assigned;
            set
            {
                assigned = value;
                OnPropertyChanged("Assigned");
            }
        }

        private bool planned;
        public bool Planned
        {
            get => planned;
            set
            {
                planned = value;
                OnPropertyChanged("Planned");
            }
        }

        public Task()
        {}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
