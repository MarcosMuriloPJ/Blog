using Blog.Domain.Entities;
using Blog.Domain.Interfaces;

namespace Blog.Application.Services;

public class UserService(IUserRepository userRepository)
{
  private readonly IUserRepository _userRepository = userRepository;

  public async Task RegisterAsync(string username, string password)
  {
    var user = new User
    {
      Id = Guid.NewGuid(),
      Username = username,
      PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
    };

    await _userRepository.AddAsync(user);
  }

  public async Task<User?> AuthenticateAsync(string username, string password)
  {
    var user = await _userRepository.GetByUsernameAsync(username);
    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
      return user;

    return null;
  }
}