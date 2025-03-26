using BoletoAPI.Application.DTOs;
using System.Threading.Tasks;

namespace BoletoAPI.Application.Services.Interfaces
{
    public interface IBoletoService
    {
        Task<BoletoResponseDto?> GetBoletoByIdAsync(int id);
        Task<BoletoDto> CreateBoletoAsync(BoletoDto boletoDto);
    }
}

