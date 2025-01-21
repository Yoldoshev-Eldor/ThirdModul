
using WebManagment.StorageBroker.Services;

namespace WebManagment.Service.Services;

public class WebManagmentService : IWebManagmentService
{
    private readonly IStorageBroker _storageBroker;

    public WebManagmentService(IStorageBroker storageBroker)
    {
        _storageBroker = storageBroker;
    }

    public void CreateDirectory(string directoryPath)
    {
        _storageBroker.CreateDirectory(directoryPath);
    }

    public void DeleteDirectory(string directoryPath)
    {
        _storageBroker.DeleteDirectory(directoryPath);
    }

    public void DeleteFile(string filePath)
    {
        _storageBroker.DeleteFile(filePath);
    }

    public Stream DownloadFile(string filePath)
    {
        return _storageBroker.DownloadFile(filePath);
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        return _storageBroker.GetAllFilesAndDirectories(directoryPath);
    }

    public void UploadFile(string filePath, Stream stream)
    {
        _storageBroker.UploadFile(filePath, stream);
    }
}
