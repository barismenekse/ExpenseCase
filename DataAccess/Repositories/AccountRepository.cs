using System.Linq.Expressions;
using ExpenseCase.Context;
using ExpenseCase.DataAccess.Entities;
using ExpenseCase.DataAccess.Repositories.Abstracts;
using ExpenseCase.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseCase.DataAccess.Repositories;

public class AccountRepository : EfRepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(MyDbContext context) : base(context)
    {
    }
    public IEnumerable<Account> GetWithIncludes(Expression<Func<Account, bool>> filter)
    {
        return DbSet
            .Include(a => a.User)
            .Include(a => a.Transactions).ThenInclude(t => t.Category)
            .Where(filter)
            .ToList();
    }
}