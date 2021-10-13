using Desafio.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public float Profit { get; private set; }
        public IEnumerable<Product> Products { get; set; }

        public void SetCategory(Category category)
        {
            Name = category.Name;
            Profit = category.Profit;
        }
               

        public Category CategoryVerifier(Category category)
        {
            if (category.Name == "Categoria Master")
                category.Profit = 45f;

            return category;
        }

        public ProductsByCategory GetProductsByCategory(IEnumerable<Product> products)
        {
            ProductsByCategory product = new ProductsByCategory();

            if (products == null) return product;

            product.CategoryName = Name;
            product.ProductCount = products.Count();
            product.ProductPrice = products.Sum(p => p.SalePrice);

            return product;
        }
    }


}
