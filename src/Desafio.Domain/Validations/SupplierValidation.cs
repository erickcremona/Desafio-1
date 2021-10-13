using Desafio.Domain.DocumentValidation;
using Desafio.Domain.Entities;
using FluentValidation;

namespace Desafio.Domain.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(supplier => supplier.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            When(supplier => supplier.TypeSupplier == TypeSupplier.PessoaFisica, () =>
            {
                RuleFor(supplier => supplier.Document)
                .NotNull().WithMessage("Informe o CPF")
                .NotEmpty().WithMessage("Informe o CPF");

                RuleFor(supplier => supplier.Document.Length).Equal(CpfValidation.LengthCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(supplier => CpfValidation.Validate(supplier.Document)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });

            When(supplier => supplier.TypeSupplier == TypeSupplier.PessoaJuridica, () =>
            {
                RuleFor(supplier => supplier.Document)
                .NotNull().WithMessage("Informe o CNPJ")
                .NotEmpty().WithMessage("Informe o CNPJ");

                RuleFor(supplier => supplier.Document.Length).Equal(CnpjValidation.LengthCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(supplier => CnpjValidation.Validate(supplier.Document)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}
