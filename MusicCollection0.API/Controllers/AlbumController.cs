using Microsoft.AspNetCore.Mvc;
using MusicCollection.Models;
using MusicCollection.Data;

namespace Core_Task_SoftServe.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AlbumController : ControllerBase
    {
        private MusicCollectionContext ctx;


        public AlbumController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Albums.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Albums.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Album model)
        {
            ctx.Albums.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Album model)
        {
            ctx.Albums.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Albums.Find(id);
            if (item == null) return NotFound();
            ctx.Albums.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}
