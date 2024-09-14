namespace ExpenseCase.Common.Dto;

public class ExceptionDto
{
        
    public ExceptionDto()
    {
    }
        
    public ExceptionDto(string message, params object[] parameters)
    {
        Message = message;
        Parameters = parameters;
    }
    public string Message { get; set; }
    public object[] Parameters { get; set; }
}