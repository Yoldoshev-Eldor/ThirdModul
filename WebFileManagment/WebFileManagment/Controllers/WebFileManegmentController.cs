using Microsoft.AspNetCore.Mvc;
using WebFileManagment.Service.Services;

namespace WebFileManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebFileManegmentController : ControllerBase
    {
        private readonly IStorageServer _storageService;

        public WebFileManegmentController(IStorageServer storageService)
        {
            _storageService = storageService;
        }
        [HttpPost("uploadedFile")]
        public void UploadedFIle(IFormFile file, string directoryPath)
        {
            directoryPath = Path.Combine(directoryPath, file.FileName);
            using (var stream = file.OpenReadStream())
            {
                _storageService.UploadFile(directoryPath, stream);
            }
        }
        [HttpPost("createFolder")]
        public void CreateFolder(string folderPath)
        {
            _storageService.CreateDirectory(folderPath);
        }
        [HttpGet("downloadFile")]
        public FileStreamResult DownloadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Error");
            }

            var fileName = Path.GetFileName(filePath);

            var stream = _storageService.DownloadFile(filePath);


            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName,
            };

            return res;
        }
        [HttpGet("getAll")]
        public List<string> GetAllFolderInPath(string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            return _storageService.GetAllDirectoriesAndFiles(directoryPath);
        }
    }
}
