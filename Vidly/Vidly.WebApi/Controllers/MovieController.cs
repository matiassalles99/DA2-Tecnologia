using Microsoft.AspNetCore.Mvc;
using Vidly.Exceptions;
using Vidly.IBusinessLogic;
using Vidly.Models.In;
using Vidly.Models.Out;

namespace Vidly.WebApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieManager _movieManager;
 
        public MovieController(IMovieManager manager)
        {
            _movieManager = manager;
        }

        // Index - Get all movies (/api/movies)
        [HttpGet]
        public IActionResult GetMovies([FromQuery] MovieSearchCriteriaModel searchCriteria)
        {
            var harcodedMovies = new List<MovieBasicModel> () { new MovieBasicModel() { Id = 1, Name = "Minions 3" }, new MovieBasicModel() { Id = 2, Name = "Rapidos y furiosos" } };
            return Ok(harcodedMovies);
        }

        // Show - Get specific movie (/api/movies/{id})
        [HttpGet("{movieId}", Name = "GetMovie")]
        public IActionResult GetMovie(int movieId)
        {
            try
            {
                var retrievedMovie = _movieManager.GetSpecificMovie(movieId);
                return Ok(new MovieDetailModel(retrievedMovie));
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // Create - Create new movie (/api/movies)
        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieModel newMovie)
        {
            try
            {
                var createdMovie = _movieManager.CreateMovie(newMovie.ToEntity());
                var movieModel = new MovieDetailModel(createdMovie);
                return CreatedAtRoute("GetMovie", new { movieId = movieModel.Id }, movieModel);
            }
            catch (InvalidResourceException e)
            {
                return BadRequest(e.Message);
            }
        }

        // Update - Update specific movie (/api/movies/{id})
        [HttpPut("{movieId}")]
        public IActionResult Update(int movieId, [FromBody] MovieModel updatedMovie)
        {
            try
            {
                var retrievedMovie = _movieManager.UpdateMovie(movieId, updatedMovie.ToEntity());
                return Ok(new MovieDetailModel(retrievedMovie));
            }
            catch (InvalidResourceException e)
            {
                return BadRequest(e.Message);
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // Delete - Delete specific movie (/api/movies/{id})
        [HttpDelete("{movieId}")]
        public IActionResult Delete(int movieId)
        {
            try
            {
                _movieManager.DeleteMovie(movieId);
                return Ok();
            }
            catch (ResourceNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
