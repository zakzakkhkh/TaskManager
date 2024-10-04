using System;
using System.Collections.Generic;

public class TaskManager
{
    private List<User> users = new List<User>();
    private User currentUser;

    public void RegisterUser(string username, string password)
    {
        users.Add(new User(username, password));
        Console.WriteLine("User registered successfully!");
    }

    public bool Login(string username, string password)
    {
        currentUser = users.Find(user => user.Username == username && user.Password == password);
        if (currentUser != null)
        {
            Console.WriteLine("Login successful!");
            return true;
        }
        Console.WriteLine("Invalid username or password.");
        return false;
    }

    public void AddTask(string title, string description, DateTime deadline)
    {
        if (currentUser == null)
        {
            Console.WriteLine("You must be logged in to add a task.");
            return;
        }

        Task task = new Task(title, description, deadline);
        currentUser.AddTask(task);
        Console.WriteLine("Task added successfully!");
    }

    public void ViewTasks()
    {
        if (currentUser == null)
        {
            Console.WriteLine("You must be logged in to view tasks.");
            return;
        }

        Console.WriteLine($"\nTasks for {currentUser.Username}:");
        for (int i = 0; i < currentUser.Tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {currentUser.Tasks[i]}");
        }
    }

    public void EditTask(int index, string newTitle, string newDescription)
    {
        if (currentUser == null)
        {
            Console.WriteLine("You must be logged in to edit tasks.");
            return;
        }

        if (index >= 0 && index < currentUser.Tasks.Count)
        {
            currentUser.Tasks[index].Title = newTitle;
            currentUser.Tasks[index].Description = newDescription;
            Console.WriteLine("Task edited successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    public void DeleteTask(int index)
    {
        if (currentUser == null)
        {
            Console.WriteLine("You must be logged in to delete tasks.");
            return;
        }

        if (index >= 0 && index < currentUser.Tasks.Count)
        {
            currentUser.RemoveTask(index);
            Console.WriteLine("Task deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    public void MarkTaskComplete(int index)
    {
        if (currentUser == null)
        {
            Console.WriteLine("You must be logged in to mark tasks as complete.");
            return;
        }

        if (index >= 0 && index < currentUser.Tasks.Count)
        {
            currentUser.MarkTaskComplete(index);
            Console.WriteLine("Task marked as complete!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}
