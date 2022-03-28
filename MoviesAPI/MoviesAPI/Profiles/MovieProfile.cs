using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Domain;

namespace MoviesAPI.Profiles;

public class MovieProfile: Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<Movie, ReadMovieDto>();
        CreateMap<UpdateMovieDto, Movie>();
    }
}