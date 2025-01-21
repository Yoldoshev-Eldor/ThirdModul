using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebManagment.Service.Services;

namespace WebManagment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebManagmentController : ControllerBase
    {
        private readonly IWebManagmentService _webManagmentService;

        public WebManagmentController(IWebManagmentService? webManagmentService)
        {
            _webManagmentService = webManagmentService;
        }
        [HttpGet("getAll")]
        public List<string> GetAllInFolderPath(string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            var all = _webManagmentService.GetAllFilesAndDirectories(directoryPath);
            return all;
        }

        [HttpPost("uploadedFile")]
        public void UploadFIle(IFormFile formFile, string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            directoryPath= Path.Combine(directoryPath, formFile.FileName);
            using (var stream = formFile.OpenReadStream())
            {
                _webManagmentService.UploadFile(directoryPath, stream);
            }
        }
        [HttpPost("createFolder")]
        public void CreateFolder(string folderPath)
        {
            _webManagmentService.CreateDirectory(folderPath);
        }
        [HttpDelete("deleteFile")]
        public void DeleteFile(string filePath)
        {
            _webManagmentService.DeleteFile(filePath);
        }

        [HttpDelete("deleteDirectory")]
        public void DeleteDirectory(string directoryPath)
        {
            _webManagmentService.DeleteDirectory(directoryPath);
        }
        [HttpGet("downloadFile")]
        public FileStreamResult DownloadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Error");
            }

            var fileName = Path.GetFileName(filePath);

            var stream = _webManagmentService.DownloadFile(filePath);


            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName,
            };

            return res;
        }

    }
}
