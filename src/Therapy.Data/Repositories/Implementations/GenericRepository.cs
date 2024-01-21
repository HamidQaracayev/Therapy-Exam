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
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes)
    {
        throw new NotImplementedException();
    }
}
