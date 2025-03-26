using BoletoAPI.Application.DTOs;
using BoletoAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoletoAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletosController : ControllerBase
    {
        private readonly IBoletoService _boletoService;
        
        public BoletosController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }
        
        /// <summary>
        /// Obtém um boleto pelo seu ID
        /// </summary>
        /// <param name="id">ID do boleto</param>
        /// <returns>Dados do boleto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BoletoResponseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BoletoResponseDto>> GetById(int id)
        {
            var boleto = await _boletoService.GetBoletoByIdAsync(id);
            
            if (boleto == null)
                return NotFound($"Boleto com ID {id} não encontrado.");
                
            return Ok(boleto);
        }
        
        /// <summary>
        /// Cadastra um novo boleto
        /// </summary>
        /// <param name="boletoDto">Dados do boleto</param>
        /// <returns>Boleto cadastrado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BoletoDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BoletoDto>> Create(BoletoDto boletoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            try
            {
                var createdBoleto = await _boletoService.CreateBoletoAsync(boletoDto);
                
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdBoleto.Id },
                    createdBoleto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

