namespace ExpenseCase.Common.Dto.Report;

public class PredictionReportDto
{
    public List<CategoryPredictionDto> CategoryPredictions { get; set; }
}

public class CategoryPredictionDto
{
    public string CategoryName { get; set; }
    public decimal PredictedAmount { get; set; }
}