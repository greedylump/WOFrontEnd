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
    public class WorkOutHistoryViewModel: INotifyPropertyChanged, IWorkOutViewModel
    {
        WorkOutDataService viewModelDataService; 
            
        private Exercise tempExercise = new Exercise();
        private WorkOut tempWorkOut = new WorkOut();
        //INPC might not be needed here
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SaveCommand { get; set; }

        public WorkOutHistoryViewModel()
        {
            viewModelDataService = new WorkOutDataService();
        }

        public WorkOutHistoryViewModel(WorkOutDataService service)
        {
            viewModelDataService = service;
        }

        public WorkOutDataService GetDataService()
        {
            return viewModelDataService;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        private void LoadCommands()
        {
            SaveCommand = new CustomCommand(SaveWorkOut, CanSave);
           
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


    }
}
