using TaskManagerCLI;
using Task = TaskManagerCLI.Task;

class Program
{
    static void Main(string[] args)
    {
        TaskEvents myTask = new();

        // Load goals from the file
        try
        {
            myTask.LoadGoalsFromFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tasks: {ex.Message}");
        }

        if (args.Length == 0)
        {
            DisplayHelp();
            return;
        }

        string command = args[0].ToLower(); // Normalize the command

        try
        {
            switch (command)
            {
                case "add_goal":
                    if (args.Length > 1)
                    {
                        string description = string.Join(" ", args[1..]);
                        myTask.AddGoal(description);
                        Console.WriteLine($"Goal added: {description}");
                        myTask.SaveGoalsToFile(); // Save immediately
                    }
                    else
                    {
                        Console.WriteLine("Usage: add_goal <description>");
                    }
                    break;

                case "view_all":
                    myTask.ViewAllGoals();
                    break;

                case "complete_goal":
                    if (args.Length > 1 && int.TryParse(args[1], out int completeTaskId))
                    {
                        myTask.CompleteGoal(completeTaskId);
                        myTask.SaveGoalsToFile(); // Save immediately
                    }
                    else
                    {
                        Console.WriteLine("Usage: complete_goal <taskId>");
                    }
                    break;

                case "remove_goal":
                    if (args.Length > 1 && int.TryParse(args[1], out int deleteTaskId))
                    {
                        myTask.RemoveGoal(deleteTaskId);
                        myTask.SaveGoalsToFile(); // Save immediately
                    }
                    else
                    {
                        Console.WriteLine("Usage: remove_goal <taskId>");
                    }
                    break;

                case "get_goal":
                    if (args.Length > 1 && int.TryParse(args[1], out int taskId))
                    {
                        myTask.GetAGoal(taskId);
                    }
                    else
                    {
                        Console.WriteLine("Usage: get_goal <taskId>");
                    }
                    break;

                case "view_completed":
                    myTask.ViewCompletedGoals();
                    break;

                case "view_pending":
                    myTask.ViewPendingGoals();
                    break;

                case "help":
                    DisplayHelp();
                    break;

                case "exit":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Unknown command. Use 'help' for a list of available commands.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Help Method
    static void DisplayHelp()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("******************************");
        Console.WriteLine("   Welcome to Goal Tracker");
        Console.WriteLine("******************************");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Commands:");
        Console.WriteLine("  add_goal <description>    - Add a new goal");
        Console.WriteLine("  view_all                  - View all goals");
        Console.WriteLine("  complete_goal <taskId>    - Mark a goal as completed");
        Console.WriteLine("  remove_goal <taskId>      - Remove a goal by its ID");
        Console.WriteLine("  get_goal <taskId>         - View details of a specific goal");
        Console.WriteLine("  view_completed            - List all completed goals");
        Console.WriteLine("  view_pending              - List all pending goals");
        Console.WriteLine("  help                      - Show this help menu");
        Console.WriteLine("  exit                      - Exit the application");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("******************************");
        Console.ResetColor();
    }
}
