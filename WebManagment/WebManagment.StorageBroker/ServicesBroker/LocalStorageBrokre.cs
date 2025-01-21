
namespace WebManagment.StorageBroker.Services;

public class LocalStorageBrokre : IStorageBroker
{
    public string _dataPath;
    public LocalStorageBrokre()
    {

        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");


        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }


    }
    public void CreateDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("directory has already created");
        }
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent Path Not Found");

        }

        Directory.CreateDirectory(directoryPath);
    }

    public void DeleteDirectory(string directoryPath)
    {

        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("Directory not found");
        }
        Directory.Delete(directoryPath, true);
    }

    public void DeleteFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("Directory not found");
        }
        File.Delete(filePath);
    }

    public Stream DownloadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("File not found");
        }
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var parentPath = Directory.GetParent(directoryPath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("parent path not founf");
        }
        return Directory.GetFileSystemEntries(directoryPath).ToList();
    }

    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        var parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("parent path not found");
        }
        using (var filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(filestream);
        }
    }
}
