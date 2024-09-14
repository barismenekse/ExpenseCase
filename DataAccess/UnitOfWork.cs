using ExpenseCase.DataAccess.Context;
using ExpenseCase.DataAccess.Interfaces;
using ExpenseCase.DataAccess.Repositories;
namespace ExpenseCase.DataAccess;

using Microsoft.EntityFrameworkCore;
using ExpenseCase.DataAccess.Repositories.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _context;
    private bool _disposed = false;

    public UnitOfWork(MyDbContext context, IUserRepository userRepository, ITransactionRepository transactionRepository, IAccountRepository accountRepository)
    {
        _context = context;
        UserRepository = userRepository;
        TransactionRepository = transactionRepository;
        AccountRepository = accountRepository;
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }

    public IUserRepository UserRepository { get; }

    public ITransactionRepository TransactionRepository { get; }

    public IAccountRepository AccountRepository { get; }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}