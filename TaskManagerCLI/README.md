# Goal Tracker CLI

A simple command-line interface (CLI) tool for managing and tracking your goals for 2025.

## Commands

- `add_goal <description>`: Add a new goal.
- `view_all`: View all goals.
- `complete_goal <taskId>`: Mark a goal as completed.
- `remove_goal <taskId>`: Remove a goal by its ID.
- `get_goal <taskId>`: View details of a specific goal.
- `view_completed`: List all completed goals.
- `view_pending`: List all pending goals.
- `help`: Show this help menu.
- `exit`: Exit the application.

## Installation

To install this tool globally:

1. Download and install the tool using the following command:
   
   dotnet tool install --global --add-source ./ goaltracker
   

2. To update to a newer version, first uninstall the existing version:
   
   dotnet tool uninstall --global goaltracker
  
   Then install the latest version:
  
   dotnet tool install --global --add-source ./ goaltracker
 

## Usage

1. Open your command-line interface (CLI).
2. Run the tool using:
   
   goaltracker <command> [options]
   
   
Example:

goaltracker add_goal "Learn C# CLI programming"
goaltracker view_all
goaltracker complete_goal 1
goaltracker remove_goal 2


## License

This project is licensed under the MIT License.


### 3. **Regenerate the `.nupkg` File**

Once you’ve added the `README.md` and updated the `.csproj` file, regenerate the package:

dotnet pack --configuration Release


### 4. **Publish the Package (Optional)**

After regenerating the `.nupkg` file, you can publish the updated package to NuGet:

dotnet nuget push ./bin/Release/goaltracker.1.0.1.nupkg --api-key <Your-API-Key> --source https://api.nuget.org/v3/index.json

