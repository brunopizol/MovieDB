using Microsoft.AspNetCore.Mvc;
using MovieDB.Domain.Entities;
using MovieDB.Domain.Services;
using System.Collections.Generic;

[Route("api/actors")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly ActorService _actorService;

    public ActorController(ActorService actorService)
    {
        _actorService = actorService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Actor>> Get()
    {
        return _actorService.GetAllActors().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Actor> Get(int id)
    {
        var actor = _actorService.GetActorById(id);
        if (actor == null)
        {
            return NotFound();
        }
        return actor;
    }

    [HttpPost]
    public ActionResult<Actor> Post([FromBody] Actor actor)
    {
        var createdActor = _actorService.CreateActor(actor);
        return CreatedAtAction(nameof(Get), new { id = createdActor.Id }, createdActor);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Actor updatedActor)
    {
        _actorService.UpdateActor(id, updatedActor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _actorService.DeleteActor(id);
        return NoContent();
    }
}
