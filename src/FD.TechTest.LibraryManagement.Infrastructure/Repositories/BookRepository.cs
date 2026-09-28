using FD.TechTest.LibraryManagement.Domain.Repositories;
using FD.TechTest.LibraryManagement.Domain.Entities;

namespace FD.TechTest.LibraryManagement.Infrastructure.Repositories
{
    //ne pas modifier ce code.
    public class BookRepository : IBookRepository
    {
        private List<Book> Books;

        public BookRepository()
        {
            Books = new List<Book>
            {
                new Book(1, "Book 1", false, "Author 1"),
                new Book(2, "Book 2", false, "Author 2"),
                new Book(3, "Book 3", false, "Author 3"),
                new Book(4, "Book 4", true, "Author 4"),
                new Book(5, "Book 5", true, "Author 5"),
            };
        }
        
        public IReadOnlyCollection<Book> GetAll()
        {
            return Books.AsReadOnly();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
    }
}
