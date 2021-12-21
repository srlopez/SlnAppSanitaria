using System;
using Sanitaria.Modelos;
using System.Collections.Generic;

namespace Sanitaria
{

    public class GestorDeUrgencias
    {
        public List<InfoVacPaciente> Ingresados { get; } = new()
        {

            new InfoVacPaciente
            {
                PacienteID = "luis",
                TipoVacunacion = TipoVacuna.Ninguna,
                DosisRecibidas = 0,
                FechaUltimaDosis = new DateTime(2021, 12, 12)
            },
            new InfoVacPaciente
            {
                PacienteID = "marta",
                TipoVacunacion = TipoVacuna.Astra,
                DosisRecibidas = 2,
                FechaUltimaDosis = new DateTime(2021, 12, 12)
            },

        };

        public void RealizarIngreso(InfoVacPaciente p)
        {
            Ingresados.Add(p);
        }
        public void DarDeAlta(InfoVacPaciente p)
        {
            Ingresados.Remove(p);
        }

        // Ejemplo de sobrecarga de métodos
        public bool RealizacionDePCR(bool sintomas, bool inmunodepresion, InfoVacPaciente paciente)
        {
            return RealizacionDePCR(
                    sintomas,
                    inmunodepresion,
                    VacunacionDelPaciente(paciente) == PautaVacunacion.Completa);
        }
        public bool RealizacionDePCR(bool sintomas, bool inmunodepresion, bool pautaCompleta)
        {
            if (sintomas) return true;
            if (inmunodepresion) return true;
            if (!pautaCompleta) return true;
            return false;
        }

        public PautaVacunacion VacunacionDelPaciente(InfoVacPaciente paciente)
        {
            // Datos de inicializacion
            if (paciente.DosisRecibidas == 0) return PautaVacunacion.NoVacunado;
            if (paciente.TipoVacunacion == TipoVacuna.Ninguna) return PautaVacunacion.NoVacunado;
            if (paciente.FechaUltimaDosis is null) return PautaVacunacion.NoVacunado;
            // Sin las dosis necesarias
            if (paciente.DosisRecibidas < Covid19.nDosisMinimas[(int)paciente.TipoVacunacion]) return PautaVacunacion.Incompleta;
            // Dias de ultima dosis + 14dias > Hoy
            if (paciente.FechaUltimaDosis.Value.AddDays(Covid19.DiasEfectivos) > DateTime.Now) return PautaVacunacion.Incompleta;
            // Pauta completa
            return PautaVacunacion.Completa;
        }

    }
}
