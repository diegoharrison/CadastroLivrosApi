using CadastroLivros.Domain.Entities;

namespace CadastroLivros.Domain.Interfaces
{
    public interface IAssuntoRepository
    {
        Task<IEnumerable<Assunto>> GetAssuntosAsync(); 
        Task<Assunto> GetAssuntoByIdAsync(int id); 
        Task AddAssuntoAsync(Assunto assunto); 
        Task UpdateAssuntoAsync(Assunto assunto); 
        Task DeleteAssuntoAsync(int id); 
    }
}
