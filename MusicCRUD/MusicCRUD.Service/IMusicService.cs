using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service;

public interface IMusicService
{
    Guid AddMusic(MusicDto music);
    void DeleteMusic(Guid id);
    void UpdateMusic (MusicDto music);
    List<MusicDto> GetAllMusic();
    List<MusicDto> GetAllMusicByAuthorName(string name);
    MusicDto GetMostLikedMusic();
    MusicDto GetMusicByName(string name);
    List<MusicDto> GetAllMusicAboveSize(double minSize);
    List<MusicDto> GetTopMostLikedMusic(int count);
    List<MusicDto> GetMusicByDescriptionKeyword(string keyword);
    List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);

}