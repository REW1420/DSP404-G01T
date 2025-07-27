using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroUsuarios
{
    public partial class Form1 : Form
    {
        int contador = 1;
        public Form1()
        {
            InitializeComponent();

            // Aqui vas los diferentes cargos
            cmbCargo.Items.AddRange(new string[]
            {
                "Operador de Empacadora",
                "Operario de fundición",
                "Coordinador de Bodega",
                "Supervisor de producción",
                "Director de operaciones",
                "Secretario Médico",
                "Auxiliar superior de apoyo",
                "Administrador de Recursos Humanos"
            });

            // Aqui la configuracion de las colunas del datagridview
            dgvPlanilla.Columns.Add("Numero", "#");
            dgvPlanilla.Columns.Add("Nombre", "Nombre completo");
            dgvPlanilla.Columns.Add("Edad", "Edad (años)");
            dgvPlanilla.Columns.Add("Cargo", "Cargo");
            dgvPlanilla.Columns.Add("SueldoNeto", "Sueldo Mensual Neto ($)");
        }
        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            DateTime fechaNacimiento = dtpNacimiento.Value;
            string cargo = cmbCargo.SelectedItem?.ToString();
            bool sueldoValido = decimal.TryParse(txtSueldo.Text, out decimal sueldo);

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cargo) || !sueldoValido)
            {
                MessageBox.Show("Complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int edad = CalcularEdad(fechaNacimiento);
            decimal sueldoNeto = CalcularSueldoNeto(sueldo);

            dgvPlanilla.Rows.Add(contador++, nombre, edad, cargo, sueldoNeto.ToString("F2"));

            // Limpiar campos
            txtNombre.Clear();
            txtSueldo.Clear();
            cmbCargo.SelectedIndex = -1;
            dtpNacimiento.Value = DateTime.Today;
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }

        // Aqui aplicamos los descuentos
        private decimal CalcularSueldoNeto(decimal sueldo)
        {
            decimal isss = sueldo * 0.035m;
            decimal afp = sueldo * 0.075m;
            decimal renta = sueldo * 0.10m;
            return sueldo - isss - afp - renta;
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
