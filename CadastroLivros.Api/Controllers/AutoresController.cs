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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDto>>> GetAutores()
        {
            var autores = await _autorService.GetAutoresAsync();
            return Ok(autores);
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, AutorRequest autorRequest)
        {
            var autorDto = new AutorDto
            {
                Id = id,  
                Nome = autorRequest.Nome
            };

            await _autorService.UpdateAutorAsync(autorDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            await _autorService.DeleteAutorAsync(id);
            return NoContent();
        }
    }
}
