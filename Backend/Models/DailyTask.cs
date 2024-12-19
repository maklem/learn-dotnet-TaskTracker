namespace TaskTracker.Models;

public class DailyTask
{
    public int id { get; set; }
    public string name { get; set; }
    public TimeSpan to_be_done_at { get; set; }
    public DateTime? done_at { get; set;}
}