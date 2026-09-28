using FD.TechTest.LibraryManagement.Domain.Exceptions;
using FD.TechTest.LibraryManagement.Domain.Services;
using FD.TechTest.LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace FD.TechTest.LibraryManagement.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _bookService;

        public LibraryController(ILibraryService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Récupère tous les livres de la bibliothèque
        /// </summary>
        /// <returns>Tous les livres</returns>
        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        /// <summary>
        /// Ajoute un livre à la bibliothèque
        /// </summary>
        /// <param name="request">Requête pour ajouter un livre</param>
        /// <returns>L'identifiant du livre ajouté</returns>
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] AddBookRequest request)
        {
            try
            {
                var addedBookId = _bookService.AddBook(request.Title, request.Author);

                return Ok(addedBookId);
            }
            catch (LibraryManagementException exc)
            {
                return BadRequest(new { error = exc.Message });
            }
        }

        /// <summary>
        /// Récupère les clients ayant emprunté au moins un livre
        /// </summary>
        [HttpGet("customers-who-borrowed-books")]
        public IActionResult GetCustomersWhoBorrowedBooks()
        {
            var customers = _bookService.GetCustomersWhoBorrowedBooks();

            return Ok(customers);
        }
    }
}
