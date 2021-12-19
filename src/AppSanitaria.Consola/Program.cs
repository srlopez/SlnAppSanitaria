using System;
using Sanitaria;
using Sanitaria.Modelos;
using Sanitaria.UI.Consola;

using System.Collections.Generic;
using System.Linq;

// Ejercicio de Refactorización
var view = new Vista();
view.Mostrar("= Servicio de Urgencias =");

// Caso De uso 1
// Registro de paciente que entra en el servicio de urgencias
view.Mostrar("\nProceso de Registro");

var id = view.TryObtenerDatoDeTipo<string>("Paciente ID");
var tv = view.TryObtenerElementoDeLista<TipoVacuna>("Vacunas", view.EnumToList<TipoVacuna>(), "Indica el tipo de vacuna");
var nd = view.TryObtenerDatoDeTipo<int>("Numero de dosis recibidas");
var fu = view.TryObtenerFecha("Fecha de la última dosis");

InfoVacPaciente pac1 = new InfoVacPaciente
{
    PacienteID = id,
    TipoVacunacion = tv,
    DosisRecibidas = nd,
    FechaUltimaDosis = fu
};

// Caso de uso 2
view.Mostrar("\nProceso sanitario");

// Verificación de Sintomas Covid
var sintomas = 'S' == view.TryObtenerCaracterDeString("Sintomatología Covid-19","SN",'S');
// Verificación de sintomaas inmunodepresivos
var inmunodepresion = 'S' == view.TryObtenerCaracterDeString("Paciente con inmunodepresión","SN",'S');

view.Mostrar("\nInforme de Resumen");

// Proceso de verificación de la prueba PCR
var sistema = new GestorDeUrgencias();
var pcr = sistema.RealizacionDePCR(sintomas, inmunodepresion, pac1);

Console.WriteLine($"Estado de vacunación de {pac1.PacienteID}: {sistema.VacunacionDelPaciente(pac1)}");
Console.WriteLine($"Sintomatología Covid-19: {sintomas}");
Console.WriteLine($"Paciente con inmunodepresión: {inmunodepresion}");
Console.WriteLine($"¿{pac1.PacienteID} debe realizar prueba PCR?: {pcr}");

/*
var casosDeUso = new Dictionary<string, Action>(){
                { "Registrar ingreso de paciente", Registrar },
                { "Comprobación de PCR", ComprobarPCR }
            };

void Registrar() { }
void ComprobarPCR() { }

void Run()
{
    view.LimpiarPantalla();
    // Acceso a las Claves del diccionario
    var menu = casosDeUso.Keys.ToList<String>();
    while (true)
        try
        {
            // Menu
            var key = view.TryObtenerElementoDeLista("Menu de Usuario", menu, "Seleciona una opción");
            // Ejecución de la opción escogida
            view.LimpiarPantalla();
            view.Mostrar(key);
            casosDeUso[key].Invoke();

            view.MostrarYReturn("Pulsa <Return> para continuar");
            view.LimpiarPantalla();
        }
        catch { return; }
}

*/