using Sanitaria;
using Sanitaria.UI.Consola;


// Más sencillo no puede quedar
var view = new Vista();
var sistema = new GestorDeUrgencias();
var controlador = new Controlador(view, sistema);
controlador.Run();


