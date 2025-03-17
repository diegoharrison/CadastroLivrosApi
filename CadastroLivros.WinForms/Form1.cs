namespace CadastroLivros.WinForms;

public partial class FormRelatorio : Form
{
    private readonly RelatorioService _relatorioService;

    // Construtor com inje��o de depend�ncia para o RelatorioService
    public FormRelatorio(RelatorioService relatorioService)
    {
        InitializeComponent();
        _relatorioService = relatorioService;
    }

    // Evento de carregamento do formul�rio
    private void FormRelatorio_Load(object sender, EventArgs e)
    {
        try
        {
            // Chama o m�todo para gerar os dados do relat�rio
            var reportDataSource = _relatorioService.GerarRelatorioLivrosPorAutor();

            // Limpa os DataSources anteriores e adiciona o novo
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Define o caminho do relat�rio, se necess�rio
            // reportViewer1.LocalReport.ReportPath = "Caminho do seu arquivo .rdlc";

            // Carrega e exibe o relat�rio
            reportViewer1.RefreshReport();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao gerar o relat�rio: {ex.Message}");
        }
    }
}
