using System.Linq.Expressions;
using ExpenseCase.Context;
using Microsoft.EntityFrameworkCore;
using ExpenseCase.DataAccess.Repositories.Interfaces;

namespace ExpenseCase.DataAccess.Repositories.Abstracts;

public class EfRepositoryBase<T> : IRepository<T> where T : class
{
    protected MyDbContext Context { get; }
    protected DbSet<T> DbSet;

    public EfRepositoryBase(MyDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return DbSet.ToList();
    }
    public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
    {
        return Context.Set<T>().Where(filter).ToList();
    }
    public T GetById(int id)
    {
        return DbSet.Find(id);
    }

    public void Insert(T entity)
    {
        DbSet.Add(entity);
    }

    public void Update(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public void Save()
    {
        Context.SaveChanges();
    }
}