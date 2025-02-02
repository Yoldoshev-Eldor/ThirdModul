using MsicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repostory.Services;

public interface IMusicRepostory
{
    Task<Guid> AddMusicAsync(Music music);
    Task DeleteMusicAsync(Guid id);
    Task UpdateMusicAsync(Music music);
    Task<Music> GetMusicByIdAsync(Guid id);
    Task<List<Music>> GetAllMusicAsync();
}