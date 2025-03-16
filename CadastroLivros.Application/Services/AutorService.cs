using CadastroLivrosAPI.Application.Interfaces;
using CadastroLivros.Application.Dtos;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Domain.Interfaces;

namespace CadastroLivrosAPI.Application.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        // Obter todos os autores
        public async Task<IEnumerable<AutorDto>> GetAutoresAsync()
        {
            var autores = await _autorRepository.GetAutoresAsync();
            return autores.Select(a => new AutorDto
            {
                Id = a.Id,
                Nome = a.Nome
            });
        }

        // Obter um autor específico por ID
        public async Task<AutorDto> GetAutorByIdAsync(int id)
        {
            var autor = await _autorRepository.GetAutorByIdAsync(id);
            if (autor == null) return null;

            return new AutorDto
            {
                Id = autor.Id,
                Nome = autor.Nome
            };
        }

        // Adicionar um novo autor
        public async Task AddAutorAsync(AutorDto autorDto)
        {
            var autor = new Autor
            {
                Nome = autorDto.Nome
            };

            await _autorRepository.AddAutorAsync(autor);
        }

        // Atualizar um autor existente
        public async Task UpdateAutorAsync(AutorDto autorDto)
        {
            var autor = new Autor
            {
                Id = autorDto.Id,
                Nome = autorDto.Nome
            };

            await _autorRepository.UpdateAutorAsync(autor);
        }

        // Excluir um autor
        public async Task DeleteAutorAsync(int id)
        {
            await _autorRepository.DeleteAutorAsync(id);
        }
    }
}
