using System.Text;
using System.Text.Json;

namespace _3._6dars;

public class MusicCrudApiBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;
    public MusicCrudApiBroker()
    {
        _baseUrl = "https://localhost:7136/api/Music";
        _httpClient = new HttpClient();
        //DeleteMusic();
        //Add();
        //GetAll();
    }

    public void GetAll()
    {
        var url = $"{_baseUrl}/getMusics";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        string responseContent = response.Content.ReadAsStringAsync().Result;

        response.EnsureSuccessStatusCode();

        if (response.IsSuccessStatusCode == false)
        {
            throw new Exception("response qoniqarli emas");
        }

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<Music[]>(responseContent, options);

        foreach (var m in music)
        {
            Console.WriteLine(m);
        }
    }


    public void Add()
    {
        var url = $"{_baseUrl}/addMusic";
        var music = new Music()
        {
            Name = "Bandaman",
            MB = 4.8,
            AuthorName = "Sherali Jo'rayev",
            Description = "Yaxshi",
            QuentityLikes = 45
        };

        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


        var response = _httpClient.PostAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);

    }
    public void DeleteMusic(Guid id)
    {
        //var url = $"{_baseUrl}/deleteMusic?id = {id}";
        var url = $"https://localhost:7136/api/Music/deleteMusic?id={id}";

        var response = _httpClient.DeleteAsync(url).Result;
        response.EnsureSuccessStatusCode();



    }
    public void UpdateMusic(Music music)
    {

        var url = $"https://localhost:7136/api/Music/updateMusic?music={music}";

        //var Updatemusic = new Music()
        //{
        //    Id = muisc.Id,
        //    Name = muisc.Name,
        //    AuthorName = muisc.AuthorName,
        //    Description = muisc.Description,
        //    QuentityLikes = muisc.QuentityLikes
        //};
        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


        var response = _httpClient.PutAsync(url, content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);
    }
    public void GetMusicByAuthorname(string name)
    {
        var url = $"https://localhost:7136/api/Music/GetAllMusicByAuthorName?name={name}";
        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        string responseContent = response.Content.ReadAsStringAsync().Result;

        response.EnsureSuccessStatusCode();

        
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<Music[]>(responseContent, options);

        foreach (var m in music)
        {
            Console.WriteLine(m);
        }

    }
}
