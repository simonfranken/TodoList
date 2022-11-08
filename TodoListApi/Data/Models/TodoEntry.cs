public class TodoEntry
{
    public Guid EntryId { get; set; }

    public string Name { get; set; }
    public bool Done { get; set; }

    public TodoEntry(string name)
    {
        Name = name;
    }
}