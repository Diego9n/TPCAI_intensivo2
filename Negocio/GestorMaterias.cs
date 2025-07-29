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

        public List<CursoResponse> ObtenerCursos(int Materia) 
        {
            var listaCursos = CursoPersistencia.buscarCursosMaterias(Materia);

            return listaCursos;


        }
    }
}
