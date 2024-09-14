namespace ExpenseCase.DataAccess.Entities;

public partial class Transaction
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public int CategoryId { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public virtual Account Account { get; set; }

    public virtual Category Category { get; set; }
}
