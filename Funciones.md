# Funciones como dato
Si una función es un dato:  
- Se declara, es decir seguiremos el patrón **tipo nombrevariable**
- Se asigna un valor
- Se puede pasar como parámetro a otra función
- Se puede recoger como retorno de otra función

Tipo:  
- TDelegate 
```C#
// Declaración de una variable de tipo 'ConcatenarLargoD'
ConcatenarLargoD funcionCLD = (string s) => $"{s}:{s.Length}";
// Definición de un tipo de dato delegate
public delegate string ConcatenarLargoD(string value);
```  
- Func<{tipos de los parámetros},{tipo return}>
```C#
// Declaración de una variable de tipo Func, y su asignación
// Declaramos la signatura/firma de la función
Func<string, string> ConcatenarLargo;
ConcatenarLargo = (string s) => $"{s}:{s.Length}";
// Declaración e inicialización
Func<string, string>  ConcatenarLargo2 = (string s) => $"{s}:{s.Length}";
Func<int,bool> Super10 = (int i) => i > 10;

```  
- Predicate<{tipos de los parámetros}> (return bool)
```C#
// Predicate -> Func retorno bool
Predicate<int> MiPredicadoSuper10 = (int i) => i > 10;
```
- Action<{tipos de los parámetros}> (no return)
```C#
// Action -> Func sin retorno
Action<int> MiActionDeSaludar = (int i) => System.Console.WriteLine($"Hola Mundo {i}");
```

Como Parámetros:  
- Con funciones declaradas  
```C#
var misEnteros = new List<int> { 2, 14, 7, 19 };
misEnteros.Where(Super10).ToList().ForEach(MiActionDeSaludar);
```
- Con definición de la función en el parámetros   
```C#
misEnteros.Where(i => i > 10).ToList().ForEach(i =>{
    Console.WriteLine($"Hola Mundo {i}");
});
```
