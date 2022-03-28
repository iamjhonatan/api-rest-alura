using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Domain;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        
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
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie is null) return NotFound();

        var movieDto = _mapper.Map<ReadMovieDto>(movie);

        return Ok(movieDto);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateMovie(Guid id, [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        
        if (movie is null)
            return NotFound();

        _mapper.Map(movieDto, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMovie(Guid id)
    {
        var movie =  _context.Movies.FirstOrDefault(movie => movie.Id == id);
        
        if (movie is null)
            return NotFound();

        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }
}