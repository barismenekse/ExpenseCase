using System.Net;
using ExpenseCase.Common.Dto;
using ExpenseCase.Extensions;
using ExpenseCase.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseCase.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly  IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("Register")]
    [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
    [AllowAnonymous]
    public IResult Register(RegisterRequestDto request)
    {
        return Results.Ok(_userService.Register(request));
    }
    
    [HttpPost("Login")]
    [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
    [AllowAnonymous]
    public IResult Login(LoginRequestDto request)
    {
        return Results.Ok(_userService.Login(request));
    }
    
    [HttpGet("MyInfo")]
    [ProducesResponseType(typeof(IResult), (int)HttpStatusCode.OK)]
    public IResult GetMyInfo()
    {
        return Results.Ok(_userService.GetMyInfo(User.GetUserId()));
    }
}