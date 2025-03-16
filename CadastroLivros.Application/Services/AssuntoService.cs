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

        // Obter todos os assuntos
        public async Task<IEnumerable<AssuntoDto>> GetAssuntosAsync()
        {
            var assuntos = await _assuntoRepository.GetAssuntosAsync();
            return assuntos.Select(a => new AssuntoDto
            {
                Id = a.Id,
                Descricao = a.Descricao
            });
        }

        // Obter um assunto específico por ID
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

        // Adicionar um novo assunto
        public async Task AddAssuntoAsync(AssuntoDto assuntoDto)
        {
            var assunto = new Assunto
            {
                Descricao = assuntoDto.Descricao
            };

            await _assuntoRepository.AddAssuntoAsync(assunto);
        }

        // Atualizar um assunto existente
        public async Task UpdateAssuntoAsync(AssuntoDto assuntoDto)
        {
            var assunto = new Assunto
            {
                Id = assuntoDto.Id,
                Descricao = assuntoDto.Descricao
            };

            await _assuntoRepository.UpdateAssuntoAsync(assunto);
        }

        // Excluir um assunto
        public async Task DeleteAssuntoAsync(int id)
        {
            await _assuntoRepository.DeleteAssuntoAsync(id);
        }
    }
}
