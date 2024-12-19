using TaskTracker.Services;
using TaskTracker.Models;

namespace BackendTest;

[TestClass]
public sealed class MemoryTaskServiceTests
{
    [TestMethod]
    public void MemoryTaskService_add_appendsTask()
    {
        var service = new MemoryTaskService();
        Assert.AreEqual(1, service.GetAllTasks().Count);

        service.Add(new DailyTask());
        Assert.AreEqual(2, service.GetAllTasks().Count);
    }

    [TestMethod]
    public void WhenTaskExists_Find_returnsTask()
    {
        var service = new MemoryTaskService();
        var task = service.Find(0);
        Assert.IsNotNull(task);
    }

    [TestMethod]
    public void WhenTaskDoesNotExists_Find_returnsNull()
    {
        var service = new MemoryTaskService();
        var task = service.Find(-1);
        Assert.IsNull(task);
    }
}
