//using Microsoft.Data.SqlClient;
//using Microsoft.Reporting.WinForms;
//using System.Data;

//namespace CadastroLivros.Api.Relatorios
//{
//    public class RelatorioService
//    {
//        private readonly IConfiguration _configuration;

//        // Injeção de dependência do IConfiguration
//        public RelatorioService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public ReportDataSource GerarRelatorioLivrosPorAutor()
//        {
//            // Obter a string de conexão do arquivo appsettings.json
//            string connectionString = _configuration.GetConnectionString("DefaultConnection");

//            using (var connection = new SqlConnection(connectionString))
//            {
//                // Comando SQL para consultar a view atualizada
//                var command = new SqlCommand("SELECT * FROM vw_LivrosRelatorio", connection);
//                var dataAdapter = new SqlDataAdapter(command);
//                var dataSet = new DataSet();

//                // Preencher o DataSet com os dados da view
//                dataAdapter.Fill(dataSet, "vw_LivrosRelatorio");

//                // Retorna a fonte de dados para o relatório
//                return new ReportDataSource("LivrosRelatorioDataSet", dataSet.Tables["vw_LivrosRelatorio"]);
//            }
//        }
//    }
//}
