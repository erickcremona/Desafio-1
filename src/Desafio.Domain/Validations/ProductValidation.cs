using Desafio.Domain.Entities;
using FluentValidation;

namespace Desafio.Domain.Validations
{
    public class ProductValidation: AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(produtc => produtc.Name)
                .NotEmpty().WithMessage("Informe o Nome do Produto")
                .NotNull().WithMessage("Informe o Nome do Produto")
                .Length(2, 200).WithMessage("O Nome do Produto deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(product => product.Description)
                .Length(2, 1000).WithMessage("O campo Descrição deve conter no máximo {MinLength} e {MaxLength} caracteres");

            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("O campo Preço deve ser maior que {ComparisonValue}");

            RuleFor(product => product.SalePrice)
               .GreaterThan(0).WithMessage("O campo Preço de Venda deve ser maior que {ComparisonValue}");

            RuleFor(product => product.Image)
               .NotEmpty().WithMessage("Informe o Nome da Imagem")
                .NotNull().WithMessage("Informe o Nome da Imagem");
        }
    }
}
