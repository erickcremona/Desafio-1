using Desafio.Domain.Entities;
using FluentValidation;

namespace Desafio.Domain.Validations
{
    public class AddressValidation: AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(address => address.PublicPlace)
                .NotEmpty().WithMessage("Informe o Logradouro")
                .Length(2, 200).WithMessage("O Logradouro deve conter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(address => address.District)
                .NotEmpty().WithMessage("Informe o Bairro")
                .Length(2, 100).WithMessage("O campo Bairro deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(address => address.ZipCode)
               .NotEmpty().WithMessage("Informe o CEP")
               .Length(8).WithMessage("O campo CEP deve conter {MaxLength} caracteres");

            RuleFor(address => address.City)
                .NotEmpty().WithMessage("Informe a Cidade")
                .Length(2, 100).WithMessage("O campo Cidade deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(address => address.State)
                .NotEmpty().WithMessage("Informe o Estado")
                .Length(2, 50).WithMessage("O campo Estado deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(address => address.Number)
                .NotEmpty().WithMessage("Informe o Número")
                .Length(1, 50).WithMessage("O campo Número deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(address => address.Complement)
                .Length(1,250).WithMessage("O campo Complemento deve conter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
