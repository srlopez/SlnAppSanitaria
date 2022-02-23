# Creación de un Servicio de Repositorio para Persistencia de Datos.

Vamos a añadir persitencia a  nuestra aplicación Sanitaria.
En este caso lo que vamos a persitir en disco son nuestros ingresados y en formato CSV.

# Paso 0.- Partiendo de una lista codificada

Hemos partido de una lista de datos (Ingresados) que estaba codificada en el `Sistema` `GestorDeUrgencias`.
- Es correcto que le `Sistema`sea quien sabe con qué datos trabajamos. 
- Incicialmente los datos los hemos `codificado` ahí, pero eso no es lo normal, ya que las aplicaciones deben trabajar con datos `persistentes`.

Por lo tanto ahora vamos a dota a nuestro `Sistema` de persitencia de datos.
Así es como estaba inicializada la lista de Ingresados en el `GestorDeUrgencias` 
```C#
List<InfoVacPaciente> Ingresados { get; set; }= new()
        {
            new InfoVacPaciente
            {
                PacienteID = "Luis",
                TipoVacunacion = TipoVacuna.Ninguna,
                DosisRecibidas = 0,
                FechaUltimaDosis = DateTime.Now,
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

# Paso 1.- Creamos un archivo co System.IO.File
Este es un paso temporal. Al crear el constuctor, éste nos a invitado a que pasemos como parámetro la lista de ingresados. Y así lo hemo hecho.

Ya que el `Sistema` es el encargado de saber los datos, temporalmente, voy a escribir el código que salva/guarda la lista dentro del mismo `Sistema`. Se podría hacer en el `Program.cs`, pero al ser algo coyuntural que lo borraremos, lo puedo hacer donde quiera.

Para trabajar con el **FileSystem** o **Sistema de Archivos del S.O**., `C#` nos provee de la clase `File` para la que nos ofrece varios métodos.
```C#
using System.IO;
using System.Linq; //<- Para poder ToList()
```

Hemos decidido, por ahora, guardar nuestros _ingresados_ en formato _CSV_ (comma separated value), un formato en el que cada línea de texto representará un ingresado, y cada campo separado por coma, será una de las propiedades del ingresado.

## ESCRITURA
```C#
var _file = "../../data.csv";  //1
List <string> data = new(){};  //2
Ingresados.ForEach(i=>{ //3
    data.Add($"{i.PacienteID},{i.TipoVacunacion},{i.DosisRecibidas},{i.FechaUltimaDosis},{i.Edad},{i.Sexo}"); //4
});
File.WriteAllLines(_file, data); //5
```
Comentarios a la forma en que guardamos los datos.  
- //1  Establecemos el lugar/path donde vamos a guardar el archivo  
     Sería más correcto en un directorio especifico para `Data`, como por ejemplo `var _file = "../../Data/data.csv";`  
 - //2 Declaramos una List de string que es lo que luego escribiremos en disco.  
 - //3 Ciclo para cada uno de los elementos de la lista ...  
 - //4 En el que añadimos a la lista cada uno de las propiedades que queremos persistir.  
 - //5 Y lo escribimos en el FS.  

Este es el resultado
```
Luis,Ninguna,0,2/23/2022 11:03:03 AM,23,H
Marta,Astra,2,2/13/2022 11:03:03 AM,45,M
```
## LECTURA
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
- //2 ciclo para cada una de las filas/row leidas  
- //3 cada linea (Un string) la convierto el una lista de string,   indicando que es un dato distinto si está separado del anterior por una coma. Obteniendo una lista de campos  
- //4 Creo un ingresado con los valores leidos  
    - Nos viene muy bien que hay tantos tipos de datos distintos en nuestro modelo. Así podemos ver como covertimos cada `string` al tipo de datos que corresponda.
    - string, char, DateTime, Enum, Int32
- //5 Añadimos el ingresado a la lista de Ingresados.

# Paso 3.- Deshacemos lo hecho. Este es nuesto punto CERO
- Es decir eliminamos del contructor el parámetro de ingresados, ya que a partir de ahora lo vamos a guardar en disco.
- En el constructor sólo dejaremos la lectura inicial de datos.
- Cada vez que se realice un ingreso o un alta debemos guardar de nuevo los datos, ya que estos han cambiado.

# Paso 4.- Errores que corregiremos de acuerdo a las buenas prácticas.
## E1
El Constructor del `Sistema` es un método en al que sólo atañe crear el `Sistema` no es responsable de leer datos de disco.  
**Solución**: Crearemos un método encargado de ello que será invocado desde el constructor.

