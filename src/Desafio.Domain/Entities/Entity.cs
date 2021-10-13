using System;

namespace Desafio.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
