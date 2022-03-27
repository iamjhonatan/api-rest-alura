using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Domain;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();
    
    [HttpPost]
    public void AddMovie([FromBody] Movie movie)
    {
        movie.Id = Guid.NewGuid();
        movies.Add(movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        return movies;
    }

    [HttpGet("{id:guid}")]
    public Movie GetMovieById(Guid id)
    {
        return movies.FirstOrDefault(movie => movie.Id == id);
    }
}