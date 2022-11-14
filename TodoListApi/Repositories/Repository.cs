using TodoListApi.Data;
using TodoListApi.Data.Models;

namespace TodoListApi.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public TEntity? CreateEntity(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
        return _dbContext.Set<TEntity>().Find(entity.Id);
    }

    public TEntity? DeleteEntity(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public IEnumerable<TEntity> GetAllEntities()
    {
        return _dbContext.Set<TEntity>();
    }

    public TEntity? GetEntityById(Guid id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> Where(Func<TEntity, bool> predicate)
    {
        return _dbContext.Set<TEntity>().Where<TEntity>(predicate);
    }
}