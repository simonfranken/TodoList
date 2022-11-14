using Microsoft.AspNetCore.Mvc;
using TodoListApi.Data.DTOs;
using TodoListApi.Services;

namespace TodoListApi.Controllers;


[Route("[Controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoEntryService _todoEntryService;

    public TodoController(ITodoEntryService todoEntryService)
    {
        _todoEntryService = todoEntryService;
    }

    [HttpGet]
    [Route("{entryId}")]
    public ActionResult<TodoEntryDto> GetEntryById(Guid entryId)
    {
        var todoEntry = _todoEntryService.GetEntryById(entryId);
        return Ok(todoEntry);
    }

    [HttpGet]
    public ActionResult<ICollection<TodoEntryDto>> GetAllEntries()
    {
        var todoEntries = _todoEntryService.GetAllEntries();
        return Ok(todoEntries);
    }

    [HttpPost]
    public ActionResult<TodoEntryDto> SaveEntry([FromBody] TodoEntryDto todoEntryDto)
    {
        if (todoEntryDto.EntryId.HasValue && !todoEntryDto.EntryId.Value.Equals(Guid.Empty))
        {
            return Ok(_todoEntryService.UpdateEntry(todoEntryDto));
        }
        return Ok(_todoEntryService.CreateEntry(todoEntryDto));
    }

    [HttpDelete]
    public ActionResult<TodoEntryDto> DeleteEntry(Guid entryId)
    {
        return Ok(_todoEntryService.DeleteEntry(entryId));
    }
}