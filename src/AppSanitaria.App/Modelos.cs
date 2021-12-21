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

        public override string ToString() => $"{PacienteID} {TipoVacunacion}:{DosisRecibidas:#;;}";
        

    }
}
