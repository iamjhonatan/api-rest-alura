using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos;

public class UpdateMovieDto
{
    [Required(ErrorMessage = "The Title field is required.")]
    public string Title { get; set; }
    
    [StringLength(30, ErrorMessage = "The Genre field must not exceed 30 characters.")]
    public string Genre { get; set; }
    
    [Required(ErrorMessage = "The Director field is required.")]
    public string Director { get; set; }
    
    [Range(1, 600, ErrorMessage = "The lenght of film must be a minimum of 1 and a maximum of 600 minutes.")]
    public int Duration { get; set; }
}