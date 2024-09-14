using ExpenseCase.Common.Dto;

namespace ExpenseCase.Services.Interfaces;

public interface IUserService
{
    bool Register(RegisterRequestDto registerRequestDto);
    string Login(LoginRequestDto loginRequestDto);
    UserDto GetMyInfo(int userId);
}