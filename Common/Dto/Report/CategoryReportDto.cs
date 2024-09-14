namespace ExpenseCase.Common.Dto.Report;

public class CategoryReportDto
{
    public List<CategoryAmountDto> CategoryAmounts { get; set; }
}

public class CategoryAmountDto
{
    public string CategoryName { get; set; }
    public decimal TotalAmount { get; set; }
}