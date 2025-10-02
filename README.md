# LeopoldPlan

LeopoldPlan is a Windows Forms application for managing tasks using a SQL Server database. It allows users to add, search, update, and delete tasks, making it suitable for simple personal or team task tracking.

## Features

- **Add Task:** Register new tasks with a name and status.
- **Search Task:** Find tasks by their ID and display them in a grid view.
- **Update Task:** Edit the name and status of an existing task by searching its ID.
- **Delete Task:** Remove a task by searching its ID.
- **View All Tasks:** Display all tasks in a grid view.

## Requirements

- .NET Framework 4.7.2
- SQL Server (with a database named `LeopoldDB` and a table `Task`)
- Visual Studio (recommended for development)

## Setup

1. Clone the repository: git clone https://github.com/yourusername/LeopoldPlan.git
2. Open the solution in Visual Studio.
3. Ensure your SQL Server is running and the connection string in `Taskform.cs` matches your server and database.
4. Create the `Task` table in your database:

CREATE TABLE Task ( taskID INT PRIMARY KEY IDENTITY(1,1), taskName NVARCHAR(100), status NVARCHAR(50) );
5. Build and run the project.

## Usage

- Enter a task name and status, then click **Register** to add a new task.
- Enter a task ID in the search box and click **Search** to view the task.
- After searching, edit the task name/status and click **Update** to save changes.
- After searching, click **Delete** to remove the task.

## License

This project is licensed under the MIT License.
