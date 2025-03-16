using CadastroLivros.Application.Interfaces;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Infrastructure.Repositories;

public class LivroAutorService : ILivroAutorService
{
    private readonly ILivroAutorRepository _livroAutorRepository;

    public LivroAutorService(ILivroAutorRepository livroAutorRepository)
    {
        _livroAutorRepository = livroAutorRepository;
    }

    public async Task AdicionarLivroAutorAsync(LivroAutor livroAutor)
    {
        await _livroAutorRepository.AdicionarLivroAutorAsync(livroAutor);
    }

    public async Task<List<LivroAutor>> ObterTodosLivrosAutoresAsync()
    {
        return await _livroAutorRepository.ObterTodosLivrosAutoresAsync();
    }

    public async Task<LivroAutor> ObterLivroAutorPorIdsAsync(int livroId, int autorId)
    {
        return await _livroAutorRepository.ObterLivroAutorPorIdsAsync(livroId, autorId);
    }

    public async Task<LivroAutor> RemoverLivroAutorAsync(int livroId, int autorId)
    {
        return await _livroAutorRepository.RemoverLivroAutorAsync(livroId, autorId);
    }
}
