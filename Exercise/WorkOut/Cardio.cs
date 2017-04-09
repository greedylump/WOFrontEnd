using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutClass.OCExtensions;

namespace WorkOutClass 
{
    public class Cardio : Exercise
    {
  
        public Cardio() { }


            
        public Cardio(string name)
        {
            Name = name;
            Sets = new ObservableCollection<int>();
        }

        public Cardio(string name, IEnumerable<int> list)
        {
            Name = name;
            Sets = list.ToObservableCollection();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
