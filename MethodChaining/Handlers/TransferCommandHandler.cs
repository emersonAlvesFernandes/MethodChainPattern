using MethodChaining.Commands;
using MethodChaining.Interfaces;
using MethodChaining.Models;
using MethodChaining.Services;
using System;
using System.Threading.Tasks;

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

        public async Task HandleAsync(TransferCommand command)
        {
            Console.WriteLine($"Log: Start");

            await _customerService
                .ValidateExistingCustomerFailAsync(command.From)
                .OnFailureAsync(() => Console.WriteLine($"Log: Invalid Client - {command.From.Name}"))
                .OnSuccessAsync(() => _accountService.IsCustomerBalanceEnoughAsync(command.From, command.Value)
                    .OnFailureAsync(() => Console.WriteLine($"Log: Not enough balance! {command.From.Name}")));
            //TODO:
            // Check if recipient client id valid;
            // Send Transfer Order;
            // Send emitter balance update order;
            // Notificate both if success;


            //Exemplo de utilização de retorno no encadeamento
            _customerService
                .ValidateExistingCustomerOkAsync(command.From)                
                .OnSuccessAsync(() => _accountService.GetAsync(123, 2121))
                .OnSuccessAsync(x => Console.WriteLine(x.ToString()));


        }
    }
}
