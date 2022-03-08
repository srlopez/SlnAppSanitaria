using System;
using Sanitaria.Modelos;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace Sanitaria.Data
{
    public interface IData
    {
        void Guardar(List<InfoVacPaciente> ingresados);
        List<InfoVacPaciente> Leer();
    }

}
