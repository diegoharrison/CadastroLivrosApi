using CadastroLivrosAPI.Application.Interfaces;
using CadastroLivros.Application.Dtos;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Domain.Interfaces;

namespace CadastroLivrosAPI.Application.Services
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IAssuntoRepository _assuntoRepository;

        public AssuntoService(IAssuntoRepository assuntoRepository)
        {
            _assuntoRepository = assuntoRepository;
        }

        public async Task<IEnumerable<AssuntoDto>> GetAssuntosAsync()
        {
            var assuntos = await _assuntoRepository.GetAssuntosAsync();
            return assuntos.Select(a => new AssuntoDto
            {
                Id = a.Id,
                Descricao = a.Descricao
            });
        }

        public async Task<AssuntoDto> GetAssuntoByIdAsync(int id)
        {
            var assunto = await _assuntoRepository.GetAssuntoByIdAsync(id);
            if (assunto == null) return null;

            return new AssuntoDto
            {
                Id = assunto.Id,
                Descricao = assunto.Descricao
            };
        }

        public async Task AddAssuntoAsync(AssuntoDto assuntoDto)
        {
            var assunto = new Assunto
            {
                Descricao = assuntoDto.Descricao
            };

            await _assuntoRepository.AddAssuntoAsync(assunto);
        }

        public async Task UpdateAssuntoAsync(AssuntoDto assuntoDto)
        {
            var assunto = new Assunto
            {
                Id = assuntoDto.Id,
                Descricao = assuntoDto.Descricao
            };

            await _assuntoRepository.UpdateAssuntoAsync(assunto);
        }

        public async Task DeleteAssuntoAsync(int id)
        {
            await _assuntoRepository.DeleteAssuntoAsync(id);
        }
    }
}
