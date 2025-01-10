using MsicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repostory.Services;

public interface IMusicRepostory
{
    Guid AddMusic(Music music);
    void DeleteMusic(Guid id);  
    void UpdateMusic(Music music);
    Music GetMusicById(Guid id);
    List<Music> GetAllMusic();
}