public class TodoEntryDto
{
    public Guid? EntryId { get; set; }
    public string Name { get; set; }
    public bool Done { get; set; }

    public TodoEntryDto(Guid? entryId, string name, bool done)
    {
        EntryId = entryId;
        Name = name;
        Done = done;
    }
}