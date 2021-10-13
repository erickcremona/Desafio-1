using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Api.ViewModels
{
    public class ProductViewModelResponse
    {
        [Key]
        public Guid Id { get; set; }        
        public string DateCreate { get; set; }
        public Guid SupplierId { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryProfit { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public string NameSupplier { get; set; }
        public string DocumentSupplier { get; set; }

    }

    public class ProductViewModelRequest
    {        
        public Guid Id { get; set; }

        [StringLength(1000, ErrorMessage = "Quantidade máxima de 1000 caracteres")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço é requerido e deve ser maior ou igual a {1}")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        [StringLength(100, ErrorMessage = "Quantidade máxima de 100 caracteres")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Quantidade máxima de 100 caracteres")]
        public string Image { get; set; }

        [Required(ErrorMessage = "O Status do Produto é Requerido")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "O Id da Categoria é Requerido")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "O Id do Fornecedor é Requerido")]
        public Guid SupplierId { get; set; }

    }
}
