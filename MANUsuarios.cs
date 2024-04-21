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
            // Deshabilitar el botón mientras se procesa la información
            btnGuardarUser.Enabled = false;


            // Tu código para guardar el usuario
            try
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

                // Cargar usuarios
                CargarUsuarios();

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

                Limpiartxts();

                // Actualizar el DataGridView con los nuevos datos
                CargarUsuarios();

                // Actualizar ComboBox de puesto y departamento
                ActualizarComboBoxPuesto();
                ActualizarComboBoxDepartamento();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Habilitar el botón después de procesar la información
                btnGuardarUser.Enabled = true;
            }
        }

        // Método para actualizar el ComboBox de puesto
        private void ActualizarComboBoxPuesto()
        {
            comboBoxPuesto.Items.Clear();
            comboBoxPuesto.Items.AddRange(new string[] { "Administrador", "Tecnico", "Empleado" });
        }

        // Método para actualizar el ComboBox de departamento
        private void ActualizarComboBoxDepartamento()
        {
            comboBoxDepar.Items.Clear();
            comboBoxDepar.Items.AddRange(new string[] { "TI", "RRHH", "CONTABILIDAD", "VENTAS", "MARKETING" });
        }

        private void CargarUsuarios()
        {
            // Realizar la consulta SQL para obtener los usuarios
            string query = "SELECT p.nombre, p.apellido1, p.apellido2, p.cedula, e.puesto, e.departamento, u.clave " +
                            "FROM Personas p " +
                            "INNER JOIN Usuarios u ON p.cedula = u.cedula " +
                            "INNER JOIN Empleados e ON p.cedula = e.cedula";

            using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Crear un nuevo DataTable para almacenar los datos
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Actualizar el DataGridView en el subproceso correcto
                Invoke(new Action(() =>
                {
                    dataGridViewUsuarios.DataSource = dataTable;
                }));
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

                // Limpiar los ComboBox
                comboBoxPuesto.Items.Clear();
                comboBoxDepar.Items.Clear();

                // Agregar el valor correspondiente a los ComboBox
                string puesto = dataGridViewUsuarios.CurrentRow.Cells["puesto"].Value.ToString();
                string departamento = dataGridViewUsuarios.CurrentRow.Cells["departamento"].Value.ToString();

                comboBoxPuesto.Items.AddRange(new string[] { puesto });
                comboBoxDepar.Items.AddRange(new string[] { departamento });

                comboBoxPuesto.SelectedItem = puesto;
                comboBoxDepar.SelectedItem = departamento;
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



        private void Limpiartxts()
        {
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtCedula.Text = "";
            comboBoxPuesto.Items.Clear();
            comboBoxDepar.Items.Clear();
            txtClave.Text = "";

        }
        private void btnEliminarUser_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Fila no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener la cédula de la fila seleccionada
            string cedula = dataGridViewUsuarios.SelectedRows[0].Cells["cedula"].Value.ToString();

            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar los datos?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar la respuesta del usuario
            if (result == DialogResult.Yes)
            {
                // Llamar al procedimiento almacenado para eliminar el usuario
                string eliminarUsuarioProcedure = "EliminarUsuario";
                using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
                {
                    SqlCommand cmd = new SqlCommand(eliminarUsuarioProcedure, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario y sus dependencias eliminados correctamente de la Base de datos");

                // Volver a cargar los usuarios en el DataGridView
                CargarUsuarios();

                // Limpiar los campos de texto
                Limpiartxts();
            }
            else
            {
                // El usuario ha cancelado la eliminación
                MessageBox.Show("La eliminación de datos ha sido cancelada.", "Eliminación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private async void BtnActuUser_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una fila para actualizar.", "Fila no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los nuevos valores de los controles
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            string cedula = txtCedula.Text;
            string puesto = comboBoxPuesto.SelectedItem?.ToString();
            string departamento = comboBoxDepar.SelectedItem?.ToString();
            string clave = txtClave.Text;

            // Verificar si se han ingresado datos en los campos obligatorios
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido1) ||
                string.IsNullOrWhiteSpace(cedula) ||
                string.IsNullOrWhiteSpace(puesto) ||
                string.IsNullOrWhiteSpace(departamento))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios antes de actualizar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deshabilitar el botón mientras se procesa la información
            btnActuUser.Enabled = false;

            try
            {
                // Obtener la cédula de la fila seleccionada
                string cedulaSeleccionada = dataGridViewUsuarios.SelectedRows[0].Cells["cedula"].Value.ToString();

                // Actualizar los datos en la base de datos
                ActualizarUsuario(cedulaSeleccionada, nombre, apellido1, apellido2, puesto, departamento, clave);

                // Mostrar un mensaje de éxito
                MessageBox.Show("Usuario actualizado correctamente.");

                // Limpiar los campos
                Limpiartxts();

                // Volver a cargar los usuarios en el DataGridView
                await Task.Run(() => CargarUsuarios());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Habilitar el botón después de procesar la información, independientemente del resultado
                btnActuUser.Enabled = true;
            }
        }




        private void ActualizarUsuario(string cedula, string nombre, string apellido1, string apellido2, string puesto, string departamento, string clave)
        {
            SqlConnection connection = Clase_Conexion.Abrir_Conexion();
            {
                string query = "UPDATE Personas SET nombre = @nombre, apellido1 = @apellido1, apellido2 = @apellido2 WHERE cedula = @cedula;" +
                               "UPDATE Empleados SET puesto = @puesto, departamento = @departamento WHERE cedula = @cedula;" +
                               "UPDATE Usuarios SET clave = @clave WHERE cedula = @cedula;";
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Clase_Conexion.Abrir_Conexion();
            MessageBox.Show("Conexion exitosa con la base de datos!");

            CargarUsuarios();

            // Mostrar un mensaje de éxito
            MessageBox.Show("Se refresco correctamente la pestaña!");

            // Limpiar los campos
            Limpiartxts();

            // Refrescar todo el formulario MANUsuarios
            Refresh();

            // Volver a cargar los datos en los ComboBox
            ActualizarComboBoxPuesto();
            ActualizarComboBoxDepartamento();
        }

        private void label_info_MouseHover(object sender, EventArgs e)
        {
            label_info.Text = "* Campo obligorio";
        }

        private void label_info_MouseLeave(object sender, EventArgs e)
        {
            label_info.Text = "*";
        }

        private void comboBoxDepar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
