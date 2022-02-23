using System;
using Sanitaria.Modelos;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace Sanitaria
{
    public class GestorDeUrgencias
    {
        public GestorDeUrgencias(List<InfoVacPaciente> ingresados)
        {
            Ingresados = ingresados;
            var _file = "../../data.csv";
            List <string> data = new(){};
            Ingresados.ForEach(i=>{
                data.Add($"{i.PacienteID},{i.TipoVacunacion},{i.DosisRecibidas},{i.FechaUltimaDosis},{i.Edad},{i.Sexo}");
            });
            File.WriteAllLines(_file, data);
            data = File.ReadAllLines(_file).ToList();
            data.ForEach(row=>{
                var campos = row.Split(",");
                // for(var i = 0; i< campos.Length;i++)
                // Console.WriteLine(campos[i]);

                var ingresado = new InfoVacPaciente{
                    PacienteID = campos[0],
                    TipoVacunacion = (TipoVacuna) Enum.Parse(typeof(TipoVacuna), campos[1]),
                    FechaUltimaDosis = DateTime.Parse(campos[3]),
                    DosisRecibidas = Int32.Parse(campos[2]),
                    Edad = Int32.Parse(campos[4]),
                    Sexo = campos[5][0],
                };
            });

        }

        public List<InfoVacPaciente> Ingresados { get; set;} 
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
