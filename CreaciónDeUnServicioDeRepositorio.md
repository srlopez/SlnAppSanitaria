# Creación de un Servicio de Repositorio para Persistencia de Datos.
## Definiciones
**Persistencia**: Duración o existencia de una cosa por largo tiempo.  
**Repositorio**: Almacén o lugar donde se guardan ciertas cosas.

Vamos a añadir persitencia a  nuestra aplicación Sanitaria, através de un repositorio.  
En este caso lo que vamos a persitir en disco son nuestros ingresados y en formato CSV.

# Paso 0.- Partiendo de una lista codificada

Hemos partido de una lista de datos (Ingresados) codificada en el `sistema` que hemos llamado `GestorDeUrgencias`.
- **Es correcto** que el `Sistema` sea quien sabe con qué datos trabajamos. 
- Incicialmente los datos los hemos `codificado` dentro de él, pero eso no es lo normal, ya que las aplicaciones deben trabajar con datos `persistentes`.

Para solucionarlo vamos a dotar a nuestro `Sistema` de un repositorio en el que persitan los datos.  

Así es como estaba inicializada la lista de Ingresados en el `GestorDeUrgencias` 
```C#
    List<InfoVacPaciente> Ingresados { get; set; }= new()
        {
            new InfoVacPaciente
            {
                PacienteID = "Luis",
                TipoVacunacion = TipoVacuna.Ninguna,
                DosisRecibidas = 0,
                FechaUltimaDosis = DateTime.Now,//debería haber puesto una fecha
                Edad = 23,
                Sexo = 'H'
            },
            new InfoVacPaciente
            {
                PacienteID = "Marta",
                TipoVacunacion = TipoVacuna.Astra,
                DosisRecibidas = 2,
                FechaUltimaDosis = DateTime.Now.AddDays(-10),
                Edad = 45,
                Sexo = 'M'
            },
        };
```
Dotamos al sistema de un constructor desde el que inicializaremos nuestra lista.  

# Paso 1.- Creamos un archivo utilizando la librería System.IO.File
Este es un paso _temporal_. Al crear el constuctor, éste nos a invitado a que pasemos como parámetro la lista de ingresados, ya que esta era un atributo/propiedad del mismo. Y así lo hemos hecho.

Ya que el `Sistema` es el encargado de conocer nuestros datos, temporalmente, voy a escribir el código que salva/guarda la lista dentro del mismo `Sistema`. Se podría hacer en el `Program.cs`, pero al ser algo coyuntural que lo borraremos, lo puedo hacer donde quiera.

Para trabajar con el **FileSystem** o **Sistema de Archivos del S.O**., `C#` nos provee de la clase `File` para la que nos ofrece varios métodos.
```C#
    using System.IO;
    using System.Linq; //<- Para poder ToList()
```

Hemos decidido, por ahora, guardar nuestros _ingresados_ en formato _CSV_ (comma separated value), un formato en el que cada línea de texto representará un ingresado, y cada campo separado por coma, será una de las propiedades del ingresado.
Es un formato típico en el que `Excel` guarda y/o importa datos.    

## ESCRITURA - File.WriteAllLines y conversión a string
```C#
    var _file = "../../data.csv";  //1
    List <string> data = new(){};  //2
    Ingresados.ForEach(i=>{ //3
        var str = $"{ingresado.PacienteID},{ingresado.TipoVacunacion},{ingresado.DosisRecibidas},{ingresado.FechaUltimaDosis},{ingresado.Edad},{ingresado.Sexo}"; //4
        data.Add(str);}); //5
    File.WriteAllLines(_file, data); //6
```
Comentarios a la forma en que guardamos los datos.  
- //1  Establecemos el lugar/path donde vamos a guardar el archivo  
     Sería más correcto en un directorio especifico para `Data`, como por ejemplo `var _file = "../../Data/data.csv";`  
 - //2 Declaramos una List de string que es lo que luego escribiremos en disco.  
 - //3 Ciclo para cada uno de los elementos de la lista ...  
 - //4 Formamos el string en formato CSV.(Cada una de las propiedades que queremos persistir)
 - //5 Lo añadimos a la lista de strings.
 - //6 Y lo escribimos en el FS.  

Este es el resultado
```
Luis,Ninguna,0,2/23/2022 11:03:03 AM,23,H
Marta,Astra,2,2/13/2022 11:03:03 AM,45,M
```
## LECTURA - File.ReadAllLines y reconversión de string
Realizamos el paso inverso, es decir, leemos del archivo y lo convertimos a una lista de ingresados.

