using CadastroLivros.Domain.Entities;
using CadastroLivros.Domain.Interfaces;
using CadastroLivros.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivrosAPI.Infrastructure.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ApplicationDbContext _context;

        public AutorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> GetAutoresAsync()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autor> GetAutorByIdAsync(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task AddAutorAsync(Autor autor)
        {
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAutorAsync(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAutorAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
