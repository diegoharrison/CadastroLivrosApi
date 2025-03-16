using CadastroLivros.Domain.Entities;
using CadastroLivros.Domain.Interfaces;
using CadastroLivros.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivrosAPI.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDbContext _context;

        public LivroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para obter todos os livros
        public async Task<IEnumerable<Livro>> GetLivrosAsync()
        {
            return await _context.Livros
                .Include(l => l.LivroAutores).ThenInclude(la => la.Autor)
                .Include(l => l.LivroAssuntos).ThenInclude(la => la.Assunto)
                .ToListAsync();
        }

        // Método para obter um livro por ID
        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            return await _context.Livros
                .Include(l => l.LivroAutores).ThenInclude(la => la.Autor)
                .Include(l => l.LivroAssuntos).ThenInclude(la => la.Assunto)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        // Método para adicionar um novo livro
        public async Task AddLivroAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
        }

        // Método para atualizar um livro existente
        public async Task UpdateLivroAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }

        // Método para excluir um livro por ID
        public async Task DeleteLivroAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
