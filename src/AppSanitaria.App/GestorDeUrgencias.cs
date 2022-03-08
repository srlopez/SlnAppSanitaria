using System;
using Sanitaria.Modelos;
using System.Collections.Generic;

using Sanitaria.Data;

namespace Sanitaria
{
    public class GestorDeUrgencias
    {
        public GestorDeUrgencias(IData  repo)
        {
            Repositorio = repo;
            Ingresados = Repositorio.Leer();
        }

        IData Repositorio;
        public List<InfoVacPaciente> Ingresados { get; set; } = new();
        public void RealizarIngreso(InfoVacPaciente p)
        {
            Ingresados.Add(p);
            Repositorio.Guardar(Ingresados);
        }
        public void DarDeAlta(InfoVacPaciente p)
        {
            Ingresados.Remove(p);
            Repositorio.Guardar(Ingresados);
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
