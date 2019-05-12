namespace MethodChaining.Models
{
    public class Customer : Entity
    {
        public Customer(string name, string document)
        {
            Name = name;
            Document = document;
        }

        public string Name { get; set; }

        public string Document { get; set; }

        public Account Account { get; set; }
    }
}
