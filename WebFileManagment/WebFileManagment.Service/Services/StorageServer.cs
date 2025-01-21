
using WebFileManagment.StorageBrokker.Services;

namespace WebFileManagment.Service.Services;

public class StorageServer : IStorageServer
{
    private readonly IStorageBrokerService _storageBrokerService;

    public StorageServer(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public void CreateDirectory(string directoryPath)
    {
        _storageBrokerService.CreateDirectory(directoryPath);
    }

    public List<string> GetAllDirectoriesAndFiles(string directoryPath)
    {
        
        return _storageBrokerService.GetAllDirectoriesAndFiles(directoryPath);
    }

    public void UploadFile(string filepath, Stream stream)
    {
        _storageBrokerService.UploadFile(filepath, stream);
    }
    public Stream DownloadFile(string filePath)
    {
        return _storageBrokerService.DownloadFile(filePath);
    }

}
