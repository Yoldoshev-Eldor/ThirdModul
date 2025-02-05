
using System.IO.Compression;

namespace WebFileManagement.Broker.Services;

public class LocalStorageBroker : IStorageBroker
{
    private string _dataPath;
    public LocalStorageBroker()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }

    public async Task CreateDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (Directory.Exists(directoryPath))
        {
            throw new Exception("this directory already created");
        }

        var parentPath = Directory.GetParent(directoryPath);

        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Parent path not found");
        }

        Directory.CreateDirectory(directoryPath);
    }

    public async Task DeleteDirectoryAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);

        if (!Directory.Exists(_dataPath))
        {
            throw new Exception("This directory not found");
        }
        Directory.Delete(directoryPath, true);

    }

    public async Task DeleteFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        if (!File.Exists(filePath))
        {
            throw new Exception("this file not found");
        }

        File.Delete(filePath);

    }

    public async Task<Stream> DownloadFileAsync(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);

        if (!File.Exists(filePath))
        {
            throw new Exception("file not found");
        }
        return new FileStream(filePath, FileMode.Open, FileAccess.Read);
    }

    public async Task<List<string>> GetAllFilesAndDirectorisAsync(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Patent Path not found");
        }

        var allFiles = Directory.GetFileSystemEntries(directoryPath).ToList();

        allFiles = allFiles.Select(p => p.Remove(0, directoryPath.Length + 1)).ToList();
        return allFiles;
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);

        var parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("parent path not found");
        }

        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await stream.CopyToAsync(fileStream);
        }

    }

    public async Task<Stream> DownloadDirectoryAsZipAsync(string directoryPath)
    {

        if (Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception("DirectoryPath is not directory");
        }

        directoryPath = Path.Combine(_dataPath, directoryPath);

        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("not found to zip");
        }
        var zip = directoryPath + ".zip";

        ZipFile.CreateFromDirectory(directoryPath, zip);
        var stream = new FileStream(zip, FileMode.Open, FileAccess.Read);
        return stream;

    }
}
