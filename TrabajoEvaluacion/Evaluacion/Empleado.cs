using System;
using System.Threading.Tasks;

namespace Evaluacion
{
    // Clase de empleado con herencia de Persona y un nuevo atributo "Salario"
    public class Empleado : Persona, IPersona
    {
        // Atributo adicional del salario
        public decimal Salario { get; set; }

        public Empleado() : base()
        {
            Salario = 10500000; // Salario mensual
        }

        // Herencia de la clase Persona
        public Empleado(int id, string nombre, int edad, string direccion, decimal salario)
            : base(id, nombre, edad, direccion)
        {
            Salario = salario;
        }

        // Mostrar la información del empleado
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Salario: {Salario:C2}");
        }

        public double CalcularSalario()
        {
            return (double)Salario;
        }

        public async Task<double> CalcularSalarioAsync()
        {
            // Método asíncrono para devolver el salario con 2 segundos de retraso
            await Task.Delay(2000);
            return (double)Salario;
        }

        // Pago de acuerdo a los días de trabajo
        public decimal CalcularSalarioPorDia(int diasTrabajados)
        {
            // Salario por día
            decimal salarioDiario = Salario / 30; // Días del mes que se trabaja
            return salarioDiario * diasTrabajados;
        }

        public async Task<decimal> CalcularSalarioPorDiaAsync(int diasTrabajados)
        {
            await Task.Delay(2000); // Simular un retraso para el cálculo
            return CalcularSalarioPorDia(diasTrabajados);
        }
    }
}
