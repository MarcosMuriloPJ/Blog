namespace Blog.Domain.Entities;

public class User
{
  public Guid Id { get; set; }
  public string Username { get; set; } = null!;
  public string PasswordHash { get; set; } = null!;
  public ICollection<Post> Posts { get; set; } = [];
}
