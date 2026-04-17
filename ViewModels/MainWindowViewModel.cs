using SAV.Models;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;

namespace SAV.ViewModels
{
    public class MainWindowViewModel
    {
        public Configuracao Config { get; set; }

        public MainWindowViewModel()
        {
            Config = CarregarConfiguracoes();

            if (Config != null)
            {
                AplicarCores(Config.TemaEscuro);
            }
        }

        private Configuracao CarregarConfiguracoes()
        {
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configuracoes.json");
            if (File.Exists(caminho))
            {
                string jsonString = File.ReadAllText(caminho);
                return JsonSerializer.Deserialize<Configuracao>(jsonString);
            }
            return null;
        }

        public void AplicarCores(bool escuro)
        {
            var conversorBrush = new BrushConverter();

            if (escuro)
            {
                Application.Current.Resources["corDestaquePrimaria"] = (Brush)conversorBrush.ConvertFrom("#1B1B1B")!;
                Application.Current.Resources["corDestaqueSecundaria"] = (Brush)conversorBrush.ConvertFrom("#F5F5F5")!;
                Application.Current.Resources["corDestaqueTerciaria"] = (Brush)conversorBrush.ConvertFrom("#292929")!;
                Application.Current.Resources["corFonte"] = (Brush)conversorBrush.ConvertFrom("#F5F5F5")!;
            }
            else
            {
                Application.Current.Resources["corDestaquePrimaria"] = (Brush)conversorBrush.ConvertFrom("#F5F5F5")!;
                Application.Current.Resources["corDestaqueSecundaria"] = (Brush)conversorBrush.ConvertFrom("#1B1B1B")!;
                Application.Current.Resources["corDestaqueTerciaria"] = (Brush)conversorBrush.ConvertFrom("#D4D4D4")!;
                Application.Current.Resources["corFonte"] = (Brush)conversorBrush.ConvertFrom("#1C2639")!;
            }
        }
    }
}
