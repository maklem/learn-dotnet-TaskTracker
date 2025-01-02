namespace TaskTracker.Models;

public class DailyTask
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public TimeSpan To_be_done_at { get; set; }
    public DateTime? Done_at { get; set;}
}