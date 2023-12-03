using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : Base
{
    private readonly PlantaoFacilContext _context;

    public GenericRepository(PlantaoFacilContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task Remove(long id)
    {
        var obj = await _context.Set<T>()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    public virtual async Task<T> GetById(long id)
    {
        return (await _context.Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync())!;
    }

    public virtual async Task<List<T>> GetAll(int skip, int take, Func<IQueryable<T>, IQueryable<T>>? includeFunc = null)
    {
        var query = _context.Set<T>().AsNoTracking();

        if (includeFunc is not null)
            query = includeFunc(query);

        return await query
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<long> TotalRecords()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .CountAsync();
    }
}