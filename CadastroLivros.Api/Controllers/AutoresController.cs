using CadastroLivrosAPI.Application.Interfaces;
using CadastroLivrosAPI.API.Models;
using Microsoft.AspNetCore.Mvc;
using CadastroLivros.Application.Dtos;

namespace CadastroLivrosAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDto>>> GetAutores()
        {
            var autores = await _autorService.GetAutoresAsync();
            return Ok(autores);
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutor(int id)
        {
            var autor = await _autorService.GetAutorByIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        // POST: api/Autores
        [HttpPost]
        public async Task<ActionResult<AutorDto>> PostAutor(AutorRequest autorRequest)
        {
            var autorDto = new AutorDto
            {
                Nome = autorRequest.Nome
            };

            await _autorService.AddAutorAsync(autorDto);
            return CreatedAtAction("GetAutor", new { id = autorDto.Id }, autorDto);
        }

        // PUT: api/Autores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, AutorRequest autorRequest)
        {
            var autorDto = new AutorDto
            {
                Id = id,  // O ID é obtido da URL (da requisição PUT)
                Nome = autorRequest.Nome
            };

            await _autorService.UpdateAutorAsync(autorDto);

            return NoContent();
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            await _autorService.DeleteAutorAsync(id);
            return NoContent();
        }
    }
}
