using System;
using Sanitaria.Modelos;
using System.Collections.Generic;
using System.Text.Json;

using System.IO;
using System.Linq;

namespace Sanitaria.Data
{
    public class DataJSON: IData
    {
        string _file = "../../data.json";
        // Persitencia
        public void Guardar(List<InfoVacPaciente> ingresados)
        {
               var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(ingresados, options);
                File.WriteAllText(_file, json);        }
        public List<InfoVacPaciente> Leer()
        {
                var txtJson = File.ReadAllText(_file);
                return JsonSerializer.Deserialize<List<InfoVacPaciente>>(txtJson);
        }
    }
}