using SAV.ViewModels;
using SAV.Views;
using System.Windows;
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