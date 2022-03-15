using System;
using Sanitaria.Modelos;
using System.Collections.Generic;

using System.Runtime.InteropServices;

// using System.IO;
// using System.Linq;

namespace Sanitaria.Data
{
    public interface IRepoPaciente
    {
        public static string DataPath
        {
            get => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    "../../../../../data/" :
                    "../../data/";
        }
        void Guardar(List<InfoVacPaciente> ingresados);
        List<InfoVacPaciente> Leer();
    }

}
