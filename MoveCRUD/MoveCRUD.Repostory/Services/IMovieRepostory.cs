using MoveCRUD.DataAccess.Entites;

namespace MoveCRUD.Repostory.Services;

public interface IMovieRepostory
{
    Guid AddMovie(Movie movie);
    void DeleteMovie(Guid id);
    void UpdateMovie(Movie movie);
    List<Movie> GetAllMovies();
    Movie GetMovieById(Guid id);

}