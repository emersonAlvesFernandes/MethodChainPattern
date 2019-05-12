using MethodChaining.Models;
using System.Threading.Tasks;

namespace MethodChaining.Interfaces
{
    public interface ICustomerService
    {
        Result ValidateExistingCustomerAsync(Customer c);        
    }
}
