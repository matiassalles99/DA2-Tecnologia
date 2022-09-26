using System.Data.Common;
using System.Linq.Expressions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Vidly.DataAccess.Contexts;
using Vidly.Domain.Entities;

namespace Vidly.DataAccess.Test;

[TestClass]
public class MovieRepository
{

    private readonly DbConnection _connection;
    private readonly BaseRepository<Movie> _repository;
    private readonly VidlyContext _vidlyContext;
    private readonly DbContextOptions<VidlyContext> _contextOptions;

    public MovieRepository()
    {
        this._connection = new SqliteConnection("Filename=:memory:");
        this._contextOptions = new DbContextOptionsBuilder<VidlyContext>().UseSqlite(this._connection).Options;
        this._vidlyContext = new VidlyContext(this._contextOptions);
        this._repository = new BaseRepository<Movie>(this._vidlyContext);
    }

    [TestInitialize]
    public void SetUp()
    {
        this._connection.Open();
        this._vidlyContext.Database.EnsureCreated();
    }

    [TestCleanup]
    public void CleanUp()
    {
        this._vidlyContext.Database.EnsureDeleted();
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
        using (var context = new VidlyContext(this._contextOptions))
        {
            context.AddRange(moviesInDataBase);
            context.SaveChanges();
        }
        var moviesExpected = moviesInDataBase.Where(m => m.Title.ToLower().Contains("el conjuro")).ToList();

        var moviesSaved = this._repository.GetAllBy(movie => movie.Title.ToLower().Contains("el conjuro")).ToList();

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

        using(var context = new VidlyContext(this._contextOptions))
        {
            var movieSaved = context.Movies.FirstOrDefault(m => m.Title == newMovie.Title);
            
            Assert.IsNotNull(movieSaved);
            Assert.AreEqual("Interstellar", movieSaved.Title);
            Assert.AreEqual("Muy buena", movieSaved.Description);
        }
    }
}