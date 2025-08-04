namespace Blog.Domain.Entities;

public class Post
{
  public Guid Id { get; set; }
  public string Title { get; set; } = null!;
  public string Content { get; set; } = null!;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public Guid UserId { get; set; }
  public User Author { get; set; } = null!;
}