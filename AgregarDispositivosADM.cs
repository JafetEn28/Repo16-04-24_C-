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
    public partial class AgregarDispositivosADM : Form
    {
        public AgregarDispositivosADM()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            LlenarComboBoxUsuarios();
        }

        private void LlenarComboBoxUsuarios()
        {
            cbUsuario.Items.Clear();
            using (SqlConnection conexion = Clase_Conexion.Abrir_Conexion())
            {
                string consulta = "SELECT idUsuario, idPersona FROM Usuarios";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idUsuario = reader.GetInt32(0);
                        int idPersona = reader.GetInt32(1);


                        string nombrePersona = ObtenerNombrePersona(idPersona);
                        cbUsuario.Items.Add(new KeyValuePair<int, string>(idUsuario, nombrePersona));
                    }
                }
            }

        }

        private string ObtenerNombrePersona(int idPersona)
        {
            string nombrePersona = string.Empty;


            using (SqlConnection conexion = Clase_Conexion.Abrir_Conexion())
            {
                string consulta = "SELECT nombre FROM Personas WHERE idPersona = @IdPersona";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdPersona", idPersona);

                object resultado = comando.ExecuteScalar();
                if (resultado != null)
                {
                    nombrePersona = resultado.ToString();
                }
            }

            return nombrePersona;
        }


        private void GuardarEquipo(int idEquipo, string modelo, string tipoEquipo, DateTime fechaIngreso, string serieCpu, string patrimonioCPU, int cantidad, string marca, int idUsuario)
        {
            using (SqlConnection conexion = Clase_Conexion.Abrir_Conexion())
            {

                string consulta = "INSERT INTO Equipos (idEquipo, modelo, tipoEquipo, fechaIngreso, serieCpu, patrimonioCPU, cantidad, marca, idUsuario) " +
                                  "VALUES (@IdEquipo, @Modelo, @TipoEquipo, @FechaIngreso, @SerieCpu, @PatrimonioCPU, @Cantidad, @Marca, @IdUsuario)";
                SqlCommand comando = new SqlCommand(consulta, conexion);


                comando.Parameters.AddWithValue("@IdEquipo", idEquipo);
                comando.Parameters.AddWithValue("@Modelo", modelo);
                comando.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                comando.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                comando.Parameters.AddWithValue("@SerieCpu", serieCpu);
                comando.Parameters.AddWithValue("@PatrimonioCPU", patrimonioCPU);
                comando.Parameters.AddWithValue("@Cantidad", cantidad);
                comando.Parameters.AddWithValue("@Marca", marca);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                comando.ExecuteNonQuery();
                MessageBox.Show("Equipo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AgregarDispositivosADM_Load(object sender, EventArgs e)
        {
            cbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (CamposCompletos())
            {
                int idEquipo;
                if (!int.TryParse(txtId.Text, out idEquipo))
                {
                    MessageBox.Show("El campo ID debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string modelo = txtModelo.Text;
                string tipoEquipo = cbTipoEquipo.Text;

                // Validar que el tipo de equipo sea seleccionado
                if (string.IsNullOrEmpty(tipoEquipo))
                {
                    MessageBox.Show("Por favor, seleccione un tipo de equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string serieCpu = txtSerie.Text;
                string patrimonioCPU = txtPatrimonio.Text;
                int cantidad = 1;
                string marca = txtMarca.Text;

                // Obtener el KeyValuePair seleccionado en el ComboBox cbUsuarios
                KeyValuePair<int, string> usuarioSeleccionado = (KeyValuePair<int, string>)cbUsuario.SelectedItem;
                int idUsuario = usuarioSeleccionado.Key; // Obtener el ID de usuario del KeyValuePair

                DateTime fechaIngreso = ObtenerFechaActual();

                GuardarEquipo(idEquipo, modelo, tipoEquipo, fechaIngreso, serieCpu, patrimonioCPU, cantidad, marca, idUsuario);
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool CamposCompletos()
        {
            return !string.IsNullOrWhiteSpace(txtId.Text) &&
                   !string.IsNullOrWhiteSpace(txtModelo.Text) &&
                   !string.IsNullOrWhiteSpace(cbTipoEquipo.Text) &&
                   !string.IsNullOrWhiteSpace(txtSerie.Text) &&
                   !string.IsNullOrWhiteSpace(txtPatrimonio.Text) &&
                   !string.IsNullOrWhiteSpace(cbUsuario.Text);
        }

        private DateTime ObtenerFechaActual()
        {
            return DateTime.Now;
        }

        private int ObtenerIdUsuarioPorNombre(string nombreUsuario)
        {
            int idUsuario;
            if (int.TryParse(nombreUsuario, out idUsuario))
            {
                return idUsuario;
            }
            else
            {
                return -1;
            }

        }

        


    }

}
