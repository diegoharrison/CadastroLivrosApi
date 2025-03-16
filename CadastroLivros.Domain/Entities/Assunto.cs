namespace CadastroLivros.Domain.Entities
{
    public class Assunto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<LivroAssunto> LivroAssuntos { get; set; }
    }
}
