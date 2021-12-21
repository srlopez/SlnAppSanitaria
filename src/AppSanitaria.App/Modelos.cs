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
        public string PacienteID { get; set; }
        public int DosisRecibidas { get; set; } = 0;
        public TipoVacuna TipoVacunacion { get; set; } = TipoVacuna.Ninguna;
        public DateTime? FechaUltimaDosis { get; set; } = null;
        public int Edad { get; set; } = 0;
        public char Sexo { get; set; } = 'H';

        public override string ToString() =>
        TipoVacunacion == TipoVacuna.Ninguna ?
            $"{Sexo} {PacienteID,-8}({Edad}): {TipoVacunacion}" :
            $"{Sexo} {PacienteID,-8}({Edad}): {TipoVacunacion}{DosisRecibidas:(#)} {FechaUltimaDosis:dd-MM-yy}";

    }
}
