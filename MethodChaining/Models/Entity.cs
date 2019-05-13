using System;

namespace MethodChaining.Models
{
    public class Entity
    {
        public Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            //return GetType().Name + " [Id=" + Id + "]";
            return $"{GetType().Name} - {Id}";

        }
    }
}
