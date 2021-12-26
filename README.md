# Verificación de PCR

## Enunciado
La siguiente imagen
![Preoperatorio](Preoperatorio.jpg)
es el protocolo que se aplica a un paciente que ingresa en Urgencias para saber si se le ha de aplicar la prueba PCR.

De la sóla imagen se puede extraer el enunciado de la Aplicación Sanitaria que vamos a analizar.

- 1º. Centrada en el servicio de Urgencias, y específicamente el foco se centra en indicar `Si/No` se debe practicar al paciente una `prueba PCR` a la llegada al servicio.
- 2º De la foto, los datos que podemos inferir y clasificar son:  
    - **Datos de la Vacunación del Paciente**: (Este conjunto de datos es para obtener un Si/No si tiene su pauta completa)  

        `PacienteID`¿?  
        `Fecha última vacuna`  
        `Tipo de vacuna aplicada`  
        `Número de dosis recibidas`  
   
    - **Datos sobre `Sintomatología` compatible (Si/No)**  
    - **Datos sobre `Inmunodepresión` (Si/No)**  
Éstos últimos simularemos que son proporcionados por el sanitario.  

**Datos de configuración de la aplicación**  
Y éstos como constantes del servicio (reglas del negocio para confirmar la pauta)  
- Datos sobre el Tipo de Vacuna  
    - `Astra`, `Moderna`, `Pfizer`, `J&J`  
- Datos sobre el cumplimiento de la pauta  
    - Días desde la última vacuna = `14`
    - Número de Dosis mínima x Tipo De Vacuna = { `2`, `2`, `2`, `1`}

## La Aplicación   
La aplicación, quedará centralizada en una clase (Lógica de Negocio) que contendrá como atributos la lista de pacients ingresados, y los metodos para su gestión, y el método que decide si se realiza la prueba, y lo que necesite.   
También realizará el ingreso y alta de pacientes.




