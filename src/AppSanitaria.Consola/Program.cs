using System;
using Sanitaria;
using Sanitaria.Modelos;
using Sanitaria.UI.Consola;

using System.Collections.Generic;
using System.Linq;


Console.WriteLine("= Servicio de Urgencias =");

// Caso De uso 1
// Registro de paciente que entra en el servicio de urgencias
InfoVacPaciente luis = new InfoVacPaciente
{
    PacienteID = "Luis",
    TipoVacunacion = TipoVacuna.Moderna,
    DosisRecibidas = 1,
    FechaUltimaDosis = new DateTime(2021, 5, 1)
};

// Caso de uso 2
// Verificación de Sintomas Covid
var sintomas = true;
// Verificación de sintomaas inmunodepresivos
var inmunodepresion = false;
// Proceso de verificación de la prueba PCR
var gu = new GestorDeUrgencias();
var pcr = gu.RealizacionDePCR(sintomas, inmunodepresion, luis);

Console.WriteLine($"Estado de vacunación de {luis.PacienteID}: {gu.VacunacionDelPaciente(luis)}");

Console.WriteLine($"¿{luis.PacienteID} debe realizar prueba PCR? {pcr}");
