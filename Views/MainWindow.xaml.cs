using SAV.Models;
using SAV.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SAV
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MinhasVias = new ObservableCollection<Via>();

            if (Properties.Settings.Default.TemaEscuro)
            {
                var conversorBrush = new BrushConverter();

                Application.Current.Resources["corDestaquePrimaria"] = (Brush)conversorBrush.ConvertFrom("#1B1B1B")!;
                Application.Current.Resources["corDestaqueSecundaria"] = (Brush)conversorBrush.ConvertFrom("#F5F5F5")!;
                Application.Current.Resources["corDestaqueTerciaria"] = (Brush)conversorBrush.ConvertFrom("#292929")!;
                Application.Current.Resources["corFonte"] = (Brush)conversorBrush.ConvertFrom("#F5F5F5")!;
            }
        }

        public ObservableCollection<Via> MinhasVias { get; set; }

        private Via _viaSelecionada;
        public Via ViaSelecionada
        {
            get => _viaSelecionada;
            set { _viaSelecionada = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void AbrirConfiguracoes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ConfiguracoesWindow configuracoes = new ConfiguracoesWindow();
                configuracoes.Owner = this;
                configuracoes.ShowDialog();
            }
        }

        private void Via_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var polyline = sender as Polyline;
            var via = polyline.DataContext as Via;
            ViaSelecionada = via; // Coloca a via no painel lateral
        }

        // Mude de BotaoAbrir_Click para AbrirMapa_MouseDown
        private void AbrirMapa_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Criamos o explorador de arquivos do Windows
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Arquivos JSON (*.json)|*.json";

            if (openFileDialog.ShowDialog() == true)
            {

                // 2. Chamamos a função de ler o arquivo (aquela que usa o Newtonsoft.Json)
                // Se você ainda não criou a função AbrirMapa na ViewModel, 
                // use o código abaixo para teste rápido:
                var pontos = new PointCollection {
                    new Point(300, 100),
                    new Point(400, 200),
                    new Point(500, 100),
                    new Point(550, 200),
                    new Point(600, 100),
                    new Point(720, 200),
                    new Point(800, 100),
                    new Point(820, 200)
                };

                MinhasVias.Add(new Via
                {
                    Nome = "Rua Importada",
                    Velocidade = 60,
                    Pontos = pontos
                });
            }
        }
    }
}