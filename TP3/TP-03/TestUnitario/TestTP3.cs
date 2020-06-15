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
        public void VerificarLanzamientoNacionalidadInvalidaException()
        {
            //Arrange
            //Act
            try
            {
                Alumno a = new Alumno(1, "Javier", "Scalise", "35087658", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch(NacionalidadInvalidaException e)
            {
                //Assert
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

        }

        [TestMethod]
        public void VerificarLanzamientoDniInvalidoException()
        {
            //Arrange
            //Act
            try
            {
                Alumno a = new Alumno(1, "Javier", "Scalise", "35J087658", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (DniInvalidoException e)
            {
                //Assert
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

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
        public void VerificarIgualdadAlumnosPorDni()
        {
            //Arrange
            Alumno a1 = new Alumno(1, "Javier", "Scalise", "35087658", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Pedro", "Gonzalez", "35087658", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

            //Act
            bool rta = a1 == a2;

            //Assert
            Assert.IsTrue(rta);
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
