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
            using (SqlConnection connection = new SqlConnection("SERVER = CRISTOPHERBV\\MSSQLSERVER01; DATABASE = ProyectoFinalPrograIV; Integrated security = true"))
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

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbTipoRep_SelectedIndexChanged(object sender, EventArgs e)
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
            cbTipoRep.Items.AddRange(new string[] { "REPORTE POR NOMBRE DE SOFTWARE", "REPORTE POR TIPO DE SOFTWARE", "REPORTE POR TIPO DE LICENCIA", "REPORTE DE SOFTWARE POR EQUIPO" });

            // Llenar cbNombreSoftware
            LlenarComboBoxDesdeBaseDeDatos("SELECT Nombre_Software FROM Software", cbNombreSoftware);

            // Llenar cbTipoSoft
            cbTipoSoft.Items.AddRange(new string[] { "Suite de Oficina", "Edición de Imágenes", "Diseño Asistido por Computadora", "Entorno de Desarrollo Integrado" });

            // Llenar cbTipoLicencia
            cbTipoLicencia.Items.AddRange(new string[] { "Licencia Única", "Licencia por Volumen", "Suscripción Anual", "Licencia de Código Abierto (Open Source)" });

            // Llenar cbEquipos
            LlenarComboBoxDesdeBaseDeDatos("SELECT modelo FROM Equipos", cbEquipos);
        }
    }
}
