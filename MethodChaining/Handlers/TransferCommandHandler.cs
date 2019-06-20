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
        private readonly IConsoleService _console;

        public TransferCommandHandler(
            ICustomerService customerService,
            IAccountService accountService,
            IConsoleService console)
        {
            _customerService = customerService;
            _accountService = accountService;
            _console = console;
        }

        public TransferCommandHandler()
        {
            _customerService = new CustomerService();
            _accountService = new AccountService();
            _console = new ConcoleService();
        }

        public async Task HandleAsync(TransferCommand command)
        {
            Console.WriteLine($"Log: Start");

            //await _customerService
            //    .ValidateExistingCustomerFailAsync(command.From)
            //    .OnFailureAsync(() => Console.WriteLine($"Log: Invalid Client - {command.From.Name}"))
            //    .OnSuccessAsync(() => _accountService.IsCustomerBalanceEnoughAsync(command.From, command.Value)
            //        .OnFailureAsync(() => Console.WriteLine($"Log: Not enough balance! {command.From.Name}")));
            //TODO:
            // Check if recipient client id valid;
            // Send Transfer Order;
            // Send emitter balance update order;
            // Notificate both if success;


            //Exemplo de utilização de retorno no encadeamento
            await _customerService
                .ValidateExistingCustomerOkAsync(command.From)
                .OnSuccessAsync(
                    () => _accountService.GetAsync(command.From.Account.AgencyNumber, command.From.Account.Number)
                    .OnSuccessAsync(() => _console.WriteLine(command.From.Account.ToString()))
                );
                //.OnSuccessAsync(() => Console.WriteLine("aaaa"));
                //.OnSuccessAsync(() => _console.WriteLine(""))




        }
    }
}
