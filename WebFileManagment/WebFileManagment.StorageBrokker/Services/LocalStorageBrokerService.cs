namespace WebFileManagment.StorageBrokker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private string _dataPath;
    public LocalStorageBrokerService()
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
        ValidateDirectory(directoryPath);
        Directory.CreateDirectory(directoryPath);
    }

    public List<string> GetAllDirectoriesAndFiles(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var allFilesAndFolders = Directory.GetFileSystemEntries(directoryPath).ToList();

        allFilesAndFolders = allFilesAndFolders.Select(p => p.Remove(0, directoryPath.Length + 1)).ToList();

        return allFilesAndFolders;
    }

    public Stream DownloadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);

        if (!File.Exists(filePath))
        {
            throw new Exception("File not found to download");
        }

        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        return stream;
    }


    public void UploadFile(string filepath, Stream stream)
    {
        filepath = Path.Combine(_dataPath, filepath);
        var parentPath = Directory.GetParent(filepath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("parent not found");
        }
        using (var fl = new FileStream(filepath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fl);
        }
    }
    private void ValidateDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Directiry already created");
        }
        var parentPath = Directory.GetParent(directoryPath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent Folder not found");

        }
    }

}
