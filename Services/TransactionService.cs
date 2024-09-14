using System.Transactions;
using AutoMapper;
using ExpenseCase.Common.Dto;
using ExpenseCase.DataAccess.Interfaces;
using ExpenseCase.Infrastructure.Exceptions;
using ExpenseCase.Services.Interfaces;
using Transaction = ExpenseCase.DataAccess.Entities.Transaction;

namespace ExpenseCase.Services;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;

    public TransactionService(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public TransactionDto AddTransaction(AddTransactionDto transactionDto, int userId)
    {
        try
        {
            using var scope = new TransactionScope();
            var account = _db.AccountRepository.GetById(transactionDto.AccountId);
            if (account == null)
            {
                throw new BadRequestException("AccountNotFound");
            }

            if (account.UserId != userId)
            {
                throw new ForbiddenException("AccountNotBelongToUser");
            }

            account.Balance += transactionDto.Amount;

            var transaction = _mapper.Map<Transaction>(transactionDto);
            _db.TransactionRepository.Insert(transaction);
            _db.Save();
            scope.Complete();
            return _mapper.Map<TransactionDto>(transaction);
        }
        catch (HttpException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new InternalServerErrorException("TransactionError", e);
        }
    }

    public IEnumerable<TransactionDto> GetTransactions(int userId, DateTime startDate, DateTime endDate)
    {
        var transactions = _db.TransactionRepository.GetWithIncludes(t =>
            t.Date >= startDate && t.Date <= endDate && t.Account.UserId == userId);
        return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
    }
}