namespace ExpenseCase.Common.Dto;

public class UserDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Email { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<AccountDto> Accounts { get; set; } = new List<AccountDto>();
}