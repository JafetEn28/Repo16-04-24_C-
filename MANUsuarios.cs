using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PrograIV
{
    public partial class MANUsuarios : Form
    {
        public MANUsuarios()
        {
            InitializeComponent();
            
        }


        public class Usuarios
        {
            private Clase_Conexion conexion = new Clase_Conexion();

            public void InsertarUsuario(string nombre, string apellido1, string apellido2, string cedula, string puesto, string departamento, string clave)
            {
                SqlConnection connection = Clase_Conexion.Abrir_Conexion();
                {
                    string query = "INSERT INTO Personas (nombre, apellido1, apellido2, cedula) VALUES (@nombre, @apellido1, @apellido2, @cedula);" +
                                   "INSERT INTO Usuarios (cedula, clave, Fecha_Creacion_Usuario, tipoUsuario) VALUES (@cedula, @clave, GETDATE(), @puesto);" +
                                   "INSERT INTO Empleados (cedula, puesto, departamento) VALUES (@cedula, @puesto, @departamento);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido1", apellido1);
                    command.Parameters.AddWithValue("@apellido2", apellido2);
                    command.Parameters.AddWithValue("@cedula", cedula);
                    command.Parameters.AddWithValue("@clave", clave);
                    command.Parameters.AddWithValue("@puesto", puesto);
                    command.Parameters.AddWithValue("@departamento", departamento);
                    command.ExecuteNonQuery();
                }
            }


        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            ControlADM formPrincipal = Application.OpenForms.OfType<ControlADM>().FirstOrDefault(); // Obtén el formulario principal existente
            if (formPrincipal != null) // Verifica si el formulario principal existe
            {
                formPrincipal.Show(); // Muestra el formulario principal
            }
            else
            {
                // Si el formulario principal no existe, puedes crear uno nuevo y mostrarlo
                ControlADM nuevoFormPrincipal = new ControlADM();
                nuevoFormPrincipal.FormClosed += (s, args) => this.Close(); // Cierra este formulario cuando se cierre el nuevo formulario principal
                nuevoFormPrincipal.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            ControlADM formPrincipal = Application.OpenForms.OfType<ControlADM>().FirstOrDefault(); // Obtén el formulario principal existente
            if (formPrincipal != null) // Verifica si el formulario principal existe
            {
                formPrincipal.Show(); // Muestra el formulario principal
            }
            else
            {
                // Si el formulario principal no existe, puedes crear uno nuevo y mostrarlo
                ControlADM nuevoFormPrincipal = new ControlADM();
                nuevoFormPrincipal.FormClosed += (s, args) => this.Close(); // Cierra este formulario cuando se cierre el nuevo formulario principal
                nuevoFormPrincipal.Show();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }



        public DataTable ObtenerDatosUsuarios()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
            {
                SqlCommand cmd = new SqlCommand("ObtenerDatosUsuarios", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }



        private void btnGuardarUser_Click(object sender, EventArgs e)
        {


            // Verificar si se han ingresado datos en los campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido1.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text) ||
                comboBoxPuesto.SelectedItem == null ||
                comboBoxDepar.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios antes de guardar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método sin continuar
            }



            Clase_Conexion.Abrir_Conexion();
            MessageBox.Show("Conexion Exitosa!!!");
            dataGridViewUsuarios.DataSource = ObtenerDatosUsuarios();

            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string cedula = txtCedula.Text;
            string puesto = comboBoxPuesto.SelectedItem.ToString();
            string departamento = comboBoxDepar.SelectedItem.ToString();
            string clave = txtClave.Text;

            Usuarios usuario = new Usuarios();
            usuario.InsertarUsuario(nombre, apellido1, apellido2, cedula, puesto, departamento, clave);

            // Mostrar un mensaje de éxito
            MessageBox.Show("Usuario guardado exitosamente.");

            // Actualizar el DataGridView con los nuevos datos
            dataGridViewUsuarios.DataSource = ObtenerDatosUsuarios();

        }

        private void CargarUsuarios()
        {
            // Crear una copia de las filas actuales
            DataGridViewRow[] rows = new DataGridViewRow[dataGridViewUsuarios.Rows.Count];
            dataGridViewUsuarios.Rows.CopyTo(rows, 0);

            // Limpiar el DataGridView antes de cargar nuevos datos
            LimpiarDataGridView();

            // Realizar la consulta SQL para obtener los usuarios
            string query = "SELECT p.nombre, p.apellido1, p.apellido2, p.cedula, e.puesto, e.departamento, u.clave " +
                            "FROM Personas p " +
                            "INNER JOIN Usuarios u ON p.cedula = u.cedula " +
                            "INNER JOIN Empleados e ON p.cedula = e.cedula";
            using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Obtener el DataTable subyacente al DataGridView
                DataTable dataTable = ((DataTable)dataGridViewUsuarios.DataSource);

                // Agregar filas al DataTable
                while (reader.Read())
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow["nombre"] = reader["nombre"];
                    newRow["apellido1"] = reader["apellido1"];
                    newRow["apellido2"] = reader["apellido2"];
                    newRow["cedula"] = reader["cedula"];
                    newRow["puesto"] = reader["puesto"];
                    newRow["departamento"] = reader["departamento"];
                    newRow["clave"] = reader["clave"];
                    dataTable.Rows.Add(newRow);
                }
            }

            // Eliminar las filas copiadas
            foreach (DataGridViewRow row in rows)
            {
                if (row.Index != -1)
                {
                    dataGridViewUsuarios.Rows.Remove(row);
                }
            }
        }



        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                txtNombre.Text = dataGridViewUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido1.Text = dataGridViewUsuarios.CurrentRow.Cells["apellido1"].Value.ToString();
                txtApellido2.Text = dataGridViewUsuarios.CurrentRow.Cells["apellido2"].Value.ToString();
                txtCedula.Text = dataGridViewUsuarios.CurrentRow.Cells["cedula"].Value.ToString();
                txtClave.Text = dataGridViewUsuarios.CurrentRow.Cells["clave"].Value.ToString();
                comboBoxPuesto.SelectedItem = dataGridViewUsuarios.CurrentRow.Cells["puesto"].Value.ToString();
                comboBoxDepar.SelectedItem = dataGridViewUsuarios.CurrentRow.Cells["departamento"].Value.ToString();
            }
        }

        private void comboBoxPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

            string puestoSeleccionado = comboBoxPuesto.SelectedItem.ToString();

            // Actualizar ComboBox de departamento según el puesto seleccionado
            if (puestoSeleccionado == "Admin")
            {
                // Mostrar opciones para TI
                comboBoxDepar.Items.Clear();
                comboBoxDepar.Items.AddRange(new string[] { "TI" });
            }
            else if (puestoSeleccionado == "Tecnico")
            {
                // Mostrar opciones para TI
                comboBoxDepar.Items.Clear();
                comboBoxDepar.Items.AddRange(new string[] { "TI" });
            }
            else if (puestoSeleccionado == "Empleado")
            {
                // Mostrar opciones para RRHH, CONTABILIDAD, VENTAS Y MARKETING
                comboBoxDepar.Items.Clear();
                comboBoxDepar.Items.AddRange(new string[] { "RRHH", "CONTABILIDAD", "VENTAS", "MARKETING" });
            }

            // Deshabilitar el TextBox de clave si se selecciona "Empleado"
            if (puestoSeleccionado == "Empleado")
            {
                txtClave.Enabled = false;
                txtClave.Text = ""; // Limpiar el contenido del TextBox de clave
            }
            else
            {
                txtClave.Enabled = true;
            }
        }

        

        private void MANUsuarios_Load_1(object sender, EventArgs e)
        {
            

            // Establecer el estilo del ComboBox de puesto para que no permita la edición directa
            comboBoxPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepar.DropDownStyle = ComboBoxStyle.DropDownList;

            // Agregar opciones al ComboBox de puesto solo si está vacío
            if (comboBoxPuesto.Items.Count == 0)
            {
                comboBoxPuesto.Items.AddRange(new string[] { "Administrador", "Tecnico", "Empleado" });
            }

            // Mostrar opciones para TI por defecto en el ComboBox de departamento
            comboBoxDepar.Items.Clear();
            comboBoxDepar.Items.AddRange(new string[] { "TI" });

            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxDepar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Limpiartxts()
        {
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtCedula.Text = "";
            comboBoxPuesto.Text = "";
            comboBoxDepar.Text = "";
            txtClave.Text = "";

        }
        private void btnEliminarUser_Click(object sender, EventArgs e)
        {
            // Verificar si se ha ingresado una cédula válida
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Por favor, ingrese una cédula válida antes de eliminar.", "Cédula vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamar al procedimiento almacenado para eliminar el usuario
            string eliminarUsuarioProcedure = "EliminarUsuario";
            using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
            {
                SqlCommand cmd = new SqlCommand(eliminarUsuarioProcedure, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", txtCedula.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Usuario y sus dependencias eliminados correctamente de la Base de datos");

            // Volver a cargar los usuarios en el DataGridView
            CargarUsuarios();

            // Limpiar los campos de texto
            Limpiartxts();
        }

        private void LimpiarDataGridView()
        {
            if (!dataGridViewUsuarios.AllowUserToAddRows) // Verifica si está permitido agregar filas
            {
                // Si no se permite agregar filas, elimina las existentes
                while (dataGridViewUsuarios.Rows.Count > 0)
                {
                    dataGridViewUsuarios.Rows.RemoveAt(0);
                }
            }
        }


        private void btnActuUser_Click(object sender, EventArgs e)
        {
            
        }
    }
   
}

