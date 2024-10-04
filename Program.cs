using System;

class Program
{
    static TaskManager taskManager = new TaskManager();

    static void Main(string[] args)
    {
        Console.Title = "WSM Student Task Manager";  // Set the console title
        DisplayASCIIArt();  // Display the WSM ASCII art

        while (true)
        {
            Console.WriteLine("\nTask Manager");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Add Task");
            Console.WriteLine("4. View Tasks");
            Console.WriteLine("5. Edit Task");
            Console.WriteLine("6. Delete Task");
            Console.WriteLine("7. Mark Task as Complete");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    AddTask();
                    break;
                case "4":
                    taskManager.ViewTasks();
                    break;
                case "5":
                    EditTask();
                    break;
                case "6":
                    DeleteTask();
                    break;
                case "7":
                    MarkTaskComplete();
                    break;
                case "8":
                    DisplayGoodbyeMessage();  // Call the goodbye message before exiting
                    return;  // Exit the program
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void DisplayASCIIArt()
    {
        Console.WriteLine(@"     ██╗    ██╗███████╗███╗   ███╗ ");
        Console.WriteLine(@"     ██║    ██║██╔════╝████╗ ████║");
        Console.WriteLine(@"     ██║ █╗ ██║███████╗██╔████╔██║");
        Console.WriteLine(@"     ██║███╗██║╚════██║██║╚██╔╝██║");
        Console.WriteLine(@"     ╚███╔███╔╝███████║██║ ╚═╝ ██║");
        Console.WriteLine(@"      ╚══╝╚══╝ ╚══════╝╚═╝     ╚═╝");
        Console.WriteLine("\nThe WSM Student Task Manager!");
    }

    static void DisplayGoodbyeMessage()
    {
        Console.WriteLine(@"    ███████  █████  ██   ██  █████  ██████  ██  █████  ███████     ██   ██ ██   ██ ███    ███ ██ ███████ ███████ ");
        Console.WriteLine(@"       ███  ██   ██ ██  ██  ██   ██ ██   ██ ██ ██   ██ ██          ██  ██  ██   ██ ████  ████ ██ ██      ██      ");
        Console.WriteLine(@"      ███   ███████ █████   ███████ ██████  ██ ███████ █████       █████   ███████ ██ ████ ██ ██ █████   ███████ ");
        Console.WriteLine(@"     ███    ██   ██ ██  ██  ██   ██ ██   ██ ██ ██   ██ ██          ██  ██  ██   ██ ██  ██  ██ ██ ██           ██ ");
        Console.WriteLine(@"    ███████ ██   ██ ██   ██ ██   ██ ██   ██ ██ ██   ██ ███████     ██   ██ ██   ██ ██      ██ ██ ███████ ███████ ");
        Console.WriteLine(@"                                                                                                                 ");
        Console.WriteLine("\n         Done By Zakariae Khmies");
    }

    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);  // Read the key without displaying it

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;   // Add the character to the password
                Console.Write("*");        // Display '*' instead of the character
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");   // Remove the last '*' from the console
            }
        } while (key.Key != ConsoleKey.Enter);  // Stop when 'Enter' is pressed

        Console.WriteLine();  // Move to the next line
        return password;      // Return the hidden password
    }

    static void RegisterUser()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = ReadPassword();  // Use the ReadPassword method to hide password input
        taskManager.RegisterUser(username, password);
    }

    static void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = ReadPassword();  // Use the ReadPassword method to hide password input
        if (taskManager.Login(username, password))
        {
            Console.WriteLine("Login successful!");
        }
        else
        {
            Console.WriteLine("Invalid credentials.");
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine();
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        Console.Write("Enter task deadline (yyyy-MM-dd): ");
        DateTime deadline = DateTime.Parse(Console.ReadLine());
        taskManager.AddTask(title, description, deadline);
    }

    static void EditTask()
    {
        taskManager.ViewTasks();
        Console.Write("Enter task number to edit: ");
        int taskNumber = int.Parse(Console.ReadLine()) - 1;
        Console.Write("Enter new title: ");
        string newTitle = Console.ReadLine();
        Console.Write("Enter new description: ");
        string newDescription = Console.ReadLine();
        taskManager.EditTask(taskNumber, newTitle, newDescription);
    }

    static void DeleteTask()
    {
        taskManager.ViewTasks();
        Console.Write("Enter task number to delete: ");
        int taskNumber = int.Parse(Console.ReadLine()) - 1;
        taskManager.DeleteTask(taskNumber);
    }

    static void MarkTaskComplete()
    {
        taskManager.ViewTasks();
        Console.Write("Enter task number to mark as complete: ");
        int taskNumber = int.Parse(Console.ReadLine()) - 1;
        taskManager.MarkTaskComplete(taskNumber);
    }
}
