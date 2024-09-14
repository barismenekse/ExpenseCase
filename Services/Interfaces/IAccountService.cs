using ExpenseCase.Common.Dto;

namespace ExpenseCase.Services.Interfaces;

public interface IAccountService
{
    AccountDto CreateAccount(CreateAccountDto accountDto);
    IEnumerable<AccountDto> GetAccounts(int userId);
}