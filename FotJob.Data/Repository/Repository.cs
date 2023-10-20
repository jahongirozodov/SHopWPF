using ForJob.Domain.Common;
using FotJob.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FotJob.Data.Repository;

public class Repository<T> : IRepository.IRepository<T> where T : Auditable
{
    private readonly DbSet<T> dbset;
    private readonly AppDbContext dbContext;

    public Repository()
    {
        this.dbContext = new AppDbContext();
        this.dbset = dbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
        => await dbset.AddAsync(entity);

    public void Modify(T entity)
        => this.dbset.Entry(entity).State = EntityState.Modified;
    public void Delete(T entity)
        => entity.IsDeleted = true;

    public void Destroy(T entity)
        => this.dbset.Remove(entity);

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null, bool IsNoTracked = true, string[] includes = null)
    {
        IQueryable<T> query = expression is null ? this.dbset.AsQueryable() : this.dbset.Where(expression);

        query = IsNoTracked ? query.AsNoTracking() : query;

        if (includes is not null)
            foreach (string include in includes)
                query.Include(include);

        return query;
    }
    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        IQueryable<T> query = this.dbset.Where(expression);

        if (includes is not null)
            foreach (string include in includes)
                query.Include(include);

        var result = await query.FirstOrDefaultAsync(expression);
        return result;
    }

    public async Task SaveAsync()
        => await dbContext.SaveChangesAsync();
}
