using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WorkOutClass;
using System.Collections.Generic;
using System.Linq;

namespace WorkOutTestNS
{
    [TestClass]
    public class WorkOutTest
    {


        [TestMethod]
        public void WorkOutTest1()
        {

            string exName = "New exercise1";
            StrTrain newEx = new StrTrain(exName);
            newEx.Sets.Add(10);
            newEx.Sets.Add(12);
            newEx.Sets.Add(11);
            newEx.Sets.Add(10);
            newEx.Sets.Add(14);

            string exNameOther = "New exercise2";
            StrTrain newExOther = new StrTrain(exNameOther);

            newExOther.Sets.Add(10);
            newExOther.Sets.Add(10);
            newExOther.Sets.Add(10);
            newExOther.Sets.Add(10);
            newExOther.Sets.Add(10);

            WorkOut work = new WorkOut();

            work.ExerciseList.Add(newEx);
            work.ExerciseList.Add(newExOther);

            work.ExerciseList.Add(new Cardio("Sprints123", new int[] { 40 }));

            work.Date = new DateTime(2011, 3, 19);
            work.Length = 50;
            WorkOutRepository Repos1 = new WorkOutRepository();
            //Repos1.Load();

           // Repos1.Save(work);
        }


    }

        
       
}
