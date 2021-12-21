using System;
using Sanitaria;
using Sanitaria.Modelos;
using Sanitaria.UI.Consola;


// Ejercicio de Refactorización
var view = new Vista();
var sistema = new GestorDeUrgencias();
var controlador = new Controlador(view, sistema);
controlador.Run();


/*
var casosDeUso = new Dictionary<string, Action>(){
                { "Registrar ingreso de paciente", Registrar },
                { "Comprobación de PCR", ComprobarPCR }
            };


void Run()
{
    view.LimpiarPantalla();
    // Acceso a las Claves del diccionario
    var menu = casosDeUso.Keys.ToList<String>();
    while (true)
        try
        {
            // Menu
            var key = view.TryObtenerElementoDeLista("Menu de Usuario", menu, "Seleciona una opción");
            // Ejecución de la opción escogida
            view.LimpiarPantalla();
            view.Mostrar(key);
            casosDeUso[key].Invoke();

            view.MostrarYReturn("Pulsa <Return> para continuar");
            view.LimpiarPantalla();
        }
        catch { return; }
}

*/