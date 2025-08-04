using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class PostRepository(BlogDbContext context) : IPostRepository
{
  private readonly BlogDbContext _context = context;

  public async Task<IEnumerable<Post>> GetAllAsync() => await _context.Posts.Include(p => p.Author).ToListAsync();

  public async Task<Post?> GetByIdAsync(Guid id) => await _context.Posts.FindAsync(id);

  public async Task AddAsync(Post post)
  {
    _context.Posts.Add(post);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAsync(Post post)
  {
    _context.Posts.Update(post);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(Guid id)
  {
    var post = await _context.Posts.FindAsync(id);
    if (post != null)
    {
      _context.Posts.Remove(post);
      await _context.SaveChangesAsync();
    }
  }
}
