using System;
using Sanitaria.Modelos;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace Sanitaria
{
    class DataCSV
    {
        string _file = "../../data.csv";
        // Persitencia
        public void Guardar(List<InfoVacPaciente> ingresados)
        {
            List<string> data = new() { };
            ingresados.ForEach(ingresado =>
            {
                var str = $"{ingresado.PacienteID},{ingresado.TipoVacunacion},{ingresado.DosisRecibidas},{ingresado.FechaUltimaDosis},{ingresado.Edad},{ingresado.Sexo}";
                data.Add(str);
            });
            File.WriteAllLines(_file, data);
        }
        public List<InfoVacPaciente> Leer()
        {
            List<InfoVacPaciente> ingresados = new();
            var data = File.ReadAllLines(_file).ToList();
            data.ForEach(row =>
            {
                var campos = row.Split(",");
                var ingresado = new InfoVacPaciente
                {
                    PacienteID = campos[0],
                    TipoVacunacion = (TipoVacuna)Enum.Parse(typeof(TipoVacuna), campos[1]),
                    FechaUltimaDosis = DateTime.Parse(campos[3]),
                    DosisRecibidas = Int32.Parse(campos[2]),
                    Edad = Int32.Parse(campos[4]),
                    Sexo = campos[5][0],
                };
                ingresados.Add(ingresado);
            });
            return ingresados;
        }
    }
    public class GestorDeUrgencias
    {
        public GestorDeUrgencias()
        {
            Ingresados = Repositorio.Leer();
        }

        DataCSV Repositorio = new DataCSV();
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
