using FD.TechTest.LibraryManagement.Domain.Entities;
using FD.TechTest.LibraryManagement.Domain.Exceptions;
using FD.TechTest.LibraryManagement.Domain.Repositories;

namespace FD.TechTest.LibraryManagement.Domain.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LibraryService(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Récupère tous les livres de la bibliothèque
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        /// <summary>
        /// Ajoute un livre à la bibliothèque
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <returns>L'identifiant du livre ajouté</returns>
        public int AddBook(string title, string author)
        {
            title = title?.Trim() ?? string.Empty;
            author = author?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(title) || title.Length < 3)
            {
                throw new InvalidBookTitleException();
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new InvalidBookAuthorException();
            }
            var allBooks = _bookRepository.GetAll();
            if (allBooks.Any(b => b.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase)
             && b.Author.Equals(author, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new DuplicateBookException();
            }
            var id = allBooks.Count == 0 ? 1 : allBooks.Max(b => b.Id) + 1;

            var book = new Book(id, title, true, author);

            _bookRepository.AddBook(book);

            return book.Id;
        }

        public IReadOnlyCollection<Customer> GetCustomersWhoBorrowedBooks()
        {
            return _customerRepository.GetAll().Where(customer => customer.BorrowedBooks.Count > 0).ToList().AsReadOnly();
        }
    }
}
