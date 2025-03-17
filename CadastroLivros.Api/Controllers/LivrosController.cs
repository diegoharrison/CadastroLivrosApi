using CadastroLivrosAPI.Application.Interfaces;
using CadastroLivrosAPI.API.Models;
using Microsoft.AspNetCore.Mvc;
using CadastroLivros.Application.Dtos;

namespace CadastroLivrosAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDto>>> GetLivros()
        {
            var livros = await _livroService.GetLivrosAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDto>> GetLivro(int id)
        {
            var livro = await _livroService.GetLivroByIdAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<LivroDto>> PostLivro(LivroRequest livroRequest)
        {
            var livroDto = new LivroDto
            {
                Titulo = livroRequest.Titulo,
                DataPublicacao = livroRequest.DataPublicacao,
                Valor = livroRequest.Valor,
                FormaCompra = livroRequest.FormaCompra
            };

            await _livroService.AddLivroAsync(livroDto);
            return CreatedAtAction("GetLivro", new { id = livroDto.Id }, livroDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, LivroRequest livroRequest)
        {
            var livroDto = new LivroDto
            {
                Id = id,  
                Titulo = livroRequest.Titulo,
                DataPublicacao = livroRequest.DataPublicacao,
                Valor = livroRequest.Valor,
                FormaCompra = livroRequest.FormaCompra
            };

            await _livroService.UpdateLivroAsync(livroDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            await _livroService.DeleteLivroAsync(id);
            return NoContent();
        }
    }
}
