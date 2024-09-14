using ExpenseCase.DataAccess.Repositories.Interfaces;

namespace ExpenseCase.DataAccess.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void Save();
    IUserRepository UserRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    IAccountRepository AccountRepository { get; }
}