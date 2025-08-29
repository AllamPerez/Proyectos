using System;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        
        private string operador = "";
        private double num1 = 0;
        private double num2 = 0;

       
        private double? memoria = null;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void screen_calculator_TextChanged(object sender, EventArgs e)
        {
        }

         
        private void Suma_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(screen_calculator.Text, out num2))
            {
                screen_calculator.Text = "Error";
                return;
            }

            switch (operador)
            {
                case "+": screen_calculator.Text = Convert.ToString(num1 + num2); break;
                case "-": screen_calculator.Text = Convert.ToString(num1 - num2); break;
                case "*": screen_calculator.Text = Convert.ToString(num1 * num2); break;
                case "/": screen_calculator.Text = num2 == 0 ? "Error" : Convert.ToString(num1 / num2); break;
                case "^": screen_calculator.Text = Convert.ToString(Math.Pow(num1, num2)); break;
                case "%": screen_calculator.Text = Convert.ToString(num1 * (num2 / 100)); break;
                default: screen_calculator.Text = "Operador inválido"; break;
            }

            operador = "";
        }

        private void reiniciobt_Click(object sender, EventArgs e)
        {
            screen_calculator.Text = "0";
            num1 = 0;
            num2 = 0;
            operador = "";
        }

        private void borrarbt_Click(object sender, EventArgs e)
        {
            if (screen_calculator.TextLength <= 1)
                screen_calculator.Text = "0";
            else
                screen_calculator.Text = screen_calculator.Text.Substring(0, screen_calculator.Text.Length - 1);
        }

        
        private void bt1_Click(object sender, EventArgs e) { AgregarNumero("1"); }
        private void bt2_Click(object sender, EventArgs e) { AgregarNumero("2"); }
        private void bt3_Click(object sender, EventArgs e) { AgregarNumero("3"); }
        private void bt4_Click(object sender, EventArgs e) { AgregarNumero("4"); }
        private void bt5_Click(object sender, EventArgs e) { AgregarNumero("5"); }
        private void bt6_Click(object sender, EventArgs e) { AgregarNumero("6"); }
        private void bt7_Click(object sender, EventArgs e) { AgregarNumero("7"); }
        private void bt8_Click(object sender, EventArgs e) { AgregarNumero("8"); }
        private void bt9_Click(object sender, EventArgs e) { AgregarNumero("9"); }
        private void Bt0_Click(object sender, EventArgs e) { AgregarNumero("0"); }

        private void AgregarNumero(string numero)
        {
            if (screen_calculator.Text == "0") screen_calculator.Text = "";
            screen_calculator.Text += numero;
        }

        private void puntobt_Click(object sender, EventArgs e)
        {
            if (!screen_calculator.Text.Contains("."))
                screen_calculator.Text += ".";
        }

        
        private void sumbt_Click(object sender, EventArgs e) { PrepararOperacion("+"); }
        private void restbt_Click(object sender, EventArgs e) { PrepararOperacion("-"); }
        private void multbt_Click(object sender, EventArgs e) { PrepararOperacion("*"); }
        private void divbt_Click(object sender, EventArgs e) { PrepararOperacion("/"); }
        private void button2_Click(object sender, EventArgs e) { PrepararOperacion("^"); }
        private void button4_Click(object sender, EventArgs e) { PrepararOperacion("%"); }

        private void PrepararOperacion(string op)
        {
            operador = op;
            if (double.TryParse(screen_calculator.Text, out num1))
                screen_calculator.Text = "0";
        }

      
        private void raizbtn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(screen_calculator.Text, out double n))
                screen_calculator.Text = Math.Sqrt(n).ToString();
        }

        private void pibtn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(screen_calculator.Text, out double n))
                screen_calculator.Text = (n * Math.PI).ToString();
        }

        private void logbtn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(screen_calculator.Text, out double n))
                screen_calculator.Text = Math.Log(n).ToString();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(screen_calculator.Text, out double n))
            {
                double res = Math.Round((n - 32) * 5 / 9);
                screen_calculator.Text = res.ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (double.TryParse(screen_calculator.Text, out double n))
                screen_calculator.Text = ((n * 9 / 5) + 32).ToString();
        }

        
        public double Factorial(int n)
        {
            double resultado = 1;
            for (int i = 1; i <= n; i++)
                resultado *= i;
            return resultado;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (double.TryParse(screen_calculator.Text, out double n) && n >= 0 && n == Math.Floor(n))
                screen_calculator.Text = Factorial((int)n).ToString();
            else
                screen_calculator.Text = "Error";
        }

      
        private void Mmasbtn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(screen_calculator.Text, out double pantalla))
            {
                if (!memoria.HasValue)
                    memoria = pantalla; 
                else
                {
                    pantalla += memoria.Value; 
                    screen_calculator.Text = pantalla.ToString();
                }
            }
        }

       
        private void Mmenosbtn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(screen_calculator.Text, out double pantalla))
            {
                if (!memoria.HasValue)
                    memoria = pantalla; 
                else
                {
                    pantalla -= memoria.Value; 
                    screen_calculator.Text = pantalla.ToString();
                }
            }
        }

 
        private void Mrbton_Click(object sender, EventArgs e)
        {
            if (memoria.HasValue)
                screen_calculator.Text = memoria.Value.ToString();
        }

        
        private void MemoryClearbtn_Click(object sender, EventArgs e)
        {
            memoria = null;
        }
    }
}
