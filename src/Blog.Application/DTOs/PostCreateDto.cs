namespace Blog.Application.DTOs;

public class PostCreateDto
{
  public string Title { get; set; } = null!;
  public string Content { get; set; } = null!;
  public Guid UserId { get; set; }
}