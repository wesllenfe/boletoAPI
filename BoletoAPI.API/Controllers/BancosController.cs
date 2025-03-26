using BoletoAPI.Application.DTOs;
using BoletoAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoletoAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BancosController : ControllerBase
    {
        private readonly IBancoService _bancoService;
        
        public BancosController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }
        
        /// <summary>
        /// Obtém todos os bancos cadastrados
        /// </summary>
        /// <returns>Lista de bancos</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BancoDto>), 200)]
        public async Task<ActionResult<IEnumerable<BancoDto>>> GetAll()
        {
            var bancos = await _bancoService.GetAllBancosAsync();
            return Ok(bancos);
        }
        
        /// <summary>
        /// Obtém um banco pelo seu código
        /// </summary>
        /// <param name="codigo">Código do banco</param>
        /// <returns>Dados do banco</returns>
        [HttpGet("codigo/{codigo}")]
        [ProducesResponseType(typeof(BancoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BancoDto>> GetByCode(string codigo)
        {
            var banco = await _bancoService.GetBancoByCodigoAsync(codigo);
            
            if (banco == null)
                return NotFound($"Banco com código {codigo} não encontrado.");
                
            return Ok(banco);
        }
        
        /// <summary>
        /// Cadastra um novo banco
        /// </summary>
        /// <param name="bancoDto">Dados do banco</param>
        /// <returns>Banco cadastrado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BancoDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BancoDto>> Create(BancoDto bancoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var createdBanco = await _bancoService.CreateBancoAsync(bancoDto);
            
            return CreatedAtAction(
                nameof(GetByCode),
                new { codigo = createdBanco.Codigo },
                createdBanco);
        }
    }
}

