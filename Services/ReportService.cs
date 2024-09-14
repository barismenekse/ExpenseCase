using AutoMapper;
using ExpenseCase.Common.Dto;
using ExpenseCase.Common.Dto.Report;
using ExpenseCase.DataAccess.Interfaces;
using ExpenseCase.Services.Interfaces;

namespace ExpenseCase.Services;

public class ReportService : IReportService
{
    private readonly IUnitOfWork _db;
    private readonly IMapper _mapper;
    public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _db = unitOfWork;
        _mapper = mapper;
    }
    
    public PeriodReportDto GeneratePeriodReport(int userId, DateTime startDate, DateTime endDate)
    {
        var transactions = _db.TransactionRepository.GetWithIncludes(t =>
            t.Date >= startDate && t.Date <= endDate && t.Account.UserId == userId);

        var totalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
        var totalExpense = transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);

        return new PeriodReportDto
        {
            StartDate = startDate,
            EndDate = endDate,
            TotalIncome = totalIncome,
            TotalExpense = totalExpense
        };
    }
    public MonthlyReportDto GenerateMonthlyReport(int userId, int year, int month)
    {
        var transactions = _db.TransactionRepository.GetWithIncludes(t =>
            t.Date.Year == year && t.Date.Month == month && t.Account.UserId == userId);

        var income = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
        var expense = transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);

        return new MonthlyReportDto
        {
            Month = month,
            Year = year,
            Income = income,
            Expense = expense
        };
    }

    public CategoryReportDto GenerateCategoryReport(int userId)
    {
        var transactions = _db.TransactionRepository.GetWithIncludes(t => t.Account.UserId == userId);

        var categoryAmounts = transactions
            .Where(t => t.Amount < 0)
            .GroupBy(t => t.Category.Name)
            .Select(g => new CategoryAmountDto
            {
                CategoryName = g.Key,
                TotalAmount = g.Sum(t => t.Amount)
            })
            .OrderByDescending(ca => ca.TotalAmount)
            .ToList();

        return new CategoryReportDto
        {
            CategoryAmounts = categoryAmounts
        };
    }

    public PredictionReportDto PredictCurrentMonthExpenses(int userId)
    {
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year;

        var transactions = _db.TransactionRepository.GetWithIncludes(t =>
            t.Account.UserId == userId &&
            !(t.Date.Year == currentYear && t.Date.Month == currentMonth));

        var monthlyCategorySums = transactions
            .Where(t => t.Amount < 0)
            .GroupBy(t => new { t.Date.Year, t.Date.Month, t.Category.Id, t.Category.Name })
            .Select(g => new
            {
                g.Key.Name,
                g.Key.Id,
                YearMonth = new DateTime(g.Key.Year, g.Key.Month, 1),
                TotalAmount = g.Sum(t => t.Amount)
            })
            .GroupBy(x => new { x.Id, x.Name })
            .Select(g => new
            {
                g.Key.Name,
                AverageAmount = g.Average(x => x.TotalAmount)
            })
            .ToList();

        var categoryPredictions = monthlyCategorySums
            .Select(x => new CategoryPredictionDto
            {
                CategoryName = x.Name,
                PredictedAmount = x.AverageAmount
            })
            .ToList();

        return new PredictionReportDto
        {
            CategoryPredictions = categoryPredictions
        };
    }
}