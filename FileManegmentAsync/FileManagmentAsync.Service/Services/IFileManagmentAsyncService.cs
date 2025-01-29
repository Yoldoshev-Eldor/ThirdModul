namespace FileManagmentAsync.Service.Services;

public interface IFileManagmentAsyncService
{
    Task UploadFileAsync(string filePath, Stream stream);
    Task CreateDirectoryAsync(string directoryPath);
    Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath);
    Task<Stream> DownloadFileAsync(string filePath);
    Task DeleteFileAsync(string filePath);
    Task DeleteDirectoryAsync(string directoryPath);

}