using Microsoft.AspNetCore.Mvc;
using MusicCollection.Models;
using MusicCollection.Data;


namespace Core_Task_SoftServe.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ArtistController : ControllerBase
    {
        private MusicCollectionContext ctx;


        public ArtistController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Artists.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Artists.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Artist model)
        {
            ctx.Artists.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Artist model)
        {
            ctx.Artists.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Artists.Find(id);
            if (item == null) return NotFound();
            ctx.Artists.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}

