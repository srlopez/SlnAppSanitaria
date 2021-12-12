using System;

namespace Sanitaria.Modelos
{
    public enum TipoVacuna
    {
        Ninguna,
        Astra,
        Pfizer,
        Moderna,
        JandJ
    }

    public enum PautaVacunacion
    {
        NoVacunado,
        Completa,
        Incompleta
    }

    public static class Covid19
    {
        public static int[] nDosisMinimas = { Int16.MaxValue, 2, 2, 2, 1 };
        public static int DiasEfectivos = 14;
    }

    public class InfoVacPaciente
    {
        public string PacienteID;
        public int DosisRecibidas = 0;
        public TipoVacuna TipoVacunacion = TipoVacuna.Ninguna;
        public DateTime? FechaUltimaDosis = null;

        public PautaVacunacion EstadoDeVacunacion
        {
            get
            {
                // No vacunado
                if (DosisRecibidas == 0) return PautaVacunacion.NoVacunado;
                if (TipoVacunacion == 0) return PautaVacunacion.NoVacunado;
                // Sin las dosis necesarias
                if (Covid19.nDosisMinimas[(int)TipoVacunacion] > DosisRecibidas) return PautaVacunacion.Incompleta;
                // Dias de efectividad de dosis cumplida
                if (FechaUltimaDosis.Value.AddDays(Covid19.DiasEfectivos) > DateTime.Now) return PautaVacunacion.Incompleta;

                return PautaVacunacion.Completa;
            }
        }
    }
}
