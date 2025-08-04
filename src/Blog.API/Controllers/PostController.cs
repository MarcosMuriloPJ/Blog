using Blog.Application.DTOs;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController(PostService postService) : ControllerBase
{
  private readonly PostService _postService = postService;

  [HttpGet]
  public async Task<IActionResult> GetAll() => Ok(await _postService.GetAllAsync());

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] PostCreateDto dto)
  {
    await _postService.CreateAsync(dto.Title, dto.Content, dto.UserId);
    return Ok();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(Guid id, [FromBody] PostUpdateDto dto)
  {
    await _postService.UpdateAsync(id, dto.Title, dto.Content);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await _postService.DeleteAsync(id);
    return Ok();
  }
}