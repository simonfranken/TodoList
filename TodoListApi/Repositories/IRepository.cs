namespace TodoListApi.Repositories;

public interface IRepository<T>
{
    public IEnumerable<T> GetAllEntities();
    public T? GetEntityById(Guid id);
    public T? UpdateEntity(T entity);
    public T? CreateEntity(T entity);
    public T? DeleteEntity(T entity);
    public IEnumerable<T> Where(Func<T, bool> predicate);
}