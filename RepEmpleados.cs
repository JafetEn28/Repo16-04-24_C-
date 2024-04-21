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
    public partial class RepEmpleados : Form
    {
        public RepEmpleados()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRep_Click(object sender, EventArgs e)
        {
            // Verificar si la opción "REPORTE DE EMPLEADOS" está seleccionada
            if (cbReporte.SelectedItem.ToString() == "REPORTE DE EMPLEADOS")
            {
                // Cargar datos de la tabla "Empleados" en el DataGridView
                LoadDataFromEmployeesTable();
            }
            else
            {
                // Si otra opción está seleccionada, mostrar un mensaje de advertencia o manejarlo según sea necesario
                MessageBox.Show("No se ha seleccionado la opción 'REPORTE DE EMPLEADOS'.");
            }

        }
        private void LoadDataFromEmployeesTable()
        {    // Consulta SQL base para seleccionar todos los datos de la tabla Empleados
            string query = "SELECT * FROM Empleados";

            // Verificar si se ha seleccionado un departamento en cbDepartamentos
            if (cbDepartamentos.SelectedIndex != -1 && cbDepartamentos.Enabled)
            {
                // Agregar filtro por departamento a la consulta SQL
                string departamentoSeleccionado = cbDepartamentos.SelectedItem.ToString();
                query = "SELECT * FROM Empleados WHERE Departamento = '" + departamentoSeleccionado + "'";
            }

            // Crear una nueva conexión utilizando la cadena de conexión
            using (SqlConnection connection = new SqlConnection("SERVER = CRISTOPHERBV\\MSSQLSERVER01; DATABASE = ProyectoFinalPrograIV; Integrated security = true"))
            {
                // Crear un SqlDataAdapter para ejecutar la consulta y llenar un DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Crear un DataTable para almacenar los resultados de la consulta
                DataTable dataTable = new DataTable();

                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Llenar el DataTable con los datos del SqlDataAdapter
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como origen de datos del DataGridView
                    dataEmpleados.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante el proceso de carga de datos
                    MessageBox.Show("Error al cargar datos de la tabla Empleados: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión
                    connection.Close();
                }
            }
        }

        private void cbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llamar al método LoadDataFromEmployeesTable() cada vez que se seleccione un departamento
            if (cbReporte.SelectedItem.ToString() == "EMPLEADOS POR DEPARTAMENTO")
            {
                LoadDataFromEmployeesTable();
            }
        }

        private void cbReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si la opción "REPORTE DE EMPLEADOS POR DEPARTAMENTO" está seleccionada
            if (cbReporte.SelectedItem.ToString() == "EMPLEADOS POR DEPARTAMENTO")
            {
                // Si la opción está seleccionada, habilitar el ComboBox cbDepartamentos
                cbDepartamentos.Enabled = true;
            }
            else
            {
                // Si otra opción está seleccionada, deshabilitar el ComboBox cbDepartamentos
                cbDepartamentos.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual de RepEmpleados
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Consulta SQL para seleccionar todos los datos de la tabla Empleados
            string query = "SELECT * FROM Empleados";

            // Crear una nueva conexión utilizando la cadena de conexión
            using (SqlConnection connection = new SqlConnection("SERVER = CRISTOPHERBV\\MSSQLSERVER01; DATABASE = ProyectoFinalPrograIV;Integrated security=true"))
            {
                // Crear un SqlDataAdapter para ejecutar la consulta y llenar un DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Crear un DataTable para almacenar los resultados de la consulta
                DataTable dataTable = new DataTable();

                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Llenar el DataTable con los datos del SqlDataAdapter
                    adapter.Fill(dataTable);

                    // Asignar el DataTable como origen de datos del DataGridView
                    dataEmpleados.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante el proceso de carga de datos
                    MessageBox.Show("Error al cargar datos de la tabla Empleados: " + ex.Message);
                }
                finally
                {
                    // Cerrar la conexión
                    connection.Close();
                }
            }
        }

        private void RepEmpleados_Load(object sender, EventArgs e)
        {
            cbDepartamentos.Items.Add("TI");
            cbDepartamentos.Items.Add("RRHH");
            cbDepartamentos.Items.Add("CONTABILIDAD");
            cbDepartamentos.Items.Add("VENTAS");
            cbDepartamentos.Items.Add("MARKETING");
            // Deshabilitar la edición del ComboBox cbDepartamentos
            cbDepartamentos.DropDownStyle = ComboBoxStyle.DropDownList;


            // Deshabilitar la edición del ComboBox cbReporte
            cbReporte.DropDownStyle = ComboBoxStyle.DropDownList;

            // Agregar las opciones al ComboBox cbReporte
            cbReporte.Items.Add("REPORTE DE EMPLEADOS");
            cbReporte.Items.Add("EMPLEADOS POR DEPARTAMENTO");

            // Deshabilitar la edición del ComboBox cbReporte
            cbReporte.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
