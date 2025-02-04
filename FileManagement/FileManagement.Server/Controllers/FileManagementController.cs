using Filemanagement.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace FileManagement.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileManagementController : ControllerBase
{
    private readonly IFileManagementService _fileService;

    public FileManagementController(IFileManagementService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet("getAll")]

    public async Task<List<string>> GetAll(string? path)
    {
        path = path ?? string.Empty;
        return await _fileService.GetDirectoriesAndFilesAsync(path);
    }

    [HttpPost("createDirectory")]
    public async Task CreateDirectory(string path)
    
    {
        await _fileService.CreateDirectoryAsync(path);
    }


    [HttpDelete("deleteDirectory")]
    public async Task DeleteDirectory(string path)
    {
        await _fileService.DeleteFileAsync(path);
    }


    [HttpDelete("deleteFile")]
    public async Task DeleteFile(string file)
    {
        await _fileService.DeleteFileAsync(file);
    }

    [HttpPost("uploadFile")]
    public async Task UploadFile(IFormFile file, string? directoryPath)
    {

        directoryPath = directoryPath ?? string.Empty;
        directoryPath = Path.Combine(directoryPath, file.Name);

        using (var stream = file.OpenReadStream())
        {
            await _fileService.UploadFileAsync(directoryPath, stream);
        }
    }


    [HttpPost("uploadFileByte")]
    public async Task UploadFileByte(IFormFile file, string? directoryPath)
    {

        directoryPath = directoryPath ?? string.Empty;
        directoryPath = Path.Combine(directoryPath, file.Name);

        using (var stream = file.OpenReadStream())
        {
            await _fileService.UploadFileChankAsync(directoryPath, stream);
        }
    }


    [HttpGet("downloadFile")]
    public async Task<FileStreamResult> DownlodaFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new Exception("");
        }

        var fileName = Path.GetFileName(filePath);
        var stream = await _fileService.DownloadFileAsync(fileName);

        var res = new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = fileName,
        };
        return res;


    }


    [HttpGet("downloadFolderAsZip")]
    public async Task<FileStreamResult> DownlodaFileAsZip(string path)
    {

        if (string.IsNullOrEmpty(path))
        {
            throw new Exception("");
        }

        var fileName = Path.GetFileName(path);
        var stream = await _fileService.DownloadFileAsync(fileName);

        var res = new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = fileName + ".zip",
        };
        return res;


    }

}
