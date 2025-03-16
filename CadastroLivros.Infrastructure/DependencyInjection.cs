using CadastroLivros.Domain.Interfaces;
using CadastroLivrosAPI.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CadastroLivrosAPI.Application.Interfaces;
using CadastroLivrosAPI.Application.Services;
using CadastroLivros.Infrastructure.Repositories;
using CadastroLivros.Application.Interfaces;
using CadastroLivros.Application.Services;


namespace CadastroLivros.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // Registrar os Repositórios
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<ILivroAutorRepository, LivroAutorRepository>();
            services.AddScoped<ILivroAssuntoRepository, LivroAssuntoRepository>();

            // Registrar os Serviços
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IAssuntoService, AssuntoService>();
            services.AddScoped<ILivroAutorService, LivroAutorService>();
            services.AddScoped<ILivroAssuntoService, LivroAssuntoService>();
        }
    }
}
