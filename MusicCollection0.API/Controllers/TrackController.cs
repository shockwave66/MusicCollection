using Microsoft.AspNetCore.Mvc;
using MusicCollection.Data;
using MusicCollection.Models;

[Route("api/[controller]")]
[ApiController]
public class TrackController : ControllerBase
{
    private MusicCollectionContext ctx = new();

    [HttpGet("")]
    public IActionResult GetAll() => Ok(ctx.Tracks.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var item = ctx.Tracks.Find(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(Track model)
    {
        ctx.Tracks.Add(model);
        ctx.SaveChanges();
        return Created();
    }

    [HttpPut]
    public IActionResult Edit(Track model)
    {
        ctx.Tracks.Update(model);
        ctx.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var item = ctx.Tracks.Find(id);
        if (item == null) return NotFound();
        ctx.Tracks.Remove(item);
        ctx.SaveChanges();
        return NoContent();
    }
}
