using ExpenseCase.Common.Dto;
using ExpenseCase.Common.Dto.Report;
using ExpenseCase.Extensions;
using ExpenseCase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseCase.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private readonly  IReportService _reportService;
    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    [HttpGet]
    [Route("GetPeriodReport")]
    public ActionResult<PeriodReportDto> GetPeriodReport(DateTime startDate, DateTime endDate)
    {
        var report = _reportService.GeneratePeriodReport(User.GetUserId(), startDate, endDate);
        return Ok(report);
    }
    
    [HttpGet]
    [Route("GetMonthlyReport")]
    public ActionResult<MonthlyReportDto> GetMonthlyReport(int year, int month)
    {
        var report = _reportService.GenerateMonthlyReport(User.GetUserId(), year, month);
        return Ok(report);
    }
    
    [HttpGet]
    [Route("GetCategoryReport")]
    public ActionResult<CategoryReportDto> GetCategoryReport()
    {
        var report = _reportService.GenerateCategoryReport(User.GetUserId());
        return Ok(report);
    }
    
    [HttpGet]
    [Route("PredictCurrentMonthExpenses")]
    public ActionResult<PredictionReportDto> PredictNextMonthExpenses()
    {
        var report = _reportService.PredictCurrentMonthExpenses(User.GetUserId());
        return Ok(report);
    }
}