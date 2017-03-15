using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WOFrontEnd.Services;
using WOFrontEnd.Utility;

namespace WOFrontEnd.ViewModels
{
    public class ViewModelLocater
    {
        private static WorkOutDataService workoutDataService = new WorkOutDataService();
        private static WorkOutHistoryViewModel workoutHistoryViewModel;
        private static WorkOutEntryViewModel workoutEntryViewModel;

        public static ICommand EntryCommand { get; set; }
        public static ICommand HistoryCommand { get; set; }

        public enum ViewState
        {
            EntryView=0,
            HistoryView
        }
        private static ViewState currentView;
        public static ViewState CurrentView
        {
            get
            {
                return currentView;
            }

            set
            {
                currentView = value;
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

       

        private static void LoadCommands()
        {
            EntryCommand = new CustomCommand(SwitchToEntry, CanSwitch);
            HistoryCommand = new CustomCommand(SwitchToHistory, CanSwitch);
            

        }

        private static void SwitchToHistory(object obj)
        {
            CurrentView = ViewState.HistoryView;
            
        }

        private static void SwitchToEntry(object obj)
        {
            CurrentView = ViewState.EntryView; 
        }

        private static bool CanSwitch(object obj)
        {

            return true;
        }

      





    }
}
