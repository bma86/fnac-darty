using FD.TechTest.LibraryManagement.Domain.Entities;
using FD.TechTest.LibraryManagement.Domain.Repositories;

namespace FD.TechTest.LibraryManagement.Domain.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IBookRepository _bookRepository;

        public LibraryService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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
            var allBooks = _bookRepository.GetAll();
            var id = allBooks.Count == 0 ? 1 : allBooks.Max(b => b.Id) + 1;

            var book = new Book(id, title, true, author);

            _bookRepository.AddBook(book);

            return book.Id;
        }
    }
}
