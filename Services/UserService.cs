using System.Security.Authentication;
using AutoMapper;
using ExpenseCase.Common.Dto;
using ExpenseCase.DataAccess.Entities;
using ExpenseCase.DataAccess.Interfaces;
using ExpenseCase.Infrastructure.Exceptions;
using ExpenseCase.Infrastructure.Services.Interfaces;
using ExpenseCase.Services.Interfaces;

namespace ExpenseCase.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _db;
    private readonly IJwtService _jwtService;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        _mapper = mapper;
        _db = unitOfWork;
        _jwtService = jwtService;
    }

    public bool Register(RegisterRequestDto registerRequestDto)
    {
        var user = _mapper.Map<User>(registerRequestDto);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequestDto.Password);
        _db.UserRepository.Insert(user);
        _db.Save();
        return true;
    }

    public string Login(LoginRequestDto loginRequestDto)
    {
        var user = _db.UserRepository.Get(u => u.Name == loginRequestDto.Name).FirstOrDefault();
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.PasswordHash))
        {
            throw new UnauthorizedException("InvalidLoginRequest");
        }

        var token = _jwtService.GenerateToken(user.Id.ToString(), user.Email, user.Name);
        return token;
    }

    public UserDto GetMyInfo(int userId)
    {
        return _mapper.Map<UserDto>(_db.UserRepository.GetById(userId));
    }
}