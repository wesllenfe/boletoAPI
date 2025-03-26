using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.DTOs
{
    public class BancoDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome do banco é obrigatório")]
        public string Nome { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O código do banco é obrigatório")]
        public string Codigo { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O percentual de juros é obrigatório")]
        [Range(0.01, 100, ErrorMessage = "O percentual de juros deve estar entre 0.01 e 100")]
        public decimal PercentualJuros { get; set; }
    }
}

