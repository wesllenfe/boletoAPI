using System;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.DTOs
{
    public class BoletoDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome do pagador é obrigatório")]
        public string NomePagador { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O CPF/CNPJ do pagador é obrigatório")]
        public string CpfCnpjPagador { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O nome do beneficiário é obrigatório")]
        public string NomeBeneficiario { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O CPF/CNPJ do beneficiário é obrigatório")]
        public string CpfCnpjBeneficiario { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal Valor { get; set; }
        
        [Required(ErrorMessage = "A data de vencimento é obrigatória")]
        public DateTime DataVencimento { get; set; }
        
        public string? Observacao { get; set; }
        
        [Required(ErrorMessage = "O ID do banco é obrigatório")]
        public int BancoId { get; set; }
    }
}

