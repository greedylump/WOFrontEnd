using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOFrontEnd.Services;
using WorkOutClass;

namespace WOFrontEnd.ViewModels
{
    class WorkOutEntryViewModel : INotifyPropertyChanged
    {
        WorkOutDataService viewModelDataService = new WorkOutDataService();

        private Exercise tempExercise = new Exercise();
        private WorkOut tempWorkOut = new WorkOut();

        public Exercise TempExercise
        {
            get
            {
                return tempExercise;
            }
            set
            {
                tempExercise = value;
                RaisePropertyChanged("TempExercise");
            }
        }

        public WorkOut TempWorkOut
        {
            get
            {
                return tempWorkOut;
            }
            set
            {
                tempWorkOut = value;
                RaisePropertyChanged("TempWorkOut");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            
        }


    }
}
