using Book.DataAccess.Entitiy;
using Book.Repostory.Services;
using Book.Service.Dtos;

namespace Book.Service.Services;

public class BookService : IBookService
{
    private readonly IBookRepostory _bookRepo;
    private List<BookDto> _books;
    public BookService()
    {
        _bookRepo = new BookRepostory();
        _books = GetAllBooks();
    }
    private Boook ConvertToEntiti(BookDto book)
    {
        return new Boook
        {
            Id = book.Id ?? Guid.NewGuid(),
            Title = book.Title,
            Author = book.Author,
            Pages = book.Pages,
            Rating = book.Rating,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
            PublishedDate = book.PublishedDate,

        };
    }
    private BookDto ConvertToDto(Boook book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Pages = book.Pages,
            Rating = book.Rating,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
            PublishedDate = book.PublishedDate,

        };
    }
    public Guid AddBook(BookDto book)
    {
       return _bookRepo.AddBook(ConvertToEntiti(book));
    }

    public void DeleteBook(Guid id)
    {
       _bookRepo.DeleteBook(id);
    }

    public List<BookDto> GetAllBooks()
    {
       var list = _bookRepo.GetAllBooks();
      var result = list.Select(bk => ConvertToDto(bk)).ToList();
        return result;
    }

    public List<BookDto> GetAllBooksByAuthor(string author)
    {
        return GetAllBooks().Where(bk => bk.Author.ToLower() == author.ToLower()).ToList();     
    }

    public BookDto GetBookById(Guid id)
    {
        var result =  _bookRepo.GetBookById(id);
        return ConvertToDto(result);
    }

    public List<BookDto> GetBooksPublishedAfterYear(int year)
    {
        return GetAllBooks().Where(bk => bk.PublishedDate.Year > year).ToList();
    }

    public List<BookDto> GetBooksSortedByRating()
    {
        return GetAllBooks().OrderByDescending(bk => bk.Rating).ToList();
    }

    public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
        throw new NotImplementedException();
    }

    public BookDto GetMostPopularBook()
    {
        throw new NotImplementedException();
    }

    public List<BookDto> GetRecentBooks(int years)
    {
        throw new NotImplementedException();
    }

    public BookDto GetTopRatedBook()
    {
        throw new NotImplementedException();
    }

    public int GetTotalCopiesSoldByAuthor(string author)
    {
        throw new NotImplementedException();
    }

    public List<BookDto> SearchBooksByTitle(string keyword)
    {
        return GetAllBooks().Where(bk => bk.Title.ToLower() == keyword.ToLower()).ToList();
    }

    public void UpdateBook(BookDto book)
    {
       _bookRepo.UpdateBook(ConvertToEntiti(book));
    }
}
