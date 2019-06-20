using MethodChaining.Commands;
using MethodChaining.Handlers;
using MethodChaining.Models;
using System.Threading.Tasks;

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

            var t = new TransferCommandHandler<TransferCommand>();

            //Task.Run(()=> t.HandleAsync(tc));
            t.HandleAsync(tc).Result;
        }
    }
}
