using System;
using Sanitaria;
using Sanitaria.Modelos;
using Sanitaria.UI.Consola;


// Ejercicio de Refactorización
var view = new Vista();
var sistema = new GestorDeUrgencias();
var controlador = new Controlador(view, sistema);
controlador.Run();


