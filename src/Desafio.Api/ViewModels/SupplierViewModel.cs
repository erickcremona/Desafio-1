using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Api.ViewModels
{
    public class SupplierViewModelResponse
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public DateTime DateCreate { get; set; }       
        public string Name { get; set; }
        public string Document { get; set; }
        public int TypeSupplier { get; set; }
        public AddressViewModel Address { get; set; }
        public bool Active { get; set; }
        public IEnumerable<ProductViewModelResponse> Products { get; set; }
    }

    public class SupplierViewModelRequest
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public DateTime DateCreate { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido")]
        [StringLength(100, ErrorMessage = "O campo Nome deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Documento é requerido")]
        [StringLength(14, ErrorMessage = "O campo Documento deve conter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Document { get; set; }

        [Required(ErrorMessage = "O campo Tipo Fornecedor é requerido")]
        public int TypeSupplier { get; set; }

        public AddressViewModel Address { get; set; }

        [Required(ErrorMessage = "O campo Ativo é requerido")]
        public bool Active { get; set; }

    }
}
