using FD.TechTest.LibraryManagement.Domain.Entities;

namespace FD.TechTest.LibraryManagement.Domain.Repositories
{
    //Dont change this code.
    public interface ICustomerRepository
    {
        IReadOnlyCollection<Customer> GetAll();
    }
}
