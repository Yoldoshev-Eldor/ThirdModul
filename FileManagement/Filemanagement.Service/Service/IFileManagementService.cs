namespace Filemanagement.Service.Service;

public interface IFileManagementService
{
    Task CreateDirectoryAsync(string directoryPath);
    Task DeleteDirectorAsync(string directoryPath);
    Task DeleteFileAsync(string filePath);
    Task<List<string>> GetDirectoriesAndFilesAsync(string directoryPath);
    Task UploadFileAsync(string directoryPath, Stream stream);
    Task UploadFileChankAsync(string directoryPath, Stream stream);
    Task<Stream> DownloadFileAsZipAsync(string filePath);
    Task<Stream> DownloadFileAsync(string directoryPath);

}