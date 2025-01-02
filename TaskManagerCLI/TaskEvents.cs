// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCLI
{
    public class TaskEvents : ITaskEvents
    {
        private readonly List<Task> goals = [];
        int taskIdCounter = 1;

        public void AddGoal(string description)
        {
            if (goals.Count == 0) // Load tasks only if they haven't been loaded yet
            {
                LoadGoalsFromFile();
            }

            var newTask = new Task
            {
                Id = taskIdCounter,
                MyGoalDescription = description,
                EntryDate = DateTime.Now,
                DueDate = new DateTime(2025, 12, 31),
                IsCompleted = false,
            };
            taskIdCounter++;
            goals.Add(newTask);
            SaveGoalsToFile();
            Console.WriteLine($"2025 Goal: '{description}' added.");
        }

        public void CompleteGoal(int taskId)
        {
            LoadGoals();
            var task = goals.Find(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
                task.MyGoalDescription = $"{task.MyGoalDescription}: Completed";
                Console.WriteLine($"Task '{task.MyGoalDescription}' marked as complete.");
            }
            else
            {
                Console.WriteLine("Goal not found.");
            }
        }

        public void GetAGoal(int taskId)
        {
            LoadGoals();
            var task = goals.Find(t => t.Id == taskId);
            Console.WriteLine(task);
        }

        public void RemoveGoal(int taskId)
        {
           LoadGoals();
           var task = goals.Find(t => t.Id == taskId);
            if (task != null)
            {
                goals.Remove(task);
                Console.WriteLine($"Task '{task.MyGoalDescription}' removed");
                Console.WriteLine(task);
                SaveGoalsToFile();
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        public void ViewAllGoals()
        {
            LoadGoalsFromFile();

            if (goals.Count == 0)
            {
                Console.WriteLine("No tasks Found");
                return;
            }
            else
            {
                foreach (var goal in goals)
                {
                    Console.WriteLine($"\nTask Id: {goal.Id}\n Description: {goal.MyGoalDescription}\n" +
                        $" StartDate:{goal.EntryDate}\n DueDate:{goal.DueDate}\n Status:{goal.IsCompleted}");
                }
            }
        }
        public void ViewPendingGoals()
        {
            LoadGoalsFromFile();
            if (goals.Count > 0)
            {
                Console.WriteLine("You have pending tasks");
            }
            else
            {
                foreach (var task in goals)
                {
                    Console.WriteLine(task.ToString());
                }
            }
        }

        public void ViewCompletedGoals()
        {
            LoadGoalsFromFile();
            var completedGoals = goals.Where(g => g.MyGoalDescription.Contains("completed")).ToList();
            if (completedGoals.Count == 0)
            {
                Console.WriteLine("No Completed goals Found");
            }
            else
            {
                foreach (var goal in completedGoals)
                {
                    Console.WriteLine("Here is your list of 2025 completed goals:");
                    Console.WriteLine($"{goal}");
                }
            }
        }

        public void SaveGoalsToFile()
        {
            // Get the current user's Desktop folder path
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Create a new directory path for the Tasks folder inside the Desktop
            string tasksDirectory = Path.Combine(desktopPath, "Tasks");

            // Ensure the directory exists (create it if it doesn't)
            Directory.CreateDirectory(tasksDirectory);

            // Combine the path with the desired file name
            string filePath = Path.Combine(tasksDirectory, "tasks.txt");

            // Write the tasks to the file
            using StreamWriter writer = new(filePath, false);
            foreach (var task in goals)
            {
                writer.WriteLine($"{task.Id}|{task.MyGoalDescription}|{task.EntryDate}|{task.DueDate}|{task.IsCompleted}");
            }
        }

        public void LoadGoalsFromFile()
        {
            // Get the current user's Desktop folder path
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Create the path for the Tasks folder
            string tasksDirectory = Path.Combine(desktopPath, "Tasks");

            // Define the full file path
            string filePath = Path.Combine(tasksDirectory, "tasks.txt");

            // Clear existing goals and load from file if it exists
            goals.Clear();

            if (File.Exists(filePath))
            {
                using StreamReader reader = new(filePath);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 5)
                    {
                        var task = new Task
                        {
                            Id = int.Parse(parts[0]),
                            MyGoalDescription = parts[1],
                            EntryDate = DateTime.Parse(parts[2]),
                            DueDate = DateTime.Parse(parts[3]),
                            IsCompleted = bool.Parse(parts[4])
                        };
                        goals.Add(task);
                    }
                }
            }
        }

        private protected int LoadGoals()
        {
            ViewAllGoals();
            int taskId = -1;
            while (taskId <= 0)
            {
                Console.WriteLine("Enter the ID of the goal to remove... ");
                string? input = Console.ReadLine(); 

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please enter a valid task ID.");
                    continue; 
                }
                try
                {
                    taskId = int.Parse(input);
                    if (taskId <= 0)
                    {
                        Console.WriteLine("Please enter a valid positive task ID.");
                    };
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer ID.");
                }
            }    
             return taskId;
        }
    }
};
