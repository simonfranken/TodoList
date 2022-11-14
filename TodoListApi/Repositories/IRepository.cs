using TodoListApi.Data.Models;

namespace TodoListApi.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    public IEnumerable<T> GetAllEntities();
    public T? GetEntityById(Guid id);
    public T? CreateEntity(T entity);
    public T? DeleteEntity(T entity);
    public IEnumerable<T> Where(Func<T, bool> predicate);
}