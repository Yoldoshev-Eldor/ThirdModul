using Microsoft.EntityFrameworkCore;
using MsicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repostory.Services;

public class MusicRepostory : IMusicRepostory
{
    private readonly MainContext _mainContext;

    public MusicRepostory(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<Guid> AddMusicAsync(Music music)
    {
        await _mainContext.Music.AddAsync(music);
        await _mainContext.SaveChangesAsync();
        return music.Id;
    }

    public async Task DeleteMusicAsync(Guid id)
    {
        var music = await GetMusicByIdAsync(id);
        _mainContext.Music.Remove(music);
        _mainContext.SaveChanges();
    }

    public Task<List<Music>> GetAllMusicAsync()
    {
        var getAll =_mainContext.Music.ToListAsync();
        return getAll;
    }

    public async Task<Music> GetMusicByIdAsync(Guid id)
    {
        var music = await _mainContext.Music.FirstOrDefaultAsync(x => x.Id == id);
        if (music == null)
        {
            throw new Exception("muisc not found");
        }
        return music;

    }

    public Task UpdateMusicAsync(Music music)
    {
        throw new NotImplementedException();
    }
}
