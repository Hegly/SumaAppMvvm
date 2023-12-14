using System;
using System.Windows.Input;
using AndroidX.Lifecycle;
using Microsoft.Maui.Controls;

namespace SumaAppMvvm.ViewModels
{
	public class MainViewModel : ViewModel
    {

        private double _primerValor;
        private double _segundoValor;
        private string _resultado;
        private string _mensajeAlerta;

        public double PrimerValor
        {
            get => _primerValor;
            set
            {
                _primerValor = value;
                OnPropertyChanged(nameof(PrimerValor));
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public double SegundoValor
        {
            get => _segundoValor;
            set
            {
                _segundoValor = value;
                OnPropertyChanged(nameof(SegundoValor));
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }

        public string MensajeAlerta
        {
            get => _mensajeAlerta;
            set
            {
                _mensajeAlerta = value;
                OnPropertyChanged(nameof(MensajeAlerta));
            }
        }

        public ICommand SumarCommand => new Command(Sumar);
        public ICommand LimpiarCamposCommand => new Command(LimpiarCampos);

        private void Sumar()
        {
            if (ValidarEntradas())
            {
                double resultado = PrimerValor + SegundoValor;
                Resultado = $"Resultado: {resultado}";
            }
        }

        private void LimpiarCampos()
        {
            PrimerValor = 0;
            SegundoValor = 0;
            Resultado = string.Empty;
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(PrimerValor.ToString()) || string.IsNullOrWhiteSpace(SegundoValor.ToString()))
            {
                MensajeAlerta = "Por favor, complete todos los campos.";
                MostrarAlerta();
                return false;
            }

            if (!double.TryParse(PrimerValor.ToString(), out _))
            {
                MensajeAlerta = "Ingrese un valor numérico válido para el primer campo.";
                MostrarAlerta();
                return false;
            }

            if (!double.TryParse(SegundoValor.ToString(), out _))
            {
                MensajeAlerta = "Ingrese un valor numérico válido para el segundo campo.";
                MostrarAlerta();
                return false;
            }

            return true;
        }

        private void MostrarAlerta()
        {
            Application.Current.MainPage.DisplayAlert("Resultado de la Operación", MensajeAlerta, "Aceptar");
        }
    }
	
}

