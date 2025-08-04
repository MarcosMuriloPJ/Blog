using Microsoft.AspNetCore.Http;

namespace Blog.Infrastructure.Notifications;

public interface IWebSocketDispatcher
{
  Task HandleConnectionAsync(HttpContext context);
  Task BroadcastAsync(string message);
}
