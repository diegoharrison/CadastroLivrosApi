using CadastroLivros.Domain.Entities;

namespace CadastroLivros.Infrastructure.Repositories
{
    public interface ILivroAssuntoRepository
    {
        Task AdicionarLivroAssuntoAsync(LivroAssunto livroAssunto);
        Task<List<LivroAssunto>> ObterTodosLivrosAssuntosAsync();
        Task<LivroAssunto> ObterLivroAssuntoPorIdsAsync(int livroId, int assuntoId);
        Task<LivroAssunto> RemoverLivroAssuntoAsync(int livroId, int assuntoId);
    }
}
