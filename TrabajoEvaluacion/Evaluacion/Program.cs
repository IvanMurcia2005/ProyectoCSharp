using System;
using System.Threading.Tasks;

namespace Evaluacion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Crear una instancia de Empleado con información predeterminada
            Empleado empleado = new Empleado(2, "Ana Gómez", 28, "Avenida Siempre Viva 456", 10500000);

            // Mostrar la información del empleado
            Console.WriteLine("Información del empleado:");
            empleado.MostrarInformacion();

            // Espera asíncrona de 1 segundo
            await empleado.EsperarAsync(1000);

            // Pedir al usuario que ingrese el salario mensual
            Console.Write("Ingrese el salario mensual: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salarioMensual))
            {
                Console.WriteLine("El valor ingresado no es un número válido.");
                return;
            }

            // Pedir al usuario que ingrese el número de días trabajados
            Console.Write("Ingrese el número de días trabajados en el mes: ");
            if (!int.TryParse(Console.ReadLine(), out int diasTrabajados) || diasTrabajados < 0)
            {
                Console.WriteLine("El valor ingresado no es un número válido o es negativo.");
                return;
            }

            // Actualizar el salario del empleado con el valor ingresado
            empleado.Salario = salarioMensual;

            // Mostrar la información actualizada del empleado
            Console.WriteLine("Información del empleado actualizada:");
            empleado.MostrarInformacion();

            // Calcular y mostrar el salario por mes
            double salarioPorMes = empleado.CalcularSalario();
            Console.WriteLine($"Salario mensual: {salarioPorMes:C2}");

            // Calcular y mostrar el salario por día
            decimal salarioPorDia = empleado.CalcularSalarioPorDia(diasTrabajados);
            Console.WriteLine($"Salario por {diasTrabajados} días trabajados: {salarioPorDia:C2}");

            // Calcular el salario de forma asíncrona (simular un retraso)
            double salarioAsync = await empleado.CalcularSalarioAsync();
            Console.WriteLine($"Salario mensual calculado (asíncrono): {salarioAsync:C2}");

            decimal salarioPorDiaAsync = await empleado.CalcularSalarioPorDiaAsync(diasTrabajados);
            Console.WriteLine($"Salario por {diasTrabajados} días trabajados (asíncrono): {salarioPorDiaAsync:C2}");
        }
    }
}
