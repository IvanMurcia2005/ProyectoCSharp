using System;
using System.Threading.Tasks;

namespace Evaluacion
{
    // Atributos de la clase persona
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }

        // Constructor con y sin informacion
        public Persona(int id, string nombre, int edad, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Direccion = direccion;
        }

        public Persona()
        {
            Id = 0;
            Edad = 0;
            Nombre = "Nombre de persona desconocido";
            Direccion = "Dirección desconocida";
        }

        // Mostrar información
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("Se muestra la informacion del empleado desde los datos de persona");
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Nombre : {Nombre}");
            Console.WriteLine($"Edad : {Edad}");
            Console.WriteLine($"Dirección : {Direccion}");
        }

        // Método sincrónico Esperar espera unos segundos
        public void Esperar(int milisegundos)
        {
            Console.WriteLine($"Esperando {milisegundos} milisegundos...");
            System.Threading.Thread.Sleep(milisegundos); // Simula una espera sincrónica
            Console.WriteLine("Terminó la espera.");
        }

        // Método asíncrono EsperarAsync no bloquea las tareas que están en proceso
        public async Task EsperarAsync(int milisegundos)
        {
            Console.WriteLine($"Esperando {milisegundos} milisegundos (asíncrono)...");
            await Task.Delay(milisegundos); // Simula una espera asíncrona
            Console.WriteLine("Terminó la espera (asíncrono).");
        }
    }
}
