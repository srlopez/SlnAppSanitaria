using System;
using Sanitaria.Modelos;
using System.Collections.Generic;
using System.Linq;


namespace Sanitaria.UI.Consola
{
    class Controlador
    {
        private Vista _vista;
        private GestorDeUrgencias _sistema;
        private Dictionary<string, Action> _casosDeUso;
        public Controlador(Vista vista, GestorDeUrgencias businessLogic)
        {
            _vista = vista;
            _sistema = businessLogic;
            _casosDeUso = new Dictionary<string, Action>(){
                { "Registrar ingreso de paciente", RealizarIngreso },
                { "Alta de paciente", DarDeAlta },
                { "Comprobación de PCR", VerificarPruebaPCR },
                { "Mostrar Ingresados", MostarIngresados}
            };
        }

        // === Ciclo de la Aplicacin ===
        public void Run()
        {
            _vista.LimpiarPantalla();
            // Acceso a las Claves del diccionario
            var menu = _casosDeUso.Keys.ToList<String>();

            while (true)
                try
                {
                    //Limpiamos
                    _vista.LimpiarPantalla();
                    // Menu
                    var key = _vista.TryObtenerElementoDeLista("Menu de Usuario", menu, "Seleciona una opción");
                    _vista.Mostrar("");
                    // Ejecución de la opción escogida
                    _casosDeUso[key].Invoke();
                    // Fin
                    _vista.MostrarYReturn("Pulsa <Return> para continuar");
                }
                catch { return; }
        }
        // === Casos De Uso ===
        private void RealizarIngreso()
        {
            try
            {
                var id = _vista.TryObtenerDatoDeTipo<string>("Paciente ID");
                var ed = _vista.TryObtenerDatoDeTipo<int>("Edad");
                var sx = _vista.TryObtenerCaracterDeString("Sexo", "HM", 'H');
                var tv = _vista.TryObtenerElementoDeLista<TipoVacuna>("Vacunas", _vista.EnumToList<TipoVacuna>(), "Indica el tipo de vacuna");
                var nd = _vista.TryObtenerDatoDeTipo<int>("Numero de dosis recibidas");
                var fu = _vista.TryObtenerFecha("Fecha de la última dosis");

                InfoVacPaciente paciente = new InfoVacPaciente
                {
                    PacienteID = id,
                    TipoVacunacion = tv,
                    DosisRecibidas = nd,
                    FechaUltimaDosis = fu,
                    Edad = ed,
                    Sexo = sx
                };

                _sistema.RealizarIngreso(paciente);
            }
            catch (Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }
        }
        private void DarDeAlta()
        {
            try
            {
                // Include caso de uso
                MostarIngresados();
                // Seleccionar paciente
                var idx = _vista.TryObtenerValorEnRangoInt(1, _sistema.Ingresados.Count, "Paciente a Dar de Alta");
                var pac = _sistema.Ingresados[idx - 1];
                // Ejecucion
                _sistema.DarDeAlta(pac);
                // Info
                _vista.Mostrar($"Informe De Alta entregdo a {pac.PacienteID}");
            }
            catch (Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }
        }
        private void VerificarPruebaPCR()
        {
            try
            {
                // Seleccionar paciente
                var pac = _vista.TryObtenerElementoDeLista<InfoVacPaciente>("Ingresados", _sistema.Ingresados, "Indica el paciente en prueba");
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
            catch (Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }
        }
        public void MostarIngresados()
        {
            // Listar paciente
            _vista.MostrarListaEnumerada<InfoVacPaciente>("Ingresados", _sistema.Ingresados);
        }
    }
}
