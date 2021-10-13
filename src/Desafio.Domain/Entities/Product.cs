using System;

namespace Desafio.Domain.Entities
{
    public class Product : Entity
    {
        public Guid SupplierId { get; private set; }
        public Guid CategoryId { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal SalePrice { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
        public bool Active { get; private set; }
        public Supplier Supplier { get; private set; }
        public Category Category { get; private set; }

        private decimal ValueSalePrice()
        {

            var result = Convert.ToDecimal(Category.Profit) * Price / 100;
            return Price + result;
        }

        public void SetProduct(Product product)
        {
            SupplierId = product.SupplierId;
            CategoryId = product.CategoryId;
            Description = product.Description;
            Price = product.Price;
            SalePrice = ValueSalePrice();
            Name = product.Name;
            Image = product.Image;
            Active = product.Active;            
        }

        public void SetCategory(Category category)
            => Category = category;
        
        public void SetSupplier(Supplier supplier)
            => Supplier = supplier;
        
    }
}
