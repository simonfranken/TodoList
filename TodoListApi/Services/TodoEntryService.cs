using System.Net;
using TodoListApi.Data;
using TodoListApi.Data.DTOs;
using TodoListApi.Data.Models;
using TodoListApi.Error;

namespace TodoListApi.Services;

public class TodoEntryService : ITodoEntryService
{
    private readonly ApplicationDbContext _dbContext;

    public TodoEntryService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TodoEntryDto GetEntryById(Guid entryId)
    {
        var todoEntry = _dbContext.TodoEntries.Where(x => x.EntryId.Equals(entryId)).SingleOrDefault()?.AsDto();
        if (todoEntry == null)
        {
            throw new TodoListException("Database entry not found", HttpStatusCode.NotFound);
        }
        return todoEntry;
    }
    public ICollection<TodoEntryDto> GetAllEntries()
    {
        return _dbContext.TodoEntries.Where(x => true).Select(x => x.AsDto()).ToList();
    }

    public TodoEntryDto CreateEntry(TodoEntryDto entryDto)
    {
        if (entryDto.EntryId != null)
        {
            throw new TodoListException("DTO already has an id", HttpStatusCode.BadRequest);
        }
        var entryModel = new TodoEntry(entryDto.EntryId, entryDto.Name, entryDto.Done);
        _dbContext.TodoEntries.Add(entryModel);
        _dbContext.SaveChanges();
        var createdEntry = _dbContext.TodoEntries.Where(x => x.EntryId.Equals(entryModel.EntryId)).SingleOrDefault();
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
        var oldEntry = _dbContext.TodoEntries.Where(x => x.EntryId.Equals(entryDto.EntryId)).SingleOrDefault();
        if (oldEntry == null)
        {
            throw new TodoListException("No database entry found to update", HttpStatusCode.NotFound);
        }
        _dbContext.TodoEntries.Remove(oldEntry);
        _dbContext.TodoEntries.Add(new TodoEntry(entryDto.EntryId, entryDto.Name, entryDto.Done));
        _dbContext.SaveChanges();
        var updatedEntry = _dbContext.TodoEntries.Where(x => x.EntryId.Equals(entryDto.EntryId)).SingleOrDefault();
        if (updatedEntry == null)
        {
            throw new TodoListException("Updated database entry not found", HttpStatusCode.InternalServerError);
        }
        return updatedEntry.AsDto();
    }

    TodoEntryDto ITodoEntryService.DeleteEntry(Guid entryId)
    {
        var deletedEntry = _dbContext.TodoEntries.Where(x => x.EntryId.Equals(entryId)).SingleOrDefault();
        if (deletedEntry == null)
        {
            throw new TodoListException("No database entry found to delete", HttpStatusCode.NotFound);
        }
        _dbContext.TodoEntries.Remove(deletedEntry);
        _dbContext.SaveChanges();
        return deletedEntry.AsDto();
    }
}