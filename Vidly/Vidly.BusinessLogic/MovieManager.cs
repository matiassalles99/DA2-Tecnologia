using Vidly.Exceptions;
using Vidly.Domain.Entities;
using Vidly.Domain.SearchCriterias;
using Vidly.IBusinessLogic;
using Vidly.IDataAccess;

namespace Vidly.BusinessLogic;

public class MovieManager : IMovieManager
{
    private readonly IRepository<Movie> _repository;

    // Si por algun motivo necesito el current user en algun lado, simplemente pido que me inyecten el sessionManager
    // y llamo sin parametros a GetCurrentUser()
    public MovieManager(IRepository<Movie> repository)
    {
        _repository = repository;
    }

    public List<Movie> GetAllMovies(MovieSearchCriteria searchCriteria)
    {
        return _repository.GetAllBy(searchCriteria.Criteria()).ToList();
    }

    public Movie GetSpecificMovie(int id)
    {
        var movieSaved = _repository.GetOneBy(m => m.Id == id);

        if (movieSaved == null)
            throw new ResourceNotFoundException($"Could not find specified movie {id}");

        return movieSaved;
    }

    public Movie CreateMovie(Movie movie)
    {
        movie.ValidOrFail();
        _repository.Insert(movie);
        _repository.Save();
        return movie;
    }

    public Movie UpdateMovie(int id, Movie updatedMovie)
    {
        updatedMovie.ValidOrFail();
        var movieSaved = _repository.GetOneBy(m => m.Id == id);

        if (movieSaved == null)
            throw new ResourceNotFoundException($"Could not find specified movie {id}");

        movieSaved.UpdateAttributes(updatedMovie);
        _repository.Update(movieSaved);
        _repository.Save();

        return movieSaved;
    }

    public void DeleteMovie(int id)
    {
        var movieSaved = _repository.GetOneBy(m => m.Id == id);

        if (movieSaved == null)
            throw new ResourceNotFoundException($"Could not find specified movie {id}");

        _repository.Delete(movieSaved);
        _repository.Save();
    }
}