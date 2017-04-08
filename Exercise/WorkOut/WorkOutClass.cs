

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
    public class WorkOut:IComparable<WorkOut>, INotifyPropertyChanged 
    {
        private int length;
        private ObservableCollection<Exercise> exerciseList;
        

        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
                RaisePropertyChanged("Length");
            }

        }
        public DateTime Date { get; set; }
        public ObservableCollection<Exercise> ExerciseList
        {
            get
            {
                return exerciseList;
            }
            set
            {
                exerciseList = value;
                RaisePropertyChanged("ExerciseList");
            }
        }

        public WorkOut()
        {
            Date = DateTime.Now;
            exerciseList = new ObservableCollection<Exercise>();
        }

        public WorkOut(int length, DateTime date, IEnumerable<Exercise> exerciseList)
        {
            Length = length;
            Date = date;
            ExerciseList = exerciseList.ToObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
             return Date.ToString("d");          
        }
        /// <summary>
        /// Parses a string in the format MM/DD/YYYY and returns a DateTime object with that value 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime stringToDate(string date)
        {
            char[] charr = new char[] { '/' };
            string[] parsed = date.Split(charr, StringSplitOptions.RemoveEmptyEntries);
            DateTime newDate = new DateTime(Int32.Parse(parsed[2]), Int32.Parse(parsed[0]), Int32.Parse(parsed[1]));
            return newDate;

        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            
        }
        /// <summary>
        /// Compares by DateTime this.Date Comparer
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(WorkOut other)
        {
            return this.Date.CompareTo(other.Date);
        }
        public static bool operator < (WorkOut w1, WorkOut w2)
        {
            return w1.Date < w2.Date;
        }
        public static bool operator >(WorkOut w1, WorkOut w2)
        {
            return w1.Date > w2.Date;
        }
        public static bool operator <=(WorkOut w1, WorkOut w2)
        {
            return w1.Date <= w2.Date;
        }
        public static bool operator >=(WorkOut w1, WorkOut w2)
        {
            return w1.Date >= w2.Date;
        }
        public static bool operator ==(WorkOut w1, WorkOut w2)
        {
            return w1.Date == w2.Date;
        }

        public static bool operator !=(WorkOut w1, WorkOut w2)
        {
            return w1.Date != w2.Date;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is WorkOut))
                return false;

            return Date == ((WorkOut)obj).Date;
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode() ^ Length.GetHashCode();
        }
    }
}
