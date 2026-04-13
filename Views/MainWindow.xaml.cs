using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using SAV.Models;
using SAV.ViewModels;
using System.IO;
using System.Windows.Media;

namespace SAV
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(); // Liga o XAML à ViewModel
        }

        private void Via_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var polyline = sender as Polyline;
            var via = polyline.DataContext as Via;
            var vm = this.DataContext as MainViewModel;
            vm.ViaSelecionada = via; // Coloca a via no painel lateral
        }

        // Mude de BotaoAbrir_Click para AbrirMapa_MouseDown
        private void AbrirMapa_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Criamos o explorador de arquivos do Windows
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Arquivos JSON (*.json)|*.json";

            if (openFileDialog.ShowDialog() == true)
            {
                // 1. Pegamos a nossa ViewModel
                var viewModel = this.DataContext as MainViewModel;

                // 2. Chamamos a função de ler o arquivo (aquela que usa o Newtonsoft.Json)
                // Se você ainda não criou a função AbrirMapa na ViewModel, 
                // use o código abaixo para teste rápido:
                var pontos = new System.Windows.Media.PointCollection {
            new Point(100, 100),
            new Point(400, 200)
        };

                viewModel.MinhasVias.Add(new Via
                {
                    Nome = "Rua Importada",
                    Velocidade = 60,
                    Pontos = pontos
                });
            }
        }
    }
}