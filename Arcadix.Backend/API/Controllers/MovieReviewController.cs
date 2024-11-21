namespace API.Controllers
{
    using DTOS;
    using IBussiness;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MovieReviewController : ControllerBase
    {
        public readonly IMovieReviewService _movieReviewService;

        public MovieReviewController(IMovieReviewService movieReviewService)
        {
            _movieReviewService = movieReviewService;
        }
        [HttpGet("GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieReviewService.GetMovies();
            if (movies == null || !movies.Any())
            {
                return NotFound("No movies found.");
            }
            return Ok(movies);
        }

        [HttpGet("GetMovieById{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieReviewService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie([FromBody] MovieReviewGetDTO movie)
        {
            try
            {
                await _movieReviewService.AddMovie(movie);
                return Ok("Added");
            }
            catch(Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie([FromBody] MovieReviewGetDTO movie)
        {
            var exist = await _movieReviewService.GetMovieById(movie.MovieIdDto);

            if (exist == null)
            {
                return NotFound($"Movie with id {movie.MovieIdDto} not found.");
            }
            var updated = await _movieReviewService.UpdateMovie(movie);
            if (updated)
            {
                return NoContent();
            }
            return StatusCode(500, $"Error while updating movie");

        }

        [HttpDelete("DeleteMovie{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var deleted = await _movieReviewService.DeleteMovie(id);

            if (!deleted)
            {
                return NotFound($"Movie with id {id} not found.");
            }
            return NoContent();
        }
    }
}
