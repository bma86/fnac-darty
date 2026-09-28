using FD.TechTest.LibraryManagement.Domain.Entities;
using FD.TechTest.LibraryManagement.Domain.Repositories;

namespace FD.TechTest.LibraryMangement.Tests;

public partial class LibraryServiceTests
{
    private sealed class FakeBookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public FakeBookRepository(params Book[] books)
        {
            _books = books.ToList();
        }

        public IReadOnlyCollection<Book> GetAll()
        {
            return _books.AsReadOnly();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
    }
}
