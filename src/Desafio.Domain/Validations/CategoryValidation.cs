using Desafio.Domain.Entities;
using FluentValidation;

namespace Desafio.Domain.Validations
{
    public class CategoryValidation: AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Informe o Nome da Categoria")
                .NotNull().WithMessage("Informe o Nome da Categoria")
                .Length(2, 50).WithMessage("O Nome da Categoria deve conter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(category => category.Profit)
                .NotNull().WithMessage("Informe a porcentagem de Lucro")
                .NotEmpty().WithMessage("Informe a porcentagem de Lucro")
                .GreaterThan(0).WithMessage("O campo Lucro deve ser maior que {ComparisonValue}");
        }
    }
}
