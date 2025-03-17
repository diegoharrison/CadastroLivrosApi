using Moq;
using Xunit;
using CadastroLivros.Domain.Entities;
using CadastroLivros.Domain.Interfaces;
using CadastroLivrosAPI.Application.Interfaces;
using CadastroLivrosAPI.Application.Services;
using CadastroLivros.Application.Dtos;

namespace CadastroLivros.Tests.Services
{
    public class LivroServiceTests
    {
        private readonly Mock<ILivroRepository> _livroRepositoryMock;
        private readonly ILivroService _livroService;

        public LivroServiceTests()
        {
            // Mock do repositório
            _livroRepositoryMock = new Mock<ILivroRepository>();
            // Instanciando o serviço
            _livroService = new LivroService(_livroRepositoryMock.Object);
        }

        [Fact]
        public async Task AdicionarLivro_AssociaLivroComSucesso()
        {
            // Arrange
            var livroDto = new LivroDto
            {
                Id = 1,
                Titulo = "Livro Teste",
                DataPublicacao = DateTime.Now,
                Valor = 30.00m,
                FormaCompra = "Balcão"
            };

            _livroRepositoryMock.Setup(repo => repo.AddLivroAsync(It.IsAny<Livro>())).Returns(Task.CompletedTask);

            // Act
            await _livroService.AddLivroAsync(livroDto);

            // Assert
            _livroRepositoryMock.Verify(repo => repo.AddLivroAsync(It.IsAny<Livro>()), Times.Once);
        }
    }
}
