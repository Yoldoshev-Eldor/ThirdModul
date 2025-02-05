using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFileManagement.Service.Services;

namespace WebFileManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebFilemanagementController : ControllerBase
    {
        private readonly IWebFileManagementService _service;

        public WebFilemanagementController(IWebFileManagementService service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public async Task<List<string>> GetAll(string? directoryPath)
        {
            directoryPath= directoryPath ?? string.Empty;
            return await _service.GetAllFilesAndDirectorisAsync(directoryPath);
        }


        [HttpPost("createDirectory")]
        public async Task CreateDirectory(string directoryPath)
        {
          await  _service.CreateDirectoryAsync(directoryPath);
        }

        [HttpDelete("deleteDirectory")]
        public async Task deleteDirectory(string directoryPath)
        {
          await  _service.DeleteDirectoryAsync(directoryPath);
        }

        [HttpDelete("deleteFile")]
        public async Task DeleteFile(string filePath)
        {
            await _service.DeleteFileAsync(filePath);
        }


        [HttpPost("uploadFile")]
        public async Task UploadFile(IFormFile file, string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            directoryPath = Path.Combine(directoryPath, file.FileName);

            using(var stream = file.OpenReadStream())
            {
                await _service.UploadFileAsync(directoryPath, stream);
            }

        }


        [HttpGet("downloadFile")]

        public async Task<FileStreamResult> DownloadFile(string filePath)
        {
            
            if(string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Error");
            }

            var fileName = Path.GetFileName(filePath);

            var stream = await _service.DownloadFileAsync(filePath);

            var res = new FileStreamResult(stream, "aplication/octet-stream")
            {
                FileDownloadName = fileName,
            };
            return res;
        }

        
        [HttpGet("downloadFolderAsZip")]

        public async Task<FileStreamResult> DownloadFileAsZip(string filePath)
        {
            
            if(string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Error");
            }

            var directoryName = Path.GetFileName(filePath);

            var stream = await _service.DownloadDirectoryAsZipAsync(filePath);

            var res = new FileStreamResult(stream, "aplication/octet-stream")
            {
                FileDownloadName = directoryName + ".zip",
            };
            return res;
        }


    }
}
