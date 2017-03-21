using Newtonsoft.Json;
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
        WorkOutDataService viewModelDataService;//MIGHT NEED TO MAKE THIS A PROPERTY

        private Exercise tempExercise = new Exercise();
        private bool isCardio=true;
        private int tempRep=0;
        private WorkOut tempWorkOut = new WorkOut();
        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddRepCommand { get; set; }


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
        public int TempRep
        {
            get
            {
                return tempRep;
            }
            set
            {
                tempRep = value;
                RaisePropertyChanged("TempRep");
            }
        }

        public bool IsCardio
        {
            get
            {
                return isCardio;
            }

            set
            {
                isCardio = value;
                RaisePropertyChanged("IsCardio");
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




        private void LoadCommands()
        {
            SaveCommand = new CustomCommand(SaveWorkOut, CanSave);
            AddCommand = new CustomCommand(AddExercise, CanAdd);
            AddRepCommand = new CustomCommand(AddRep, CanAddRep );
        }

        private void AddRep(object obj)
        {
            
            TempExercise.Sets.Add(tempRep);
            tempRep = 0; 
        }

        private bool CanAdd(object obj)
        {
            if (tempExercise.Sets.Count != 0)
                return true;

            return false;
        }
        private bool CanAddRep(object obj)
        {
            if (tempRep != 0)
                return true;

            return false;
        }


        private bool CanSave(object obj)
        {

            if (tempWorkOut.ExerciseList.Count!=0)
                return true;

            return false; 
        }

        private void SaveWorkOut(object obj)
        {
            viewModelDataService.Save(TempWorkOut);
            TempWorkOut = new WorkOut();
#warning NEED TO CLEAR  DATE AND LENGTH BOX 






        }



        private void AddExercise(object obj)
        {
         
            if (IsCardio)
            {
                var serEx = JsonConvert.SerializeObject(tempExercise);
                Cardio newTemp = JsonConvert.DeserializeObject<Cardio>(serEx);
                tempWorkOut.ExerciseList.Add(newTemp);
            }
            else
            {
                var serEx = JsonConvert.SerializeObject(tempExercise);
                StrTrain newTemp = JsonConvert.DeserializeObject<StrTrain>(serEx);
                tempWorkOut.ExerciseList.Add(newTemp);
            }
           
            TempExercise = new Exercise();
           
            
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
