using CadastroLivros.Domain.Entities;
using CadastroLivros.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Infrastructure.Repositories
{
    public class LivroAssuntoRepository : ILivroAssuntoRepository
    {
        private readonly ApplicationDbContext _context;

        public LivroAssuntoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarLivroAssuntoAsync(LivroAssunto livroAssunto)
        {
            _context.LivroAssuntos.Add(livroAssunto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LivroAssunto>> ObterTodosLivrosAssuntosAsync()
        {
            return await _context.LivroAssuntos
                .Include(la => la.Livro)
                .Include(la => la.Assunto)
                .ToListAsync();
        }

        public async Task<LivroAssunto> ObterLivroAssuntoPorIdsAsync(int livroId, int assuntoId)
        {
            return await _context.LivroAssuntos
                .FirstOrDefaultAsync(la => la.LivroId == livroId && la.AssuntoId == assuntoId);
        }

        public async Task<LivroAssunto> RemoverLivroAssuntoAsync(int livroId, int assuntoId)
        {
            var livroAssunto = await _context.LivroAssuntos
                .FirstOrDefaultAsync(la => la.LivroId == livroId && la.AssuntoId == assuntoId);

            if (livroAssunto != null)
            {
                _context.LivroAssuntos.Remove(livroAssunto);
                await _context.SaveChangesAsync();
            }

            return livroAssunto;
        }
    }
}
