using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieDB.Domain.Entities;
using MovieDB.Domain.Services;

namespace MovieDB.WebApi.Controllers
{

        [Authorize]
        [Route("api/movies")]
        [ApiController]
        public class MovieController : ControllerBase
        {
            private readonly MovieService _movieService;

            public MovieController(MovieService movieService)
            {
                _movieService = movieService;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Movie>> Get()
            {
                return _movieService.GetAllMovies().ToList();
            }

            [HttpGet("{id}")]
            public ActionResult<Movie> Get(int id)
            {
                var movie = _movieService.GetMovieById(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return movie;
            }

            [HttpPost]
            public ActionResult<Movie> Post([FromBody] Movie movie)
            {
                var createdMovie = _movieService.CreateMovie(movie);
                return CreatedAtAction(nameof(Get), new { id = createdMovie.Id }, createdMovie);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] Movie updatedMovie)
            {
                _movieService.UpdateMovie(id, updatedMovie);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _movieService.DeleteMovie(id);
                return NoContent();
            }
        }

    }

