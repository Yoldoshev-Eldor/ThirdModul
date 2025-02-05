using WebFileManagement.Broker.Services;

namespace WebFileManagement.Service.Services;

public class WebFileManagementService : IWebFileManagementService
{
    private readonly IStorageBroker _storageBroker;

    public WebFileManagementService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
      await _storageBroker.CreateDirectoryAsync(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
       await _storageBroker.DeleteDirectoryAsync(directoryPath);
    }

    public async Task DeleteFileAsync(string filePath)
    {
      await _storageBroker.DeleteFileAsync(filePath);
    }

    public async Task<Stream> DownloadDirectoryAsZipAsync(string directoryPath)
    {
      return await _storageBroker.DownloadDirectoryAsZipAsync(directoryPath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        return await _storageBroker.DownloadFileAsync(filePath);
    }

    public async Task<List<string>> GetAllFilesAndDirectorisAsync(string directoryPath)
    {
        var res = await _storageBroker.GetAllFilesAndDirectorisAsync(directoryPath);
        return res;
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        await _storageBroker.UploadFileAsync(filePath, stream);
    }
}
