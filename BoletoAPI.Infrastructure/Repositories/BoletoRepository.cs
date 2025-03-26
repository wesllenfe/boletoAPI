using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using BoletoAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BoletoAPI.Infrastructure.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly AppDbContext _context;
        
        public BoletoRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<Boleto?> GetByIdAsync(int id)
        {
            return await _context.Boletos
                .Include(b => b.Banco)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        
        public async Task<Boleto> AddAsync(Boleto boleto)
        {
            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();
            return boleto;
        }
    }
}

