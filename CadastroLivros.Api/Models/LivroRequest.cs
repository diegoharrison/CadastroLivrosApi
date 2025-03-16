namespace CadastroLivrosAPI.API.Models
{
    public class LivroRequest
    {
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public decimal Valor { get; set; }
        public string FormaCompra { get; set; }
    }
}
