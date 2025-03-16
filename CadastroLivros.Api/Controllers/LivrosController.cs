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

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDto>>> GetLivros()
        {
            var livros = await _livroService.GetLivrosAsync();
            return Ok(livros);
        }

        // GET: api/Livros/5
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

        // POST: api/Livros
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

        // PUT: api/Livros/5
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

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            await _livroService.DeleteLivroAsync(id);
            return NoContent();
        }
    }
}
