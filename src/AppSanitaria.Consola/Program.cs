using Sanitaria;
using Sanitaria.UI.Consola;
using Sanitaria.Modelos;
using System.Collections.Generic;
using System;


// Más sencillo no puede
var view = new Vista();
var sistema = new GestorDeUrgencias();
var controlador = new Controlador(view, sistema);
controlador.Run();


