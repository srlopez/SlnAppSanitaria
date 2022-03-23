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

        // INYECCION DE LA DEPENDENCIA
        public MainForm(GestorDeUrgencias sistema)
        {
            _sistema = sistema;
            InitializeComponent();
        }

        // METODOS DE PREPARACION Y MANEJO DE EVENTOS DE LA INTERFACE DE USUARIO
        private void MainForm_Load(object sender, EventArgs e)
        {
            CargarPacientesIngresados();
            CargarTipoVacuna();
        }
        private void lboxIngresados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var paciente = (InfoVacPaciente)lboxIngresados.SelectedItem;
            if (paciente == null) return;

            // Mostramos el Paciente ingresado
            lblPCRID.Text = paciente.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e) => IngresoDepaciente();
        private void btnAlta_Click(object sender, EventArgs e) => AltaDePaciente();
        private void btnPCR_Click(object sender, EventArgs e) => EfectuarPruebaPCR();

        // METODOS RELATIVOS A LOS CASOS DE USO
        // INGRESO
        private void IngresoDepaciente()
        {
            try
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
                CargarPacientesIngresados();
            }catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "ERROR"); ;
            }
        }
        // ALTA
        private void AltaDePaciente()
        {
            // Seleccion del paciente
            var paciente = (InfoVacPaciente) lboxIngresados.SelectedItem;
            if (paciente == null) return;
            // Alta
            _sistema.DarDeAlta(paciente);
            // Refrescamos
            CargarPacientesIngresados();
        }
        // VERIFICACION DE PRUEBA PCR
        private void EfectuarPruebaPCR()
        {
            // Obtenemos los datos para realizar la prueba
            var sintomas = chkSintomas.Checked;
            var inmuno = chkInmunodepresion.Checked;
            var paciente = (InfoVacPaciente)lboxIngresados.SelectedItem;
            if (paciente == null) return;
            
            // Realizamos la prueba
            var testPCR = _sistema.RealizacionDePCR(sintomas, inmuno, paciente);

            // Mostramos el resultado
            MessageBox.Show(testPCR ? "SI": "NO", "Test PCR"); ;
        }
        // OBTENER/MOSTRAR PACIENTES INGRESADOS
        private void CargarPacientesIngresados()
        {
            // Limpiamos la lista
            lboxIngresados.Items.Clear();
            // La cargamos con nuestros datos
            var ingresados = _sistema.Ingresados;
            ingresados.ForEach(i => lboxIngresados.Items.Add(i));
            // Marcamos el primero como seleccionado
            if (ingresados.Count > 0) lboxIngresados.SelectedIndex = 0;
        }
        // OTROS
        private void CargarTipoVacuna() =>
                cmbTipo.Items.AddRange(Enum.GetNames(typeof(TipoVacuna)));

    }
}
