using System;
using System.Collections.Generic;

namespace Desafio.Domain.Entities
{
    public class Supplier: Entity
    {
        public Guid AddressId { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public TypeSupplier TypeSupplier { get; private set; }
        public Address Address { get; private set; }
        public bool Active { get; private set; }
        public IEnumerable<Product> Products { get; private set; }

        public void SetSupplier(Supplier supplier)
        {
            AddressId = supplier.AddressId;
            Name = supplier.Name;
            Document = supplier.Document;
            TypeSupplier = supplier.TypeSupplier;
            Active = supplier.Active;
        }

        public void SetAddress(Address address)
            => Address = address;

    }
}
