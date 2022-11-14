using System.Net;
using TodoListApi.Data;
using TodoListApi.Data.DTOs;
using TodoListApi.Data.Models;
using TodoListApi.Error;
using TodoListApi.Repositories;

namespace TodoListApi.Services;

public class TodoEntryService : ITodoEntryService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IRepository<TodoEntry> _repository;

    public TodoEntryService(ApplicationDbContext dbContext, IRepository<TodoEntry> repository)
    {
        _dbContext = dbContext;
        _repository = repository;
    }

    public TodoEntryDto GetEntryById(Guid id)
    {
        var todoEntry = _repository.GetEntityById(id);
        if (todoEntry == null)
        {
            throw new TodoListException("Entry not found", HttpStatusCode.NotFound);
        }
        return todoEntry.AsDto();
    }
    public ICollection<TodoEntryDto> GetAllEntries()
    {
        return _repository.GetAllEntities().Select(x => x.AsDto()).ToList();
    }

    public TodoEntryDto CreateEntry(TodoEntryDto entryDto)
    {
        if (entryDto.EntryId != null)
        {
            throw new TodoListException("DTO already has an id", HttpStatusCode.BadRequest);
        }
        var entryModel = new TodoEntry(entryDto.EntryId, entryDto.Name, entryDto.Description, entryDto.Done);
        _repository.CreateEntity(entryModel);
        var createdEntry = _repository.GetEntityById(entryModel.Id);
        if (createdEntry == null)
        {
            throw new TodoListException("Database entry was not created", HttpStatusCode.InternalServerError);
        }
        return createdEntry.AsDto();
    }

    public TodoEntryDto UpdateEntry(TodoEntryDto entryDto)
    {
        if (entryDto.EntryId == null || entryDto.EntryId.Equals(Guid.Empty))
        {
            throw new TodoListException("DTO has no id", HttpStatusCode.BadRequest);
        }
        var oldEntry = _repository.GetEntityById(entryDto.EntryId.Value);
        if (oldEntry == null)
        {
            throw new TodoListException("No database entry found to update", HttpStatusCode.NotFound);
        }
        _repository.DeleteEntity(oldEntry);
        _repository.CreateEntity(new TodoEntry(entryDto.EntryId, entryDto.Name, entryDto.Description, entryDto.Done));
        var updatedEntry = _repository.GetEntityById(entryDto.EntryId.Value);
        if (updatedEntry == null)
        {
            throw new TodoListException("Updated database entry not found", HttpStatusCode.InternalServerError);
        }
        return updatedEntry.AsDto();
    }

    TodoEntryDto ITodoEntryService.DeleteEntry(Guid entryId)
    {
        var deletedEntry = _repository.GetEntityById(entryId);
        if (deletedEntry == null)
        {
            throw new TodoListException("No database entry found to delete", HttpStatusCode.NotFound);
        }
        _repository.DeleteEntity(deletedEntry);
        return deletedEntry.AsDto();
    }
}