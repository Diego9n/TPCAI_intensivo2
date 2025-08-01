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

                            if (estado == "APROBADO"  || estado == "FINAL")
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

        public double ObtenerRanking(int idAlummno)
        {
            double ranking =0.0 , A = 0.0 , B = 0.0;
            
            GestorInscripciones gestorInscripciones = new GestorInscripciones();
            var listaAprobadas = gestorInscripciones.ObtenerAlumno(idAlummno);
            foreach ( var aprobadas in listaAprobadas )
            {
                if (aprobadas.condicion == "APROBADO" || aprobadas.condicion == "FINAL")
                {
                    A++;
                }
                if (aprobadas.condicion == "APROBADO")
                {
                    B++;
                }

            }

            ranking = (A * 100) + (B * 3) ;



            return ranking;
        }
    }
}