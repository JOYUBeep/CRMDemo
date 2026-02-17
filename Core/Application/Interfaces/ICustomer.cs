using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICustomer
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(CustomerCreateDTO customerDto);
        void UpdateCustomer(int id, CustomerUpdateDTO customerDto);
    }
}