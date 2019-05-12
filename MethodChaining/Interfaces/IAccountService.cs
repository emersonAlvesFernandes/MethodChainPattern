using MethodChaining.Models;

namespace MethodChaining.Interfaces
{
    public interface IAccountService
    {
        Result IsCustomerBalanceEnough(Customer c, double value);
    }
}
