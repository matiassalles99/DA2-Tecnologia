using System.Linq.Expressions;
using Moq;
using Vidly.Domain.Entities;
using Vidly.Exceptions;
using Vidly.IDataAccess;

namespace Vidly.BusinessLogic.Test;

[TestClass]
public class MovieControllerTest
{
    private Mock<IRepository<Movie>> _repoMock;

    [TestInitialize]
    public void Setup()
    {
        _repoMock = new Mock<IRepository<Movie>>(MockBehavior.Strict);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _repoMock.VerifyAll();
    }

    [TestMethod]
    public void GetExistingMovieReturnsAsExpected()
    {
        // 1. Arrange
        var movie = CreateMovie();
        _repoMock.Setup(manager => manager.GetOneBy(It.IsAny<Expression<Func<Movie, bool>>>())).Returns(movie);
        var manager = new MovieManager(_repoMock.Object);

        // 2. Act 
        var retrievedMovie = manager.GetSpecificMovie(movie.Id);

        // 3. Assert
        Assert.AreEqual(movie.Id, retrievedMovie.Id);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ResourceNotFoundException))]
    public void GetNonExistingMovieThrowsException()
    {
        _repoMock.Setup(manager => manager.GetOneBy(It.IsAny<Expression<Func<Movie, bool>>>())).Returns(default(Movie));
        var manager = new MovieManager(_repoMock.Object);

        manager.GetSpecificMovie(-1);
    }

    private Movie CreateMovie()
    {
        return new Movie()
        {
            Id = 1,
            Title = "A title",
            Description = "A description"
        };
    }
}