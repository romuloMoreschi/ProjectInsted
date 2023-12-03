using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : Base
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task Remove(long id);
    Task<T> GetById(long id);
    Task<long> TotalRecords();
    Task<List<T>> GetAll(int skip, int take, Func<IQueryable<T>, IQueryable<T>>? includeFunc = null);
}