using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NihongoMaster.Application.Interfaces;
using NihongoMaster.Infrastructure.Data;

namespace NihongoMaster.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{

    protected readonly ApplicationContext _context;
    internal DbSet<T> dbSet;
    public Repository(ApplicationContext context)
    {
        _context = context;
        this.dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity) => await dbSet.AddAsync(entity);

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await dbSet.AnyAsync(predicate);

    public Task DeleteAsync(T entity)
    {
        dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await dbSet.Where(predicate).ToListAsync();

    public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await dbSet.FindAsync(id);

    public Task UpdateAsync(T entity)
    {
        dbSet.Update(entity);
        return Task.CompletedTask;
    }
}
