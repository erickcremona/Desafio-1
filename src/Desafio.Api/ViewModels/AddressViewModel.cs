using System.ComponentModel.DataAnnotations;

namespace Desafio.Api.ViewModels
{
    public class AddressViewModel
    {
        
        [Required(ErrorMessage = "O campo Nome é requerido")]
        [StringLength(200, ErrorMessage = "O Logradouro deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string PublicPlace { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido")]
        [StringLength(50, ErrorMessage = "O Logradouro deve conter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Number { get; set; }

        [StringLength(250, ErrorMessage = "O Complemento deve conter no máximo {1} caracteres")]
        public string Complement { get; set; }

        [Required(ErrorMessage = "O campo CEP é requerido")]
        [StringLength(8, ErrorMessage = "O CEP deve conter {1} caracteres")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "O campo Bairro é requerido")]
        [StringLength(100, ErrorMessage = "O campo Bairro deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string District { get; set; }

        [Required(ErrorMessage = "O campo Cidade é requerido")]
        [StringLength(100, ErrorMessage = "O campo Cidade deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo Estado é requerido")]
        [StringLength(50, ErrorMessage = "O campo Estado deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string State { get; set; }

    }
}
