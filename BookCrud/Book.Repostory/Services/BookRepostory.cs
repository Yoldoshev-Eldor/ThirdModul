using Book.DataAccess.Entitiy;
using System.Text.Json;

namespace Book.Repostory.Services;

public class BookRepostory : IBookRepostory
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private List<Boook> _books;
    public BookRepostory()
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Boook.json");
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }

        _books = GetAllBooks();
    }

    public Guid AddBook(Boook book)
    {
        _books.Add(book);
        SaveData();
        return book.Id;
    }

    public void DeleteBook(Guid id)
    {
        var book = GetBookById(id);
        _books.Remove(book);
        SaveData();
    }

    public List<Boook> GetAllBooks()
    {
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Boook>>(json);
    }

    public Boook GetBookById(Guid id)
    {
        var book = GetAllBooks().FirstOrDefault(bk => bk.Id == id);
        if (book == null)
        {
            throw new Exception("Not found");
        }
        return book;
    }

    public void UpdateBook(Boook book)
    {
        var bookUpdate = GetBookById(book.Id);
        var index = _books.IndexOf(bookUpdate);
        _books[index] = book;
        SaveData();
    }
    private void SaveData()
    {
        var jsonFile = JsonSerializer.Serialize(_books);
        File.WriteAllText(_filePath, jsonFile);
    }
}
