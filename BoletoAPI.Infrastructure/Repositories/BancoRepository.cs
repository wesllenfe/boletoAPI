using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using BoletoAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoletoAPI.Infrastructure.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly AppDbContext _context;
        
        public BancoRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Banco>> GetAllAsync()
        {
            return await _context.Bancos.ToListAsync();
        }
        
        public async Task<Banco?> GetByIdAsync(int id)
        {
            return await _context.Bancos.FindAsync(id);
        }
        
        public async Task<Banco?> GetByCodigoAsync(string codigo)
        {
            return await _context.Bancos.FirstOrDefaultAsync(b => b.Codigo == codigo);
        }
        
        public async Task<Banco> AddAsync(Banco banco)
        {
            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();
            return banco;
        }
        
        public async Task<bool> BancoExistsAsync(int id)
        {
            return await _context.Bancos.AnyAsync(b => b.Id == id);
        }
    }
}

