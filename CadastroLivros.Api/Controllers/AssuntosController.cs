using CadastroLivrosAPI.Application.Interfaces;
using CadastroLivrosAPI.API.Models;
using Microsoft.AspNetCore.Mvc;
using CadastroLivros.Application.Dtos;

namespace CadastroLivrosAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntosController : ControllerBase
    {
        private readonly IAssuntoService _assuntoService;

        public AssuntosController(IAssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssuntoDto>>> GetAssuntos()
        {
            var assuntos = await _assuntoService.GetAssuntosAsync();
            return Ok(assuntos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssuntoDto>> GetAssunto(int id)
        {
            var assunto = await _assuntoService.GetAssuntoByIdAsync(id);
            if (assunto == null)
            {
                return NotFound();
            }
            return Ok(assunto);
        }

        [HttpPost]
        public async Task<ActionResult<AssuntoDto>> PostAssunto(AssuntoRequest assuntoRequest)
        {
            var assuntoDto = new AssuntoDto
            {
                Descricao = assuntoRequest.Descricao
            };

            await _assuntoService.AddAssuntoAsync(assuntoDto);
            return CreatedAtAction("GetAssunto", new { id = assuntoDto.Id }, assuntoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssunto(int id, AssuntoRequest assuntoRequest)
        {
            var assuntoDto = new AssuntoDto
            {
                Id = id,  
                Descricao = assuntoRequest.Descricao
            };

            await _assuntoService.UpdateAssuntoAsync(assuntoDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssunto(int id)
        {
            await _assuntoService.DeleteAssuntoAsync(id);
            return NoContent();
        }
    }
}
