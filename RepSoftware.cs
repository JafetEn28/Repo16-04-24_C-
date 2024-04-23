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
    public partial class RepSoftware : Form
    {
        public RepSoftware()
        {
            InitializeComponent();
        }
        private void LlenarComboBoxDesdeBaseDeDatos(string query, ComboBox comboBox)
        {
            using (SqlConnection connection = new SqlConnection("Server=JAFETPC;Database=ProyectoFinalProgra44;Integrated Security=True;"))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> items = new List<string>();

                    while (reader.Read())
                    {
                        items.Add(reader.GetString(0));
                    }

                    comboBox.Items.AddRange(items.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos desde la base de datos: " + ex.Message);
                }
            }
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual de RepEmpleados
            this.Close();
        }

        private void BtnRep_Click(object sender, EventArgs e)
        {
            // Limpiar el DataGridView antes de cargar nuevos datos
            dataSoftware.DataSource = null;

            // Conectar a la base de datos

            

            string connectionString = "Server=JAFETPC;Database=ProyectoFinalProgra44;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = null;

                // Consulta SQL según la opción seleccionada en cbTipoRep
                switch (cbTipoRepSoft.SelectedIndex)
                {
                    case 0: // REPORTE POR NOMBRE DE SOFTWARE
                        string nombreSoftware = cbNombreSoftware.SelectedItem.ToString();
                        string queryNombreSoftware = "SELECT * FROM Software WHERE Nombre_Software = @NombreSoftware";
                        command = new SqlCommand(queryNombreSoftware, connection);
                        command.Parameters.AddWithValue("@NombreSoftware", nombreSoftware);
                        break;
                    case 1: // REPORTE POR TIPO DE LICENCIA
                        string tipoLicencia = cbTipoLicencia.SelectedItem.ToString();
                        string queryTipoLicencia = "SELECT * FROM Software WHERE Tipo_Licenciamiento = @TipoLicencia";
                        command = new SqlCommand(queryTipoLicencia, connection);
                        command.Parameters.AddWithValue("@TipoLicencia", tipoLicencia);
                        break;
                    case 2: // REPORTE DE SOFTWARE POR EQUIPO
                        string equipo = cbEquipos.SelectedItem.ToString();
                        string queryEquipo = @"
                    SELECT s.*
                    FROM Software s
                    INNER JOIN Equipos e ON s.idEquipo = e.idEquipo
                    WHERE e.modelo = @Equipo";
                        command = new SqlCommand(queryEquipo, connection);
                        command.Parameters.AddWithValue("@Equipo", equipo);
                        break;
                    default:
                        break;
                }

                if (command != null)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Mostrar los resultados en el DataGridView
                    dataSoftware.DataSource = dataTable;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbNombreSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbTipoSoft_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTipoLicencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataSoftware_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RepSoftware_Load(object sender, EventArgs e)
        {
            // Llenar cbTipoRep
            cbTipoRepSoft.Items.AddRange(new string[] { "REPORTE POR NOMBRE DE SOFTWARE", "REPORTE POR TIPO DE LICENCIA", "REPORTE DE SOFTWARE POR EQUIPO" });

            // Llenar cbTipoLicencia
            cbTipoLicencia.Items.AddRange(new string[] { "Licencia Única", "Licencia por Volumen", "Suscripción Anual", "Licencia de Código Abierto (Open Source)" });

            // Llenar cbEquipos
            LlenarComboBoxDesdeBaseDeDatos("SELECT modelo FROM Equipos", cbEquipos);
            // Llenar cbNombreSoftware
            LlenarComboBoxDesdeBaseDeDatos("SELECT Nombre_Software FROM Software", cbNombreSoftware);

            // Deshabilitar la edición del ComboBox
            cbTipoRepSoft.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNombreSoftware.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoLicencia.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbTipoRepSoft_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Deshabilitar todos los ComboBox al principio
            cbNombreSoftware.Enabled = false;
            cbTipoLicencia.Enabled = false;
            cbEquipos.Enabled = false;

            // Habilitar el ComboBox correspondiente según la opción seleccionada en cbTipoRep
            switch (cbTipoRepSoft.SelectedIndex)
            {
                case 0: // REPORTE POR NOMBRE DE SOFTWARE
                    cbNombreSoftware.Enabled = true;
                    break;
                case 1: // REPORTE POR TIPO DE LICENCIA
                    cbTipoLicencia.Enabled = true;
                    break;
                case 2: // REPORTE DE SOFTWARE POR EQUIPO
                    cbEquipos.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void cbEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}