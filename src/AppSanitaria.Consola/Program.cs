using System;
using Sanitaria;
using Sanitaria.Modelos;
using Sanitaria.UI.Consola;

using System.Collections.Generic;
Console.WriteLine("= Servicio de Urgencias =");
List<string>[,] datos = {
    {
        new List<string>{"1","2"},
        new List<string>{"1","2"},
        new List<string>{"1","2"}
    },
    {
        new List<string>{"1","2"},
        new List<string>{"1","2"},
        new List<string>{"1","2"}
    }
    };

var v = new Vista();
v.MostrarParrilla("hola", datos);
try
{
    Console.WriteLine(v.TryObtenerSiNo("Si o NO"));
    Console.WriteLine(v.TryObtenerArrayInt("5 enteros", 5));
    Console.WriteLine(v.TryObtenerFecha("Fecha"));
}
catch
{
    Console.WriteLine("capturado");
}


// Caso De uso 1
// Registro de paciente que entra en el servicio de urgencias
InfoVacPaciente luis = new InfoVacPaciente
{
    PacienteID = "Luis",
    TipoVacunacion = TipoVacuna.Moderna,
    DosisRecibidas = 1,
    FechaUltimaDosis = new DateTime(2021, 5, 1)
};
Console.WriteLine($"Estado de vacunación de {luis.PacienteID}: {luis.EstadoDeVacunacion}");


// Caso de uso 2
// Verificación de Sintomas Covid
var sintomas = true;
// Verificación de sintomaas inmunodepresivos
var inmunodepresion = false;
// Proceso de verificación de la prueba PCR
var gu = new GestorDeUrgencias();
var pcr = gu.RealizacionDePCR(sintomas, inmunodepresion, luis);
Console.WriteLine($"¿{luis.PacienteID} debe realizar prueba PCR? {pcr}");
