namespace ExpenseCase.DataAccess.Entities;

public class Account
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; }

    public decimal Balance { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; }
}
