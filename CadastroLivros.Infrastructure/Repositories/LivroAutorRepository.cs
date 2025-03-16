using CadastroLivros.Domain.Entities;
using CadastroLivros.Infrastructure.Data;
using CadastroLivros.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class LivroAutorRepository : ILivroAutorRepository
{
    private readonly ApplicationDbContext _context;

    public LivroAutorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarLivroAutorAsync(LivroAutor livroAutor)
    {
        _context.LivroAutores.Add(livroAutor);
        await _context.SaveChangesAsync();
    }

    public async Task<List<LivroAutor>> ObterTodosLivrosAutoresAsync()
    {
        return await _context.LivroAutores
            .Include(la => la.Livro)
            .Include(la => la.Autor)
            .ToListAsync();
    }

    public async Task<LivroAutor> ObterLivroAutorPorIdsAsync(int livroId, int autorId)
    {
        return await _context.LivroAutores
            .Include(la => la.Livro)
            .Include(la => la.Autor)
            .FirstOrDefaultAsync(la => la.LivroId == livroId && la.AutorId == autorId);
    }

    public async Task<LivroAutor> RemoverLivroAutorAsync(int livroId, int autorId)
    {
        var livroAutor = await _context.LivroAutores
            .FirstOrDefaultAsync(la => la.LivroId == livroId && la.AutorId == autorId);

        if (livroAutor != null)
        {
            _context.LivroAutores.Remove(livroAutor);
            await _context.SaveChangesAsync();
        }

        return livroAutor;
    }
}