```C#
    data = File.ReadAllLines(_file).ToList(); //1
    data.ForEach(row=>{ //2
        var campos = row.Split(","); //3
        var ingresado = new InfoVacPaciente{ //4
            PacienteID = campos[0],
            TipoVacunacion = Enum.Parse(typeof(TipoVacuna), campos[1]),
            FechaUltimaDosis = DateTime.Parse(campos[3]),
            DosisRecibidas = Int32.Parse(campos[2]),
            Edad = Int32.Parse(campos[4]),
            Sexo = campos[5][0],
        };
        Ingresados.Add(ingresado); //5
    });
```
Comentarios:
- //1 leemos la lista de strings del disco.  
- //2 ciclo para trabajar cada una de las filas/row leidas  
- //3 cada linea (Un `string`) la convierto el una `List` de `string`, indicando que es un dato distinto si está separado del anterior por una coma. Obteniendo una lista de campos  
- //4 Creo cada _ingresado_ con los valores leidos  
    - Nos viene muy bien que hay varios tipos de datos distintos en nuestro modelo. Así podemos ver como covertimos cada `string` al tipo de datos que corresponda.
    - `string`, `char`, `DateTime`, `Enum`, `Int32`
- //5 Añadimos el _ingresado_ a la lista de _Ingresados_.

# Paso 3.- Deshacemos lo hecho. Este es nuestro PUNTO CERO
Lo hecho hasta aquí es sólo para conocer las sentencia que tenemos que codificar para leer y escribir de disco nuestros datos.  

Ahora, limpiamos del código lo que no necesitamos.  

- Es decir eliminamos del contructor el parámetro de ingresados, ya que a partir de ahora lo vamos a guardar en disco.
- En el constructor sólo dejaremos la lectura inicial de datos.
- Cada vez que se realice un **ingreso** o un **alta** debemos guardar de nuevo los datos, ya que estos han cambiado.

# Paso 4.- Mejoras que podemos practicar de acuerdo a las buenas prácticas.

## Mejora #1
El Constructor del `Sistema` es un método en al que sólo atañe crear el `Sistema` no es responsable de leer datos de disco.  
**Solución**: Crearemos métodos encargado de ello que serán invocado desde el constructor o desde nos interese.

Esta pŕactica se llama Principio SoC (separation of concerns). Los diferentes asuntos, debe de ser separados en distintos métodos/clases/componentes/proyectos. 


## Mejora #2
Nuestro `Sistema` está leyendo directamente del disco para cargar unos datos.  
No es bueno que un módulo o clase de alto nivel (El responsble de la Lógica de nuestro negocio) se preocupe de temas como dónde guardar los datos, y meno en el nombre del archivo.
**Solución**: Creamos un clase, responsable de la gestión de los datos en el disco
A esto se le llama IoC. **Inversion Of Control**

Inversión de control es un principio de diseño de software en el que el flujo de ejecución de un programa se invierte respecto a los métodos de programación tradicionales. 
Podemos separar la actuación en disco en Leer y Escribir, e invocar dichos métodos desde cada punto donde se altere la lista de datos.  

Al mismo tiempo tenemos que darnos cuenta que no cumplimos nuestro principio básico el `SRP` (_Single Responsibility Principle_) que dice que las clases o módulos deben tener una sola razón para cambiar, porque debe tener una sola responsabilidad. Además esa clase debe ser la única con esa responsabilidad. Es decir, si tenemos que cambiar una clase, que sea por una única razón.

Tras esta explicación, creamos una Clase que se encarge de persistir en disco, y en formato CSV nuestros datos.

```C#
    class DataCSV
    {
        string _file = "../../data.csv";
        // Persitencia
        public void Guardar(List<InfoVacPaciente> ingresados)
        {
            List<string> data = new() { };
            ingresados.ForEach(ingresado =>
            {
                var str = $"{ingresado.PacienteID},{ingresado.TipoVacunacion},{ingresado.DosisRecibidas},{ingresado.FechaUltimaDosis},{ingresado.Edad},{ingresado.Sexo}";
                data.Add(str);
            });
            File.WriteAllLines(_file, data);
        }
        public List<InfoVacPaciente> Leer()
        {
            List<InfoVacPaciente> ingresados = new();
            var data = File.ReadAllLines(_file).ToList();
            data.ForEach(row =>
            {
                var campos = row.Split(",");
                var ingresado = new InfoVacPaciente
                {
                    PacienteID = campos[0],
                    TipoVacunacion = (TipoVacuna)Enum.Parse(typeof(TipoVacuna), campos[1]),
                    FechaUltimaDosis = DateTime.Parse(campos[3]),
                    DosisRecibidas = Int32.Parse(campos[2]),
                    Edad = Int32.Parse(campos[4]),
                    Sexo = campos[5][0],
                };
                ingresados.Add(ingresado);
            });
            return ingresados;
        }
    }
```

## Mejora #3
Crear esa utilidad como un clase interna o instanciada dentro de nuestro constructor, tampoco no es una buena pŕactica. Hace que el `Sistema` dependa de la instanciación y del Tipo de clase de la utilidad.   

**Solución**: Pasamos la clase como parámetro en la creación del `Sistema`.  
A esto le llamamos ID. **Dendencency Inyection**, aunque todavía le falta un paso más.  
En informática, inyección de dependencias (en inglés Dependency Injection, DI) es un patrón de diseño orientado a objetos, en el clases no crean los objetos que necesitan, sino que se los suministran desde otra clase que inyectará la implementación deseada a nuestro contrato.

