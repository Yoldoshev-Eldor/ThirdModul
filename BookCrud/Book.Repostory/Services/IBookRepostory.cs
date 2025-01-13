using Book.DataAccess.Entitiy;

namespace Book.Repostory.Services;

public interface IBookRepostory
{
    Guid AddBook(Boook book);
    void DeleteBook(Guid id);
    void UpdateBook(Boook book);
    List<Boook> GetAllBooks();
    Boook GetBookById(Guid id);
}