namespace CadastroLivros.Application.Dtos
{
    public class LivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public decimal Valor { get; set; }
        public string FormaCompra { get; set; }
    }
}
