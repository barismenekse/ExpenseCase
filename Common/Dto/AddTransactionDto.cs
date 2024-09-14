﻿namespace ExpenseCase.Common.Dto;

public class AddTransactionDto
{
    public int AccountId { get; set; }
    public int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}