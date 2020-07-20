using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Paquete paquete;
        private Correo correo;

        #region Constructor 

        /// <summary>
        /// Constructo por defecto del Formulario
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.Text = "Correo UTN por Javier.Scalise.2A";
            this.correo = new Correo();
        }

        #endregion

        #region Manejadores

        /// <summary>
        /// Manejador del evento click del boton agregar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingId.Text);

                PaqueteDAO.ExcepcionDAO += new PaqueteDAO.DelegadoExcepcionDAO(MostrarMensajeExcepcionDAO);

                paquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);

                this.correo += this.paquete;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible ingresar el paquete! Mensaje de error: " + ex.Message);

                PaqueteDAO.ExcepcionDAO -= new PaqueteDAO.DelegadoExcepcionDAO(MostrarMensajeExcepcionDAO);
            }

            this.ActualizarEstados();
            this.txtDireccion.Clear();
            this.mtxtTrackingId.Clear();

        }

        /// <summary>
        /// Manejador del evento click del boton Mostrar Todos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Manejador del evento click del context menu strip Mostrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Manejador del evento closing del formulario principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinDeEntregas();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }


        /// <summary>
        /// Método que actualiza el estado de los paquetes.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();


            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        {
                            this.lstEstadoIngresado.Items.Add(item);
                            break;
                        }
                    case Paquete.EEstado.EnViaje:
                        {
                            this.lstEstadoEnViaje.Items.Add(item);
                            break;
                        }
                    case Paquete.EEstado.Entregado:
                        {
                            this.lstEstadoEntregado.Items.Add(item);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Muestra los datos del elemento en el rtbMostrar y guarda los datos en un archivo a traves del metodo 
        /// de extension de la clase string Guardar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                try
                {
                    this.rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception ex)
                {
                   
                    string mensaje = String.Format("No ha sido posible guardar los datos. Mensaje de error: {0}",ex.Message); 
                    MessageBox.Show(mensaje);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        private void MostrarMensajeExcepcionDAO(string msg, Exception e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("No fue posible almacenar la informacion en la base de datos!");
            sb.AppendLine();
            sb.Append("Excepcion: ");
            sb.AppendLine(e.GetType().ToString());
            sb.AppendLine();
            sb.AppendLine(msg);
            
            MessageBox.Show(sb.ToString());

            PaqueteDAO.ExcepcionDAO -= new PaqueteDAO.DelegadoExcepcionDAO(MostrarMensajeExcepcionDAO);

        }

        #endregion
    }
}
