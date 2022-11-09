using Microsoft.AspNetCore.Mvc;

[Route("[Controller]/[Action]")]
public class TodoController : Controller
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
}