using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface INotificationSender
{
  Task SendAsync(Post post);
}