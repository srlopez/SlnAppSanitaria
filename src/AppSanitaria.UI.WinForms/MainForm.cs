using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sanitaria.Modelos;

namespace Sanitaria.UI.WinForms
{
    public partial class MainForm : Form
    {
        private GestorDeUrgencias _sistema;

        public MainForm(GestorDeUrgencias sistema)
        {
            _sistema = sistema;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var ingresados = _sistema.Ingresados;
            ingresados.ForEach(i => listBoxIngresados.Items.Add(i));

            cmbTipo.Items.Add(TipoVacuna.Ninguna);
            cmbTipo.Items.Add(TipoVacuna.Astra);
            cmbTipo.Items.Add(TipoVacuna.Moderna);
            cmbTipo.Items.Add(TipoVacuna.Pfizer);
            cmbTipo.Items.Add(TipoVacuna.JandJ);
        }

    

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var paciente = new InfoVacPaciente()
            {
                PacienteID = txtID.Text,
                Edad = Int32.Parse(txtEdad.Text),
                Sexo = btnH.Checked ? 'H' : 'M',
                TipoVacunacion = (TipoVacuna)Enum.Parse(typeof(TipoVacuna), cmbTipo.SelectedItem.ToString()),
                DosisRecibidas = Int32.Parse(txtDosis.Text),
                FechaUltimaDosis = dataFUVacuna.Value
            };
            _sistema.RealizarIngreso(paciente);

            listBoxIngresados.Items.Clear();
            var ingresados = _sistema.Ingresados;
            ingresados.ForEach(i => listBoxIngresados.Items.Add(i));
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
