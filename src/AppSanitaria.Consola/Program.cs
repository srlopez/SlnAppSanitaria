using Sanitaria;
using Sanitaria.UI.Consola;
using Sanitaria.Modelos;
using System.Collections.Generic;
using System;

class AppSanitaria
{
    public static void Main()
    {
        // Más sencillo no puede
        var repositorio = new Sanitaria.Data.DataCSV();
        var view = new Vista();
        var sistema = new GestorDeUrgencias(repositorio);
        var controlador = new Controlador(view, sistema);
        controlador.Run();

    }
}
