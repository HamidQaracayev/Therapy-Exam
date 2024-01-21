using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Therapy.Core.Models;
using Therapy.Core.Repositories.Interfaces;
using Therapy.Data.DAL;

namespace Therapy.Data.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void DeleteAsync(T entity)
    {
        Table.Remove(entity);
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
    {
        var query = Table.AsQueryable();
        if(includes is not null)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }
        return expression is not null ? await query.Where(expression).ToListAsync() : await query.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
    {
        var query = Table.AsQueryable();
        if (includes is not null)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }
        return expression is not null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
    }
}
