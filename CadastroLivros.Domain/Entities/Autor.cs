namespace CadastroLivros.Domain.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<LivroAutor> LivroAutores { get; set; }
    }
}
