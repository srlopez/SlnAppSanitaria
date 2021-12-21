using System;
using Sanitaria;
using Sanitaria.Modelos;
using Sanitaria.UI.Consola;
class Controlador{


    
public InfoVacPaciente ObtenerPaciente()
{
    var id = view.TryObtenerDatoDeTipo<string>("Paciente ID");
    var tv = view.TryObtenerElementoDeLista<TipoVacuna>("Vacunas", view.EnumToList<TipoVacuna>(), "Indica el tipo de vacuna");
    var nd = view.TryObtenerDatoDeTipo<int>("Numero de dosis recibidas");
    var fu = view.TryObtenerFecha("Fecha de la última dosis");

    InfoVacPaciente pac1 = new InfoVacPaciente
    {
        PacienteID = id,
        TipoVacunacion = tv,
        DosisRecibidas = nd,
        FechaUltimaDosis = fu
    };
    return pac1;
}


}