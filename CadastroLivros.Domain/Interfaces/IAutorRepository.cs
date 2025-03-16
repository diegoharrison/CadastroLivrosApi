using CadastroLivros.Domain.Entities;

namespace CadastroLivros.Domain.Interfaces
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutoresAsync(); 
        Task<Autor> GetAutorByIdAsync(int id); 
        Task AddAutorAsync(Autor autor); 
        Task UpdateAutorAsync(Autor autor); 
        Task DeleteAutorAsync(int id); 
    }
}
