using MethodChaining.Commands;
using MethodChaining.Interfaces;
using MethodChaining.Models;
using MethodChaining.Services;
using System;

namespace MethodChaining.Handlers
{
    public class TransferCommandHandler<T> : CommandHandler where T : TransferCommand
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;

        public TransferCommandHandler(
            ICustomerService customerService, 
            IAccountService accountService)
        {
            _customerService = customerService;
            _accountService = accountService;
        }

        public TransferCommandHandler()
        {
            _customerService = new CustomerService();
            _accountService = new AccountService();
        }

        public void Handle(TransferCommand command)
        {
            Console.WriteLine($"Log: Start");

            _customerService                
                .ValidateExistingCustomerAsync(command.From)
                .OnFailure(() => Console.WriteLine($"Log: Invalid Client - {command.From.Name}"))                
                .OnSuccess(() => _accountService.IsCustomerBalanceEnough(command.From, command.Value)
                    .OnFailure(()=> Console.WriteLine($"Log: Not enough balance! {command.From.Name}")));            

            //TODO:
            // Check if recipient client id valid;
            // Send Transfer Order;
            // Send emitter balance update order;
            // Notificate both if success;
        }
    }
}
