using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Negocio
{
    public class GestorInscripciones
    {


        CarreraPersistencia CarreraPersistencia = new CarreraPersistencia();
        ProfesorPersistencia ProfesorPersistencia = new ProfesorPersistencia();
        AlumnoPersistencia AlumnoPersistencia = new AlumnoPersistencia();
        List<CarreraResponse> carreras = new List<CarreraResponse>();
        List<ProfesorResponse> profesores = new List<ProfesorResponse>();
        MateriaPersistencia materiaPersistencia = new MateriaPersistencia();
        List<MateriaResponse> materias = new List<MateriaResponse>();

        public List<MateriaDto> ObtenerMaterias(int idcarrera)
        {

            var listaResponse = materiaPersistencia.buscarDatosUsuario(idcarrera);
            List<MateriaDto> listaDTO = new List<MateriaDto>();
            foreach (var materia in listaResponse)
            {
                listaDTO.Add(new MateriaDto
                {
                    Id = (int)materia.Id,
                    Nombre = materia.Nombre,
                    HorasSemanales = materia.HorasSemanales,
                    Correlativas = materia.Correlativas?.Select(c => new MateriaDto
                    {
                        Id = (int)c.Id,
                        Nombre = c.Nombre,
                        HorasSemanales = c.HorasSemanales
                    }).ToList() // Convertir correlativas a MateriaDto  

                });
            }

            return listaDTO;
        }

        public List<CarreraDto> ObtenerCarreras()
        {
            var listaResponse = CarreraPersistencia.buscarDatosUsuario();

            // Convertir CarreraResponse a CarreraDTO para manejar datos
            // de forma más sencilla en la interfaz de usuario.
            List<CarreraDto> listaDTO = new List<CarreraDto>();
            foreach (var carrera in listaResponse)
            {
                listaDTO.Add(new CarreraDto
                {
                    Id = (int)carrera.Id,
                    Nombre = carrera.Nombre
                });
            }

            return listaDTO;
        }
        public List<AlumnoCondicionDto> ObtenerAlumno(int idalummno)
        {

            var listaResponse = AlumnoPersistencia.BuscarConddiconAlumno(idalummno);
            List<AlumnoCondicionDto> listaDTO = new List<AlumnoCondicionDto>();
            foreach (var Acondicion in listaResponse)
            {
                listaDTO.Add(new AlumnoCondicionDto
                {
                    id = (int)Acondicion.id,
                    nombre = Acondicion.nombre,
                    condicion = Acondicion.condicion,
                    nota = Acondicion.nota ?? 0 // Asignar 0 si nota es null

                });
            }



            return listaDTO;
        }
        public List<MateriaDto> ObtenerMateriasHabilitadas(int idCarrera, int idAlumno)
        {
            List<MateriaDto> todasLasMaterias = ObtenerMaterias(idCarrera);
            List<AlumnoCondicionResponse> condicionesAlumno = AlumnoPersistencia.BuscarConddiconAlumno(idAlumno);
            List<MateriaDto> materiasNoAprobadas = new List<MateriaDto>();

            foreach (var materia in todasLasMaterias)
            {
                bool aprobada = false;

                for (int i = 0; i < condicionesAlumno.Count; i++)
                {
                    var condicion = condicionesAlumno[i];

                    if (condicion.id == materia.Id)
                    {
                        string estado = "";
                        if (condicion.condicion != null)
                            estado = condicion.condicion.ToUpper();

                        if (estado == "APROBADO" || estado == "INSCRIPTO")
                        {
                            aprobada = true;
                            break;
                        }
                    }
                }

                if (!aprobada)
                {
                    materiasNoAprobadas.Add(materia);
                }
            }
            List<MateriaDto> materiasHabilitadas = new List<MateriaDto>();

            foreach (var materia in materiasNoAprobadas)
            {
                var correlativas = materia.Correlativas;

                if (correlativas == null || correlativas.Count == 0)
                {
                    materiasHabilitadas.Add(materia);
                    continue;
                }

                bool todasCorrelativasAprobadas = true;

                foreach (var correlativa in correlativas)
                {
                    bool correlativaAprobada = false;

                    for (int j = 0; j < condicionesAlumno.Count; j++)
                    {
                        var condicion = condicionesAlumno[j];

                        if (condicion.id == correlativa.Id)
                        {
                            string estado = "";
                            if (condicion.condicion != null)
                                estado = condicion.condicion.ToUpper();

                            if (estado == "APROBADO" || estado == "FINAL")
                            {
                                correlativaAprobada = true;
                                break;
                            }
                        }
                    }

                    if (!correlativaAprobada)
                    {
                        todasCorrelativasAprobadas = false;
                        break;
                    }
                }

                if (todasCorrelativasAprobadas)
                {
                    materiasHabilitadas.Add(materia);
                }
            }

            return materiasHabilitadas;

        }

        public double ObtenerRanking(int idAlumno, CarreraDto carrera)
        {
            double A = 0.0, B = 0.0, C = 0.0, D = 0.0, acumulador = 0.0;
            double contadorRestantes = 0.0;
            double contadordenota = 0.0;
            double contadorRestantes2 = 0.0;

            List<AlumnoCondicionDto> alumnoCondicion = new List<AlumnoCondicionDto>();
            alumnoCondicion = ObtenerAlumno(idAlumno);
            GestorInscripciones gestorInscripciones = new GestorInscripciones();
            List<MateriaDto> materiasdecarrera = gestorInscripciones.ObtenerMaterias(carrera.Id);
            var listaResponse = CarreraPersistencia.ObtenerMateriasPorCarrera(carrera.Id);

            foreach (var materia in alumnoCondicion)

            {
                foreach (var Carrera in materiasdecarrera)
                {
                    {
                        if (materia.id == Carrera.Id)
                        {
                            if (materia.condicion == "DESAPROBADO" || materia.condicion == "FINAL")
                            {
                                contadorRestantes2++;
                            }
                        }
                    }
                }
                if (materia.condicion == "APROBADO" || materia.condicion == "FINAL")
                {
                    A++;
                }

                if (materia.condicion == "APROBADO")
                {
                    B++;
                    acumulador += materia.nota;
                }

                if (materia.condicion == "APROBADO" || materia.condicion == "DESAPROBADO" || materia.condicion == null)
                {
                    contadorRestantes++;
                    contadordenota = contadordenota + materia.nota;

                }
                if (contadorRestantes > 8)
                {
                    D = 0; // Si hay más de 8 materias restantes, D es 0
                }
                if (contadorRestantes == 1)
                {
                    D = 90;
                }
                if (contadorRestantes == 2)
                {
                    D = 60;
                }
                if (contadorRestantes == 3)
                {
                    D = 45;
                }
                if (contadorRestantes == 4)
                {
                    D = 30;
                }
                if (contadorRestantes == 5)
                {
                    D = 20;
                }
                if (contadorRestantes == 6)
                {
                    D = 15;
                }
                if (contadorRestantes == 7)
                {
                    D = 10;
                }
                if (contadorRestantes == 8)
                {
                    D = 5;
                }

            }
            C = contadordenota / contadorRestantes;
            // Dictionary<int, int> puntosPorMateriasRestantes = new Dictionary<int, int>

            //  {
            //  {8, 5},
            // {7, 10},
            // {6, 15},
            // {5, 20},
            // {4, 30},
            // {//3, 45},
            //{2, 60},
            //{1, 90}
            // };

            //if (puntosPorMateriasRestantes.TryGetValue((int)contadorRestantes2, out int puntosExtra))
            //{
            //  D = puntosExtra;
            //}
            //else
            //{
            // D = 0;
            // }



            double ranking = (A * 100) + (B * 3) + (C * 3) + D;
            return ranking;
        }
        
   public bool HorariosCursos(List<CursoResponseDto> Cursos, List<CursoResponseDto> cursosSeleccionados, int CursoAinscribrirse)
        {
            CursoResponseDto cursoNuevo = null;

            foreach (var Curso in Cursos)
            {
                if (Curso.id == CursoAinscribrirse)
                {
                    cursoNuevo = Curso;
                    break;
                }
            }

            if (cursoNuevo == null)
                return false;

            foreach (var cursoSeleccionado in cursosSeleccionados)
            {
                foreach (var horarioNuevo in cursoNuevo.horarios)
                {
                    foreach (var horarioExistente in cursoSeleccionado.horarios)
                    {

                        if (horarioNuevo.dia == horarioExistente.dia)
                        {
                            string inicioNuevo = horarioNuevo.horaInicio;
                            string finNuevo = horarioNuevo.horaFin;
                            string inicioExistente = horarioExistente.horaInicio;
                            string finExistente = horarioExistente.horaFin;
                            bool haySolapamiento = inicioNuevo.CompareTo(finExistente) < 0 && inicioExistente.CompareTo(finNuevo) < 0;
                            if (haySolapamiento)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public void InscribirAlumno(int idAlumno, List<int> idsCursos)
        {
            AlumnoPersistencia alumnoPersistencia = new AlumnoPersistencia();
            AlumnoPersistencia.InscribirAlumno(idAlumno, idsCursos);


        }

        public List<AlumnoCondicionDto> ObtenerMateriasFinales(int idAlumno)
        {
            List<AlumnoCondicionDto> materiasenfinal = new List<AlumnoCondicionDto>();
            List<AlumnoCondicionDto> alumnoCondicion = new List<AlumnoCondicionDto>();
            alumnoCondicion = ObtenerAlumno(idAlumno);
            foreach (var materia in alumnoCondicion)
            {
                if (materia.condicion == "FINAL")
                {
                    materiasenfinal.Add(materia);
                }
            }



            return materiasenfinal;



        }
        public bool ValidarFinal(AlumnoCondicionDto MateriaFinalaInscribirse, List<AlumnoCondicionDto> listaMateriasInscriptas)
        {
            foreach (var materia in listaMateriasInscriptas)
            {
                if (materia.id == MateriaFinalaInscribirse.id)
                {
                    return true;
                }
            }


            return false;
        }
    }

}



