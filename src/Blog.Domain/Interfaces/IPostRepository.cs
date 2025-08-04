using Blog.Domain.Entities;

namespace Blog.Domain.Interfaces;

public interface IPostRepository
{
  Task<IEnumerable<Post>> GetAllAsync();
  Task<Post?> GetByIdAsync(Guid id);
  Task AddAsync(Post post);
  Task UpdateAsync(Post post);
  Task DeleteAsync(Guid id);
}
