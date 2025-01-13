using MoveCRUD.DataAccess.Entites;
using System.Text.Json;

namespace MoveCRUD.Repostory.Services;

public class MovieRepostory : IMovieRepostory
{
    private readonly string _path;
    private readonly string _directoryPath;
    private List<Movie> _movies;
    public MovieRepostory()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Movie.json");
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _movies = GetAllMovies();
    }

    public Guid AddMovie(Movie movie)
    {
       _movies.Add(movie);
        SaveData();
        return movie.Id;
    }

    public void DeleteMovie(Guid id)
    {
        var movie = GetMovieById(id);
        _movies.Remove(movie);
        SaveData();
    }

    public List<Movie> GetAllMovies()
    {
        var movieList = JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText(_path));
        return movieList;

    }

    public Movie GetMovieById(Guid id)
    {
       var movie = _movies.FirstOrDefault(mv => mv.Id == id);
        if (movie == null)
        {
            throw new Exception("not found");
        }
        return movie;
    }

    public void UpdateMovie(Movie movie)
    {
        var updateMovie = GetMovieById(movie.Id);
        var index = _movies.IndexOf(updateMovie);
        _movies[index] = updateMovie;
        SaveData();
    }
    private void SaveData()
    {
        var json =JsonSerializer.Serialize(_movies);
        File.WriteAllText(_path, json);
    }
}
