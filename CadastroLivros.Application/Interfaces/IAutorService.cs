using CadastroLivros.Application.Dtos;

namespace CadastroLivrosAPI.Application.Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<AutorDto>> GetAutoresAsync();
        Task<AutorDto> GetAutorByIdAsync(int id);
        Task AddAutorAsync(AutorDto autorDto);
        Task UpdateAutorAsync(AutorDto autorDto);
        Task DeleteAutorAsync(int id);
    }
}
