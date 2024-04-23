using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class AsignarSoftTEC : Form
    {
        public AsignarSoftTEC()
        {
            InitializeComponent();
            CargarComboBoxSoft();
            CargarComboBoxEquipos();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            MenuTecnico formPrincipal = Application.OpenForms.OfType<MenuTecnico>().FirstOrDefault(); // Obtén el formulario principal existente
            if (formPrincipal != null) // Verifica si el formulario principal existe
            {
                formPrincipal.Show(); // Muestra el formulario principal
            }
            else
            {
                // Si el formulario principal no existe, puedes crear uno nuevo y mostrarlo
                MenuTecnico nuevoFormPrincipalTEC = new MenuTecnico();
                nuevoFormPrincipalTEC.FormClosed += (s, args) => this.Close(); // Cierra este formulario cuando se cierre el nuevo formulario principal
                nuevoFormPrincipalTEC.Show();
            }
        }




        private void CargarComboBoxSoft()
        {
            using (SqlConnection con = Clase_Conexion.Abrir_Conexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT idSoftware, Nombre_Software FROM Software", con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                cbSoft.DisplayMember = "Nombre_Software";
                cbSoft.ValueMember = "idSoftware"; // Asignar el ID como el valor
                cbSoft.DataSource = dt;
            }
        }

        private void CargarComboBoxEquipos()
        {
            using (SqlConnection con = Clase_Conexion.Abrir_Conexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT idEquipo, modelo FROM Equipos", con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                cbEquipos.DisplayMember = "modelo";
                cbEquipos.ValueMember = "idEquipo"; // Asignar el ID como el valor
                cbEquipos.DataSource = dt;
            }
        }







        private void btnAsignar_Click(object sender, EventArgs e)
        {

            int idSoftware = (int)cbSoft.SelectedValue;
            int idEquipo = (int)cbEquipos.SelectedValue;

            using (SqlConnection con = Clase_Conexion.Abrir_Conexion())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Equipos SET idSoftware = @idSoftware WHERE idEquipo = @idEquipo", con);
                cmd.Parameters.AddWithValue("@idSoftware", idSoftware);
                cmd.Parameters.AddWithValue("@idEquipo", idEquipo);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Software asignado correctamente al equipo.");
        }








        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AsignarSoftTEC_Load(object sender, EventArgs e)
        {
            cbSoft.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbSoft_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Verificar si hay un elemento seleccionado en el ComboBox cbSoft
            if (cbSoft.SelectedValue != null)
            {
                // Limpiar el DataGridView antes de cargar nuevos datos
                dgvSoft.DataSource = null;

                // Obtener el valor seleccionado del ComboBox cbSoft
                object selectedValue = cbSoft.SelectedValue;

                // Verificar si el valor seleccionado se puede convertir a int
                if (selectedValue is int)
                {
                    int idSoftware = (int)selectedValue;

                    // Obtener los datos del software seleccionado y cargarlos en el DataGridView
                    using (SqlConnection con = Clase_Conexion.Abrir_Conexion())
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Software WHERE idSoftware = @idSoftware", con);
                        cmd.Parameters.AddWithValue("@idSoftware", idSoftware);
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dgvSoft.DataSource = dt;
                    }
                }
                else
                {
                    // Si el valor seleccionado no se puede convertir a int, muestra un mensaje de error
                    MessageBox.Show("El valor seleccionado no es válido.");
                }
            }


        }

        private void cbEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Verificar si hay un elemento seleccionado en el ComboBox cbEquipos
            if (cbEquipos.SelectedValue != null)
            {
                // Limpiar el DataGridView antes de cargar nuevos datos
                dgvEquipo.DataSource = null;

                // Obtener el ID del equipo seleccionado
                int idEquipo = (int)cbEquipos.SelectedValue;

                // Obtener los datos del equipo seleccionado y cargarlos en el DataGridView
                using (SqlConnection con = Clase_Conexion.Abrir_Conexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos WHERE idEquipo = @idEquipo", con);
                    cmd.Parameters.AddWithValue("@idEquipo", idEquipo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    dgvEquipo.DataSource = dt;
                }
            }

        }


  


        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            // Verificar si hay un elemento seleccionado en el ComboBox cbEquipos
            if (cbEquipos.SelectedItem != null)
            {
                // Desseleccionar cualquier elemento seleccionado en el ComboBox cbEquipos
                cbEquipos.SelectedIndex = -1;
            }

            // Desseleccionar cualquier elemento seleccionado en el ComboBox cbSoft
            cbSoft.SelectedIndex = -1;

            // Limpiar el DataGridView dgvEquipo
            dgvEquipo.DataSource = null;

            // Limpiar el DataGridView dgvSoft
            dgvSoft.DataSource = null;
        }



        // Método para limpiar los datos de los ComboBox
        private void LimpiarComboBox()
        {
            cbEquipos.SelectedIndex = -1; // Desselecciona cualquier elemento seleccionado en el ComboBox cbEquipo
            cbSoft.SelectedIndex = -1; // Desselecciona cualquier elemento seleccionado en el ComboBox cbEmpleado
        }

        // Método para limpiar los datos de los DataGridView
        private void LimpiarDataGridView()
        {
            dgvEquipo.DataSource = null; // Elimina cualquier origen de datos asignado al DataGridView dgvEquipos
            dgvSoft.DataSource = null; // Elimina cualquier origen de datos asignado al DataGridView dgvEmpleados
        }

        private void dgvSoft_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSoft.Dock = DockStyle.Fill;
        }

        private void dgvEquipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEquipo.Dock = DockStyle.Fill;
        }
    }
}
