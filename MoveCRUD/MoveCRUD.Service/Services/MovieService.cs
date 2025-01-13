using MoveCRUD.DataAccess.Entites;
using MoveCRUD.Repostory.Services;
using MovieCRUD.Service.Dtos;
using System.Threading.Tasks.Sources;

namespace MovieCRUD.Service.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepostory _movieRepo;
    private readonly List<MovieDto> _movies;

    public MovieService()
    {
        _movieRepo = new MovieRepostory();
    }
    private Movie ConvertToEntiti(MovieDto movie)
    {
        return new Movie
        {
            Id = movie.Id ?? Guid.NewGuid(),
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate,
        };
    }
    private MovieDto ConvertToDto(Movie movie)
    {
        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate,
        };
    }
    public Guid AddMovie(MovieDto movie)
    {
       _movieRepo.AddMovie(ConvertToEntiti(movie));
        return ConvertToEntiti(movie).Id;
    }

    public void DeleteMovie(Guid id)
    {
       _movieRepo.DeleteMovie(id);
    }

    public List<MovieDto> GetAllMovie()
    {
        
        var movieListEntiti = _movieRepo.GetAllMovies();
       return  movieListEntiti.Select(mv => ConvertToDto(mv)).ToList();

    }

    public void UpdateMovie(MovieDto movie)
    {
        _movieRepo.UpdateMovie(ConvertToEntiti(movie));
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return GetAllMovie().Where(mv => mv.Director == director).ToList(); 
            }

    public MovieDto GetTopRatedMovie()
    {
        var mov = GetAllMovie().Max(mv => mv.Rating);
        return GetAllMovie().FirstOrDefault(mv => mv.Rating == mov);
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
       return GetAllMovie().Where(mv => mv.ReleaseDate.Year > year).ToList();
    }

    public MovieDto GetHighestGrossingMovie()
    {
        var mov = GetAllMovie().Max(mv => mv.BoxOfficeEarnings);
        return GetAllMovie().FirstOrDefault(mv => mv.BoxOfficeEarnings == mov);
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        return GetAllMovie().Where(mv => mv.Title.Contains(keyword)).ToList();
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        return GetAllMovie().Where(mv => mv.DurationMinutes > minMinutes 
                                  && mv.DurationMinutes < maxMinutes).ToList();
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
       var directorList = GetAllMovie().Where(mv => mv.Director == director).ToList();
        long result = directorList.Sum(mv => mv.BoxOfficeEarnings);
        return result;

    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
       return GetAllMovie().OrderByDescending(mv => mv.Rating).ToList();
    }

    public List<MovieDto> GetRecentMovies(int years)
    {
        return GetAllMovie().Where(mv => mv.ReleaseDate.Year == years).ToList();
    }
}
