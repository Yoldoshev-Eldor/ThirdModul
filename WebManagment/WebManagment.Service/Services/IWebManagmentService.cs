namespace WebManagment.Service.Services;

public interface IWebManagmentService
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllFilesAndDirectories(string directoryPath);
    Stream DownloadFile(string filePath);
    void DeleteFile(string filePath);
    void DeleteDirectory(string directoryPath);
}