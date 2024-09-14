using ExpenseCase.Common.Dto;
using ExpenseCase.Common.Dto.Report;

namespace ExpenseCase.Services.Interfaces;

public interface IReportService
{
    PeriodReportDto GeneratePeriodReport(int userId, DateTime startDate, DateTime endDate);
    MonthlyReportDto GenerateMonthlyReport(int userId, int year, int month);
    CategoryReportDto GenerateCategoryReport(int userId);
    PredictionReportDto PredictCurrentMonthExpenses(int userId);
}