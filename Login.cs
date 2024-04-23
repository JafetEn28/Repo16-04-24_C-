using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Final_PrograIV
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            // Establecer la posición de inicio del formulario en el centro de la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        SqlConnection con = new SqlConnection("Server=JAFETPC;Database=ProyectoFinalPrograIV;Integrated Security=True;");

        public void Logear(string usuario, string contra)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, tipoUsuario FROM Usuarios JOIN Personas ON Usuarios.idPersona = Personas.idPersona WHERE Personas.idPersona = @usuario AND Usuarios.clave = @pas", con);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pas", contra);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                // Crear un formulario de carga
                PantallaDeCarga pantalladeCarga = new PantallaDeCarga();

                if (dt.Rows.Count == 1)
                {
                    this.Hide();

                    if (dt.Rows[0]["tipoUsuario"].ToString() == "Admin")
                    {
                        // Mostrar formulario de carga
                        pantalladeCarga.Show();

                        // Configurar un temporizador para cerrar el formulario de carga después de 5 segundos
                        Timer timer = new Timer();
                        timer.Interval = 2000; // 5000 milisegundos = 5 segundos
                        timer.Tick += (s, ev) =>
                        {
                            // Detener el temporizador
                            timer.Stop();

                            // Cerrar el formulario de carga
                            pantalladeCarga.Close();

                            // Abrir formulario de ControlADM
                            this.Hide();
                            ControlADM controlADM = new ControlADM();
                            controlADM.ShowDialog();
                            this.Close();
                        };
                        timer.Start();
                    }
                    else if (dt.Rows[0]["tipoUsuario"].ToString() == "Tecnico")
                    {
                        // Mostrar formulario de carga
                        pantalladeCarga.Show();

                        // Configurar un temporizador para cerrar el formulario de carga después de 5 segundos
                        Timer timer = new Timer();
                        timer.Interval = 2000; // 5000 milisegundos = 5 segundos
                        timer.Tick += (s, ev) =>
                        {
                            // Detener el temporizador
                            timer.Stop();

                            // Cerrar el formulario de carga
                            pantalladeCarga.Close();

                            // Abrir formulario de MenuTecnico
                            this.Hide();
                            MenuTecnico menuTecnico = new MenuTecnico();
                            menuTecnico.ShowDialog();
                            this.Close();
                        };
                        timer.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
        } 
        /*private void txtCedula_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCedula.Text == "Digite su Cedula")
            {
                txtCedula.Text = "";
            }
        }*/



        //CARGA DEL LOAD
        private void Login_Load(object sender, EventArgs e)
        {

            // Obtener la fecha y hora actual
            DateTime fechaHoraActual = DateTime.Now;

            // Mostrar la fecha y hora en el formato deseado en un Label
            label1.Text = fechaHoraActual.ToString("dd/MM/yyyy HH:mm");
        }



            private void txtCedula_Enter(object sender, EventArgs e)
        {
            if (txtCedula.Text == "Digite su cédula")
            {
                txtCedula.Text = "";
                txtCedula.ForeColor = Color.DimGray;
            }
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            if (txtCedula.Text == "")
            {
                txtCedula.Text = "Digite su cédula";
                txtCedula.ForeColor = Color.LightGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "Ejemplo123")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "Ejemplo123";
                txtContra.ForeColor = Color.LightGray;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            string contraseña = txtContra.Text;
            string tipoUsuario = "";

            // Verificar qué tipo de usuario se seleccionó
            if (chkAdmin.Checked)
            {
                tipoUsuario = "Admin";
            }
            else if (chkTecnico.Checked)
            {
                tipoUsuario = "Tecnico";
            }
            else
            {
                MessageBox.Show("Por favor, seleccione el tipo de usuario.");
                return;
            }

            try
            {
                using (SqlConnection connection = Clase_Conexion.Abrir_Conexion())
                {
                    // Consulta SQL para verificar las credenciales del usuario
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE idPersona = @Cedula AND clave = @Contraseña AND tipoUsuario = @TipoUsuario";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Cedula", cedula);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);
                        command.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Inicio de sesión exitoso como " + tipoUsuario);

                            
                            // Aquí puedes redirigir al usuario a la página correspondiente
                        }
                        else
                        {
                            MessageBox.Show("Cédula, tipo de usuario o contraseña incorrectos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        
    }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrar.Checked == true)

            {
                txtContra.UseSystemPasswordChar = false;
            }
            else
            {
                txtContra.UseSystemPasswordChar= true;
            }
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAdmin.Checked)
            {

                chkTecnico.Checked = false;
            }
        }

        private void chkTecnico_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTecnico.Checked)
            {

                chkAdmin.Checked = false;
            }


        }
    }
}


    




    
