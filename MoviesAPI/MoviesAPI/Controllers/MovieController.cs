using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Domain;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();
    
    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        movie.Id = Guid.NewGuid();
        movies.Add(movie);
        return CreatedAtAction(nameof(GetMovieById), new { movie.Id }, movie);
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        return Ok(movies);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMovieById(Guid id)
    {
        var movie =  movies.FirstOrDefault(movie => movie.Id == id);
        
        if (movie != null)
            Ok(movie);
        return NotFound();
    }
}