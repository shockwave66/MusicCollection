using Microsoft.AspNetCore.Mvc;
using MusicCollection.Data;
using MusicCollection.Models;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private MusicCollectionContext ctx = new();

    [HttpGet("")]
    public IActionResult GetAll() => Ok(ctx.Reviews.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var item = ctx.Reviews.Find(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(Review model)
    {
        ctx.Reviews.Add(model);
        ctx.SaveChanges();
        return Created();
    }

    [HttpPut]
    public IActionResult Edit(Review model)
    {
        ctx.Reviews.Update(model);
        ctx.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var item = ctx.Reviews.Find(id);
        if (item == null) return NotFound();
        ctx.Reviews.Remove(item);
        ctx.SaveChanges();
        return NoContent();
    }
}
