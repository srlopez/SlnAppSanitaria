using Sanitaria;
using Sanitaria.UI.Consola;
using Sanitaria.Modelos;
using System.Collections.Generic;
using System;

  List<InfoVacPaciente> ingresados = new()
        {
            new InfoVacPaciente
            {
                PacienteID = "Luis",
                TipoVacunacion = TipoVacuna.Ninguna,
                DosisRecibidas = 0,
                FechaUltimaDosis = DateTime.Now,
                Edad = 23,
                Sexo = 'H'
            },
            new InfoVacPaciente
            {
                PacienteID = "Marta",
                TipoVacunacion = TipoVacuna.Astra,
                DosisRecibidas = 2,
                FechaUltimaDosis = DateTime.Now.AddDays(-10),
                Edad = 45,
                Sexo = 'M'
            },

        };
// Más sencillo no puede
var view = new Vista();
var sistema = new GestorDeUrgencias(ingresados);
var controlador = new Controlador(view, sistema);
controlador.Run();


