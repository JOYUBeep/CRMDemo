using Application.DTO;
using Domain.Entities;

namespace Application.Services.Customers
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int Id);
         List<Customer> GetAllCustomers();
         void CreateCustomer(CustomerCreateDTO customerDTO);
         void UpdateCustomer(int Id, CustomerUpdateDTO customerDTO);
    }
}