using ExpenseCase.Common.Dto;
using ExpenseCase.Extensions;
using ExpenseCase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseCase.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost]
    [Route("CreateAccount")]
    public IResult CreateAccount(CreateAccountDto accountDto)
    {
        return Results.Ok(_accountService.CreateAccount(accountDto));
    }
    
    [HttpGet]
    [Route("GetMyAccounts")]
    public IEnumerable<AccountDto> GetMyAccounts()
    {
        return _accountService.GetAccounts(User.GetUserId());
    }
}