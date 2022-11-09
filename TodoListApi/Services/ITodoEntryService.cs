using TodoListApi.Data.DTOs;

namespace TodoListApi.Services;

public interface ITodoEntryService
{

    public TodoEntryDto? GetEntryById(Guid entryId);
}