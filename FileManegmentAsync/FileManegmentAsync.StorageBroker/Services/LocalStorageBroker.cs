
namespace FileManegmentAsync.StorageBroker.Services;

public class LocalStorageBroker : IStoragebroker
{
    private string _dataPath;
    public LocalStorageBroker()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        ValidateDirectory(directoryPath);
        Directory.CreateDirectory(directoryPath);

    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine (_dataPath, directoryPath);
        if(!Directory.Exists(_dataPath))
        {
            throw new Exception("This Directory not found to deleted");
        }
        Directory.Delete(directoryPath, true );
    }

    public async Task DeleteFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(_dataPath))
        {
            throw new Exception("This file not found to deleted");
        }
        File.Delete(filePath);
    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);

        if(!File.Exists(_dataPath))
        {
            throw new Exception("File not found to download");
        }

        var stream = new FileStream(filePath,FileMode.Open, FileAccess.Read);

        return stream;
    }

    public async Task<List<string>> GetDirectoriesAndFilesAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var parentPath = Directory.GetParent(directoryPath);

        if(!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("parent path not found");
        }

        var allFilesAndFolders = Directory.GetFileSystemEntries(directoryPath).ToList();

        allFilesAndFolders = allFilesAndFolders.Select(p => p.Remove(0, directoryPath.Length + 1)).ToList();

        return allFilesAndFolders;


    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath,filePath);
        var parentPath = Directory.GetParent(filePath);

        if(!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent Path not founf to uploaded");
        }

        using(var fileStream = new FileStream(filePath,FileMode.Create, FileAccess.Write))
        {
            await stream.CopyToAsync(fileStream);
        }
    }
    private void ValidateDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Directory has already created");
        }
        var parentPath = Directory.GetParent(directoryPath);

        if(!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent path not found");
        }
    }
}
