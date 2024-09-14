﻿namespace ExpenseCase.Common.Dto.Report;

public class MonthlyReportDto
{
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Income { get; set; }
    public decimal Expense { get; set; }
}