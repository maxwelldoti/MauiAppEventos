using MauiAppEventos.Models;

namespace MauiAppEventos.Views
{
    public partial class ContratacaoEvento : ContentPage
    {
        public Evento Evento { get; set; }
        public DateTime DataInicioMinima { get; set; }
        public DateTime DataFimMaxima { get; set; }

        public ContratacaoEvento()
        {
            InitializeComponent();
            Evento = new Evento();
            BindingContext = Evento;

            Evento.DataInicio = DateTime.Today; 
            Evento.DataFim = Evento.DataInicio.AddMonths(1); 

            DataInicioMinima = DateTime.Today;
            DataFimMaxima = DateTime.Today.AddMonths(6);
        }

        private void OnCustoParticipanteTextChanged(object sender, TextChangedEventArgs e)
        {
            string newText = e.NewTextValue;

            if (decimal.TryParse(newText, out decimal value))
            {
                Evento.CustoParticipante = value;
                entryCustoParticipante.Text = value.ToString("C2");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Evento.Nome) || string.IsNullOrWhiteSpace(Evento.Local) ||
                    Evento.DataInicio == DateTime.MinValue || Evento.DataFim == DateTime.MinValue ||
                    Evento.NumeroParticipantes == 0 || Evento.CustoParticipante == 0)
                {
                    DisplayAlert("Erro", "Preencha todos os campos corretamente.", "OK");
                    return;
                }

                Navigation.PushAsync(new ResumoEvento(Evento));
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Ok");
            }
        }

    
        private void OnDataInicioChanged(object sender, DateChangedEventArgs e)
        {
           
            if (e.NewDate < DateTime.Today)
            {
                Evento.DataInicio = DateTime.Today;
                DisplayAlert("Aviso", "A data de início não pode ser no passado. Foi ajustada para hoje.", "OK");
            }
            else
            {
          
                Evento.DataFim = Evento.DataInicio.AddMonths(6);
            }
        }

   
        private void OnDataFimChanged(object sender, DateChangedEventArgs e)
        {
            if (Evento.DataFim < Evento.DataInicio)
            {
             
                Evento.DataFim = Evento.DataInicio.AddMonths(6);
            }
        }

     
        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            Evento.NumeroParticipantes = (int)e.NewValue;
        }
    }
}
