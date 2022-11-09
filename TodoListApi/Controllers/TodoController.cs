using Microsoft.AspNetCore.Mvc;
using TodoListApi.Data.DTOs;
using TodoListApi.Services;

namespace TodoListApi.Controllers;
[Route("[Controller]/[Action]")]
public class TodoController : ControllerBase
{
    private readonly ITodoEntryService _todoEntryService;

    public TodoController(ITodoEntryService todoEntryService)
    {
        _todoEntryService = todoEntryService;
    }

    [HttpGet]
    public ActionResult<TodoEntryDto> GetEntryById(Guid entryId)
    {
        var todoEntry = _todoEntryService.GetEntryById(entryId);
        return todoEntry != null ? Ok(todoEntry) : NotFound();
    }

    [HttpGet]
    public ActionResult<ICollection<TodoEntryDto>> GetAllEntries()
    {
        var todoEntries = _todoEntryService.GetAllEntries();
        return Ok(todoEntries);
    }
}