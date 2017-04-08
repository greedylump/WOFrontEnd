using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutClass.OCExtensions;

namespace WorkOutClass
{
   
        /// <summary>
        /// Reworked Exercise Class to use Auto properties, and greatly simplified the code
        /// </summary>
        public class StrTrain : Exercise
    {

        //public string Name { get; set; }
        //public List<int> Sets { get; set; } //Units are reps


            public StrTrain()
        {
            Sets = new ObservableCollection<int>();

        }


        public StrTrain(string name)
            {
                Name = name;
                Sets = new ObservableCollection<int>();
            }

            public StrTrain(string name, IEnumerable<int> list)
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
