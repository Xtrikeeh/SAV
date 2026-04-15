using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SAV.Views
{
    public partial class ConfiguracoesWindow : Window
    {
        public ConfiguracoesWindow()
        {
            InitializeComponent();

            inicializarConfiguracoes();
        }

        // Botão trocar tema
        private void trocarTema_Checked(object sender, EventArgs e)
        {
            if (trocarTema.Content == "Claro")
            {
                var conversorBrush = new BrushConverter();

                Application.Current.Resources["corDestaquePrimaria"] = (Brush)conversorBrush.ConvertFrom("#1B1B1B")!;
                Application.Current.Resources["corDestaqueSecundaria"] = (Brush)conversorBrush.ConvertFrom("#F5F5F5")!;
                Application.Current.Resources["corDestaqueTerciaria"] = (Brush)conversorBrush.ConvertFrom("#292929")!;
                Application.Current.Resources["corFonte"] = (Brush)conversorBrush.ConvertFrom("#F5F5F5")!;
                trocarTema.Content = "Escuro";

                Properties.Settings.Default.TemaEscuro = true;
                Properties.Settings.Default.Save();
            }
        }

        private void trocarTema_Unchecked(object sender, EventArgs e)
        {
            if (trocarTema.Content == "Escuro")
            {
                var conversorBrush = new BrushConverter();

                Application.Current.Resources["corDestaquePrimaria"] = (Brush)conversorBrush.ConvertFrom("#F5F5F5")!;
                Application.Current.Resources["corDestaqueSecundaria"] = (Brush)conversorBrush.ConvertFrom("#1B1B1B")!;
                Application.Current.Resources["corDestaqueTerciaria"] = (Brush)conversorBrush.ConvertFrom("#D4D4D4")!;
                Application.Current.Resources["corFonte"] = (Brush)conversorBrush.ConvertFrom("#1C2639")!;
                trocarTema.Content = "Claro";

                Properties.Settings.Default.TemaEscuro = false;
                Properties.Settings.Default.Save();
            }
        }

        // Botão opções salvamento automático
        private void botaoSalvamentoAutomatico_Click(object sender, EventArgs e)
        {
            Button botaoSalvamento = sender as Button;
            botaoSalvamento.ContextMenu.IsEnabled = true;
            botaoSalvamento.ContextMenu.PlacementTarget = botaoSalvamento;
            botaoSalvamento.ContextMenu.IsOpen = true;
        }

        private void opcaoSalvamentoAutomatico_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            string opcao = item.Tag.ToString()!;

            if (opcao == "5")
            {
                Properties.Settings.Default.TempoSalvamento = 5;
                Properties.Settings.Default.Save();
            } 
            else if (opcao == "10")
            {
                Properties.Settings.Default.TempoSalvamento = 10;
                Properties.Settings.Default.Save();
            }
            else if (opcao == "15")
            {
                Properties.Settings.Default.TempoSalvamento = 15;
                Properties.Settings.Default.Save();
            }
            else if (opcao == "30")
            {
                Properties.Settings.Default.TempoSalvamento = 30;
                Properties.Settings.Default.Save();
            }
            else if (opcao == "Nunca")
            {
                Properties.Settings.Default.TempoSalvamento = 0;
                Properties.Settings.Default.Save();
            }

            int tempoSalvamento = Properties.Settings.Default.TempoSalvamento;

            if (tempoSalvamento == 0)
            {
                botaoSalvamento.Content = "Nunca";
            }
            else
            {
                botaoSalvamento.Content = $"{tempoSalvamento.ToString()} minutos";
            }
        }

        private void inicializarConfiguracoes()
        {
            bool temaEscuro = Properties.Settings.Default.TemaEscuro;
            int tempoSalvamento = Properties.Settings.Default.TempoSalvamento;
            string diretorioPadrao = Properties.Settings.Default.DiretorioPadrao;

            if (tempoSalvamento == 0)
            {
                botaoSalvamento.Content = "Nunca";
            }
            else
            {
                botaoSalvamento.Content = $"{tempoSalvamento.ToString()} minutos";
            }

            trocarTema.IsChecked = temaEscuro;

            trocarTema.Content = temaEscuro ? "Escuro" : "Claro";

            textoDiretorio.Text = diretorioPadrao;
        }

        private void botaoCaminho_Click(object sender, EventArgs e)
        {
            OpenFolderDialog selecionarPasta = new OpenFolderDialog();
            selecionarPasta.Title = "Selecione o diretório padrão";

            if (selecionarPasta.ShowDialog() == true)
            {
                string pastaSelecionada = selecionarPasta.FolderName;

                Properties.Settings.Default.DiretorioPadrao = pastaSelecionada;
                Properties.Settings.Default.Save();

                textoDiretorio.Text = pastaSelecionada;
            }
        }
    }
}
