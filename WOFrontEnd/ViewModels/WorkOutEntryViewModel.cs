using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WOFrontEnd.Services;
using WOFrontEnd.Utility;
using WorkOutClass;

namespace WOFrontEnd.ViewModels
{
    public class WorkOutEntryViewModel : INotifyPropertyChanged, IWorkOutViewModel
    {
        WorkOutDataService viewModelDataService;

        private Exercise tempExercise = new Exercise();
        private WorkOut tempWorkOut = new WorkOut();


        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public WorkOutEntryViewModel()
        {
            LoadCommands();
            viewModelDataService = new WorkOutDataService();
        }
        public WorkOutEntryViewModel(WorkOutDataService service)
        {
            LoadCommands();
            viewModelDataService = service;
        }
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

       

        private void LoadCommands()
        {
            SaveCommand = new CustomCommand(SaveWorkOut,CanSave);
            AddCommand = new CustomCommand(AddWorkOut, CanAdd);
        }

        private bool CanSave(object obj)
        {

            if (tempWorkOut != null)
                return true;

            return false; 
        }

        private void SaveWorkOut(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanAdd(object obj)
        {
            if (tempExercise != null)
                return true;

            return false;
        }

        private void AddWorkOut(object obj)
        {
            throw new NotImplementedException();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            
        }

        public WorkOutDataService GetDataService()
        {
            return viewModelDataService;
        }
    }
}
