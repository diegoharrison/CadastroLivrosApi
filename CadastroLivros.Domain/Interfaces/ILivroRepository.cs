using CadastroLivros.Domain.Entities;

namespace CadastroLivros.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetLivrosAsync();
        Task<Livro> GetLivroByIdAsync(int id); 
        Task AddLivroAsync(Livro livro); 
        Task UpdateLivroAsync(Livro livro); 
        Task DeleteLivroAsync(int id); 
    }
}
