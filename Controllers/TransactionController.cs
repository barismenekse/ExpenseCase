using ExpenseCase.Common.Dto;
using ExpenseCase.Extensions;
using ExpenseCase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseCase.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly  ITransactionService _transactionService;
    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    
    [HttpGet]
    [Route("GetMyTransactions")]
    public IEnumerable<TransactionDto> GetMyTransactions(DateTime startDate, DateTime endDate)
    {
        return _transactionService.GetTransactions(User.GetUserId(), startDate, endDate);
    }
    
    [HttpPost]
    [Route("AddTransaction")]
    public ActionResult<TransactionDto> AddTransaction([FromBody] AddTransactionDto transactionDto)
    {
        var transaction = _transactionService.AddTransaction(transactionDto, User.GetUserId());
        return Ok(transaction);
    }
}