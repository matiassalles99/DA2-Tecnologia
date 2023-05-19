using Vidly.Domain.Entities;
using Vidly.Exceptions;

namespace Vidly.Domain.Test;

[TestClass]
public class MovieTest
{
    [TestMethod]
    public void ValidOrFailPassesWithValidMovie()
    {
        var validMovie = new Movie() { Title = "A title", Description = "A description" };
        validMovie.ValidOrFail();
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidResourceException))]
    public void ValidOrFailThrowsExceptionWithInvalidMovie()
    {
        var validMovie = new Movie() { Title = "", Description = "A description" };
        validMovie.ValidOrFail();
    }
}