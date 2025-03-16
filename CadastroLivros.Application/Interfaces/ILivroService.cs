using CadastroLivros.Application.Dtos;

namespace CadastroLivrosAPI.Application.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroDto>> GetLivrosAsync(); 
        Task<LivroDto> GetLivroByIdAsync(int id); 
        Task AddLivroAsync(LivroDto livroDto); 
        Task UpdateLivroAsync(LivroDto livroDto); 
        Task DeleteLivroAsync(int id); 
    }
}
