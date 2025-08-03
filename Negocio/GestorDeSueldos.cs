using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorDeSueldos
    {
        ProfesorDto ProfesorDto = new ProfesorDto();    

        public SueldoPersonal CalcularSueldo(long profesorid)
        {
            bool profesorencontrado = false;
            int horasSemanales = 0;
            List<int> cursosContados = new List<int>();
            GestorCarreras gestorCarreras = new GestorCarreras();   
            GestorMaterias gestorMaterias = new GestorMaterias();
            SueldoPersonal sueldoPersonal = new SueldoPersonal();
            GestorProfesores gestorProfesores = new GestorProfesores();
            List<ProfesorDto> listaProfesores = gestorProfesores.ObtenerProfesores();   
           
            foreach (var profesor in listaProfesores)
            {
                if (profesor.Id == profesorid)
                {
                   
               
                    sueldoPersonal.Dni = profesor.Dni;
                    sueldoPersonal.Nombre = profesor.Nombre;
                    sueldoPersonal.Apellido = profesor.Apellido;
                    sueldoPersonal.Cuit = profesor.Cuit;
                    sueldoPersonal.Antiguedad = profesor.Antiguedad;
                    sueldoPersonal.Tipo = profesor.Tipo;
                    profesorencontrado = true;

                    break;
                   
                }
            }
            if (sueldoPersonal.Tipo == "AYUDANTE_AD_HONOREM")
            {
                sueldoPersonal.Mensaje = ("El cargo de ayudante ad honorem se ejerce con carácter" + "\n" +
                                          "no rentado sin derecho a percepción de haberes ni" + "\n" +
                                          "compensacion economica ni genera vínculo laboral con " + "\n" +
                                          "la institución. No obstante su aporte voluntario es " + " \n" +
                                          "especialmente valorado y agradecido por esta casa de  " + "\n" +
                                          "estudios en reconocimiento al compromiso académico y "+ "\n" +
                                          "al espíritu de colaboración con la formación universitaria."
                                          );

            }
            else if (profesorencontrado == true)
            { 
                List<CarreraDto> ListaCarreras = gestorCarreras.ObtenerCarreras();

                foreach (var carreras in ListaCarreras)
                {
                List < MateriaDto >listaMaterias = gestorMaterias.ObtenerMaterias(carreras.Id);
               
                foreach (var materias in listaMaterias )
                {
                    List<CursoResponseDto> listaCursos = gestorMaterias.ObtenerCursos(materias.Id);
                    foreach (var cursos in listaCursos)
                    {
                            if (cursosContados.Contains(cursos.id))
                                continue;
                            foreach (var listaprofesores in cursos.idDocentes)
                        {
                            if (profesorid == listaprofesores)
                            {   
                               
                                    cursosContados.Add(cursos.id);
                                    horasSemanales = horasSemanales +  materias.HorasSemanales;
                                    break;
                                }


                        }
                       

                    }



                }
                }

                if (sueldoPersonal.Tipo == "PROFESOR")
                {
                    double precioHora = 7700;
                    double coefCargo = 1.2;
                    int tramosAntiguedad = sueldoPersonal.Antiguedad / 5;
                    double coefAntiguedad = Math.Pow(1.1, tramosAntiguedad);

                    sueldoPersonal.preciohora = precioHora;
                    sueldoPersonal.CoeficienteSueldo = coefCargo;
                    sueldoPersonal.Sueldo = Math.Round( horasSemanales * precioHora * coefCargo * coefAntiguedad ,2);

                }else if (sueldoPersonal.Tipo == "AYUDANTE")
                {
                    double precioHora = 7700;
                    double coefCargo = 1.05;
                    int tramosAntiguedad = sueldoPersonal.Antiguedad / 5;
                    double coefAntiguedad = Math.Pow(1.1, tramosAntiguedad);

                    sueldoPersonal.preciohora = precioHora;
                    sueldoPersonal.CoeficienteSueldo = coefCargo;
                    sueldoPersonal.Sueldo = Math.Round(horasSemanales * precioHora * coefCargo * coefAntiguedad,2);



                }


            }
                return sueldoPersonal;





        }

    }
}
