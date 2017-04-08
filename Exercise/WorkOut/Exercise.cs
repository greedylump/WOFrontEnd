using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutClass.OCExtensions;

namespace WorkOutClass
{
    
    public class Exercise:INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get
            {
                return name;

            }
            
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        private ObservableCollection<int> sets;
        public ObservableCollection<int> Sets
        {
            get
            {
                return sets;
            }
            set
            {
                sets = value;
                RaisePropertyChanged("Sets");
            }
        }

        public Exercise()
        {
            sets = new ObservableCollection<int>();
        }

        public Exercise(string name)
        {
            this.name = name;
            sets = new ObservableCollection<int>();
        }

        public Exercise(string name, IEnumerable<int> list)
        {
            this.name = name;
            sets = list.ToObservableCollection();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }


    }
}
