using TodoListApi.Data.DTOs;

namespace TodoListApi.Services;

public interface ITodoEntryService
{
    public TodoEntryDto GetEntryById(Guid entryId);
    public ICollection<TodoEntryDto> GetAllEntries();
    public TodoEntryDto UpdateEntry(TodoEntryDto entryDto);
    public TodoEntryDto CreateEntry(TodoEntryDto entryDto);
    public TodoEntryDto DeleteEntry(Guid entryId);
}