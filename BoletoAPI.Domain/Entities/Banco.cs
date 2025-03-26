namespace BoletoAPI.Domain.Entities
{
    public class Banco
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public decimal PercentualJuros { get; set; }
        
        // Navigation property
        public ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();
    }
}

