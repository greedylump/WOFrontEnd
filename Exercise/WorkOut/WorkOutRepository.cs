

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using WOFrontEnd.OCExtensions;

namespace WorkOutClass
{
    public class WorkOutRepository
    {
      
        public ObservableCollection<WorkOut> allWorkOuts { get; set; }

        public WorkOut WorkOutByDate(string s)
        {
            DateTime date = WorkOut.stringToDate(s);

            var wo = from workKvp in allWorkOuts
                      where workKvp.Date == date
                      select workKvp;
            return wo.ToList()[0];
        }

        public WorkOutRepository()
        {
            allWorkOuts = new ObservableCollection<WorkOut>();
            
        }
        /// <summary>
        /// Adds workout to Observable Collection
        /// </summary>
        /// <param name="work"></param>
        public void AddToCollection(WorkOut work)
        {
            allWorkOuts.Add( work);
        }
        
        /// <summary>
        /// Reorders the collection of workouts, ordered from earliest to latest
        /// </summary>
        /// <returns></returns>
        public void ToOrderedObservableCollection()
        {
            allWorkOuts.Sort();
        }

        
    }
}
