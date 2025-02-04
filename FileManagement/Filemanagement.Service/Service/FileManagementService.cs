using StorageBroker.Services;

namespace Filemanagement.Service.Service;

public class FileManagementService : IFileManagementService
{
    private readonly IStorageBroker _storageBroker;

    public FileManagementService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        await _storageBroker.CreateDirectoryAsync(directoryPath);
    }

    public async Task DeleteDirectorAsync(string directoryPath)
    {
        await _storageBroker.DeleteDirectorAsync(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
        await _storageBroker.DeleteFileAsync(filePath);
    }

    public async Task<Stream> DownloadFileAsync(string directoryPath)
    {
        return await _storageBroker.DownloadFileAsync(directoryPath);
    }

    public async Task<Stream> DownloadFileAsZipAsync(string filePath)
    {
        return await _storageBroker.DownloadFileAsZipAsync(filePath);
    }

    public async Task<List<string>> GetDirectoriesAndFilesAsync(string directoryPath)
    {
        return await _storageBroker.GetDirectoriesAndFilesAsync(directoryPath);
    }

    public async Task UploadFileAsync(string directoryPath, Stream stream)
    {
        await _storageBroker.UploadFileAsync(directoryPath, stream);
    }

    public async Task UploadFileChankAsync(string directoryPath, Stream stream)
    {
        await _storageBroker.UploadFileChankAsync(directoryPath, stream);
    }
}
