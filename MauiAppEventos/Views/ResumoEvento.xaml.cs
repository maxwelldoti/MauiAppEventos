using MauiAppEventos.Models;
using Microsoft.Maui.Controls;
using System;

namespace MauiAppEventos.Views
{
    public partial class ResumoEvento : ContentPage
    {
        public ResumoEvento(Evento evento)
        {
            InitializeComponent();
            BindingContext = evento;  
        }
    }
}
