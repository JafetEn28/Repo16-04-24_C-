using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual de RepEmpleados
            this.Close();
        }

        private void BtnRep_Click(object sender, EventArgs e)
        {

        }
    }
}
