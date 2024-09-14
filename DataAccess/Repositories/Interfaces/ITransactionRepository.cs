using System.Linq.Expressions;
using ExpenseCase.DataAccess.Entities;

namespace ExpenseCase.DataAccess.Repositories.Interfaces;

public interface ITransactionRepository : IRepository<Transaction>
{
    IEnumerable<Transaction> GetWithIncludes(Expression<Func<Transaction, bool>> filter);
}