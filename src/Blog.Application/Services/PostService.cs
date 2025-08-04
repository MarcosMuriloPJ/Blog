using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;

namespace Blog.Application.Services;

public class PostService(IPostRepository postRepository, INotificationSender notificationSender)
{
  private readonly IPostRepository _postRepository = postRepository;
  private readonly INotificationSender _notificationSender = notificationSender;

  public async Task<IEnumerable<Post>> GetAllAsync() => await _postRepository.GetAllAsync();

  public async Task CreateAsync(string title, string content, Guid userId)
  {
    var post = new Post
    {
      Id = Guid.NewGuid(),
      Title = title,
      Content = content,
      CreatedAt = DateTime.UtcNow,
      UserId = userId
    };
    await _postRepository.AddAsync(post);
    await _notificationSender.SendAsync(post);
  }

  public async Task UpdateAsync(Guid id, string title, string content)
  {
    var post = await _postRepository.GetByIdAsync(id);
    if (post == null) return;
    post.Title = title;
    post.Content = content;
    await _postRepository.UpdateAsync(post);
  }

  public async Task DeleteAsync(Guid id) => await _postRepository.DeleteAsync(id);
}