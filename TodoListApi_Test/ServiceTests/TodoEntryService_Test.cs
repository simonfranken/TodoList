using Moq;
using TodoListApi.Data.DTOs;
using TodoListApi.Data.Models;
using TodoListApi.Error;
using TodoListApi.Repositories;
using TodoListApi.Services;
using TodoListApi.Data;

namespace TodoListApi_Test;

public class TodoEntryService_Test
{
    private static Guid guid0 = Guid.NewGuid();
    private static Guid guid1 = Guid.NewGuid();
    private static TodoEntry todoEntry0 = new TodoEntry(guid0, "Test", "Test", false);
    private static TodoEntry todoEntry1 = new TodoEntry(guid1, "Test", "Test", false);


    [Fact]
    public void GetEntryById_Test()
    {
        var mockRepo = new Mock<IRepository<TodoEntry>>();
        mockRepo.Setup(mock => mock.GetEntityById(It.Is<Guid>(x => x.Equals(guid0)))).Returns(todoEntry0);
        mockRepo.Setup(mock => mock.GetEntityById(It.Is<Guid>(x => x.Equals(guid1)))).Returns((TodoEntry?)null);

        var service = new TodoEntryService(mockRepo.Object);

        var result0 = service.GetEntryById(guid0);
        Assert.IsType<TodoEntryDto>(result0);
        Assert.Throws<TodoListException>(() => service.GetEntryById(guid1));
    }

    [Fact]
    public void GetAllEntries_Test()
    {
        var mockRepo = new Mock<IRepository<TodoEntry>>();
        mockRepo.Setup(mock => mock.GetAllEntities()).Returns(new List<TodoEntry>() { todoEntry0, todoEntry1 });

        var service = new TodoEntryService(mockRepo.Object);

        var result0 = service.GetAllEntries();
        Assert.IsAssignableFrom<ICollection<TodoEntryDto>>(result0);
    }

    [Fact]
    public void CreateEntry_Test()
    {
        var mockRepo = new Mock<IRepository<TodoEntry>>();
    }
}