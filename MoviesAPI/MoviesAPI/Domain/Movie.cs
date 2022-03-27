using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Domain;

public class Movie
{
    [Required(ErrorMessage = "The Title field is required.")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "The Genre field is required.")]
    public string Genre { get; set; }
    public string Director { get; set; }
    
    [Range(1, 600, ErrorMessage = "The lenght of film must be a minimum of 1 and a maximum of 600 minutes.")]
    public int Duration { get; set; }
}