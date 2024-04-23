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
    public partial class AsigDispTEC : Form
    {
        public AsigDispTEC()
        {
            InitializeComponent();
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

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado un equipo y un empleado
                if (cbEquipo.SelectedItem != null && cbEmpleado.SelectedItem != null)
                {
                    // Obtener el id del equipo y del empleado seleccionados
                    int idEquipo = ((KeyValuePair<int, string>)cbEquipo.SelectedItem).Key;
                    int idEmpleado = ((KeyValuePair<int, string>)cbEmpleado.SelectedItem).Key;

                    using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
                    {
                        // Consulta SQL para actualizar la tabla Equipos con el id del empleado
                        string query = "UPDATE Equipos SET idEmpleado = @IdEmpleado WHERE idEquipo = @IdEquipo";

                        // Crear el comando SQL
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Asignar parámetros
                            command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                            command.Parameters.AddWithValue("@IdEquipo", idEquipo);

                            // Ejecutar la consulta
                            int filasAfectadas = command.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("El equipo se ha asignado al empleado correctamente.", "Asignación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Volver a cargar los ComboBox para reflejar los cambios
                                CargarComboBoxEquipos();
                                CargarComboBoxEmpleados();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo realizar la asignación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un equipo y un empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar asignar el equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }



        // Método para cargar los equipos en el ComboBox cbEquipo
        private void CargarComboBoxEquipos()
        {
            cbEquipo.Items.Clear();
            try
            {
                using (SqlConnection conexion = Clase_Conexion.Abrir_Conexion())
                {
                    string consulta = "SELECT idEquipo, modelo FROM Equipos";
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idEquipo = reader.GetInt32(0);
                            string modelo = reader.GetString(1);
                            cbEquipo.Items.Add(new KeyValuePair<int, string>(idEquipo, modelo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de equipos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los empleados en el ComboBox cbEmpleado
        private void CargarComboBoxEmpleados()
        {
            cbEmpleado.Items.Clear();
            try
            {
                using (SqlConnection conexion = Clase_Conexion.Abrir_Conexion())
                {
                    string consulta = "SELECT idEmpleado, nombre FROM Empleados INNER JOIN Personas ON Empleados.idPersona = Personas.idPersona";
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idEmpleado = reader.GetInt32(0);
                            string nombre = reader.GetString(1);
                            cbEmpleado.Items.Add(new KeyValuePair<int, string>(idEmpleado, nombre));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        // Método para cargar los datos de la tabla Equipos en el DataGridView dgvEquipos, filtrado por el equipo seleccionado en cbEquipo
        private void CargarDatosEquipos()
        {
            if (cbEquipo.SelectedItem != null)
            {
                try
                {
                    using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
                    {
                        int idEquipo = ((KeyValuePair<int, string>)cbEquipo.SelectedItem).Key;
                        string query = "SELECT * FROM Equipos WHERE idEquipo = @IdEquipo";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@IdEquipo", idEquipo);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvEquipo.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de equipos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para cargar los datos de la tabla Empleados en el DataGridView dgvEmpleados, filtrado por el empleado seleccionado en cbEmpleado
        private void CargarDatosEmpleados()
        {
            if (cbEmpleado.SelectedItem != null)
            {
                try
                {
                    using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
                    {
                        int idEmpleado = ((KeyValuePair<int, string>)cbEmpleado.SelectedItem).Key;
                        string query = "SELECT * FROM Empleados WHERE idEmpleado = @IdEmpleado";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvEmpleado.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos de empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        private void AsigDispTEC_Load(object sender, EventArgs e)
        {
            CargarComboBoxEquipos();
            CargarComboBoxEmpleados();

            CargarDatosEquipos();
            CargarDatosEmpleados();
        }

        private void cbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosEquipos();
        }

        private void cbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosEmpleados();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarComboBox();
            LimpiarDataGridView();
        }


        // Método para limpiar los datos de los ComboBox
        private void LimpiarComboBox()
        {
            cbEquipo.SelectedIndex = -1; // Desselecciona cualquier elemento seleccionado en el ComboBox cbEquipo
            cbEmpleado.SelectedIndex = -1; // Desselecciona cualquier elemento seleccionado en el ComboBox cbEmpleado
        }

        // Método para limpiar los datos de los DataGridView
        private void LimpiarDataGridView()
        {
            dgvEquipo.DataSource = null; // Elimina cualquier origen de datos asignado al DataGridView dgvEquipos
            dgvEmpleado.DataSource = null; // Elimina cualquier origen de datos asignado al DataGridView dgvEmpleados
        }


    }
}
