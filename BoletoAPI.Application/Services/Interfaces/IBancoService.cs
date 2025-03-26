using BoletoAPI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoletoAPI.Application.Services.Interfaces
{
    public interface IBancoService
    {
        Task<IEnumerable<BancoDto>> GetAllBancosAsync();
        Task<BancoDto?> GetBancoByIdAsync(int id);
        Task<BancoDto?> GetBancoByCodigoAsync(string codigo);
        Task<BancoDto> CreateBancoAsync(BancoDto bancoDto);
    }
}

