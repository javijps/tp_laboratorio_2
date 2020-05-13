using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        #region "Enumerados"

        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor privado de la Clase Estacionamiento. Inicializa la lista de tipo vehiculos.
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor publico de la Clase Estacionamiento. Recibe como parametro espacio disponible e inicializa el atributo con ese valor.
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Estacionamiento(int espacioDisponible)
            :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Estacionamiento.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles\n", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if (v is Camioneta)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if (v is Moto)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Automovil:
                        if (v is Automovil)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            if (c.vehiculos.Count < c.espacioDisponible)
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v == p)
                    {
                        return c;
                    }
                }
                c.vehiculos.Add(p);
            }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            for (int i = 0; i < c.vehiculos.Count(); i++)
            {
                if (c.vehiculos[i] == p)
                {
                    c.vehiculos.Remove(c.vehiculos[i]);
                    return c;
                }
            }
            return c;
        }
        #endregion

    }
}
