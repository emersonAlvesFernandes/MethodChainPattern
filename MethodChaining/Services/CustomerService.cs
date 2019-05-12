using MethodChaining.Interfaces;
using MethodChaining.Models;

namespace MethodChaining.Services
{
    public class CustomerService : ICustomerService
    {
        public Result ValidateExistingCustomerAsync(Customer c) 
            => Result.Fail<Customer>($"{c.Name} - Invalid Client");            
    }
}
