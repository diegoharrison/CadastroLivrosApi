namespace CadastroLivros.Domain.Entities
{
    public class LivroAssunto
    {
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int AssuntoId { get; set; }
        public Assunto Assunto { get; set; }
    }
}
