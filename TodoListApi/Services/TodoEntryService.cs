using TodoListApi.Data;
using TodoListApi.Data.DTOs;
using TodoListApi.Data.Models;

namespace TodoListApi.Services;

public class TodoEntryService : ITodoEntryService
{
    public TodoEntryDto? GetEntryById(Guid entryId)
    {
        return new TodoEntry(null, "Essen kochen", false).AsDto();
    }
}