using System;
using Sanitaria.Modelos;

namespace Sanitaria
{

    public class GestorDeUrgencias
    {

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
            if (paciente.TipoVacunacion == 0) return PautaVacunacion.NoVacunado;
            if (paciente.FechaUltimaDosis is null) return PautaVacunacion.NoVacunado;
            // Sin las dosis necesarias
            if (paciente.DosisRecibidas < Covid19.nDosisMinimas[(int)paciente.TipoVacunacion] ) return PautaVacunacion.Incompleta;
            // Dias de ultima dosis + 14dias > Hoy
            if (paciente.FechaUltimaDosis.Value.AddDays(Covid19.DiasEfectivos) > DateTime.Now) return PautaVacunacion.Incompleta;
            // Pauta completa
            return PautaVacunacion.Completa;
        }

    }
}
