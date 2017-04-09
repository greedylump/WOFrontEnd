using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOFrontEnd.OCExtensions
{
    public static class ObservableCollectionExtensions
    {
        public static void Sort<T>(this ObservableCollection<T> oc)
        {
            List<T> ocList = oc.ToList();
            oc.Clear();
            ocList.Sort();
            foreach(var workout in ocList)
            {
                oc.Add(workout);
            }
        }


    }
}
