using System.Linq.Expressions;
using ExpenseCase.Context;
using ExpenseCase.DataAccess.Entities;
using ExpenseCase.DataAccess.Repositories.Abstracts;
using ExpenseCase.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseCase.DataAccess.Repositories;

public class TransactionRepository : EfRepositoryBase<Transaction>, ITransactionRepository
{
    public TransactionRepository(MyDbContext context) : base(context)
    {
    }
    public IEnumerable<Transaction> GetWithIncludes(Expression<Func<Transaction, bool>> filter)
    {
        return DbSet
            .Include(t => t.Account).ThenInclude(a => a.User)
            .Include(t => t.Category)
            .Where(filter)
            .ToList();
    }
}