using BookStore.Core.Books.Models;

namespace BookStore.Core.Books.Services;

public interface IBookServices
{
    List<Book> GetBooks();
    Book AddBook(Book book);
    Book GetBook(string id);
    void DeleteBook(string id);

    Book UpdateBook(Book book);

}

