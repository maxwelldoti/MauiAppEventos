using System.ComponentModel;

namespace MauiAppEventos.Models
{
    public class Evento : INotifyPropertyChanged
    {
        private int numeroParticipantes;
        private string nome;
        private string local;
        private DateTime dataInicio;
        private DateTime dataFim;
        private decimal custoParticipante;

        public event PropertyChangedEventHandler PropertyChanged;

       
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Nome
        {
            get => nome;
            set
            {
                if (nome != value)
                {
                    nome = value;
                    OnPropertyChanged(nameof(Nome));
                }
            }
        }

        public string Local
        {
            get => local;
            set
            {
                if (local != value)
                {
                    local = value;
                    OnPropertyChanged(nameof(Local));
                }
            }
        }

        public DateTime DataInicio
        {
            get => dataInicio;
            set
            {
                if (dataInicio != value)
                {
                    dataInicio = value;
                    OnPropertyChanged(nameof(DataInicio));
                }
            }
        }

        public DateTime DataFim
        {
            get => dataFim;
            set
            {
                if (dataFim != value)
                {
                    dataFim = value;
                    OnPropertyChanged(nameof(DataFim));
                }
            }
        }

        public int NumeroParticipantes
        {
            get => numeroParticipantes;
            set
            {
                if (numeroParticipantes != value)
                {
                    numeroParticipantes = value;
                    OnPropertyChanged(nameof(NumeroParticipantes));
                }
            }
        }

        public decimal CustoParticipante
        {
            get => custoParticipante;
            set
            {
                if (custoParticipante != value)
                {
                    custoParticipante = value;
                    OnPropertyChanged(nameof(CustoParticipante));
                }
            }
        }

     
        public int Duracao => (DataFim - DataInicio).Days;

        public decimal CustoTotal => NumeroParticipantes * CustoParticipante;
    }
}
