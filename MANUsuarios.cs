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

        SqlConnection conexion = new SqlConnection("Server=JAFETPC;Database=ProyectoFinalPrograIV;Integrated Security=True;");
        public MANUsuarios()
        {
            InitializeComponent();

        }


        public class Usuarios
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



        private void btnGuardarUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se han ingresado todos los datos necesarios
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido1.Text) || string.IsNullOrEmpty(txtApellido2.Text) ||
                    string.IsNullOrEmpty(txtIDpersona.Text) || comboBoxPuesto.SelectedItem == null || comboBoxDepar.SelectedItem == null ||
                    (comboBoxPuesto.SelectedItem.ToString() != "Empleado" && string.IsNullOrEmpty(txtClave.Text)))
                {
                    MessageBox.Show("Por favor, ingrese todos los datos requeridos.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPersona;
                if (!int.TryParse(txtIDpersona.Text, out idPersona))
                {
                    MessageBox.Show("El ID de persona debe ser un número entero.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conexion = new SqlConnection("Server=JAFETPC;Database=ProyectoFinalPrograIV;Integrated Security=True;"))
                {
                    conexion.Open();

                    string nombre = txtNombre.Text;
                    string apellido1 = txtApellido1.Text;
                    string apellido2 = txtApellido2.Text;
                    string puesto = comboBoxPuesto.SelectedItem.ToString();
                    string departamento = comboBoxDepar.SelectedItem.ToString();
                    string clave = txtClave.Text;

                    // Insertar datos en la tabla Personas
                    SqlCommand cmd = new SqlCommand("INSERT INTO Personas (idPersona, nombre, apellido1, apellido2) " +
                                                    "VALUES (@idPersona, @nombre, @apellido1, @apellido2);", conexion);

                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido1", apellido1);
                    cmd.Parameters.AddWithValue("@apellido2", apellido2);

                    cmd.ExecuteNonQuery();

                    // Generar un valor único para idUsuario
                    int idUsuario = GenerarIdUsuario();

                    // Insertar datos en la tabla Usuarios
                    cmd = new SqlCommand("INSERT INTO Usuarios (idUsuario, idPersona, clave, Fecha_Creacion_Usuario, tipoUsuario) " +
                                          "VALUES (@idUsuario, @idPersona, @clave, @fechaCreacion, @tipoUsuario);", conexion);

                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@tipoUsuario", "TipoEjemplo");

                    cmd.ExecuteNonQuery();


                    // Generar un valor único para idEmpleado
                    int idEmpleado = GenerarIdEmpleado();

                    // Insertar datos en la tabla Empleados
                    cmd = new SqlCommand("INSERT INTO Empleados (idEmpleado, idPersona, puesto, departamento, idUsuario) " +
                                          "VALUES (@idEmpleado, @idPersona, @puesto, @departamento, @idUsuario);", conexion);

                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado); // Asignar el valor único de idEmpleado
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    cmd.Parameters.AddWithValue("@puesto", puesto);
                    cmd.Parameters.AddWithValue("@departamento", departamento);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuario guardado correctamente");

                    Limpiartxts();
                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message);
            }
        }


        // Método para generar un valor único para idEmpleado
        private int GenerarIdEmpleado()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 10000); // Genera un número aleatorio entre 1000 y 9999
        }

        // Método para generar un valor único para idUsuario
        private int GenerarIdUsuario()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 10000); // Genera un número aleatorio entre 1000 y 9999
        }

        // Método para actualizar el ComboBox de puesto
        private void ActualizarComboBoxPuesto()
        {
            comboBoxPuesto.Items.Clear();
            comboBoxPuesto.Items.Add("Administrador"); 
            comboBoxPuesto.Items.Add("Tecnico");
            comboBoxPuesto.Items.Add("Empleado");
        }

        // Método para actualizar el ComboBox de departamento
        private void ActualizarComboBoxDepartamento()
        {
            comboBoxDepar.Items.Clear();
            comboBoxDepar.Items.Add("TI");
            comboBoxDepar.Items.Add("RRHH");
            comboBoxDepar.Items.Add("Contabilidad");
            comboBoxDepar.Items.Add("Marketing");
            comboBoxDepar.Items.Add("Ventas");
        }

        private void CargarUsuarios()
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT P.nombre, P.apellido1, P.apellido2, P.idPersona, U.clave, E.puesto, E.departamento FROM Personas P INNER JOIN Usuarios U ON P.idPersona = U.idPersona INNER JOIN Empleados E ON P.idPersona = E.idPersona;", conexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tablaUsuarios = new DataTable();
                adaptador.Fill(tablaUsuarios);
                dataGridViewUsuarios.DataSource = tablaUsuarios;
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
            }
        }





        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                txtNombre.Text = dataGridViewUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido1.Text = dataGridViewUsuarios.CurrentRow.Cells["apellido1"].Value.ToString();
                txtApellido2.Text = dataGridViewUsuarios.CurrentRow.Cells["apellido2"].Value.ToString();
                txtIDpersona.Text = dataGridViewUsuarios.CurrentRow.Cells["idPersona"].Value.ToString();
                txtClave.Text = dataGridViewUsuarios.CurrentRow.Cells["clave"].Value.ToString();

                // Habilitar la edición de los ComboBox
                comboBoxPuesto.Enabled = true;
                comboBoxDepar.Enabled = true;

                // Obtener el valor de puesto y departamento de la fila
                string puesto = dataGridViewUsuarios.CurrentRow.Cells["puesto"].Value?.ToString();
                string departamento = dataGridViewUsuarios.CurrentRow.Cells["departamento"].Value?.ToString();

                // Limpiar y cargar los ComboBox
                ActualizarComboBoxPuesto();
                ActualizarComboBoxDepartamento();

                // Seleccionar el valor correspondiente en los ComboBox
                if (!string.IsNullOrEmpty(puesto))
                {
                    comboBoxPuesto.SelectedItem = puesto;
                }

                if (!string.IsNullOrEmpty(departamento))
                {
                    comboBoxDepar.SelectedItem = departamento;
                }
            }
        }






        private void comboBoxPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string puestoSeleccionado = comboBoxPuesto.SelectedItem.ToString();

            // Si se selecciona Administrador o Técnico, establecer departamento como TI
            if (puestoSeleccionado == "Administrador" || puestoSeleccionado == "Tecnico")
            {
                comboBoxDepar.Items.Clear(); // Limpiar los elementos existentes
                comboBoxDepar.Items.Add("TI"); // Agregar solo la opción TI
                comboBoxDepar.SelectedIndex = 0; // Establecer TI como seleccionado
            }
            // Si se selecciona Empleado, mostrar todos los departamentos disponibles excepto TI
            else if (puestoSeleccionado == "Empleado")
            {
                ActualizarComboBoxDepartamento(); // Volver a cargar todas las opciones de departamento
                comboBoxDepar.Items.Remove("TI"); // Eliminar la opción TI si está presente
            }
            

            // Si se selecciona Administrador o Técnico, habilitar el campo de texto de la clave
            if (puestoSeleccionado == "Administrador" || puestoSeleccionado == "Tecnico")
            {
                txtClave.Enabled = true; // Habilitar el campo de texto de la clave
            }
            // Si se selecciona Empleado, deshabilitar el campo de texto de la clave
            else if (puestoSeleccionado == "Empleado")
            {
                txtClave.Enabled = false; // Deshabilitar el campo de texto de la clave
                txtClave.Text = ""; // Limpiar el campo de texto de la clave
            }
        }



        private void MANUsuarios_Load_1(object sender, EventArgs e)
        {

            // Establecer el estilo del ComboBox de puesto y departamento para que no permita la edición directa
            comboBoxPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepar.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargar opciones de puesto
            ActualizarComboBoxPuesto();

            // Cargar opciones de departamento
            ActualizarComboBoxDepartamento();
        }



        private void Limpiartxts()
        {
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtIDpersona.Text = "";
            comboBoxPuesto.Items.Clear();
            comboBoxDepar.Items.Clear();
            txtClave.Text = "";

        }
        private void btnEliminarUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado una fila en el DataGridView
                if (dataGridViewUsuarios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Fila no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el ID de la persona de la fila seleccionada
                int idPersona = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["idPersona"].Value);

                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar los datos?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Verificar la respuesta del usuario
                if (result == DialogResult.Yes)
                {
                    // Query para eliminar el usuario y sus dependencias
                    string eliminarUsuarioQuery = "DELETE FROM Empleados WHERE idPersona = @idPersona; " +
                                                  "DELETE FROM Usuarios WHERE idPersona = @idPersona; " +
                                                  "DELETE FROM Personas WHERE idPersona = @idPersona;";

                    // Establecer la conexión y ejecutar la consulta
                    using (SqlConnection connection = new SqlConnection("Server=JAFETPC;Database=ProyectoFinalPrograIV;Integrated Security=True;"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(eliminarUsuarioQuery, connection);
                        cmd.Parameters.AddWithValue("@idPersona", idPersona);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
            }
        }


        private void LimpiarDataGridView()
        {
            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.Rows.Clear();
        }

        private async void BtnActuUser_Click(object sender, EventArgs e)
        {
            try
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
                int idPersona = Convert.ToInt32(txtIDpersona.Text);
                string puesto = comboBoxPuesto.SelectedItem?.ToString();
                string departamento = comboBoxDepar.SelectedItem?.ToString();
                string clave = txtClave.Text;

                // Verificar si se han ingresado datos en los campos obligatorios
                if (string.IsNullOrWhiteSpace(nombre) ||
                    string.IsNullOrWhiteSpace(apellido1) ||
                    string.IsNullOrWhiteSpace(apellido2) ||
                    string.IsNullOrWhiteSpace(puesto) ||
                    string.IsNullOrWhiteSpace(departamento))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios antes de actualizar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Deshabilitar el botón mientras se procesa la información
                btnActuUser.Enabled = false;

                // Actualizar los datos en la base de datos
                await ActualizarUsuario(idPersona, nombre, apellido1, apellido2, puesto, departamento, clave);

                // Mostrar un mensaje de éxito
                MessageBox.Show("Usuario actualizado correctamente.");

                // Limpiar los campos
                Limpiartxts();

                // Volver a cargar los usuarios en el DataGridView
                CargarUsuarios();

                // Volver a cargar los datos en los ComboBox
                ActualizarComboBoxPuesto();
                ActualizarComboBoxDepartamento();

                Refresh();
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

        private async Task ActualizarUsuario(int idPersona, string nombre, string apellido1, string apellido2, string puesto, string departamento, string clave)
        {
            using (SqlConnection connection = new SqlConnection("Server=JAFETPC;Database=ProyectoFinalPrograIV;Integrated Security=True;"))
            {
                await connection.OpenAsync();

                string query = "UPDATE Personas SET nombre = @nombre, apellido1 = @apellido1, apellido2 = @apellido2 WHERE idPersona = @idPersona;" +
                               "UPDATE Empleados SET puesto = @puesto, departamento = @departamento WHERE idPersona = @idPersona;" +
                               "UPDATE Usuarios SET clave = @clave WHERE idPersona = @idPersona;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido1", apellido1);
                command.Parameters.AddWithValue("@apellido2", apellido2);
                command.Parameters.AddWithValue("@idPersona", idPersona);
                command.Parameters.AddWithValue("@clave", clave);
                command.Parameters.AddWithValue("@puesto", puesto);
                command.Parameters.AddWithValue("@departamento", departamento);
                await command.ExecuteNonQueryAsync();
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Clase_Conexion.Abrir_Conexion();
            MessageBox.Show("Conexion exitosa con la base de datos!");

            CargarUsuarios();


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
