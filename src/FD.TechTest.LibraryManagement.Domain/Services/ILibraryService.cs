using FD.TechTest.LibraryManagement.Domain.Entities;

namespace FD.TechTest.LibraryManagement.Domain.Services
{
    public interface ILibraryService
    {
        int AddBook(string Title, string Author);
        IReadOnlyCollection<Book> GetAllBooks();
        IReadOnlyCollection<Customer> GetCustomersWhoBorrowedBooks();

    }
}
