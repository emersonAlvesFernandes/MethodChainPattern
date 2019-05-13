using MethodChaining.Models;
using System.Threading.Tasks;

namespace MethodChaining.Interfaces
{
    public interface IAccountService
    {
        Task<Result> IsCustomerBalanceEnoughAsync(Customer c, double value);
        Task<Account> GetAsync(int agencyNumber, int number);
    }
}
