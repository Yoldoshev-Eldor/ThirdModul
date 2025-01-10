using MsicCRUD.DataAccess.Entity;
using MusicCRUD.Repostory.Services;
using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service;

public class MusicService : IMusicService
{
    private readonly IMusicRepostory _musicRepo;
    public MusicService()
    {
        _musicRepo = new MusicRepostory();

    }
    public Guid AddMusic(MusicDto music)
    {
        _musicRepo.AddMusic(ConvertToMusicEntity(music));
        return ConvertToMusicEntity(music).Id;
    }

    public void DeleteMusic(Guid id)
    {
        _musicRepo.DeleteMusic(id);
    }

    public List<MusicDto> GetAllMusic()
    {
        var listMusic = _musicRepo.GetAllMusic();
        var result = listMusic.Select(muz => ConvertToMusicDto(muz)).ToList();
        return result;
    }

    public void UpdateMusic(MusicDto music)
    {
        _musicRepo.UpdateMusic(ConvertToMusicEntity(music));
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

    public List<MusicDto> GetAllMusicByAuthorName(string name)
    {
        var list = _musicRepo.GetAllMusic();
        var result = list.Where(mc => mc.Name == name).ToList();
        var dto = result.Select(ConvertToMusicDto).ToList();
        return dto;

    }

    public MusicDto GetMostLikedMusic()
    {
        var result = GetAllMusic().Max(mc => mc.QuentityLikes);
        return GetAllMusic().FirstOrDefault(bk => bk.QuentityLikes == result);
    }

    public MusicDto GetMusicByName(string name)
    {
        return GetAllMusic().FirstOrDefault(mc => mc.Name == name);
    }

    public List<MusicDto> GetAllMusicAboveSize(double minSize)
    {
        var result = GetAllMusic().Where(mc => mc.MB > minSize).ToList();
        return result;
    }

    public List<MusicDto> GetTopMostLikedMusic(int count)
    {
        var result = GetAllMusic().Where(mc => mc.QuentityLikes > count).ToList();
        return result;
    }

    public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
    {
        var result = GetAllMusic().Where(mc => mc.Name == keyword).ToList();
        return result;
    }

    public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        var result = GetAllMusic().Where(mc => mc.QuentityLikes > minLikes && 
        mc.QuentityLikes < maxLikes).ToList();
        return result;
    }

    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        var result = GetAllMusic().Where(mc => mc.AuthorName == authorName).ToList();
        var res = result.Sum(mc => mc.MB);
        return res;
    }

    public List<string> GetAllUniqueAuthors()
    {
        throw new NotImplementedException();
    }
}
