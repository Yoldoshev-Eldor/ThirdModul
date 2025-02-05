using WebFileManagement.Broker.Services;

namespace WebFileManagement.Service.Services;

public interface IWebFileManagementService
{
    Task CreateDirectoryAsync(string directoryPath);
    Task DeleteDirectoryAsync(string directoryPath);
    Task DeleteFileAsync(string filePath);
    Task<List<string>> GetAllFilesAndDirectorisAsync(string directoryPath);
    Task UploadFileAsync(string filePath, Stream stream);
    Task<Stream> DownloadFileAsync(string filePath);
    Task<Stream> DownloadDirectoryAsZipAsync(string directoryPath);


}