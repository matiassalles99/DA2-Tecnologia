using Vidly.Exceptions;
using Vidly.Domain.Entities;
using Vidly.Domain.SearchCriterias;

namespace Vidly.BusinessLogic;

// "Orquestar"
public class MovieManager
{
    private static List<Movie> _movies = new List<Movie>()
    {
        new Movie() { Id = 1, Title = "El conjuro", Description = "De terror" },
        new Movie() { Id = 2, Title = "Los minions", Description = "De comedia" }
    };

    public List<Movie> GetAllMovies(MovieSearchCriteria searchCriteria)
    {
        return _movies;
    }

    public Movie GetSpecificMovie(int id)
    {
        var movieSaved = _movies.FirstOrDefault(m => m.Id == id);

        if (movieSaved == null)
            throw new ResourceNotFoundException($"Could not find specified movie {id}");

        return movieSaved;
    }

    public Movie CreateMovie(Movie movie)
    {
        movie.ValidOrFail();
        movie.Id = _movies.Count() + 1;
        _movies.Add(movie);
        return movie;
    }

    public Movie UpdateMovie(int id, Movie updatedMovie)
    {
        updatedMovie.ValidOrFail();
        var movieSaved = _movies.FirstOrDefault(m => m.Id == id);

        if (movieSaved == null)
            throw new ResourceNotFoundException($"Could not find specified movie {id}");

        // Workaround - como no puedo editar el elemento directamente en List, lo elimino y lo vuelvo a insertar actualizado
        var newMovie = new Movie()
        {
            Id = movieSaved.Id,
            Description = updatedMovie.Description,
            Title = updatedMovie.Title
        };
        _movies.Remove(movieSaved);
        _movies.Add(newMovie);

        return newMovie;
    }

    public void DeleteMovie(int id)
    {
        var movieSaved = _movies.FirstOrDefault(m => m.Id == id);

        if (movieSaved == null)
            throw new ResourceNotFoundException($"Could not find specified movie {id}");

        _movies.Remove(movieSaved);
    }
}