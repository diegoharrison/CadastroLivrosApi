using CadastroLivros.Application.Dtos;

namespace CadastroLivrosAPI.Application.Interfaces
{
    public interface IAssuntoService
    {
        Task<IEnumerable<AssuntoDto>> GetAssuntosAsync();
        Task<AssuntoDto> GetAssuntoByIdAsync(int id);
        Task AddAssuntoAsync(AssuntoDto assuntoDto);
        Task UpdateAssuntoAsync(AssuntoDto assuntoDto);
        Task DeleteAssuntoAsync(int id);
    }
}
