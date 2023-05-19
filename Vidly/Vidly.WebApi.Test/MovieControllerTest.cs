using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Vidly.Domain.Entities;
using Vidly.Exceptions;
using Vidly.IBusinessLogic;
using Vidly.Models.Out;
using Vidly.WebApi.Controllers;

namespace Vidly.WebApi.Test;

[TestClass]
public class MovieControllerTest
{
    private Mock<IMovieManager> _managerMock;

    [TestInitialize]
    public void Setup()
    {
        _managerMock = new Mock<IMovieManager>(MockBehavior.Strict);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _managerMock.VerifyAll();
    }

    [TestMethod]
    public void GetExistingMovieReturnsAsExpected()
    {
        // 1. Arrange
        var movie = CreateMovie();
        var expectedMovie = new MovieDetailModel(movie);
        _managerMock.Setup(manager => manager.GetSpecificMovie(It.IsAny<int>())).Returns(movie);
        var controller = new MovieController(_managerMock.Object);

        // 2. Act 
        var response = controller.GetMovie(movie.Id);
        var okResponseObject = response as OkObjectResult;

        // 3. Assert
        Assert.AreEqual(expectedMovie, okResponseObject.Value);
    }
    
    [TestMethod]
    public void GetNonExistingMovieReturnsNotFound()
    {
        // 1. Arrange
        var exception = new ResourceNotFoundException("Could not find this movie, sorry :)");
        _managerMock.Setup(manager => manager.GetSpecificMovie(It.IsAny<int>()))
            .Throws(exception);
        var controller = new MovieController(_managerMock.Object);

        // 2. Act 
        var response = controller.GetMovie(-1);
        var objectResult = response as ObjectResult;

        // 3. Assert
        Assert.AreEqual((int)HttpStatusCode.NotFound, objectResult.StatusCode);
        Assert.AreEqual(exception.Message, objectResult.Value);
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