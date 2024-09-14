using System.Linq.Expressions;

namespace ExpenseCase.DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    IEnumerable<T> Get(Expression<Func<T, bool>> filter);
    T GetById(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
}