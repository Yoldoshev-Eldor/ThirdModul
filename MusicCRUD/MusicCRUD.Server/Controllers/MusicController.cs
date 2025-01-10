using Microsoft.AspNetCore.Mvc;
using MusicCRUD.Service;
using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        public MusicController()
        {
            _musicService = new MusicService();
        }
        [HttpPost("Add Music")]
        public Guid AddMusic(MusicDto music)
        {
            return _musicService.AddMusic(music);
        }
        [HttpGet("Get Musics")]
        public List<MusicDto> GetMusics()
        {
            return _musicService.GetAllMusic();
        }
        [HttpPost("Update Music")]
        public void UpdateMusic(MusicDto music)
        {
            _musicService.UpdateMusic(music);
        }
        [HttpPost("Delete Music")]
        public void DeleteMusic(Guid id)
        {
            _musicService.DeleteMusic(id);
        }
        [HttpGet("GetTotalMusicSizeByAuthor")]
        public double GetTotalMusicSizeByAuthor(string authorName)
        {
            return _musicService.GetTotalMusicSizeByAuthor(authorName);            
        }
        [HttpGet("GetMusicWithLikesInRange")]
        public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
        {
            return _musicService.GetMusicWithLikesInRange(minLikes, maxLikes);
        }
        [HttpGet("GetMusicByDescriptionKeyword")]
        public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
        {
            return _musicService.GetMusicByDescriptionKeyword(keyword);
        }
        [HttpGet("GetTopMostLikedMusic")]
        public List<MusicDto> GetTopMostLikedMusic(int count)
        {
            return _musicService.GetTopMostLikedMusic(count);
        }
        [HttpGet("GetAllMusicAboveSize")]
        public List<MusicDto> GetAllMusicAboveSize(double minSize)
        {
            return _musicService.GetAllMusicAboveSize(minSize);
        }
        [HttpGet("GetMusicByName")]
        public MusicDto GetMusicByName(string name)
        {
            return _musicService.GetMusicByName(name);
        }
        [HttpGet("GetMostLikedMusic")]
        public MusicDto GetMostLikedMusic()
        {
            return _musicService.GetMostLikedMusic();
        }
        [HttpGet("GetAllMusicByAuthorName")]
        public List<MusicDto> GetAllMusicByAuthorName(string name)
        {
            return _musicService.GetAllMusicByAuthorName(name);
        }
    }
}
