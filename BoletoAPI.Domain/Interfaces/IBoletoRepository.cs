using BoletoAPI.Domain.Entities;
using System.Threading.Tasks;

namespace BoletoAPI.Domain.Interfaces
{
    public interface IBoletoRepository
    {
        Task<Boleto?> GetByIdAsync(int id);
        Task<Boleto> AddAsync(Boleto boleto);
    }
}

