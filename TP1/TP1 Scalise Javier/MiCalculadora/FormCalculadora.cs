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
          lblResultado.Text = Convert.ToString(Operar(txtNumero1.Text,txtNumero2.Text,cmbOperador.Text));
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
            Numero numeroIngresado = new Numero();
            numeroIngresado.SetNumero = lblResultado.Text;
            lblResultado.Text = numeroIngresado.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertitADecimal_Click(object sender, EventArgs e)
        {
            Numero numeroIngresado = new Numero();
            lblResultado.Text = numeroIngresado.BinarioDecimal(lblResultado.Text);
        }

        public void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = String.Empty;
        }

        public static double Operar(string num1, string num2,string operador)
        {
            Numero numero1 = new Numero();
            Numero numero2 = new Numero();
            Calculadora calculadora = new Calculadora();
            numero1.SetNumero = num1;
            numero2.SetNumero = num2;
            double resultado = calculadora.Operar(numero1, numero2, operador);
            return resultado;
        }

        public void LaCalculadora()
        {

        }
    }
}
