namespace ExpenseCase.Common.Dto;

public class TransactionDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public CategoryDto Category { get; set; }
    public AccountDto Account { get; set; }
}