using AutoMapper;
using BoletoAPI.Application.DTOs;
using BoletoAPI.Application.Services.Interfaces;
using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoletoAPI.Application.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;
        
        public BancoService(IBancoRepository bancoRepository, IMapper mapper)
        {
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<BancoDto>> GetAllBancosAsync()
        {
            var bancos = await _bancoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BancoDto>>(bancos);
        }
        
        public async Task<BancoDto?> GetBancoByIdAsync(int id)
        {
            var banco = await _bancoRepository.GetByIdAsync(id);
            return banco != null ? _mapper.Map<BancoDto>(banco) : null;
        }
        
        public async Task<BancoDto?> GetBancoByCodigoAsync(string codigo)
        {
            var banco = await _bancoRepository.GetByCodigoAsync(codigo);
            return banco != null ? _mapper.Map<BancoDto>(banco) : null;
        }
        
        public async Task<BancoDto> CreateBancoAsync(BancoDto bancoDto)
        {
            var banco = _mapper.Map<Banco>(bancoDto);
            var createdBanco = await _bancoRepository.AddAsync(banco);
            return _mapper.Map<BancoDto>(createdBanco);
        }
    }
}

