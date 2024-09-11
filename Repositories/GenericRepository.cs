using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
{
    protected AppDbContext Context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();

    public async ValueTask<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsQueryable().AsNoTracking();

    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }



}
