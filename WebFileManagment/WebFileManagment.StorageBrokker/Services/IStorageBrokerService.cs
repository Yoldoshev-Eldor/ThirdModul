namespace WebFileManagment.StorageBrokker.Services;

public interface IStorageBrokerService
{
    void UploadFile(string filepath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllDirectoriesAndFiles(string directoryPath);
    public Stream DownloadFile(string filePath);

}
