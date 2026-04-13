using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SAV.Models;

namespace SAV.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Via> MinhasVias { get; set; }

        private Via _viaSelecionada;
        public Via ViaSelecionada
        {
            get => _viaSelecionada;
            set { _viaSelecionada = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            MinhasVias = new ObservableCollection<Via>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}