using CadastroLivros.Application.Interfaces;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Infrastructure.Repositories;

namespace CadastroLivros.Application.Services
{
    public class LivroAssuntoService : ILivroAssuntoService
    {
        private readonly ILivroAssuntoRepository _livroAssuntoRepository;

        public LivroAssuntoService(ILivroAssuntoRepository livroAssuntoRepository)
        {
            _livroAssuntoRepository = livroAssuntoRepository;
        }

        public async Task AdicionarLivroAssuntoAsync(LivroAssunto livroAssunto)
        {
            await _livroAssuntoRepository.AdicionarLivroAssuntoAsync(livroAssunto);
        }

        public async Task<List<LivroAssunto>> ObterTodosLivrosAssuntosAsync()
        {
            return await _livroAssuntoRepository.ObterTodosLivrosAssuntosAsync();
        }

        public async Task<LivroAssunto> ObterLivroAssuntoPorIdsAsync(int livroId, int assuntoId)
        {
            return await _livroAssuntoRepository.ObterLivroAssuntoPorIdsAsync(livroId, assuntoId);
        }

        public async Task<LivroAssunto> RemoverLivroAssuntoAsync(int livroId, int assuntoId)
        {
            return await _livroAssuntoRepository.RemoverLivroAssuntoAsync(livroId, assuntoId);
        }
    }
}
