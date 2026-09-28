using FD.TechTest.LibraryManagement.Domain.Entities;
using FD.TechTest.LibraryManagement.Domain.Repositories;

namespace FD.TechTest.LibraryMangement.Tests;

public partial class LibraryServiceTests
{
    private sealed class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;

        public FakeCustomerRepository(params Customer[] customers)
        {
            _customers = customers.ToList();
        }

        public IReadOnlyCollection<Customer> GetAll()
        {
            return _customers.AsReadOnly();
        }
    }
}
