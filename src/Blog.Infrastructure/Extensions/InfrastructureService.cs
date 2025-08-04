using Blog.Application.Interfaces;
using Blog.Application.Services;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Notifications;
using Blog.Infrastructure.Repositories;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.Extensions;

public static class InfrastructureService
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
  {
    services.AddDbContext<BlogDbContext>(options =>
    {
      options.UseSqlServer(config.GetConnectionString("Blog"),
          o => o.EnableRetryOnFailure(
          maxRetryCount: 5,
          maxRetryDelay: TimeSpan.FromSeconds(30),
          errorNumbersToAdd: null));

      options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

    services.AddSingleton<IWebSocketDispatcher, WebSocketDispatcher>();
    services.AddScoped<INotificationSender, WebSocketNotificationSender>();
    services.AddScoped<UserService>();
    services.AddScoped<PostService>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IPostRepository, PostRepository>();

    return services;
  }
}
