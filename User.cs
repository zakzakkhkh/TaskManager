using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Task> Tasks { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        Tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    public void RemoveTask(int index)
    {
        if (index >= 0 && index < Tasks.Count)
        {
            Tasks.RemoveAt(index);
        }
    }

    public void MarkTaskComplete(int index)
    {
        if (index >= 0 && index < Tasks.Count)
        {
            Tasks[index].MarkAsComplete();
        }
    }

    public override string ToString()
    {
        return Username;
    }
}
