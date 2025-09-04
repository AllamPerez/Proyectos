using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTareas
{

  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Tarea
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            public string Lugar { get; set; }
            public string Estado { get; set; }


        }
        List<Tarea> listaTareas = new List<Tarea>();
        private void ActualizarGrid()
        {
            dgvTareas.DataSource = null;
            dgvTareas.DataSource = listaTareas;
        }


        private void BuscarPorFecha(DateTime fecha)
        {
            var resultado = listaTareas
                .Where(t => t.Fecha.Date == fecha.Date)
                .ToList();

            dgvTareas.DataSource = null;
            dgvTareas.DataSource = resultado;
        }
        private void BuscarPorEstado(string estado)
        {
            var resultado = listaTareas
                .Where(t => t.Estado == estado)
                .ToList();

            dgvTareas.DataSource = null;
            dgvTareas.DataSource = resultado;
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void dgwTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvTareas.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = dgvTareas.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDescripcion.Text = dgvTareas.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpFecha.Value = (DateTime)dgvTareas.Rows[e.RowIndex].Cells[3].Value;
                txtLugar.Text = dgvTareas.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbEstado.SelectedItem = dgvTareas.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
        private void BuscadorDTGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvTareas.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = dgvTareas.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDescripcion.Text = dgvTareas.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpFecha.Value = (DateTime)dgvTareas.Rows[e.RowIndex].Cells[3].Value;
                txtLugar.Text = dgvTareas.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbEstado.SelectedItem = dgvTareas.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Tarea nueva = new Tarea()
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Fecha = dtpFecha.Value,
                Lugar = txtLugar.Text,
                Estado = cmbEstado.SelectedItem.ToString()
            };

            listaTareas.Add(nueva);
            ActualizarGrid();
            MessageBox.Show("Tarea agregada correctamente.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0)
            {
                int index = dgvTareas.SelectedRows[0].Index;
                listaTareas[index].Codigo = txtCodigo.Text;
                listaTareas[index].Nombre = txtNombre.Text;
                listaTareas[index].Descripcion = txtDescripcion.Text;
                listaTareas[index].Fecha = dtpFecha.Value;
                listaTareas[index].Lugar = txtLugar.Text;
                listaTareas[index].Estado = cmbEstado.SelectedItem.ToString();

                ActualizarGrid();
                MessageBox.Show("Tarea editada correctamente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0)
            {
                int index = dgvTareas.SelectedRows[0].Index;
                listaTareas.RemoveAt(index);
                ActualizarGrid();
                MessageBox.Show("Tarea eliminada correctamente.");
            }
        }

        private void lblBuscadorti_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (buscadorcombobox.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un estado.");
                return;
            }

            string estado = buscadorcombobox.SelectedItem.ToString();

            var resultado = listaTareas
                .Where(t => t.Estado == estado)
                .ToList();

            if (resultado.Any())
            {
                BuscadorDTGV.DataSource = null;
                BuscadorDTGV.DataSource = resultado;
            }
            else
            {
                MessageBox.Show("No hay tareas con ese estado.");
                MostrarTodo();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigo.Text = dgvTareas.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = dgvTareas.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDescripcion.Text = dgvTareas.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpFecha.Value = (DateTime)dgvTareas.Rows[e.RowIndex].Cells[3].Value;
                txtLugar.Text = dgvTareas.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbEstado.SelectedItem = dgvTareas.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
        private void MostrarTodo()
        {
            BuscadorDTGV.DataSource = null;
            BuscadorDTGV.DataSource = listaTareas;
        }


        private void BuscarCodbtn_Click(object sender, EventArgs e)
        {
            string codigo = Buscodtxt.Text.Trim();

            if (string.IsNullOrEmpty(codigo))
            {
                MostrarTodo(); // Si el TextBox está vacío, muestra todo
                return;
            }

            var tareaEncontrada = listaTareas
                  .Where(t => t.Codigo.Contains(codigo))
                  .ToList();

            if (tareaEncontrada.Any())
            {
                BuscadorDTGV.DataSource = null;
                BuscadorDTGV.DataSource = tareaEncontrada;
            }
            else
            {
                MessageBox.Show("No se encontró ninguna tarea con ese código.");
                MostrarTodo(); // opcional: muestra todo si no encuentra nada
            }
        }


        private void Buscodtxt_TextChanged(object sender, EventArgs e)
        {

        }
        private void BuscarFechabtn_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.");
                return;
            }

            var resultado = listaTareas
                .Where(t => t.Fecha.Date >= fechaInicio && t.Fecha.Date <= fechaFin)
                .ToList();

            if (resultado.Any())
            {
                BuscadorDTGV.DataSource = null;
                BuscadorDTGV.DataSource = resultado;
            }
            else
            {
                MessageBox.Show("No hay tareas dentro de ese rango de fechas.");
                MostrarTodo();
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            dtpFecha.Value = DateTime.Now;
            txtLugar.Text = "";
            cmbEstado.SelectedIndex = -1;   
        }
    }

}
