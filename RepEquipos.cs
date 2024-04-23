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
    public partial class RepEquipos : Form
    {
        public RepEquipos()
        {
            InitializeComponent();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual de RepEmpleados
            this.Close();
        }

        private void btnRep_Click(object sender, EventArgs e)
        {
            // Limpiar el DataGridView antes de cargar nuevos datos
            dataEquipos.DataSource = null;

            // Conectar a la base de datos
            string connectionString = "SERVER = CRISTOPHERBV\\MSSQLSERVER01; DATABASE = ProyectoFinalPrograIV; Integrated security = true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definir la consulta SQL base para todas las opciones de reporte
                string sqlQuery = "SELECT * FROM Equipos WHERE 1 = 1";

                // Modificar la consulta según la opción seleccionada en cbTipoReporte
                if (cbTipoReporte.SelectedIndex == 0) // REPORTE POR TIPO DE EQUIPO
                {
                    string tipoEquipo = cbTipoEquipo.SelectedItem.ToString();
                    sqlQuery += $" AND tipoEquipo = '{tipoEquipo}'";
                }
                else if (cbTipoReporte.SelectedIndex == 1) // REPORTE DE EQUIPOS POR DEPARTAMENTO
                {
                    string tipoEquipo = cbTipoEquipo.SelectedItem.ToString();
                    string departamento = cbDepartamento.SelectedItem.ToString();

                    // Consulta para obtener los equipos según el tipo y el departamento del empleado asociado
                    sqlQuery = @"
                SELECT e.*
                FROM Equipos e
                INNER JOIN Empleados emp ON e.idEmpleado = emp.idEmpleado
                WHERE emp.departamento = @Departamento
                  AND e.tipoEquipo = @TipoEquipo";

                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@Departamento", departamento);
                    command.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Mostrar los resultados en el DataGridView
                    dataEquipos.DataSource = dataTable;
                }
                else if (cbTipoReporte.SelectedIndex == 3) // REPORTE POR MARCA
                {
                    string marca = cbMarca.SelectedItem.ToString();
                    sqlQuery += $" AND marca = '{marca}'";
                }
            }
        }

        private void RepEquipos_Load(object sender, EventArgs e)
        {
            // Llenar cbTipoReporte
            cbTipoReporte.Items.Add("REPORTE POR TIPO DE EQUIPO");
            cbTipoReporte.Items.Add("REPORTE DE EQUIPOS POR DEPARTAMENTO");
            cbTipoReporte.Items.Add("REPORTE GENERAL");
            cbTipoReporte.Items.Add("REPORTE POR MARCA");

            // Llenar cbMarca
            cbMarca.Items.Add("DELL");
            cbMarca.Items.Add("SAMSUNG");
            cbMarca.Items.Add("IOS");
            cbMarca.Items.Add("TOSHIBA");

            // Llenar cbTipoEquipo
            cbTipoEquipo.Items.Add("LAPTOP");
            cbTipoEquipo.Items.Add("TABLET");
            cbTipoEquipo.Items.Add("PC ESCRITORIO");

            // Llenar cbDepartamento
            cbDepartamento.Items.Add("TI");
            cbDepartamento.Items.Add("RRHH");
            cbDepartamento.Items.Add("CONTABILIDAD");
            cbDepartamento.Items.Add("VENTAS");
            cbDepartamento.Items.Add("MARKETING");
        }

        private void cbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Opción 1: REPORTE POR TIPO DE EQUIPO
            if (cbTipoReporte.SelectedIndex == 0)
            {
                cbTipoEquipo.Enabled = true;
                cbDepartamento.Enabled = false;
                cbMarca.Enabled = false;
            }
            // Opción 2: REPORTE DE EQUIPOS POR DEPARTAMENTO
            else if (cbTipoReporte.SelectedIndex == 1)
            {
                cbTipoEquipo.Enabled = true;
                cbDepartamento.Enabled = true;
                cbMarca.Enabled = false;
            }
            // Opción 3: REPORTE GENERAL
            else if (cbTipoReporte.SelectedIndex == 2)
            {
                cbTipoEquipo.Enabled = false;
                cbDepartamento.Enabled = false;
                cbMarca.Enabled = false;
            }
            // Opción 4: REPORTE POR MARCA
            else if (cbTipoReporte.SelectedIndex == 3)
            {
                cbTipoEquipo.Enabled = false;
                cbDepartamento.Enabled = false;
                cbMarca.Enabled = true;
            }
        }

        private void cbTipoEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
