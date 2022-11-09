using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Data.Models;

public class TodoEntry
{
    [Key]
    public Guid EntryId { get; set; }

    public string Name { get; set; }
    public bool Done { get; set; }

    public TodoEntry()
    {

    }

    public TodoEntry(Guid? entryId, string name, bool done)
    {
        EntryId = entryId.HasValue ? entryId.Value : Guid.NewGuid();
        Name = name;
        Done = done;
    }
}