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
    private static TodoEntry todoEntry0 = new TodoEntry(guid0, "Test0", "Test", false);
    private static TodoEntryDto todoEntryDto0 = new TodoEntryDto(null, "Test0", "Test", false);


    [Fact]
    public void GetEntryById_ValidId_TodoEntryDto()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Returns(todoEntry0);

        var service = new TodoEntryService(mock.Object);

        var result = service.GetEntryById(guid0);
        Assert.IsType<TodoEntryDto>(result);
    }

    [Fact]
    public void GetEntryById_InvalidId_Exception()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Returns((TodoEntry?)null);

        var service = new TodoEntryService(mock.Object);

        Assert.Throws<TodoListException>(() => service.GetEntryById(guid0));
    }

    [Fact]
    public void GetEntryById_RepositoryException_Exception()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Throws(new Exception());

        var service = new TodoEntryService(mock.Object);

        Assert.Throws<Exception>(() => service.GetEntryById(guid0));
    }

    [Fact]
    public void GetAllEntries_TodoEntryCollection()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetAllEntities()).Returns(new List<TodoEntry>() { todoEntry0 });

        var service = new TodoEntryService(mock.Object);

        var restult = service.GetAllEntries();
        Assert.IsAssignableFrom<ICollection<TodoEntryDto>>(restult);
    }

    [Fact]
    public void GetAllEntries_Exception()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetAllEntities()).Throws(new Exception());

        var service = new TodoEntryService(mock.Object);

        Assert.Throws<Exception>(() => service.GetAllEntries());
    }

    [Fact]
    public void CreateOrUpdateEntry_NoGuid_TodoEntryDto()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.CreateEntity(It.IsAny<TodoEntry>())).Returns(todoEntry0);

        var service = new TodoEntryService(mock.Object);

        var result = service.CreateOrUpdateEntry(todoEntryDto0);
        Assert.IsType<TodoEntryDto>(result);
    }

    [Fact]
    public void CreateOrUpdateEntry_NoGuid_Exception()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.CreateEntity(It.IsAny<TodoEntry>())).Returns((TodoEntry?)null);

        var service = new TodoEntryService(mock.Object);

        Assert.Throws<TodoListException>(() => service.CreateOrUpdateEntry(todoEntryDto0));
    }

    [Fact]
    public void CreateOrUpdateEntry_ValidGuid_TodoEntryDto()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Returns(todoEntry0);
        mock.Setup(mock => mock.CreateEntity(It.IsAny<TodoEntry>())).Returns(todoEntry0);

        var service = new TodoEntryService(mock.Object);

        var result = service.CreateOrUpdateEntry(todoEntry0.AsDto());
        Assert.IsType<TodoEntryDto>(result);
    }

    [Fact]
    public void CreateOrUpdateEntry_InvalidGuid_Exception()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Returns((TodoEntry?)null);

        var service = new TodoEntryService(mock.Object);

        Assert.Throws<TodoListException>(() => service.CreateOrUpdateEntry(todoEntry0.AsDto()));
    }

    [Fact]
    public void CreateOrUpdateEntry_ValidGuid_Exception()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Returns(todoEntry0);
        mock.Setup(mock => mock.CreateEntity(It.IsAny<TodoEntry>())).Returns((TodoEntry?)null);

        var service = new TodoEntryService(mock.Object);

        Assert.Throws<TodoListException>(() => service.CreateOrUpdateEntry(todoEntry0.AsDto()));
    }

    [Fact]
    public void CreateOrUpdateEntry_ValidGuid_RepoException()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Returns(todoEntry0);
        mock.Setup(mock => mock.CreateEntity(It.IsAny<TodoEntry>())).Throws(new Exception());

        var service = new TodoEntryService(mock.Object);

        Assert.Throws<Exception>(() => service.CreateOrUpdateEntry(todoEntry0.AsDto()));
    }

    [Fact]
    public void DeleteEntry_ValidGuid_TodoEntryDto()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Returns(todoEntry0);


        var service = new TodoEntryService(mock.Object);
        var result = service.DeleteEntry(guid0);
        Assert.IsType<TodoEntryDto>(result);
    }

    [Fact]
    public void DeleteEntry_InvalidGuid_TodoEntryDto()
    {
        var mock = new Mock<IRepository<TodoEntry>>();
        mock.Setup(mock => mock.GetEntityById(It.IsAny<Guid>())).Returns((TodoEntry?)null);


        var service = new TodoEntryService(mock.Object);

        Assert.Throws<TodoListException>(() => service.DeleteEntry(guid0));
    }
}