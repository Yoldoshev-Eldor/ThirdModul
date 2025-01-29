using FileManagmentAsync.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManegmentAsync.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagmentController : ControllerBase
    {
        private readonly IFileManagmentAsyncService _fileServise;

        public FileManagmentController(IFileManagmentAsyncService fileServise)
        {
            _fileServise = fileServise;
        }
        [HttpPut("uploadeFile")]
        public async Task UploadFile(IFormFile file, string directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            directoryPath = Path.Combine(directoryPath, file.FileName);

            using (var stream = file.OpenReadStream())
            {
                await _fileServise.UploadFileAsync(directoryPath, stream);
            }
        }
        [HttpPost("createDirectory")]
        public async Task CreateDirectory(string directoryPath)
        {
            await _fileServise.CreateDirectoryAsync(directoryPath);
        }
        [HttpGet("getAll")]
        public async Task<List<string>> GetAll(string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            return await _fileServise.GetAllFilesAndDirectoriesAsync(directoryPath);
        }
        [HttpGet("dowloadFile")]
        public async Task<FileStreamResult> DownloadFileAsync(string filePath)
        {
            if(string.IsNullOrEmpty(filePath))
            {
                throw new Exception("error");
            }

            var fileName = Path.GetFileName(filePath); 
            var stream = await _fileServise.DownloadFileAsync(filePath);
            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName,
            };
            return res;
        }
        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string filePath)
        {
           await _fileServise.DeleteFileAsync(filePath);
        }
        [HttpDelete("deleteDirectory")]
        public async Task DeleteDirectory(string filePath)
        {
           await _fileServise.DeleteDirectoryAsync(filePath);
        }

    }
}
