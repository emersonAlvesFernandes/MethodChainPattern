using MethodChaining.Commands;
using MethodChaining.Handlers;
using MethodChaining.Models;

namespace MethodChaining
{
    class Program
    {
        static void Main(string[] args)
        {
            var tc = new TransferCommand(
                new Customer("John", "123456"), 
                new Customer("Chad","12345" ), 
                1000);

            new TransferCommandHandler<TransferCommand>()
                .Handle(tc);
        }
    }
}
