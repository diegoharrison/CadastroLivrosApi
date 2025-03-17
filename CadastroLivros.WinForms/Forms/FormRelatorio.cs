//using System;
//using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
//using CadastroLivros.WinForms.Relatorios;
//using Microsoft.Reporting.WebForms;

//namespace CadastroLivros.WinForms.Forms
//{
//    public partial class FormRelatorio : Form
//    {
//        private readonly RelatorioService _relatorioService;

//        // Construtor com injeção de dependência para o RelatorioService
//        public FormRelatorio(RelatorioService relatorioService)
//        {
//            InitializeComponent(); // Chamando o método que inicializa os componentes
//            _relatorioService = relatorioService;
//        }

//        // Evento de carregamento do formulário
//        private void FormRelatorio_Load(object sender, EventArgs e)
//        {
//            try
//            {
//                // Chama o método para gerar os dados do relatório
//                var reportDataSource = _relatorioService.GerarRelatorioLivrosPorAutor();

//                // Limpa os DataSources anteriores e adiciona o novo
//                reportViewer1.LocalReport.DataSources.Clear();
//                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

//                // Define o caminho do relatório, se necessário
//                // reportViewer1.LocalReport.ReportPath = "Caminho do seu arquivo .rdlc";

//                // Carrega e exibe o relatório
//                reportViewer1.RefreshReport();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Erro ao gerar o relatório: {ex.Message}");
//            }
//        }
//    }
//}
