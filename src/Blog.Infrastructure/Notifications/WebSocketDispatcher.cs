using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Blog.Infrastructure.Notifications;

public class WebSocketDispatcher : IWebSocketDispatcher
{
  private readonly List<WebSocket> _sockets = [];

  public async Task HandleConnectionAsync(HttpContext context)
  {
    if (context.WebSockets.IsWebSocketRequest)
    {
      var socket = await context.WebSockets.AcceptWebSocketAsync();
      _sockets.Add(socket);
      var buffer = new byte[1024 * 4];
      while (socket.State == WebSocketState.Open)
      {
        var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        if (result.MessageType == WebSocketMessageType.Close)
        {
          _sockets.Remove(socket);
          await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close", CancellationToken.None);
        }
      }
    }
  }

  public async Task BroadcastAsync(string message)
  {
    var bytes = Encoding.UTF8.GetBytes(message);
    var buffer = new ArraySegment<byte>(bytes);
    foreach (var socket in _sockets.Where(s => s.State == WebSocketState.Open))
    {
      await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
    }
  }
}
