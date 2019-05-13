using MethodChaining.Interfaces;
using MethodChaining.Models;
using System.Threading.Tasks;

namespace MethodChaining.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<Result> ValidateExistingCustomerOkAsync(Customer c) 
            => await Task.Run(()=> Result.Ok<Customer>(c));

        public async Task<Result> ValidateExistingCustomerFailAsync(Customer c)
            => await Task.Run(()=> Result.Fail<Customer>($"{c.Name} - Invalid Client"));
    }
}
