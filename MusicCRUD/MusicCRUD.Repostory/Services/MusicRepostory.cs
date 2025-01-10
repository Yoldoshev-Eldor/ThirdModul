using MsicCRUD.DataAccess.Entity;
using System.Text.Json;

namespace MusicCRUD.Repostory.Services;

public class MusicRepostory : IMusicRepostory
{
    private readonly string _path;
    private List<Music> _musics;
    public MusicRepostory()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Music.json");
        if(!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _musics = GetAllMusic();
    }

    public Guid AddMusic(Music music)
    {
       _musics.Add(music);
        SavaData();
        return music.Id;
    }

    public void DeleteMusic(Guid id)
    {
        
        var music = GetMusicById(id);
        _musics.Remove(music);  
    }

    public List<Music> GetAllMusic()
    {
        var list = JsonSerializer.Deserialize<List<Music>>(File.ReadAllText(_path));
        return list;
    }

    public Music GetMusicById(Guid id)
    {
        var music = _musics.FirstOrDefault(mc => mc.Id == id);

        if (music == null)
        {
            throw new Exception("not found");
        }

        return music;
    }


    public void UpdateMusic(Music music)
    {
      var  musicId = GetMusicById(music.Id);
        var index = _musics.IndexOf(music);
        _musics[index] = music;
        SavaData();
    }
    private void SavaData()
    {
        var jsonFile = JsonSerializer.Serialize(_musics);
        File.WriteAllText(_path,jsonFile);
    }
}
