namespace FD.TechTest.LibraryManagement.Domain.Exceptions
{
    public class LibraryManagementException : Exception
    {
        public LibraryManagementException(string? message) : base(message)
        {
        }
    }
    public class InvalidBookTitleException : LibraryManagementException
    {
        public InvalidBookTitleException()
            : base("The book title must contain at least 3 characters.")
        {
        }
    }
    public class DuplicateBookException : LibraryManagementException
    {
        public DuplicateBookException()
            : base("A book with this title and author already exists.")
        {
        }
    }
}
