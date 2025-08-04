using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Infrastructure.Notifications;

public class WebSocketNotificationSender(IWebSocketDispatcher dispatcher) : INotificationSender
{
  private readonly IWebSocketDispatcher _dispatcher = dispatcher;

  public async Task SendAsync(Post post)
  {
    await _dispatcher.BroadcastAsync($"Nova postagem: {post.Title}");
  }
}
