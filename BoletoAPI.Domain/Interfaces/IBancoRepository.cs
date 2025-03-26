using BoletoAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoletoAPI.Domain.Interfaces
{
    public interface IBancoRepository
    {
        Task<IEnumerable<Banco>> GetAllAsync();
        Task<Banco?> GetByIdAsync(int id);
        Task<Banco?> GetByCodigoAsync(string codigo);
        Task<Banco> AddAsync(Banco banco);
        Task<bool> BancoExistsAsync(int id);
    }
}

