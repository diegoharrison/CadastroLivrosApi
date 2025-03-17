using CadastroLivros.Application.Dtos;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LivroAssuntoController : ControllerBase
{
    private readonly ILivroAssuntoService _livroAssuntoService;

    public LivroAssuntoController(ILivroAssuntoService livroAssuntoService)
    {
        _livroAssuntoService = livroAssuntoService;
    }

    [HttpPost]
    public async Task<ActionResult> PostLivroAssunto(LivroAssuntoDto livroAssuntoDTO)
    {
        var livroAssunto = new LivroAssunto
        {
            LivroId = livroAssuntoDTO.LivroId,
            AssuntoId = livroAssuntoDTO.AssuntoId
        };

        await _livroAssuntoService.AdicionarLivroAssuntoAsync(livroAssunto);

        return CreatedAtAction(nameof(GetLivroAssunto), new { id = livroAssunto.LivroId }, livroAssunto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivroAssuntoDto>>> GetLivroAssuntos()
    {
        var livroAssuntos = await _livroAssuntoService.ObterTodosLivrosAssuntosAsync();

        if (livroAssuntos == null || livroAssuntos.Count == 0)
        {
            return NotFound("Não há associações de livros e assuntos.");
        }
       
        return Ok(livroAssuntos.Select(la => new { la.LivroId, la.AssuntoId }));
    }

    [HttpGet("{livroId}/{assuntoId}")]
    public async Task<ActionResult<LivroAssuntoDto>> GetLivroAssunto(int livroId, int assuntoId)
    {
        var livroAssunto = await _livroAssuntoService.ObterLivroAssuntoPorIdsAsync(livroId, assuntoId);

        if (livroAssunto == null)
        {
            return NotFound("Associação de Livro e Assunto não encontrada.");
        }
      
        return Ok(new { livroAssunto.LivroId, livroAssunto.AssuntoId });
    }

    
    [HttpDelete("{livroId}/{assuntoId}")]
    public async Task<IActionResult> DeleteLivroAssunto(int livroId, int assuntoId)
    {
        var livroAssunto = await _livroAssuntoService.RemoverLivroAssuntoAsync(livroId, assuntoId);
        if (livroAssunto == null)
        {
            return NotFound("Associação entre o livro e o assunto não encontrada.");
        }

        return NoContent();
    }
}
