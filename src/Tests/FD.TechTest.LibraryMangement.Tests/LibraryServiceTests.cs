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
        var repository = new FakeBookRepository();
        var service = new LibraryService(repository);

        var exception = Assert.Throws<InvalidBookTitleException>(
            () => service.AddBook(title!, "Author"));

        Assert.That(exception!.Message,
            Is.EqualTo("The book title must contain at least 3 characters."));
        Assert.That(repository.GetAll(), Is.Empty);
    }

    [Test]
    public void AddBook_WhenTitleAndAuthorAlreadyExist_ThrowsDuplicateBookException()
    {
        var existingBook = new Book(1, "Book 1", true, "Author 1");
        var repository = new FakeBookRepository(existingBook);
        var service = new LibraryService(repository);

        var exception = Assert.Throws<DuplicateBookException>(
            () => service.AddBook("Book 1", "Author 1"));

        Assert.That(exception!.Message,
            Is.EqualTo("A book with this title and author already exists."));
        Assert.That(repository.GetAll(), Has.Count.EqualTo(1));
    }

}
