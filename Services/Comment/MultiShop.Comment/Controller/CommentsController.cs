using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controller;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(CommentContext context) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await context.UserComments.ToListAsync());
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] UserComment item)
    {
        await context.UserComments.AddAsync(item);
        await context.SaveChangesAsync();
        return Ok("Comment created");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UserComment item)
    {
        context.UserComments.Update(item);
        await context.SaveChangesAsync();
        return Ok("Comment updated");
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        context.UserComments.Remove(await context.UserComments.FindAsync(id) ??
                                    throw new InvalidOperationException("UserComment not found"));
        await context.SaveChangesAsync();
        return Ok("Comment deleted");
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await context.UserComments.FirstOrDefaultAsync(x => x.Id == id));
    }

    [HttpGet("GetAllByProductId/{id}")]
    public async Task<IActionResult> GetAllByProductId(string id)
    {
        return Ok(await context.UserComments.Where(x => x.ProductId == id).ToListAsync());
    }
}