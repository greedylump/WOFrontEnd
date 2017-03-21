using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutClass;
using Newtonsoft.Json;
using System.ComponentModel;

namespace WOFrontEnd.Services
{/// <summary>
/// The purpose of this data service is to load the saved workouts and 
/// facilitate saving operations. This allows the repository to be agnostic about the save medium.
/// Also, the SAME service is being passed to both views, ensuring they have the same data
/// </summary>
    public class WorkOutDataService:INotifyPropertyChanged
    {
        private WorkOutRepository workoutRepository;

        public event PropertyChangedEventHandler PropertyChanged;

        public WorkOutRepository WorkoutRepository
        {
            get
            {
                return workoutRepository;
            }

            set
            {
                workoutRepository = value;
                RaisePropertyChanged("WorkoutRepository");
            }
        }

        public WorkOutDataService()
        {
            workoutRepository = new WorkOutRepository();
            Load();
        }

        public WorkOutDataService(WorkOutRepository repos)
        {
            workoutRepository = repos;
        }

        public ObservableCollection<WorkOut> GetAllWorkOuts()
        {
            return workoutRepository.allWorkOuts;
        }

        public WorkOutRepository GetRepository()
        {
            return workoutRepository;
        }


        private static string DataFolder
        {
            get
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                folder = Path.Combine(folder, "greedyLump"); 
                folder = Path.Combine(folder, "Workout9001");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);//creates the folder if it doesnt exist
                }
                return folder;
            }
            
        }

        private static string DataFile
        {
            get
            {
                return Path.Combine(DataFolder, "WOData.xml");
            }
        }
        
        public void Load()
        {
            if (!File.Exists(DataFile))
            {
                workoutRepository.allWorkOuts = new ObservableCollection<WorkOut>();
                using (StreamWriter stream = File.CreateText(DataFile)) { };
            }

            using (StreamReader stream = File.OpenText(DataFile))
            {

                try
                {
                    var nullCheck = JsonConvert.DeserializeObject<ObservableCollection<WorkOut>>(stream.ReadToEnd());
                    if (nullCheck == null)
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        workoutRepository.allWorkOuts = nullCheck;
                    }

                }
                
                catch (JsonSerializationException) 
                {
                    stream.Close();
                    using (StreamWriter newstream = File.CreateText(Path.Combine(DataFolder, "WODataBlank.xml"))) { };
                    File.Replace(Path.Combine(DataFolder, "WODataBlank.xml"), Path.Combine(DataFolder, "WOData.xml"), Path.Combine(DataFolder, "WODataBackup.xml"));
                    Console.Beep();
                    workoutRepository.allWorkOuts = new ObservableCollection<WorkOut>();
                }

            }
            
        }

        /// <summary>
        /// Save the current workouts in memory
        /// </summary>
        public void Save()
        {

            if (!(workoutRepository.allWorkOuts == null))
            {
                Load();
            }

            using (StreamWriter stream = File.CreateText(DataFile)) //rewrites the file each time
            {
                stream.Write(JsonConvert.SerializeObject(workoutRepository.allWorkOuts));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
        /// <summary>
        /// Add a new workout and save all to file
        /// </summary>
        /// <param name="work"></param>
        public void Save(WorkOut work)
        {

            if (!(workoutRepository.allWorkOuts == null))
            {
                Load();
            }
#warning Insert logic to check for existing date

            workoutRepository.AddToCollection(work);


            using (StreamWriter stream = File.CreateText(DataFile)) //rewrites the file each time
            {
                stream.Write(JsonConvert.SerializeObject(workoutRepository.allWorkOuts));
            }
        }
   
    }
}
