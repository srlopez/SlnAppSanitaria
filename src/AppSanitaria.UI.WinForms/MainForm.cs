using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
