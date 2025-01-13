using Microsoft.AspNetCore.Mvc;
using MovieCRUD.Service.Dtos;
using MovieCRUD.Service.Services;

namespace MovieCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController()
        {
            _movieService = new MovieService();
        }
        [HttpPost("addMovie")]
        public Guid PostMovie(MovieDto movie)
        {
            return _movieService.AddMovie(movie);
        }
        [HttpGet("getallMovie")]
        public List<MovieDto> GetAllMovie()
        {
            return _movieService.GetAllMovie();
        }
        [HttpPut("updateMovie")]
        public void UpdateMovie(MovieDto movie)
        {
            _movieService.UpdateMovie(movie);
        }
        [HttpDelete("deleteMovie")]
        public void DeleteMovie(Guid id)
        {
            _movieService.DeleteMovie(id);
        }



        [HttpGet("GetAllMoviesByDirector")]
        public List<MovieDto> GetAllMoviesByDirector(string director)
        {
            return _movieService.GetAllMoviesByDirector(director);
        }
        [HttpGet("getTopRatedMovie")]
        public MovieDto GetTopRatedMovie()
        {
            return _movieService.GetTopRatedMovie();
        }
        [HttpGet("getMoviesReleasedAfterYear")]
        public List<MovieDto> GetMoviesReleasedAfterYear(int year)
        {
            return _movieService.GetMoviesReleasedAfterYear(year);
        }
        [HttpGet("getHighestGrossingMovie")]
        public MovieDto GetHighestGrossingMovie()
        {
            return _movieService.GetHighestGrossingMovie();
        }
        [HttpGet("searchMoviesByTitle")]
        public List<MovieDto> SearchMoviesByTitle(string keyword)
        {
            return _movieService.SearchMoviesByTitle(keyword);
        }
        [HttpGet("getMoviesWithinDurationRange")]
        public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
        {
            return _movieService.GetMoviesWithinDurationRange(minMinutes, maxMinutes);
        }
        [HttpGet("getTotalBoxOfficeEarningsByDirector")]
        public long GetTotalBoxOfficeEarningsByDirector(string director)
        {
            return _movieService.GetTotalBoxOfficeEarningsByDirector(director);
        }
        [HttpGet("getMoviesSortedByRating")]
        public List<MovieDto> GetMoviesSortedByRating()
        {
            return _movieService.GetMoviesSortedByRating();
        }
        [HttpGet("getRecentMovies")]
        public List<MovieDto> GetRecentMovies(int years)
        {
            return _movieService.GetRecentMovies(years);
        }

    }
}