> Este paso es muy posible que nos obligue a separar en otro proyecto los Modelos, ya que:
- Se suele poner en proyecto aparte el acceso a datos
- El acceso a datos, debe hacer referencia a los Modelos, que están en el Proyecto del `Sistema`. Y el sistema debe hacer referencia al proyecto de persistencia de datos, para usarse cada vez que queramos guardar o leer datos. Se crea una **referencia cíclica**, que debemos eliminar. Y lo podemos hacer sacando los Modelos del proyecto principal.

**Ojo**: Si tenemos el proyecto con distinta version NEt5/6 podemos tener algún error, que solucionamos o bien cambiando la plataforma de destino, o bien antes de ejecutar los comandos creando un archivo `global.json`
```json
{
  "sdk": {
    "version": "5.0.0"
  }
}
```  
Estos son los comandos para crear los proyectos  
```bsh
    dotnet new classlib -o src/AppSanitaria.App.Models
    dotnet new classlib -o src/AppSanitaria.Data
    dotnet add src/AppSanitaria.Data reference src/AppSanitaria.App.Models
    dotnet add src/AppSanitaria.App reference src/AppSanitaria.App.Models
    dotnet sln AppSanitaria.sln add src/AppSanitaria.App.Models
    dotnet sln AppSanitaria.sln add src/AppSanitaria.Data
```

> Hemos de tocar el Program.cs para indicar el nuevo parámetro.

## Mejora #4
A nuestra lógica de negocio le hemos inyectado, un servicio de repositorio del que ahora depende, pero el pricipio de [Inversión de Dependencia](https://es.wikipedia.org/wiki/Principio_de_inversi%C3%B3n_de_la_dependencia) que:  
1.- Los módulos de alto nivel no deberían depender de los módulos de bajo nivel. Ambos deberían depender de abstracciones (p.ej., interfaces).  
2.- Las abstracciones no deberían depender de los detalles. Los detalles (implementaciones concretas) deben depender de abstracciones.  

Básicamente esto significa que:
Nuestro `Sistema` debe depender de una abstración (una `interface`). La abstracción no debe tener detalles, sino que estos deben ser implementados en la clase que implementará la interface.
**Solución**:
Así que creamos una interface. (Ctrl+. y generar interface)
```C#
```
y hacemos que nuestra clase de detalle implemente esos métodos.
```C#
```
Y refactorizamos nuestro sistema para que dependa de la interfaz.

# Resumen de lo que hemos hecho

Las sentencias que antes leían y/o escribían en disco en el método constructor, las hemos trasladado a un método distinto, ese método lo hemos encapsulado en una clase responsable de la persistencia en CSV. 
Hemos inyectado esa dependencia a través de un paraḿetro en el constructor, y hemos desacoplado nuestro `Sistema` haciendo que dependa de una interfaz.

Veamos si es así.   
Si así fuese podríamos crear un nuevo servicio de persistencia, que en lugar de guardar en CSV, guarde en JSON, o guarde en BBDD.
Sólo debe implementar la interfaz, pero nuestro sistema se va a acomportar exactamente igual. 

Ejercicio hacer lo mismo en formato Json (_observa que no utilizamos los mismos métodos de leectur y escritura_):
```C#
using System.Text.Json;

var txtJson = File.ReadAllText(datafile);
var data = JsonSerializer.Deserialize<List<InfoVacPaciente>>(txtJson);
          
var options = new JsonSerializerOptions { WriteIndented = true };
var txtJson = JsonSerializer.Serialize(data, options);
File.WriteAllText(datafile, txtJson);
```


# Más mejoras.
La conversión de datos entre [`Tiers y Layers`](https://www.baeldung.com/cs/layers-vs-tiers) de la aplicación, suele ser un disgusto de conversiones. En este caso los Layers de sistema y acceso a datos, necesitan una conversón de `InfoVacPaciente` a `string` y viceversa.  

La conversión de datos se realiza por motivos de un protocolo de comunicaciones y obliga a crear objetos específicos llamados `DTO` (Data Transfer Objects) que se necesitan convertir, y también cuando tenemos que presentar datos en una vista se suele componer un objeto llamado `MV`(ModelView o vista de Modelo) que contiene muchos más datos que el original. Nuestro MV lo hemos solucionado haciendo que todos los Modelos implement el ToString() que es lo que se necesita para presentarlo en consola.

Pero el asunto aquí es donde poner esas utilidades de conversión de datos.
Hay que decidir un criterio, o creamos una utilidad de conversión para cada Layer que maneje nuestra aplicación, o creamos un clase utilidad que agrupe los conversores, o podemos añadirlo como métodos de nuestro Modelo, y es ésta donde ahora mismo me gustará que estén.

# Embelleciendo nuestros métodos
- Explicación sobre Lambdas.....

- Añadimos una Cabecera y la saltamos
- Saltamos posibles lineas en blanco
