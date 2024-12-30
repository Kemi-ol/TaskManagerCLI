// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCLI
{
    public interface ITaskEvents
    {
        public void AddGoal(string desc);
        public void CompleteGoal(int id);
        public void GetAGoal( int id);
        public void RemoveGoal(int id);
        public void ViewAllGoals();
        public void ViewPendingGoals();
        public void ViewCompletedGoals();

        public void SaveGoalsToFile();

        public void LoadGoalsFromFile();
    }
}
