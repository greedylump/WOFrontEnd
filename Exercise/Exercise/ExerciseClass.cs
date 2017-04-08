using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseClass
{
    /// <summary>
    /// Reworked Exercise Class to use Auto properties, and greatly simplified the code
    /// </summary>
    public class Exercise
    {

        public string Name { get; set; }
        public List<int> RepsPerSet { get; set; } //Consider making setter private?

        public Exercise(string name)
        {
            Name = name;
            RepsPerSet = new List<int>();
        }

        public Exercise(string name, IEnumerable<int> list)
        {
            Name = name;
            RepsPerSet = list.ToList();
        }
        public override string ToString()
        {
            return Name;
        }
    }



}
