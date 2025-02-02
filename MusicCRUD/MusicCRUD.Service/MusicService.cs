using MsicCRUD.DataAccess.Entity;
using MusicCRUD.Repostory.Services;
using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service;

public class MusicService : IMusicService
{
    private readonly IMusicRepostory _musicRepo;

    public MusicService(IMusicRepostory musicRepo)
    {
        _musicRepo = musicRepo;
    }

    public async Task<Guid> AddMusicAsync(MusicDto music)
    {
        await _musicRepo.AddMusicAsync(ConvertToMusicEntity(music));
        return ConvertToMusicEntity(music).Id;
    }

    public async Task DeleteMusicAsync(Guid id)
    {
        await _musicRepo.DeleteMusicAsync(id);
    }

    public async Task<List<MusicDto>> GetAllMusicAsync()
    {
        var listMusic = await _musicRepo.GetAllMusicAsync();
        var result = listMusic.Select(muz => ConvertToMusicDto(muz)).ToList();
        return result;
    }

    public async Task UpdateMusicAsync(MusicDto music)
    {
        await _musicRepo.UpdateMusicAsync(ConvertToMusicEntity(music));
    }
    private Music ConvertToMusicEntity(MusicDto musicDto)
    {
        return new Music()
        {
            Id = musicDto.Id ?? Guid.NewGuid(),
            Name = musicDto.Name,
            MB = musicDto.MB,
            AuthorName = musicDto.AuthorName,
            Description = musicDto.Description,
            QuentityLikes = musicDto.QuentityLikes,
        };
    }
    private MusicDto ConvertToMusicDto(Music music)
    {
        return new MusicDto()
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes,
        };
    }

    public async Task<List<MusicDto>> GetAllMusicByAuthorNameAsync(string name)
    {
        var list = await _musicRepo.GetAllMusicAsync();
        var result = list.Where(mc => mc.AuthorName == name).ToList();
        var dto = result.Select(ConvertToMusicDto).ToList();
        return dto;

    }

    public async Task<MusicDto> GetMostLikedMusicAsync()
    {
        var result = await GetAllMusicAsync();
        var maxx = result.Max(mc => mc.QuentityLikes);

        return result.FirstOrDefault(bk => bk.QuentityLikes == maxx);
    }

    public async Task<MusicDto> GetMusicByNameAsync(string name)
    {
        var res = await GetAllMusicAsync();
        return res.FirstOrDefault(mc => mc.Name == name);
    }

    public async Task<List<MusicDto>> GetAllMusicAboveSizeAsync(double minSize)
    {
        var result = await GetAllMusicAsync();
        var res = result.Where(mc => mc.MB > minSize).ToList();
        return res;
    }

    public async Task<List<MusicDto>> GetTopMostLikedMusicAsync(int count)
    {
        var result = await GetAllMusicAsync();
        var res = result.Where(mc => mc.QuentityLikes > count).ToList();
        return res;
    }

    public async Task<List<MusicDto>> GetMusicByDescriptionKeywordAsync(string keyword)
    {
        var result = await GetAllMusicAsync();
        var res = result.Where(mc => mc.Name == keyword).ToList();
        return res;
    }

    public async Task<List<MusicDto>> GetMusicWithLikesInRangeAsync(int minLikes, int maxLikes)
    {
        var result = await GetAllMusicAsync();
        var res = result.Where(mc => mc.QuentityLikes > minLikes &&
     mc.QuentityLikes < maxLikes).ToList();
        return res;
    }

    public async Task<double> GetTotalMusicSizeByAuthorAsync(string authorName)
    {
        var result = await GetAllMusicAsync();
        var ress = result.Where(mc => mc.AuthorName == authorName).ToList();
        var res = ress.Sum(mc => mc.MB);
        return res;
    }

    public async Task<List<string>> GetAllUniqueAuthorsAsync()
    {
        throw new NotImplementedException();
    }
}
