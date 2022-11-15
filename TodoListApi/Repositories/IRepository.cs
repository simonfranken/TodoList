using TodoListApi.Data.Models;

namespace TodoListApi.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Get an IEnumerable of all entities
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> GetAllEntities();

    /// <summary>
    /// GEt an entity by its id
    /// </summary>
    /// <param name="id">the id of the requested entity</param>
    /// <returns></returns>
    public T? GetEntityById(Guid id);

    /// <summary>
    /// Create an entity in the database
    /// </summary>
    /// <param name="entity">the datamodel from which the entity is to be created</param>
    /// <returns></returns>
    public T? CreateEntity(T entity);

    /// <summary>
    /// Delete an entity
    /// </summary>
    /// <param name="entity">the id of the entity that is to be deleted</param>
    /// <returns></returns>
    public T? DeleteEntity(T entity);

    /// <summary>
    /// Get an IEnumerable of all entities matching the given expression
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<T> Where(Func<T, bool> predicate);
}