namespace CadastroLivros.Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public decimal Valor { get; set; }
        public string FormaCompra { get; set; }
        public List<LivroAutor> LivroAutores { get; set; }
        public List<LivroAssunto> LivroAssuntos { get; set; }
    }
}
