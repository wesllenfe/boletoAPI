using AutoMapper;
using BoletoAPI.Application.DTOs;
using BoletoAPI.Application.Services.Interfaces;
using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using System.Threading.Tasks;

namespace BoletoAPI.Application.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IBoletoRepository _boletoRepository;
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;
        
        public BoletoService(
            IBoletoRepository boletoRepository,
            IBancoRepository bancoRepository,
            IMapper mapper)
        {
            _boletoRepository = boletoRepository;
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }
        
        public async Task<BoletoResponseDto?> GetBoletoByIdAsync(int id)
        {
            var boleto = await _boletoRepository.GetByIdAsync(id);
            return boleto != null ? _mapper.Map<BoletoResponseDto>(boleto) : null;
        }
        
        public async Task<BoletoDto> CreateBoletoAsync(BoletoDto boletoDto)
        {
            // Verify if the bank exists
            var bancoExists = await _bancoRepository.BancoExistsAsync(boletoDto.BancoId);
            if (!bancoExists)
            {
                throw new System.Exception($"Banco com ID {boletoDto.BancoId} não encontrado.");
            }
            
            var boleto = _mapper.Map<Boleto>(boletoDto);
            var createdBoleto = await _boletoRepository.AddAsync(boleto);
            return _mapper.Map<BoletoDto>(createdBoleto);
        }
    }
}

