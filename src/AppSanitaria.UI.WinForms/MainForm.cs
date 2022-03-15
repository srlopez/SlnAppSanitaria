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

        // METODOS DE PREPARACION DE LA INTERFACE DE USUARIO
        private void MainForm_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            CargarTipos();
        }

        private void CargarTipos()
        {
            cmbTipo.Items.Add(TipoVacuna.Ninguna);
            cmbTipo.Items.Add(TipoVacuna.Astra);
            cmbTipo.Items.Add(TipoVacuna.Moderna);
            cmbTipo.Items.Add(TipoVacuna.Pfizer);
            cmbTipo.Items.Add(TipoVacuna.JandJ);
        }

        private void CargarPacientes()
        {
            lboxIngresados.Items.Clear();
            var ingresados = _sistema.Ingresados;
            ingresados.ForEach(i => lboxIngresados.Items.Add(i));

            if(ingresados.Count>0) lboxIngresados.SelectedIndex = 0;
        }

        // METODOS RELATIVOS A LOS CASOS DE USO
        // INGRESO
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Nuevo Paciente
            var paciente = new InfoVacPaciente()
            {
                PacienteID = txtID.Text,
                Edad = Int32.Parse(txtEdad.Text),
                Sexo = btnH.Checked ? 'H' : 'M',
                TipoVacunacion = (TipoVacuna)Enum.Parse(typeof(TipoVacuna), cmbTipo.SelectedItem.ToString()),
                DosisRecibidas = Int32.Parse(txtDosis.Text),
                FechaUltimaDosis = dataFUVacuna.Value
            };
            // Ingreso
            _sistema.RealizarIngreso(paciente);
            // Refrescamos la pantalla
            CargarPacientes();
        }
        // ALTA
        private void btnAlta_Click(object sender, EventArgs e)
        {
            // Seleccion del paciente
            var paciente = (InfoVacPaciente) lboxIngresados.SelectedItem;
            if (paciente == null) return;
            // Alta
            _sistema.DarDeAlta(paciente);
            // Refrescamos
            CargarPacientes();
        }

        private void btnPCR_Click(object sender, EventArgs e)
        {
            // Obtenemos los datos para realizar la prueba
            var sintomas = chkSintomas.Checked;
            var inmuno = chkInmunodepresion.Checked;
            var paciente = (InfoVacPaciente)lboxIngresados.SelectedItem;
            if (paciente == null) return;
            
            // Realizamos la prueba
            var pcr = _sistema.RealizacionDePCR(sintomas, inmuno, paciente);

            // Mostramos el resultado
            MessageBox.Show(pcr ? "SI": "NO", "Test PCR"); ;
        }

  

        private void lboxIngresados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var paciente = (InfoVacPaciente)lboxIngresados.SelectedItem;
            if (paciente == null) return;

            // Mostramos el Paciente ingresado
            lblPCRID.Text = paciente.ToString();
        }
    }
}
