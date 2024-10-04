using System;

public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public bool IsComplete { get; set; }

    public Task(string title, string description, DateTime deadline)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        IsComplete = false;
    }

    public void MarkAsComplete()
    {
        IsComplete = true;
    }

    public override string ToString()
    {
        return $"{Title} - {Description} - Due: {Deadline.ToShortDateString()} - {(IsComplete ? "Completed" : "Incomplete")}";
    }
}
