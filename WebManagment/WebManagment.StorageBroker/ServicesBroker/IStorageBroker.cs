namespace WebManagment.StorageBroker.Services;

public interface IStorageBroker
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllFilesAndDirectories(string directoryPath);
    Stream DownloadFile(string filePath);
    void DeleteFile(string filePath);
    void DeleteDirectory(string directoryPath);

}
