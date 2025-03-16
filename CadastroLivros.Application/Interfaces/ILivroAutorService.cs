using CadastroLivros.Domain.Entities;

namespace CadastroLivros.Application.Interfaces
{
    public interface ILivroAutorService
    {
        Task AdicionarLivroAutorAsync(LivroAutor livroAutor);
        Task<List<LivroAutor>> ObterTodosLivrosAutoresAsync();
        Task<LivroAutor> ObterLivroAutorPorIdsAsync(int livroId, int autorId);
        Task<LivroAutor> RemoverLivroAutorAsync(int livroId, int autorId);
    }

}
