public class TodoEntryService : ITodoEntryService
{
    public TodoEntryDto? GetEntryById(Guid entryId)
    {
        return new TodoEntry(null, "Essen kochen", false).AsDto();
    }
}