using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorEgresados
    {
        public Validar gestorDatos = new Validar();

        public List<EgresadoReporte> GenerarReporteEgresados(int carreraId)
        {
            List<AlumnoDto> todosLosAlumnos = gestorDatos.ObtenerAlumnos();
            List<MateriaDto> materiasDeLaCarrera = gestorDatos.ObtenerMateriasPorCarrera(carreraId);

            var listaDeEgresados = new List<EgresadoReporte>();

            if (materiasDeLaCarrera == null || !materiasDeLaCarrera.Any())
            {
                return listaDeEgresados;
            }

            foreach (var alumno in todosLosAlumnos)
            {
                if (alumno.CarrerasIds != null && alumno.CarrerasIds.Contains(carreraId))
                {
                    List<MateriaAlumnoDto> materiasDelAlumno = gestorDatos.ObtenerMateriasDeAlumno(alumno.Id);

                    if (EsEgresado(materiasDeLaCarrera, materiasDelAlumno))
                    {
                        double promedio = CalcularPromedio(materiasDelAlumno);
                        string titulo = ObtenerTituloHonorifico(promedio);

                        listaDeEgresados.Add(new EgresadoReporte
                        {
                            Nombre = alumno.Nombre,
                            Apellido = alumno.Apellido,
                            DNI = alumno.Dni,
                            Promedio = Math.Round(promedio, 2),
                            TituloHonorifico = titulo
                        });
                    }
                }
            }

            return listaDeEgresados;
        }
        public bool EsEgresado(List<MateriaDto> materiasRequeridas, List<MateriaAlumnoDto> materiasCursadas)
        {
            if (materiasCursadas == null) return false;

            var idsMateriasRequeridas = materiasRequeridas.Select(m => m.Id).ToHashSet();
            var idsMateriasAprobadas = materiasCursadas
                .Where(m => m.Condicion != null && m.Condicion.Trim().Equals("APROBADO", StringComparison.OrdinalIgnoreCase))
                .Select(m => m.Id)
                .ToHashSet();

            return idsMateriasRequeridas.IsSubsetOf(idsMateriasAprobadas);
        }
        public double CalcularPromedio(List<MateriaAlumnoDto> materiasDelAlumno)
        {
            var materiasAprobadasConNota = materiasDelAlumno.Where(m =>
                m.Condicion != null &&
                m.Condicion.Trim().Equals("APROBADO", StringComparison.OrdinalIgnoreCase) &&
                m.Nota.HasValue
            );

            if (!materiasAprobadasConNota.Any()) return 0;
            return materiasAprobadasConNota.Average(m => m.Nota.Value);
        }

        public string ObtenerTituloHonorifico(double promedio)
        {
            if (promedio == 10.00) return "Summa Cum Laude";
            if (promedio >= 9.00) return "Magna Cum Laude";
            if (promedio >= 8.00) return "Cum Laude";
            return "Ninguno";
        }
        public List<CarreraDto> ObtenerCarreras()
        {
            return gestorDatos.ObtenerCarreras();
        }
        public class EgresadoReporte
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string DNI { get; set; }
            public double Promedio { get; set; }
            public string TituloHonorifico { get; set; }
        }
    }
}
