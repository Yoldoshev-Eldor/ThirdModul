using MsicCRUD.DataAccess.Entity;
using System.Text.Json;

namespace MusicCRUD.Repostory.Services;

public class MusicRepostoryFile : IMusicRepostory
{
    private readonly string _path;
    private List<Music> _musics;
    public MusicRepostoryFile()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Music.json");
        if(!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _musics = GetAllMusicAsync().Result;
    }

    public async Task<Guid> AddMusicAsync(Music music)
    {
       _musics.Add(music);
      await SavaDataAsync();
        return music.Id;
    }

    public async Task DeleteMusicAsync(Guid id)
    {
        
         var music =await GetMusicByIdAsync(id);
        _musics.Remove(music);
       await SavaDataAsync();
    }

    public async Task<List<Music>> GetAllMusicAsync()
    {
        var list = JsonSerializer.Deserialize<List<Music>>(File.ReadAllText(_path));
        return list;
    }

    public async Task<Music> GetMusicByIdAsync(Guid id)
    {
        var music = _musics.FirstOrDefault(mc => mc.Id == id);

        if (music == null)
        {
            throw new Exception("not found");
        }

        return music;
    }


    public async Task UpdateMusicAsync(Music music)
    {
        var musicFromDb = await GetMusicByIdAsync(music.Id);
        var index = _musics.IndexOf(musicFromDb);
        _musics[index] = music;
       await SavaDataAsync();
    }
    private async Task SavaDataAsync()
    {
        var jsonFile = JsonSerializer.Serialize(_musics);
       await File.WriteAllTextAsync(_path,jsonFile);
    }
}
