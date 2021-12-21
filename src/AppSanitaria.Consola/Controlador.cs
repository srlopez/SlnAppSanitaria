using System;
using Sanitaria;
using Sanitaria.Modelos;
using Sanitaria.UI.Consola;
using System.Collections.Generic;

namespace Sanitaria.UI.Consola
{
    class Controlador
    {

        private Vista _vista;
        private GestorDeUrgencias _sistema;

        private List<String> menu = new()
        {
            "Realizar Ingreso",
            "Dar Alta a paciente",
            "Realizar Prueba PCR"
        };

        public Controlador(Vista vista, GestorDeUrgencias businessLogic)
        {
            _vista = vista;
            _sistema = businessLogic;

        }

        public void Run()
        {
            while (true)
            {
                _vista.LimpiarPantalla();
                _vista.MostrarListaEnumerada<string>("Menu De Urgencias", menu);
                var opcion = _vista.TryObtenerValorEnRangoInt(
                    1, menu.Count, "Indica una opción");
                switch (opcion)
                {
                    case 1:
                        RealizarIngreso();
                        break;
                    case 2:
                        DarDeAlta();
                        break;
                    case 3:
                        VerificarPCR();
                        break;
                }
                _vista.MostrarYReturn("Pulse <Return> para continuar");
            }
        }

        private void RealizarIngreso()
        {
            var id = _vista.TryObtenerDatoDeTipo<string>("Paciente ID");
            var tv = _vista.TryObtenerElementoDeLista<TipoVacuna>("Vacunas", _vista.EnumToList<TipoVacuna>(), "Indica el tipo de vacuna");
            var nd = _vista.TryObtenerDatoDeTipo<int>("Numero de dosis recibidas");
            var fu = _vista.TryObtenerFecha("Fecha de la última dosis");

            InfoVacPaciente paciente = new InfoVacPaciente
            {
                PacienteID = id,
                TipoVacunacion = tv,
                DosisRecibidas = nd,
                FechaUltimaDosis = fu
            };

            _sistema.RealizarIngreso(paciente);
        }

        private void DarDeAlta()
        {
            // Seleccionar paciente
            var pac = _vista.TryObtenerElementoDeLista<InfoVacPaciente>("Paciente a Dar de Alta", _sistema.Ingresados, "dime a quien probamos");
            // 
            _sistema.DarDeAlta(pac);
        }
        private void VerificarPCR()
        {
            // Seleccionar paciente
            var pac = _vista.TryObtenerElementoDeLista<InfoVacPaciente>("Ingresados", _sistema.Ingresados, "dime a quien probamos");
            // Verificación de Sintomas Covid
            var sintomas = 'S' == _vista.TryObtenerCaracterDeString("Sintomatología Covid-19", "SN", 'S');
            // Verificación de sintomaas inmunodepresivos
            var inmunodepresion = 'S' == _vista.TryObtenerCaracterDeString("Paciente con inmunodepresión", "SN", 'S');
            // Verificamos la prueba PCR
            var pcr = _sistema.RealizacionDePCR(sintomas, inmunodepresion, pac);
            // Informamos al sanitario
            _vista.Mostrar($"Estado de vacunación de {pac.PacienteID}: {_sistema.VacunacionDelPaciente(pac)}");
            _vista.Mostrar($"Sintomatología Covid-19: {sintomas}");
            _vista.Mostrar($"Paciente con inmunodepresión: {inmunodepresion}");
            _vista.Mostrar("");
            _vista.Mostrar($"¿{pac.PacienteID} debe realizar prueba PCR?: {pcr}");
        }
    }
}