using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using WorkOutClass;
using WOFrontEnd.ViewModels;

namespace WOFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        /*
        WorkOut workout = new WorkOut();
        Exercise exercise;
        //= new Exercise();
        */
        public MainWindow()
        {
            InitializeComponent();
            ViewModelLocater vmLocater = new ViewModelLocater();
           
            
            
            /*
            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save);
            this.CommandBindings.Add(saveCommand);
            
            saveCommand.Executed += new ExecutedRoutedEventHandler( saveCommand_Executed);
            */

        }
        /*
        private void saveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        { 
            workout.Date = WorkOut.stringToDate(dateTB.Text);
            workout.Length = Int32.Parse(lengthTB.Text);
            WorkOutRepos repos = new WorkOutRepos();
            repos.Save(workout);
            exerciseBox.Clear();
            repBox.Clear();
            repList.Items.Clear();
            dateBox.Clear();
            lengthBox.Clear();

        }

        private void repBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Return)
            {                
                repList.Items.Add(repBox.Text);
                repBox.Clear();
            }
           
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if((bool)cardioButton.IsChecked)
            {
                exercise = new Cardio(exerciseTB.Text);
            }
            else
            {
                exercise = new StrTrain(exerciseTB.Text);
            }
            List<int> boxList = new List<int>();
            foreach(var num in repList.Items.OfType<string>())
            {
                boxList.Add(Int32.Parse(num));
            }
            exercise.Sets.AddRange(boxList);
            workout.ExerciseList.Add(exercise);
            exercise = new Exercise();
            exerciseBox.Clear();
            repBox.Clear();
            repList.Items.Clear();
              
        }
        */
    }
}
