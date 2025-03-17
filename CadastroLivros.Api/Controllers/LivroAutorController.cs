using CadastroLivros.Application.Dtos;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LivroAutorController : ControllerBase
{
    private readonly ILivroAutorService _livroAutorService;

    public LivroAutorController(ILivroAutorService livroAutorService)
    {
        _livroAutorService = livroAutorService;
    }

    [HttpPost]
    public async Task<ActionResult> PostLivroAutor(LivroAutorDto livroAutorDTO)
    {
        var livroAutor = new LivroAutor
        {
            LivroId = livroAutorDTO.LivroId,
            AutorId = livroAutorDTO.AutorId
        };

        await _livroAutorService.AdicionarLivroAutorAsync(livroAutor);

        return CreatedAtAction(nameof(GetLivroAutor), new { livroId = livroAutor.LivroId, autorId = livroAutor.AutorId }, livroAutor);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivroAutorDto>>> GetLivroAutores()
    {
        var livroAutores = await _livroAutorService.ObterTodosLivrosAutoresAsync();

        if (livroAutores == null || livroAutores.Count == 0)
        {
            return NotFound("Não há associações de livros e autores.");
        }

        return Ok(livroAutores.Select(la => new { la.LivroId, la.AutorId }));
    }

    [HttpGet("{livroId}/{autorId}")]
    public async Task<ActionResult<LivroAutorDto>> GetLivroAutor(int livroId, int autorId)
    {
        var livroAutor = await _livroAutorService.ObterLivroAutorPorIdsAsync(livroId, autorId);

        if (livroAutor == null)
        {
            return NotFound("Associação entre o livro e o autor não encontrada.");
        }

        return Ok(new { livroAutor.LivroId, livroAutor.AutorId });
    }

    [HttpDelete("{livroId}/{autorId}")]
    public async Task<IActionResult> DeleteLivroAutor(int livroId, int autorId)
    {
        var livroAutor = await _livroAutorService.RemoverLivroAutorAsync(livroId, autorId);
        if (livroAutor == null)
        {
            return NotFound("Associação entre o livro e o autor não encontrada.");
        }

        return NoContent();
    }
}
