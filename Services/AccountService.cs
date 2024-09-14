using AutoMapper;
using ExpenseCase.Common.Dto;
using ExpenseCase.DataAccess.Entities;
using ExpenseCase.DataAccess.Interfaces;
using ExpenseCase.DataAccess.Repositories.Interfaces;
using ExpenseCase.Services.Interfaces;

namespace ExpenseCase.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;
    public AccountService(IUnitOfWork db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public AccountDto CreateAccount(CreateAccountDto accountDto)
    {
        var account = new Account
        {
            Name = accountDto.Name,
            UserId = accountDto.UserId,
            CreatedDate = DateTime.Now,
            Balance = 0
        };

        _db.AccountRepository.Insert(account);
        _db.Save();
        return _mapper.Map<AccountDto>(_db.AccountRepository.GetById(account.Id));
    }
    public IEnumerable<AccountDto> GetAccounts(int userId)
    {
        var accounts = _db.AccountRepository.Get(a => a.UserId == userId);
        return _mapper.Map<IEnumerable<AccountDto>>(accounts);
    }
}