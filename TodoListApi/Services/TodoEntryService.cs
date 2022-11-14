using System.Net;
using TodoListApi.Data;
using TodoListApi.Data.DTOs;
using TodoListApi.Data.Models;
using TodoListApi.Error;
using TodoListApi.Repositories;

namespace TodoListApi.Services;

public class TodoEntryService : ITodoEntryService
{
    private readonly IRepository<TodoEntry> _repository;

    public TodoEntryService(IRepository<TodoEntry> repository)
    {
        _repository = repository;
    }

    public TodoEntryDto GetEntryById(Guid id)
    {
        var todoEntry = _repository.GetEntityById(id);
        if (todoEntry == null)
        {
            throw new TodoListException("Entity not found", HttpStatusCode.NotFound);
        }
        return todoEntry.AsDto();
    }
    public ICollection<TodoEntryDto> GetAllEntries()
    {
        return _repository.GetAllEntities().Select(x => x.AsDto()).ToList();
    }

    public TodoEntryDto CreateEntry(TodoEntryDto entryDto)
    {
        var entryModel = new TodoEntry(null, entryDto.Name, entryDto.Description, entryDto.Done);
        _repository.CreateEntity(entryModel);
        var createdEntry = _repository.GetEntityById(entryModel.Id);
        if (createdEntry == null)
        {
            throw new TodoListException("Entity was not created", HttpStatusCode.InternalServerError);
        }
        return createdEntry.AsDto();
    }

    public TodoEntryDto UpdateEntry(TodoEntryDto entryDto)
    {
        if (!entryDto.EntryId.HasValue)
        {
            throw new TodoListException("Entity has no id", HttpStatusCode.BadRequest);
        }
        var entry = _repository.GetEntityById(entryDto.EntryId.Value);
        if (entry == null)
        {
            throw new TodoListException("Entity to be updated was not found", HttpStatusCode.NotFound);
        }
        _repository.DeleteEntity(entry);
        var updatedEntry = _repository.CreateEntity(new TodoEntry(entryDto.EntryId.Value, entryDto.Name, entryDto.Description, entryDto.Done));
        if (updatedEntry == null)
        {
            throw new TodoListException("Entity was not updated", HttpStatusCode.InternalServerError);
        }
        return updatedEntry.AsDto();
    }

    TodoEntryDto ITodoEntryService.DeleteEntry(Guid entryId)
    {
        var deletedEntry = _repository.GetEntityById(entryId);
        if (deletedEntry == null)
        {
            throw new TodoListException("Entity to be deleted was not found", HttpStatusCode.NotFound);
        }
        _repository.DeleteEntity(deletedEntry);
        return deletedEntry.AsDto();
    }
}