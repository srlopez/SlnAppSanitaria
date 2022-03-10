using System;
using Sanitaria.Modelos;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace Sanitaria.Data
{
 

    public class DataCSV : IData
    {
        string _file = "../../data.csv";
        // Persitencia
        public void Guardar(List<InfoVacPaciente> ingresados)
        {
            // Decoramos el CSV con una cabecera
            var cabecera = "ID,TipoVac,Dosis,UltDosis,Edad,Sexo";
            List<string> data = new() { cabecera };
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
            // Nos saltamos la cabecera y las líneas en blanco
            var data = File.ReadAllLines(_file)
                .Skip(1)
                .Where(row=>row.Length>0)
                .ToList();
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
}