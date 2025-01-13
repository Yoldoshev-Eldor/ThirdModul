using MovieCRUD.Service.Dtos;

namespace MovieCRUD.Service.Services;

public interface IMovieService
{
    Guid AddMovie(MovieDto movie);
    void DeleteMovie(Guid id);
    void UpdateMovie(MovieDto movie);
    List<MovieDto> GetAllMovie();


    List<MovieDto> GetAllMoviesByDirector(string director);
    MovieDto GetTopRatedMovie();
    List<MovieDto> GetMoviesReleasedAfterYear(int year);
    MovieDto GetHighestGrossingMovie();
    List<MovieDto> SearchMoviesByTitle(string keyword);
    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);
    long GetTotalBoxOfficeEarningsByDirector(string director);
    List<MovieDto> GetMoviesSortedByRating();
    List<MovieDto> GetRecentMovies(int years);
}