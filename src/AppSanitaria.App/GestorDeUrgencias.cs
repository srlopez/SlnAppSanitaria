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
                    PautaCompletaDeVacunación(paciente));
        }
        public bool RealizacionDePCR(bool sintomas, bool inmunodepresion, bool pautaCompleta)
        {
            if (sintomas) return true;
            if (inmunodepresion) return true;
            if (!pautaCompleta) return true;
            return false;
        }

        public bool PautaCompletaDeVacunación(InfoVacPaciente paciente)=>
            paciente.EstadoDeVacunacion == PautaVacunacion.Completa;

    }
}
