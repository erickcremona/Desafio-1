using Desafio.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Api.ViewModels
{
    public class CategoryViewModelResponse
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }       
        public string Name { get; set; }        
        public float Profit { get; set; }
        public IEnumerable<ProductViewModelResponse> Products { get; set; }
        public ProductsByCategory ProductsByCategory { get; set; }
    }

    public class CategoryViewModelRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O Campo Nome deve ter no mínimo {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Lucro é obrigatório")]
        public float Profit { get; set; }
              
    }
}
