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
    public partial class ReportesADM : Form
    {
        public ReportesADM()
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

        private void ReportesADM_Load(object sender, EventArgs e)
        {
            // Agregar las opciones al ComboBox
            cbTipoReporte.Items.Add("Reporte Empleados");
            cbTipoReporte.Items.Add("Reporte Equipos");
            cbTipoReporte.Items.Add("Reporte SoftWare");

            // Deshabilitar la edición del ComboBox
            cbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void cbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la opción seleccionada
            int indiceSeleccionado = cbTipoReporte.SelectedIndex;

            // Dependiendo del índice seleccionado, mostrar el formulario correspondiente
            switch (indiceSeleccionado)
            {
                case 0:
                    // Mostrar el formulario RepEmpleados
                    RepEmpleados formRepEmpleados = new RepEmpleados();
                    formRepEmpleados.FormClosed += (s, args) => cbTipoReporte.Enabled = true; // Habilitar el ComboBox nuevamente cuando se cierre el formulario
                    formRepEmpleados.Show();
                    break;
                case 1:
                    // Mostrar el formulario RepEquipos
                    RepEquipos formRepEquipos = new RepEquipos();
                    formRepEquipos.FormClosed += (s, args) => cbTipoReporte.Enabled = true; // Habilitar el ComboBox nuevamente cuando se cierre el formulario
                    formRepEquipos.Show();
                    break;
                case 2:
                    // Mostrar el formulario RepSoftware
                    RepSoftware formRepSoftware = new RepSoftware();
                    formRepSoftware.FormClosed += (s, args) => cbTipoReporte.Enabled = true; // Habilitar el ComboBox nuevamente cuando se cierre el formulario
                    formRepSoftware.Show();
                    break;
                default:
                    // Por si acaso, manejar cualquier otro caso aquí
                    cbTipoReporte.Enabled = true; // Asegúrate de habilitar el ComboBox nuevamente en caso de un valor no esperado
                    break;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
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
    }
}
