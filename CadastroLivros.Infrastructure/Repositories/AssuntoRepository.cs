using CadastroLivros.Domain.Entities;
using CadastroLivros.Domain.Interfaces;
using CadastroLivros.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivrosAPI.Infrastructure.Repositories
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private readonly ApplicationDbContext _context;

        public AssuntoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assunto>> GetAssuntosAsync()
        {
            return await _context.Assuntos.ToListAsync();
        }

        public async Task<Assunto> GetAssuntoByIdAsync(int id)
        {
            return await _context.Assuntos.FindAsync(id);
        }

        public async Task AddAssuntoAsync(Assunto assunto)
        {
            await _context.Assuntos.AddAsync(assunto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssuntoAsync(Assunto assunto)
        {
            _context.Assuntos.Update(assunto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssuntoAsync(int id)
        {
            var assunto = await _context.Assuntos.FindAsync(id);
            if (assunto != null)
            {
                _context.Assuntos.Remove(assunto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
