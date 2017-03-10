using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutClass;
using Newtonsoft.Json;

namespace WOFrontEnd.Services
{/// <summary>
/// The purpose of this data service is to load the saved workouts and 
/// facilitate saving operations. This allows the repository to be agnostic about the save medium
/// </summary>
    class WorkOutDataService
    {
        WorkOutRepository workoutrepository;
     

        public WorkOutDataService()
        {
            workoutrepository = new WorkOutRepository();
            Load();
        }

        public WorkOutDataService(WorkOutRepository repos)
        {
            workoutrepository = repos;
        }

        public ObservableCollection<WorkOut> GetAllWorkOuts()
        {
            return workoutrepository.allWorkOuts;
        }

        public WorkOutRepository GetRepository()
        {
            return workoutrepository;
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
                workoutrepository.allWorkOuts = new ObservableCollection<WorkOut>();
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
                        workoutrepository.allWorkOuts = nullCheck;
                    }

                }
                
                catch (JsonSerializationException) 
                {
                    stream.Close();
                    using (StreamWriter newstream = File.CreateText(Path.Combine(DataFolder, "WODataBlank.xml"))) { };
                    File.Replace(Path.Combine(DataFolder, "WODataBlank.xml"), Path.Combine(DataFolder, "WOData.xml"), Path.Combine(DataFolder, "WODataBackup.xml"));
                    Console.Beep();
                    workoutrepository.allWorkOuts = new ObservableCollection<WorkOut>();
                }

            }
            
        }

        /// <summary>
        /// Save the current workouts in memory
        /// </summary>
        public void Save()
        {

            if (!(workoutrepository.allWorkOuts == null))
            {
                Load();
            }

            using (StreamWriter stream = File.CreateText(DataFile)) //rewrites the file each time
            {
                stream.Write(JsonConvert.SerializeObject(workoutrepository.allWorkOuts));
            }
        }
        /// <summary>
        /// Add a new workout and save all to file
        /// </summary>
        /// <param name="work"></param>
        public void Save(WorkOut work)
        {

            if (!(workoutrepository.allWorkOuts == null))
            {
                Load();
            }
#warning Insert logic to check for existing date

            workoutrepository.AddToCollection(work);


            using (StreamWriter stream = File.CreateText(DataFile)) //rewrites the file each time
            {
                stream.Write(JsonConvert.SerializeObject(workoutrepository.allWorkOuts));
            }
        }
   
    }
}
