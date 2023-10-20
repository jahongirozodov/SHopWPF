using ForJob.Domain.Common;
using ForJob.Domain.Users;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace FotJob.Data.IRepository;

public interface IRepository<T> where T : Auditable
{
    Task AddAsync(T entity);
    void Modify(T entity);
    void Delete(T entity);
    void Destroy(T entity);
    Task<T> GetAsync(Expression<Func<T,bool>> expression, string[] includes = null);
    IEnumerable<T> GetAll(Expression<Func<T,bool>> expression = null, bool IsNoTracking = true, string[] includes = null);
    Task SaveAsync();
}
