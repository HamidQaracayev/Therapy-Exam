using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Therapy.Core.Models;

namespace Therapy.Core.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity,new()
{
    public DbSet<T> Table { get; }
    Task CreateAsync(T entity);
    void DeleteAsync(T entity);

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);
    Task<T> GetAsync(Expression<Func<T, bool>>? expression = null, params string[]? includes);
}
