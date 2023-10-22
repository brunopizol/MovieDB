using Microsoft.AspNetCore.Mvc;
using MovieDB.Domain.Entities;
using MovieDB.Domain.Services;
using System.Collections.Generic;

[Route("api/directors")]
[ApiController]
public class DirectorController : ControllerBase
{
    private readonly DirectorService _directorService;

    public DirectorController(DirectorService directorService)
    {
        _directorService = directorService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Director>> Get()
    {
        return _directorService.GetAllDirectors().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Director> Get(int id)
    {
        var director = _directorService.GetDirectorById(id);
        if (director == null)
        {
            return NotFound();
        }
        return director;
    }

    [HttpPost]
    public ActionResult<Director> Post([FromBody] Director director)
    {
        var createdDirector = _directorService.CreateDirector(director);
        return CreatedAtAction(nameof(Get), new { id = createdDirector.Id }, createdDirector);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Director updatedDirector)
    {
        _directorService.UpdateDirector(id, updatedDirector);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _directorService.DeleteDirector(id);
        return NoContent();
    }
}
