using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WOFrontEnd.Services;
using WOFrontEnd.Utility;

namespace WOFrontEnd.ViewModels
{
    public class ViewModelLocater : INotifyPropertyChanged
    {
        private static WorkOutDataService workoutDataService = new WorkOutDataService();
        private static WorkOutHistoryViewModel workoutHistoryViewModel;
        private static WorkOutEntryViewModel workoutEntryViewModel;
        private static ViewState currentView;

        public static ICommand EntryCommand { get; set; }
        public static ICommand HistoryCommand { get; set; }

        public enum ViewState
        {
            EntryView=0,
            HistoryView
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public  ViewState CurrentView
        {
            get
            {
                return currentView;
            }

            set
            {
                currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }
        public static WorkOutHistoryViewModel WorkoutHistoryViewModel
        {
            get
            {
                return workoutHistoryViewModel;

            }

        }
        public static WorkOutEntryViewModel WorkoutEntryViewModel
        {
            get
            {
                return workoutEntryViewModel;
            }

        }
        public ViewModelLocater()
        {
            workoutHistoryViewModel = new WorkOutHistoryViewModel(workoutDataService);
            workoutEntryViewModel = new WorkOutEntryViewModel(workoutDataService);
            LoadCommands();
            CurrentView = ViewState.EntryView;

        }


        private bool CanSwitch(object obj)
        {

            return true;
        }
        private void LoadCommands()
        {
            EntryCommand = new CustomCommand(SwitchToEntry, CanSwitch);
            HistoryCommand = new CustomCommand(SwitchToHistory, CanSwitch);
            

        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
        private void SwitchToHistory(object obj)
        {
            CurrentView = ViewState.HistoryView;
            
        }

        private void SwitchToEntry(object obj)
        {
            CurrentView = ViewState.EntryView; 
        }

        
        








    }
}
