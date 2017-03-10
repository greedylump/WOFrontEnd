using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutClass;

namespace WOFrontEnd.Services
{
    class WorkOutDataService
    {
        WorkOutRepository workoutrepository;

        public WorkOutDataService()
        {
            workoutrepository = new WorkOutRepository();
        }

        public WorkOutDataService(WorkOutRepository repos)
        {
            workoutrepository = repos;
        }

        public void Add(WorkOut wo)
        {
            workoutrepository.AddToCollection(wo);
        }

        public void Save() { }
        public void Load() { }

    }
}
