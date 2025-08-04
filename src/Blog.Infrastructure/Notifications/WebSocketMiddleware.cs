using Microsoft.AspNetCore.Http;

namespace Blog.Infrastructure.Notifications;

public class WebSocketMiddleware(RequestDelegate next, IWebSocketDispatcher dispatcher)
{
  public async Task InvokeAsync(HttpContext context)
  {
    if (context.Request.Path == "/ws")
    {
      await dispatcher.HandleConnectionAsync(context);
    }
    else
    {
      await next(context);
    }
  }
}
