using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Data.Models;

public class TodoEntry : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }

    public TodoEntry() { }

    public TodoEntry(Guid? entryId, string name, string description, bool done)
    {
        Id = entryId.HasValue ? entryId.Value : Guid.NewGuid();
        Name = name;
        Done = done;
        Description = description;
    }
}