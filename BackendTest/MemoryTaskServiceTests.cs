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

    [TestMethod]
    public void WhenTaskExists_Update_implementsChanges()
    {
        var service = new MemoryTaskService();
        Assert.AreEqual(1, service.GetAllTasks().Count);

        service.Update(new DailyTask{Id=0, Name="Test"});
        Assert.AreEqual(1, service.GetAllTasks().Count);
        var task = service.Find(0);
        Assert.IsNotNull(task);
        Assert.AreEqual("Test", task.Name);
    }
    [TestMethod]
    public void WhenTaskDoesNotExist_Update_keepsListUnchanged()
    {
        var service = new MemoryTaskService();
        Assert.AreEqual(1, service.GetAllTasks().Count);

        service.Update(new DailyTask{Id=10, Name="Test"});
        Assert.AreEqual(1, service.GetAllTasks().Count);
        var task = service.Find(0);
        Assert.IsNotNull(task);
        Assert.AreEqual("Hello World", task.Name);
    }

    [TestMethod]
    public void WhenTaskExists_Delete_removesEntry()
    {
        var service = new MemoryTaskService();
        Assert.AreEqual(1, service.GetAllTasks().Count);

        service.Delete(0);
        Assert.AreEqual(0, service.GetAllTasks().Count);
    }
    [TestMethod]
    public void WhenTaskDoesNotExist_Delete_keepsListUnchanged()
    {
        var service = new MemoryTaskService();
        Assert.AreEqual(1, service.GetAllTasks().Count);

        service.Delete(10);
        Assert.AreEqual(1, service.GetAllTasks().Count);
        var task = service.Find(0);
        Assert.IsNotNull(task);
        Assert.AreEqual("Hello World", task.Name);
    }
}
