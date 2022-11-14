using TodoListApi.Data.DTOs;
using TodoListApi.Data.Models;

namespace TodoListApi.Data;

public static class AsDtoHelper
{
    public static TodoEntryDto AsDto(this TodoEntry todoEntry)
    {
        return new TodoEntryDto(todoEntry.EntryId, todoEntry.Name, todoEntry.Description, todoEntry.Done);
    }
}