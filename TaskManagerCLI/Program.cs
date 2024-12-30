using TaskManagerCLI;
using Task = TaskManagerCLI.Task;


// Create an instance of TaskEvents to manage tasks
TaskEvents MyTask = new();

// Try loading the goals from the file
try
{
    MyTask.LoadGoalsFromFile();
}
catch (Exception ex)
{
    Console.WriteLine($"Error loading tasks: {ex.Message}");
}


// Check if there are any command-line arguments
if (args.Length == 0)
        {
            Console.WriteLine("Usage: taskmanager <command> [options]");
            Console.WriteLine("Commands: goals <year>, add goal <description>, view all goals, complete goal <taskId>, remove goal <taskId>, get goal <taskId>, view completed goals, view pending goals, exit");
            return; // End program early if no args are provided
        }

        if (args[0].Equals("goals", StringComparison.CurrentCultureIgnoreCase) && args.Length > 1)
        {
            string year = args[1];
            Console.WriteLine($"Welcome to your {year} Goals Tracker!");
            DisplayHelp();  // Show the list of available commands
            return;
        }


        // Process the command passed as an argument
        switch (args[0].ToLower())
        {
            case "add goal":
                if (args.Length > 1)
                {
                    string description = string.Join(" ", args[1..]); // Join the rest of the args as the description
                    MyTask.AddGoal(description);
                    Console.WriteLine($"Goal '{description}' added successfully!");
                }
                else
                {
                    Console.WriteLine("Please provide a task description.");
                }
                break;

            case "view all goals":
                MyTask.ViewAllGoals();
                break;

            case "complete goal":
                if (args.Length > 1 && int.TryParse(args[1], out int completeTaskId))
                {
                    MyTask.CompleteGoal(completeTaskId);
                }
                else
                {
                    Console.WriteLine("Please provide a valid task ID.");
                }
                break;

            case "remove goal":
                if (args.Length > 1 && int.TryParse(args[1], out int deleteTaskId))
                {
                    MyTask.RemoveGoal(deleteTaskId);
                }
                else
                {
                    Console.WriteLine("Please provide a valid task ID.");
                }
                break;

            case "get goal":
                if (args.Length > 1 && int.TryParse(args[1], out int taskId))
                {
                    MyTask.GetAGoal(taskId);
                }
                else
                {
                    Console.WriteLine("Please provide a valid task ID.");
                }
                break;

            case "view completed goals":
                MyTask.ViewCompletedGoals();
                break;

            case "view pending goals":
                MyTask.ViewPendingGoals();
                break;

            case "exit":
                Console.WriteLine("Exiting the Task Manager. Goodbye!");
                return; 

            default:
                Console.WriteLine("Invalid command or missing parameters. Please check the available commands.");
                break;
        }

        // Try saving the goals to the file
        try
        {
            MyTask.SaveGoalsToFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving tasks: {ex.Message}");
}


// Method to display the help message with available commands
static void DisplayHelp()
{
    // Clear the console to start fresh
    Console.Clear();

    // Set the header design to white
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("******************************************");
    Console.WriteLine("   Welcome to Your 2025 Goal Tracker");
    Console.WriteLine("******************************************\n");

    // Make the commands stand out with DarkGreen
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    // Add Thread.Sleep to make it more visually appealing
    Thread.Sleep(100);
    Console.WriteLine("Here are a list of commands you can use:");

    Thread.Sleep(300);
    Console.WriteLine("  add goal <description>    - Add a new goal");

    Thread.Sleep(300);
    Console.WriteLine("  view goal                 - View all goals");

    Thread.Sleep(300);
    Console.WriteLine("  complete goal <taskId>    - Mark a goal as completed");

    Thread.Sleep(300);
    Console.WriteLine("  remove goal <taskId>      - Remove a goal by its ID");

    Thread.Sleep(300);
    Console.WriteLine("  get goal <taskId>         - Get a specific goal by its ID");

    Thread.Sleep(300);
    Console.WriteLine("  view completed goals      - View all completed goals");

    Thread.Sleep(300);
    Console.WriteLine("  view pending goals        - View all pending goals");

    Thread.Sleep(300);
    Console.WriteLine("  exit                      - Exit the application");

    Thread.Sleep(300);

    // Reset the color to white for the footer message
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("******************************");
    Console.WriteLine("    Happy Goal Setting!      ");
    Console.WriteLine("******************************\n");

    Thread.Sleep(00);

    // Reset to the default color after displaying the help
    Console.ResetColor();
}


