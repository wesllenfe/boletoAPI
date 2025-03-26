using BoletoAPI.Application.DTOs;
using FluentValidation;

namespace BoletoAPI.Application.Validators
{
    public class BancoValidator : AbstractValidator<BancoDto>
    {
        public BancoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do banco é obrigatório")
                .MaximumLength(100).WithMessage("O nome do banco não pode ter mais de 100 caracteres");
                
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O código do banco é obrigatório")
                .MaximumLength(10).WithMessage("O código do banco não pode ter mais de 10 caracteres");
                
            RuleFor(x => x.PercentualJuros)
                .NotEmpty().WithMessage("O percentual de juros é obrigatório")
                .GreaterThan(0).WithMessage("O percentual de juros deve ser maior que zero")
                .LessThanOrEqualTo(100).WithMessage("O percentual de juros não pode ser maior que 100%");
        }
    }
}

