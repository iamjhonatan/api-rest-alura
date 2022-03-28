using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Domain;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        return _context.Movies;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMovieById(Guid id)
    {
        var movie =  _context.Movies.FirstOrDefault(movie => movie.Id == id);
        
        if (movie != null)
            return Ok(movie);
        return NotFound();
    }
}