## E2
Nuestro `Sistema` está leyendo directamente del disco para cargar unos datos.  
No es bueno que un módulo o clase de alto nivel (El responsble de la Lógica de nuestro negocio) se preocupe de temas como dónde guardar los datos, y meno en el nombre del archivo.
**Solución**: Creamos un clase, responsable de la gestión de los datos en el disco
A esto se le llama IoC. **Inversion Of Control**

## E3
Crear esa utilidad como un clase interna o instanciada dentro de nuestro constructor, no es una buena pŕactica. Hace que el `Sistema` dependa de la instanciación y del Tipo de clse de la utilidad.
**Solución**: Pasamos la clase como parámetro en la creación del `Sistema`.
A esto le llamamos ID. **Decencency Inyection**, aunque todavía le falta un paso más.

> Este paso es muy posible que nos obligue a separar en otro proyecto los Modelos, ya que:
- Se suele poner en proyecto aparte el acceso a datos
- El acceso a datos, debe hacer referencia a los Modelos, que están en el Proyecto del `Sistema`. Y el sistema debe hacer referencia al proyecto de persistencia de datos, para usarse cada vez que queramos guardar o leer datos. Se crea una **referencia cíclica**, que debemos eliminar. Y lo podemos hacer sacando los Modelos del proyecto principal.

```bsh
dotnet new classlib -o src/AppSanitaria.App.Models
dotnet new classlib -o src/AppSanitaria.Data
```

> Hemos de tocar el Program.cs para indicar el nuevo parámetro.

## E4
A nuestra lógica de negocio le hemos inyectado, un servicio de repositorio del que ahora depende, pero el pricipio de [Inversión de Dependencia](https://es.wikipedia.org/wiki/Principio_de_inversi%C3%B3n_de_la_dependencia) que:  
1.- Los módulos de alto nivel no deberían depender de los módulos de bajo nivel. Ambos deberían depender de abstracciones (p.ej., interfaces).  
2.- Las abstracciones no deberían depender de los detalles. Los detalles (implementaciones concretas) deben depender de abstracciones.  

Básicamente esto significa que:
Nuestro `Sistema` debe depender de una abstración (una `interface`). La abstracción no debe tener detalles, sino que estos deben ser implementados en la clase que implementará la interface.
**Solución**:
Así que creamos una interface.
```C#
```
y hacemos que nuestra clase de detalle implemente esos métodos.
```C#
```
Y refactorizamos nuestro Sistema para que dependa de la interfaz.

# Resumen de lo que hemos hecho

Las sentencias que antes leían y/o escribían en disco en el método constructor, las hemos trasladado a un método distinto, ese método lo hemos encapsulado en una clase responsable de la persistencia en CSV. 
Hemos inyectado esa dependencia a través de un paraḿetro en el constructor, y hemos desacoplado nuestro `Sistema` haciendo que dependa de una interfaz.

Veamos si es así.   
Si así fuese podríamos crear un nuevo servicio de persistencia, que en lugar de guardar en CSV, guarde en JSON, o guarde en BBDD.
Sólo debe implementar la interfaz, pero nuestro sistema se va a acomportar exactamente igual. 


# Todavía no está bien.
La conversión de datos entre [`Tiers y Layers`](https://www.baeldung.com/cs/layers-vs-tiers) de la aplicación, suele ser un disgusto de conversiones. En este caso los Layers de sistema y acceso a datos, necesitan una conversón de `InfoVacPaciente` a `string` y viceversa. Cuando esta conversión se realiza através de un protocolo de comunicaciones se crear objetos específicos llamados DTO (Data Transfer Objects) que se necesitan convertir, y cuando tenemos que presentar datos en una vista se suele componer un objeto llamado MV(ModelView o vista de Modelo) que contiene muchos más datos que el original. Nuestro MV lo hemos solucionado haciendo que todos los Modelos implement el ToString() que es lo que se necesita para presentarlo en consola.

Pero el asunto aquí es donde poner esas utilidades de conversión de datos.
Hay que decidir un criterio, o creamos una utilidad de conversión para cada Layer que maneje nuestra aplicación, o creamos un clase utilidad que agrupe los conversores, o podemos añadirlo como métodos de nuestro Modelo, y es está donde ahora mismo me gustará que estén.

# Embelleciendo nuestros métodos
- Explicación sobre Lambdas.....

- Añadimos un aCabecera y la saltamos
- Saltamos posibles lineas en blanco
