using MethodChaining.Models;
using System.Threading.Tasks;

namespace MethodChaining.Interfaces
{
    public interface ICustomerService
    {
        Task<Result> ValidateExistingCustomerOkAsync(Customer c);
        Task<Result> ValidateExistingCustomerFailAsync(Customer c);
    }
}
