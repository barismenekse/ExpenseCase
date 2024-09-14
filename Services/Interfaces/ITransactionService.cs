using ExpenseCase.Common.Dto;

namespace ExpenseCase.Services.Interfaces;

public interface ITransactionService
{
    TransactionDto AddTransaction(AddTransactionDto transactionDto, int userId);
    IEnumerable<TransactionDto> GetTransactions(int userId, DateTime startDate, DateTime endDate);
}