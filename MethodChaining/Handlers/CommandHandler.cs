using MethodChaining.Commands;

namespace MethodChaining.Handlers
{
    public class CommandHandler
    {
        protected void Notify(Command message)
        {

        }

        public bool Commit()
        {
            return true;
        }
    }
}
