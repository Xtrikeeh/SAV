using Microsoft.Win32;
using SAV.ViewModels;
using SAV.Views;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SAV
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel => (MainWindowViewModel)this.DataContext;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        // Abrir menu do projeto
        private void AbrirMenuProjeto_MouseDown(object sender, EventArgs e)
        {
            TextBlock botaoProjeto = sender as TextBlock;
            botaoProjeto.ContextMenu.IsEnabled = true;
            botaoProjeto.ContextMenu.PlacementTarget = botaoProjeto;
            botaoProjeto.ContextMenu.IsOpen = true;
        }

        // Opção escolhida no projeto
        private void OpcaoProjeto_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem item)
            {
                string valorTag = item.Tag.ToString();

                if (valorTag == "AbrirProjeto")
                {
                    OpenFileDialog seletor = new OpenFileDialog();
                    seletor.Filter = "Arquivos JSON (*.json)|*.json|Todos os arquivos (*.*)|*.*";
                    seletor.Title = "Selecione um projeto";

                    if (seletor.ShowDialog() == true)
                    {
                        // 3. Pega o caminho completo do arquivo selecionado
                        string caminhoDoArquivo = seletor.FileName;

                        // 4. Lê o texto bruto de dentro do arquivo
                        string conteudoJson = File.ReadAllText(caminhoDoArquivo);
                    }
                }
                else if (valorTag == "NovoProjeto")
                {
                    NovoProjetoWindow NovoProjeto = new NovoProjetoWindow();
                    NovoProjeto.Owner = this;
                    NovoProjeto.ShowDialog();
                }
            }
        }

        // Abrir janela de configurações
        private void AbrirConfiguracoes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ConfiguracoesWindow Configuracoes = new ConfiguracoesWindow();
                Configuracoes.Owner = this;
                Configuracoes.ShowDialog();
            }
        }
    }
}