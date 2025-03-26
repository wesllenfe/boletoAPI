using System;

namespace BoletoAPI.Application.DTOs
{
    public class BoletoResponseDto
    {
        public int Id { get; set; }
        public string NomePagador { get; set; } = string.Empty;
        public string CpfCnpjPagador { get; set; } = string.Empty;
        public string NomeBeneficiario { get; set; } = string.Empty;
        public string CpfCnpjBeneficiario { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public decimal ValorComJuros { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public int BancoId { get; set; }
        public string NomeBanco { get; set; } = string.Empty;
        public string CodigoBanco { get; set; } = string.Empty;
        public decimal PercentualJuros { get; set; }
        public bool Vencido { get; set; }
    }
}

