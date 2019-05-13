using MethodChaining.Interfaces;
using MethodChaining.Models;
using System;
using System.Threading.Tasks;

namespace MethodChaining.Services
{
    public class AccountService : IAccountService
    {
        public async Task<Result> IsCustomerBalanceEnoughAsync(Customer c, double value)
            => await Task.Run(() => Result.Ok<Customer>(c));

        public async Task<Account> GetAsync(int agencyNumber, int number)
            => await Task.Run(() => new Account() { AgencyNumber = agencyNumber, Number = number });
    }
}
