using FileManegmentAsync.StorageBroker.Services;

namespace FileManagmentAsync.Service.Services;

public class FileManegmentAsyncServer : IFileManagmentAsyncService
{
    private readonly IStoragebroker _storagebroker;

    public FileManegmentAsyncServer(IStoragebroker storagebroker)
    {
        _storagebroker = storagebroker;
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
       await _storagebroker.CreateDirectoryAsync(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
       await _storagebroker.DeleteFileAsync(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
       await _storagebroker.DeleteFileAsync(filePath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
      return await _storagebroker.DownloadFileAsync(filePath);
    }

    public async Task<List<string>> GetAllFilesAndDirectoriesAsync(string directoryPath)
    {
       return await _storagebroker.GetDirectoriesAndFilesAsync(directoryPath);
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
       await _storagebroker.UploadFileAsync(filePath, stream);
    }
}
