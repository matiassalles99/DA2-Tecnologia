using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Vidly.DataAccess.Contexts;
using Vidly.Domain.Entities;

namespace Vidly.DataAccess.Test;

[TestClass]
public class MovieRepository
{
    private readonly BaseRepository<Movie> _repository;
    private readonly VidlyContext _vidlyContext;

    public MovieRepository()
    {
        _vidlyContext = ContextFactory.GetNewContext(ContextType.SQLite);
        _repository = new BaseRepository<Movie>(_vidlyContext);
    }

    [TestInitialize]
    public void SetUp()
    {
        _vidlyContext.Database.OpenConnection();
        _vidlyContext.Database.EnsureCreated();
    }

    [TestCleanup]
    public void CleanUp()
    {
        _vidlyContext.Database.EnsureDeleted();
    }

    [TestMethod]
    public void GetAllMoviesFilteredByName()
    {
        var moviesInDataBase = new List<Movie>{
            new()
            {
                Title = "El conjuro 2",
                Description = "De terror",
            },
            new()
            {
                Title = "Minions",
                Description = "esta buena"
            }
        };

        _vidlyContext.AddRange(moviesInDataBase);
        _vidlyContext.SaveChanges();
        var moviesExpected = moviesInDataBase.Where(m => m.Title.ToLower().Contains("el conjuro")).ToList();

        var moviesSaved = _repository.GetAllBy(movie => movie.Title.ToLower().Contains("el conjuro")).ToList();

        Assert.AreEqual(moviesExpected.Count(), moviesSaved.Count());
    }

    [TestMethod]
    public void InsertNewMovie()
    {
        var newMovie = new Movie()
        {
            Title = "Interstellar",
            Description = "Muy buena",
        };

        _repository.Insert(newMovie);
        _repository.Save();

        var movieSaved = _vidlyContext.Movies.FirstOrDefault(m => m.Title == newMovie.Title);
        
        Assert.IsNotNull(movieSaved);
        Assert.AreEqual("Interstellar", movieSaved.Title);
        Assert.AreEqual("Muy buena", movieSaved.Description);
    }
}