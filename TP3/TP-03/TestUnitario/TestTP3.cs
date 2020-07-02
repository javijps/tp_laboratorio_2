using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;


namespace TestUnitario
{
    [TestClass]
    public class TestTP3
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void VerificarLanzamientoNacionalidadInvalidaException()
        {
            //Arrange
           
            //Act
            Alumno a = new Alumno(1, "Javier", "Scalise", "35087658", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            
            //Assert Exception
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void VerificarLanzamientoDniInvalidoException()
        {
            Alumno a = new Alumno(1, "Javier", "Scalise", "35J087658", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }


        [TestMethod]
        public void JornadaDefault()
        {
            //Arrange
            Profesor p = new Profesor(1,"Javier","Scalise","35087658",Persona.ENacionalidad.Argentino);

            //Act
            Jornada j = new Jornada(Universidad.EClases.Laboratorio, p);

            //Assert
            Assert.IsNotNull(j.Alumnos);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void VerificarIgualdadAlumnosPorDni()
        {
            //Arrange
            Universidad u1 = new Universidad();
            Alumno a1 = new Alumno(1, "Javier", "Scalise", "35087658", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Pedro", "Gonzalez", "35087658", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

            u1 += a1;
            u1 += a2;


            //Assert exception




            //////Act
            ////bool rta = a1 == a2;

            //////Assert
            ////Assert.IsTrue(rta);
        }

        [TestMethod]
        public void VerificarInscripcionAlumno()
        {
            //Arrange
            Alumno a1 = new Alumno(1, "Javier", "Scalise", "35087658", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Universidad u = new Universidad();

            //Act
            //si la comparacion Universidad == Alumno es true, el alumno fue inscripto exitosamente.

            u += a1;
            bool rta = u == a1;

            //Assert
            Assert.IsTrue(rta);
        }
    }
}
