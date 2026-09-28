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

    [Test]
    public void GetCustomersWhoBorrowedBooks_ReturnsOnlyCustomersWithBorrowedBooks()
    {
        var customerWithOneBorrowedBook = new Customer(
            1,
            "Customer 1",
            new List<BorrowedBook>
            {
                new(1, new DateTime(2026, 1, 1))
            });
        var customerWithoutBorrowedBooks = new Customer(
            2,
            "Customer 2",
            Array.Empty<BorrowedBook>());
        var customerWithTwoBorrowedBooks = new Customer(
            3,
            "Customer 3",
            new List<BorrowedBook>
            {
                new(2, new DateTime(2026, 1, 2)),
                new(3, new DateTime(2026, 1, 3))
            });
        var bookRepository = new FakeBookRepository();
        var customerRepository = new FakeCustomerRepository(
            customerWithOneBorrowedBook,
            customerWithoutBorrowedBooks,
            customerWithTwoBorrowedBooks);
        var service = new LibraryService(bookRepository, customerRepository);

        var customers = service.GetCustomersWhoBorrowedBooks();

        Assert.That(customers, Has.Count.EqualTo(2));
        Assert.That(customers.Select(customer => customer.Id),
            Is.EquivalentTo(new[] { 1, 3 }));
    }

}
