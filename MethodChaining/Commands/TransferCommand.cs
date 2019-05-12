using MethodChaining.Models;

namespace MethodChaining.Commands
{
    public class TransferCommand : Command
    {
        public TransferCommand(Customer from, Customer to, double value)
        {
            From = from;
            To = to;
            Value = value;
        }

        public Customer From{ get; private set; }
        public Customer To { get; private set; }
        public double Value { get; private set; }

        public override bool IsValid()
        {
            // validar campos obrigatórios
            return true;
        }
    }
}
