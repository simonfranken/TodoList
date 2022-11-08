using Microsoft.AspNetCore.Mvc;

public class TodoController : Controller
{
    public TodoController()
    {

    }

    [HttpGet]
    public IActionResult GetEntryById(Guid entryID)
    {
        return NotFound();
    }
}