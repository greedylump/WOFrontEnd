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
        private WorkOutDataService workoutDataService = new WorkOutDataService();
        private WorkOutHistoryViewModel workoutHistoryViewModel;
        private WorkOutEntryViewModel workoutEntryViewModel;

        public ICommand EntryCommand { get; set; }
        public ICommand HistoryCommand { get; set; }

        public enum ViewState
        {
            EntryView=0,
            HistoryView
        }
        public ViewState CurrentView;
        public ViewModelLocater()
        {
            workoutHistoryViewModel = new WorkOutHistoryViewModel(workoutDataService);
            workoutEntryViewModel = new WorkOutEntryViewModel(workoutDataService);
            CurrentView= ViewState.EntryView;
        }

        public WorkOutHistoryViewModel WorkoutHistoryViewModel
        {
            get
            {
                return workoutHistoryViewModel;
            }

        }
        public WorkOutEntryViewModel WorkoutEntryViewModel
        {
            get
            {
                return workoutEntryViewModel;
            }

        }

        private void LoadCommands()
        {
            EntryCommand = new CustomCommand(SwitchToEntry, CanSwitch);
            HistoryCommand = new CustomCommand(SwitchToHistory, CanSwitch);

        }

        private void SwitchToHistory(object obj)
        {
            CurrentView = ViewState.HistoryView;
        }

        private void SwitchToEntry(object obj)
        {
            CurrentView = ViewState.EntryView; ;
        }

        private bool CanSwitch(object obj)
        {

            return true;
        }

      





    }
}
