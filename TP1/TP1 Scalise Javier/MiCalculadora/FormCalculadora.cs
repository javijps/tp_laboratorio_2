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

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;
            double resultado;

            if(this.cmbOperador.SelectedItem == null)
            {
                operador = "+";       
            }
            else
            {
                operador = Convert.ToString(cmbOperador.SelectedItem);
            }
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, operador);
            this.lblResultado.Text = Convert.ToString(resultado);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            string resultadoConvertido = numero.DecimalBinario(lblResultado.Text);
            lblResultado.Text = resultadoConvertido;
        }

        private void btnConvertitADecimal_Click(object sender, EventArgs e)
        {
            
        }

        public void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = -1;
            lblResultado.Text = String.Empty;
        }

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
