//using Microsoft.Extensions.DependencyInjection;
//using CadastroLivros.WinForms.Relatorios;
//using CadastroLivros.WinForms;
////using CadastroLivros.WinForms.Forms;

//internal static class Program
//{
//    [STAThread]
//    static void Main()
//    {
//        Application.EnableVisualStyles();
//        Application.SetCompatibleTextRenderingDefault(false);

//        // Cria��o do ServiceProvider
//        var serviceProvider = new ServiceCollection()
//            .AddScoped<RelatorioService>()   // Registrar o RelatorioService
//            .BuildServiceProvider();

//        // Obter a inst�ncia do Formul�rio com a depend�ncia injetada
//        //var formRelatorio = serviceProvider.GetService<FormRelatorio>();

//        // Rodar o formul�rio
//        //Application.Run(formRelatorio);
//    }
//}

