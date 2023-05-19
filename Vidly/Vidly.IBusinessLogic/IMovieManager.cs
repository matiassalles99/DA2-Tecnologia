using Vidly.Domain.Entities;
using Vidly.Domain.SearchCriterias;

namespace Vidly.IBusinessLogic;

public interface IMovieManager
{
    List<Movie> GetAllMovies(MovieSearchCriteria searchCriteria);
    Movie GetSpecificMovie(int id);
    Movie CreateMovie(Movie movie);
    Movie UpdateMovie(int id, Movie updatedMovie);
    void DeleteMovie(int id);
}