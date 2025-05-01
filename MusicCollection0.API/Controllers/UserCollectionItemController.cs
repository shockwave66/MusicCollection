using Microsoft.AspNetCore.Mvc;
using MusicCollection.Data;
using MusicCollection.Models;

[Route("api/[controller]")]
[ApiController]
public class UserCollectionItemController : ControllerBase
{
    private MusicCollectionContext ctx = new();

    [HttpGet("")]
    public IActionResult GetAll() => Ok(ctx.UserCollectionItems.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var item = ctx.UserCollectionItems.Find(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(UserCollectionItem model)
    {
        ctx.UserCollectionItems.Add(model);
        ctx.SaveChanges();
        return Created();
    }

    [HttpPut]
    public IActionResult Edit(UserCollectionItem model)
    {
        ctx.UserCollectionItems.Update(model);
        ctx.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var item = ctx.UserCollectionItems.Find(id);
        if (item == null) return NotFound();
        ctx.UserCollectionItems.Remove(item);
        ctx.SaveChanges();
        return NoContent();
    }
}
