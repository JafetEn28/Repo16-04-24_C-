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
    public partial class AgregarSoftADM : Form
    {
        public AgregarSoftADM()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
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

        private void Limpiartxts()
        {
            txtFun.Text = "";
            txtLicencia.Text = "";
            txtNombre.Text = "";
            txtSoft.Text = "";
            txtVersion.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                // Obtener los datos del formulario o de donde sea que los recibas
                int idSoftware = Convert.ToInt32(txtSoft.Text);
                string version = txtVersion.Text;
                string nombre = txtNombre.Text;
                string licencia = txtLicencia.Text;
                string funcionalidad = txtFun.Text;
                int cantidad = 1; // cantidad quemada a 1
                DateTime fechaInstalacion = DateTime.Now; // fecha actual

                // Realizar la inserción en la base de datos
                InsertarSoftware(idSoftware, nombre, funcionalidad, licencia, cantidad, fechaInstalacion);

                Limpiartxts();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
            }
        }
        private bool ValidarCampos()
        {
            // Verificar que todos los campos estén llenos y con el tipo de dato correcto
            if (string.IsNullOrWhiteSpace(txtSoft.Text) ||
                string.IsNullOrWhiteSpace(txtVersion.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtLicencia.Text) ||
                string.IsNullOrWhiteSpace(txtFun.Text))
            {
                return false;
            }

            int idSoftware;
            if (!int.TryParse(txtSoft.Text, out idSoftware))
            {
                return false;
            }

            // Puedes agregar más validaciones según el tipo de dato requerido para cada campo

            return true;
        }

        private void InsertarSoftware(int idSoftware, string nombre, string funcionalidad, string licencia, int cantidad, DateTime fechaInstalacion)
        {
            try
            {
                // Abrir la conexión
                using (SqlConnection conexion = Clase_Conexion.Abrir_Conexion())
                {
                    // Crear la consulta SQL parametrizada
                    string consulta = "INSERT INTO Software (idSoftware, Nombre_Software, Funcionalidad, Tipo_Licenciamiento, cantidad, fechaInstalacion) " +
                                      "VALUES (@idSoftware, @nombre, @funcionalidad, @licencia, @cantidad, @fechaInstalacion)";

                    // Crear el comando SQL con la consulta y la conexión
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Agregar parámetros a la consulta
                        comando.Parameters.AddWithValue("@idSoftware", idSoftware);
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@funcionalidad", funcionalidad);
                        comando.Parameters.AddWithValue("@licencia", licencia);
                        comando.Parameters.AddWithValue("@cantidad", cantidad);
                        comando.Parameters.AddWithValue("@fechaInstalacion", fechaInstalacion);

                        // Ejecutar el comando
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Datos de software insertados correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos de software: " + ex.Message);
            }
        }
    }
}   
