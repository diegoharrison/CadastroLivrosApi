using CadastroLivrosAPI.Application.Interfaces;
using CadastroLivros.Application.Dtos;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Domain.Interfaces;

namespace CadastroLivrosAPI.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<LivroDto>> GetLivrosAsync()
        {
            var livros = await _livroRepository.GetLivrosAsync();
            return livros.Select(l => new LivroDto
            {
                Id = l.Id,
                Titulo = l.Titulo,
                DataPublicacao = l.DataPublicacao,
                Valor = l.Valor,
                FormaCompra = l.FormaCompra
            });
        }

        public async Task<LivroDto> GetLivroByIdAsync(int id)
        {
            var livro = await _livroRepository.GetLivroByIdAsync(id);
            if (livro == null) return null;

            return new LivroDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                DataPublicacao = livro.DataPublicacao,
                Valor = livro.Valor,
                FormaCompra = livro.FormaCompra
            };
        }

        public async Task AddLivroAsync(LivroDto livroDto)
        {
            var livro = new Livro
            {
                Titulo = livroDto.Titulo,
                DataPublicacao = livroDto.DataPublicacao,
                Valor = livroDto.Valor,
                FormaCompra = livroDto.FormaCompra
            };

            await _livroRepository.AddLivroAsync(livro);
        }

        public async Task UpdateLivroAsync(LivroDto livroDto)
        {
            var livro = new Livro
            {
                Id = livroDto.Id,
                Titulo = livroDto.Titulo,
                DataPublicacao = livroDto.DataPublicacao,
                Valor = livroDto.Valor,
                FormaCompra = livroDto.FormaCompra
            };

            await _livroRepository.UpdateLivroAsync(livro);
        }

        public async Task DeleteLivroAsync(int id)
        {
            await _livroRepository.DeleteLivroAsync(id);
        }
    }
}
