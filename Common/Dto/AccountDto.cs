using Newtonsoft.Json;

namespace ExpenseCase.Common.Dto;

public class AccountDto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; }

    public decimal Balance { get; set; }

    public DateTime CreatedDate { get; set; }

    [JsonIgnore]
    public ICollection<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
    
}