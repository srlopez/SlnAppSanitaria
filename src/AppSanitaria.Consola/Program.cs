using System;
using Sanitaria;
using Sanitaria.Modelos;
using Sanitaria.UI.Consola;

using System.Collections.Generic;
using System.Linq;

// Ejercicio de Refactorización
var view = new Vista();
    var sistema = new GestorDeUrgencias();

view.Mostrar("= Servicio de Urgencias =");

// Caso De uso 1
// Registro de paciente que entra en el servicio de urgencias
view.Mostrar("\nProceso de Registro");


var p1 = ObtenerPaciente();
sistema.RealizarIngreso(p1);

view.Mostrar("");

var p2 = ObtenerPaciente();
sistema.RealizarIngreso(p2);

// Caso de uso 2
view.Mostrar("\nProceso sanitario");

// seleccionar paciente
var pac = view.TryObtenerElementoDeLista<InfoVacPaciente>("Ingresados",sistema.Ingresados,"dime a quien probamos");
// Verificación de Sintomas Covid
var sintomas = 'S' == view.TryObtenerCaracterDeString("Sintomatología Covid-19", "SN", 'S');
// Verificación de sintomaas inmunodepresivos
var inmunodepresion = 'S' == view.TryObtenerCaracterDeString("Paciente con inmunodepresión", "SN", 'S');

view.Mostrar("\nInforme de Resumen");
Informe(pac, sintomas, inmunodepresion);


void Informe(InfoVacPaciente p, bool sitomas, bool inmunodepresion)
{
    // Proceso de verificación de la prueba PCR
    var pcr = sistema.RealizacionDePCR(sintomas, inmunodepresion, p);

    Console.WriteLine($"Estado de vacunación de {p.PacienteID}: {sistema.VacunacionDelPaciente(p)}");
    Console.WriteLine($"Sintomatología Covid-19: {sintomas}");
    Console.WriteLine($"Paciente con inmunodepresión: {inmunodepresion}");
    Console.WriteLine($"¿{p.PacienteID} debe realizar prueba PCR?: {pcr}");
}



InfoVacPaciente ObtenerPaciente()
{
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
    return pac1;
}



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