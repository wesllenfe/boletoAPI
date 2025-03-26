using BoletoAPI.Application.DTOs;
using FluentValidation;
using System;

namespace BoletoAPI.Application.Validators
{
    public class BoletoValidator : AbstractValidator<BoletoDto>
    {
        public BoletoValidator()
        {
            RuleFor(x => x.NomePagador)
                .NotEmpty().WithMessage("O nome do pagador é obrigatório")
                .MaximumLength(100).WithMessage("O nome do pagador não pode ter mais de 100 caracteres");
                
            RuleFor(x => x.CpfCnpjPagador)
                .NotEmpty().WithMessage("O CPF/CNPJ do pagador é obrigatório")
                .MaximumLength(20).WithMessage("O CPF/CNPJ do pagador não pode ter mais de 20 caracteres");
                
            RuleFor(x => x.NomeBeneficiario)
                .NotEmpty().WithMessage("O nome do beneficiário é obrigatório")
                .MaximumLength(100).WithMessage("O nome do beneficiário não pode ter mais de 100 caracteres");
                
            RuleFor(x => x.CpfCnpjBeneficiario)
                .NotEmpty().WithMessage("O CPF/CNPJ do beneficiário é obrigatório")
                .MaximumLength(20).WithMessage("O CPF/CNPJ do beneficiário não pode ter mais de 20 caracteres");
                
            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("O valor é obrigatório")
                .GreaterThan(0).WithMessage("O valor deve ser maior que zero");
                
            RuleFor(x => x.DataVencimento)
                .NotEmpty().WithMessage("A data de vencimento é obrigatória")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("A data de vencimento não pode ser no passado")
                .When(x => x.Id == 0); // Only validate this for new boletos
                
            RuleFor(x => x.BancoId)
                .NotEmpty().WithMessage("O ID do banco é obrigatório")
                .GreaterThan(0).WithMessage("O ID do banco deve ser maior que zero");
        }
    }
}

