using System;

namespace BoletoAPI.Domain.Entities
{
    public class Boleto
    {
        public int Id { get; set; }
        public string NomePagador { get; set; } = string.Empty;
        public string CpfCnpjPagador { get; set; } = string.Empty;
        public string NomeBeneficiario { get; set; } = string.Empty;
        public string CpfCnpjBeneficiario { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public int BancoId { get; set; }
        
        // Navigation property
        public Banco? Banco { get; set; }
        
        public decimal CalcularValorComJuros()
        {
            if (Banco == null)
                return Valor;
                
            if (DateTime.Now > DataVencimento)
            {
                return Valor * (1 + (Banco.PercentualJuros / 100));
            }
            
            return Valor;
        }
    }
}

