using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorMaterias
    {
          
      
        MateriaPersistencia materiaPersistencia = new MateriaPersistencia();
        CursoPersistencia CursoPersistencia = new CursoPersistencia();
        List<MateriaResponse> materias = new List<MateriaResponse>();
        List<CursoResponse> Cursos = new List<CursoResponse>();
        public List<MateriaDto> ObtenerMaterias(int idcarrera)
        {

            var listaResponse = materiaPersistencia.buscarDatosUsuario(idcarrera);
            List<MateriaDto> listaDTO = new List<MateriaDto>();
            foreach (var materia in listaResponse)
            {
                listaDTO.Add(new MateriaDto
                {
                    id = (int)materia.id,
                    nombre = materia.nombre,
                    horassemanales = materia.horassemanales,

                });
            }

            return listaDTO;
        }

        public List<CursoResponseDto> ObtenerCursos(int Materia)
        {
            var listaCursos = CursoPersistencia.buscarCursosMaterias(Materia);
            List<CursoResponseDto> listaCursosDto = new List<CursoResponseDto>();
            foreach (var curso in listaCursos)
            {
                listaCursosDto.Add(new CursoResponseDto
                {
                    id = curso.id,
                    profesorNombre = curso.profesorNombre,
                    dias = curso.dias,
                    horarios = curso.horarios.Select(h => new HorariosResponseDtocs
                    {
                        dia = h.dia,
                        horaInicio = h.horaInicio,
                        horaFin = h.horaFin
                    }).ToList(),
                    idDocentes = curso.idDocentes
                });
            }

            return listaCursosDto;
        }
    }
}
