using System;
using System.Threading.Tasks;

namespace Evaluacion
{
    // Interfaz de Persona para manejar el salario
    internal interface IPersona
    {
        double CalcularSalario();
        Task<double> CalcularSalarioAsync();
    }
}
