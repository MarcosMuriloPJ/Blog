using Blog.Application.DTOs;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(UserService userService) : ControllerBase
{
  private readonly UserService _userService = userService;

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
  {
    await _userService.RegisterAsync(dto.Username, dto.Password);
    return Ok();
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
  {
    var user = await _userService.AuthenticateAsync(dto.Username, dto.Password);
    if (user == null) return Unauthorized();
    return Ok(new { user.Id, user.Username });
  }
}