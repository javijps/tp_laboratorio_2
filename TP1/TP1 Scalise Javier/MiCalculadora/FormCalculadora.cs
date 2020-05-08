using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Boton Operar. Realiza Operaciones con los valores ingresados en txtNumero1 y txtNumero2 a traves
        /// del Metodo Operar asignando el resultado a lblResultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;
            double resultado;
            operador = Convert.ToString(cmbOperador.SelectedItem);
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, operador);
            this.lblResultado.Text = Convert.ToString(resultado);
        }

        /// <summary>
        /// Boton Limpiar. Llama al Metodo Limpiar para dejar libres los textBox, comboBox y label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Boton Cerrar. Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
           Close();
        }
        
        /// <summary>
        /// Boton Convertir a Binario. Convierte el resultado de decimal a binario en caso de ser posible,
        /// a traves del metodo DecimalBinario() de la Clase Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text != null)
            {
                Numero numero = new Numero();
                string resultadoConvertido = numero.DecimalBinario(lblResultado.Text);
                lblResultado.Text = resultadoConvertido;
            }
        }

        /// <summary>
        /// Boton Convertir a Decimal. Convierte el resultado de binario a decimal en caso de ser posible,
        /// a traves del metodo BinarioDecimal() de la Clase Numero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertitADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != null)
            {
                Numero numero = new Numero();
                string resultadoConvertido = numero.BinarioDecimal(lblResultado.Text);
                lblResultado.Text = resultadoConvertido;
            }
        }

        /// <summary>
        /// Limpia todo texto de textBox, comboBox y label.
        /// </summary>
        public void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = String.Empty;
        }

        /// <summary>
        /// Instancia dos objetos de la clase Numero y realiza operaciones con los mismos a traves del metodo
        /// Operar de la Clase Numero
        /// </summary>
        /// <param name="num1">string recibido en txtNumero1</param>
        /// <param name="num2">string recibido en txtNumero2</param>
        /// <param name="operador">Operador seleccionado en cmbOperador,indica la operacion a ser realizada</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        public static double Operar(string num1, string num2,string operador)
        {
            Calculadora calculadora = new Calculadora();
            Numero numero1 = new Numero(num1);
            Numero numero2 = new Numero(num2);
            double resultado = calculadora.Operar(numero1, numero2, operador);
            return resultado;
        }

        public void LaCalculadora()
        {

        }
    }
}
