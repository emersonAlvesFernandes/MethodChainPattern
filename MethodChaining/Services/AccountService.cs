using MethodChaining.Interfaces;
using MethodChaining.Models;
using System;

namespace MethodChaining.Services
{
    public class AccountService : IAccountService
    {
        public Result IsCustomerBalanceEnough(Customer c, double value)
            => Result.Ok<Customer>(c);
    }
}
