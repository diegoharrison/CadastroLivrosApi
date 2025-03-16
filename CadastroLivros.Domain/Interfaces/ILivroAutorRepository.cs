using CadastroLivros.Domain.Entities;

namespace CadastroLivros.Infrastructure.Repositories
{
    public interface ILivroAutorRepository
    {
        Task AdicionarLivroAutorAsync(LivroAutor livroAutor);
        Task<List<LivroAutor>> ObterTodosLivrosAutoresAsync();
        Task<LivroAutor> ObterLivroAutorPorIdsAsync(int livroId, int autorId);
        Task<LivroAutor> RemoverLivroAutorAsync(int livroId, int autorId);
    }

}
