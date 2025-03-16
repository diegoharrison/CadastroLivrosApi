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

        // GET: api/Assuntos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssuntoDto>>> GetAssuntos()
        {
            var assuntos = await _assuntoService.GetAssuntosAsync();
            return Ok(assuntos);
        }

        // GET: api/Assuntos/5
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

        // POST: api/Assuntos
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

        // PUT: api/Assuntos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssunto(int id, AssuntoRequest assuntoRequest)
        {
            var assuntoDto = new AssuntoDto
            {
                Id = id,  // O ID é obtido da URL (da requisição PUT)
                Descricao = assuntoRequest.Descricao
            };

            await _assuntoService.UpdateAssuntoAsync(assuntoDto);

            return NoContent();
        }

        // DELETE: api/Assuntos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssunto(int id)
        {
            await _assuntoService.DeleteAssuntoAsync(id);
            return NoContent();
        }
    }
}
