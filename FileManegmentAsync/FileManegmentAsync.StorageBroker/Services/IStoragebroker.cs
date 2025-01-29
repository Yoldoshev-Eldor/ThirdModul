namespace FileManegmentAsync.StorageBroker.Services;

public interface IStoragebroker
{
    Task UploadFileAsync(string filePath, Stream stream);
    Task CreateDirectoryAsync(string directoryPath);
    Task<List<string>> GetDirectoriesAndFilesAsync(string directoryPath);
    Task<Stream> DownloadFileAsync(string filePath);
    Task DeleteFileAsync(string filePath);
    Task DeleteDirectoryAsync(string directoryPath);
}
