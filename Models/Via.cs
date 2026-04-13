using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SAV.Models
{
    public class Via : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public PointCollection Pontos { get; set; } // Desenho da linha

        private int _velocidade;
        public int Velocidade
        {
            get => _velocidade;
            set { _velocidade = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}