using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que la lista paquetes este instanciada.
        /// </summary>
        [TestMethod]
        public void InstanciaListaPaquetes()
        {
            Correo c = new Correo();

            Assert.IsNotNull(c.Paquetes);
        }


        /// <summary>
        /// Verifica que se lance la excepcion TrackingIdRepetidoException al agregar dos paquetes con el mismo trackingID
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TrackingIdRepetido()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Pareta 515", "1234");
            Paquete p2 = new Paquete("Kurt 234", "1234");

            c += p1;
            c += p2;
        }

        /// <summary>
        /// Verifica que se se carguen correctamente paquetes con tracking ID distinto.
        /// </summary>
        [TestMethod]
        public void TrackingIdDiferente()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Pareta 515", "1234");
            Paquete p2 = new Paquete("Pareta 515", "4321");
            
            c += p1;
            c += p2;

            int cantidadDePaquetes = c.Paquetes.Count;

            Assert.IsTrue(cantidadDePaquetes == 2);
        }
    }

}
