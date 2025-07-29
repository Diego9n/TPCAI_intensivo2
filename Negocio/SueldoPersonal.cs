using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SueldoPersonal
    {
        String nombre;
        String apellido;
        string cuit;
        string dni;
        int antiguedad;
        string tipo;
        double sueldo;  
        string horasTrabajadas;
        string mensaje;

        public double preciohora { get; set; }
        public double CoeficienteSueldo { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public string Dni { get => dni; set => dni = value; }
        public int Antiguedad { get => antiguedad; set => antiguedad = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public string HorasTrabajadas { get => horasTrabajadas; set => horasTrabajadas = value; }

        public string Mensaje { get; set; }

        
    }
}
