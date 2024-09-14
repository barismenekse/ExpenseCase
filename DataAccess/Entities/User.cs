namespace ExpenseCase.DataAccess.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
