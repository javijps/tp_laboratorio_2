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

    }
}
