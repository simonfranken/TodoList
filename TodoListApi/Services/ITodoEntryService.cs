using TodoListApi.Data.DTOs;

namespace TodoListApi.Services;

public interface ITodoEntryService
{
    /// <summary>
    /// Get the DTO of a TodoEntry by its id
    /// </summary>
    /// <param name="entryId">the id of the requested TodoEntry</param>
    /// <returns>the DTO of the requested TodoEntry</returns>
    public TodoEntryDto GetEntryById(Guid id);

    /// <summary>
    /// Get the DTO of all TodoEntries
    /// </summary>
    /// <returns>an ICollection of DTOs</returns>
    public ICollection<TodoEntryDto> GetAllEntries();

    /// <summary>
    /// Update an existing TodoEntry by a DTO
    /// </summary>
    /// <param name="entryDto">the DTO from which the TodoEntry should be updated</param>
    /// <returns>the DTO of the updated TodoEntry</returns>
    public TodoEntryDto CreateOrUpdateEntry(TodoEntryDto entryDto);

    /// <summary>
    /// Delete a TodoEntry by its id
    /// </summary>
    /// <param name="entryId">th id of the TodoEntry</param>
    /// <returns>the DTO of the deleted TodoEntry</returns>
    public TodoEntryDto DeleteEntry(Guid entryId);
}