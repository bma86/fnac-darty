using FD.TechTest.LibraryManagement.Domain.Entities;
using FD.TechTest.LibraryManagement.Domain.Exceptions;
using FD.TechTest.LibraryManagement.Domain.Services;

namespace FD.TechTest.LibraryMangement.Tests;

[TestFixture]
public partial class LibraryServiceTests
{
    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    [TestCase("AB")]
    [TestCase(" A ")]
    public void AddBook_WhenTitleHasFewerThanThreeCharacters_ThrowsInvalidBookTitleException(
        string? title)
    {
        var bookRepository = new FakeBookRepository();
        var customerRepository = new FakeCustomerRepository();
        var service = new LibraryService(bookRepository, customerRepository);

        var exception = Assert.Throws<InvalidBookTitleException>(
            () => service.AddBook(title!, "Author"));

        Assert.That(exception!.Message,
            Is.EqualTo("The book title must contain at least 3 characters."));
        Assert.That(bookRepository.GetAll(), Is.Empty);
    }

    [Test]
    public void AddBook_WhenTitleAndAuthorAlreadyExist_ThrowsDuplicateBookException()
    {
        var existingBook = new Book(1, "Book 1", true, "Author 1");
        var bookRepository = new FakeBookRepository(existingBook);
        var customerRepository = new FakeCustomerRepository();
        var service = new LibraryService(bookRepository, customerRepository);

        var exception = Assert.Throws<DuplicateBookException>(
            () => service.AddBook("Book 1", "Author 1"));

        Assert.That(exception!.Message,
            Is.EqualTo("A book with this title and author already exists."));
        Assert.That(bookRepository.GetAll(), Has.Count.EqualTo(1));
    }

}
