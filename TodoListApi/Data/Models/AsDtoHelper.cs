public static class AsDtoHelper
{
    public static TodoEntryDto AsDto(this TodoEntry todoEntry)
    {
        return new TodoEntryDto(todoEntry.EntryId, todoEntry.Name, todoEntry.Done);
    }
}