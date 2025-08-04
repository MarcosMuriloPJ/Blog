using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class UserRepository(BlogDbContext context) : IUserRepository
{
  private readonly BlogDbContext _context = context;

  public async Task<User?> GetByUsernameAsync(string username) => await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

  public async Task AddAsync(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
  }
}