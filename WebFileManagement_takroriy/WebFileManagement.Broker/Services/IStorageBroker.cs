namespace WebFileManagement.Broker.Services;

public interface IStorageBroker
{
    Task CreateDirectoryAsync(string directoryPath);
    Task DeleteDirectoryAsync(string directoryPath);
    Task DeleteFileAsync(string filePath);
    Task<List<string>> GetAllFilesAndDirectorisAsync(string directoryPath);  
    Task UploadFileAsync(string filePath, Stream stream);
    Task<Stream> DownloadFileAsync(string filePath);
    Task<Stream> DownloadDirectoryAsZipAsync(string directoryPath);
}
