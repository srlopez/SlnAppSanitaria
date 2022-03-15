
namespace Sanitaria.UI.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lboxIngresados = new System.Windows.Forms.ListBox();
            this.lblIngresados = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.txtDosis = new System.Windows.Forms.TextBox();
            this.lblDosis = new System.Windows.Forms.Label();
            this.lblTVacuna = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnH = new System.Windows.Forms.RadioButton();
            this.btnM = new System.Windows.Forms.RadioButton();
            this.dataFUVacuna = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.grpPCR = new System.Windows.Forms.GroupBox();
            this.chkInmunodepresion = new System.Windows.Forms.CheckBox();
            this.chkSintomas = new System.Windows.Forms.CheckBox();
            this.lblPCRID = new System.Windows.Forms.Label();
            this.btnPCR = new System.Windows.Forms.Button();
            this.lblNuevoIngreso = new System.Windows.Forms.Label();
            this.grpPCR.SuspendLayout();
            this.SuspendLayout();
            // 
            // lboxIngresados
            // 
            this.lboxIngresados.FormattingEnabled = true;
            this.lboxIngresados.ItemHeight = 15;
            this.lboxIngresados.Location = new System.Drawing.Point(330, 61);
            this.lboxIngresados.Name = "lboxIngresados";
            this.lboxIngresados.Size = new System.Drawing.Size(299, 169);
            this.lboxIngresados.TabIndex = 0;
            this.lboxIngresados.SelectedIndexChanged += new System.EventHandler(this.lboxIngresados_SelectedIndexChanged);
            // 
            // lblIngresados
            // 
            this.lblIngresados.AutoSize = true;
            this.lblIngresados.Location = new System.Drawing.Point(330, 32);
            this.lblIngresados.Name = "lblIngresados";
            this.lblIngresados.Size = new System.Drawing.Size(64, 15);
            this.lblIngresados.TabIndex = 1;
            this.lblIngresados.Text = "Ingresados";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(26, 64);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 15);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(94, 61);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(200, 23);
            this.txtID.TabIndex = 3;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(94, 90);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(200, 23);
            this.txtEdad.TabIndex = 5;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(26, 93);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(33, 15);
            this.lblEdad.TabIndex = 4;
            this.lblEdad.Text = "Edad";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(26, 122);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(32, 15);
            this.lblSexo.TabIndex = 6;
            this.lblSexo.Text = "Sexo";
            // 
            // txtDosis
            // 
            this.txtDosis.Location = new System.Drawing.Point(94, 177);
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Size = new System.Drawing.Size(200, 23);
            this.txtDosis.TabIndex = 11;
            // 
            // lblDosis
            // 
            this.lblDosis.AutoSize = true;
            this.lblDosis.Location = new System.Drawing.Point(26, 180);
            this.lblDosis.Name = "lblDosis";
            this.lblDosis.Size = new System.Drawing.Size(35, 15);
            this.lblDosis.TabIndex = 10;
            this.lblDosis.Text = "Dosis";
            // 
            // lblTVacuna
            // 
            this.lblTVacuna.AutoSize = true;
            this.lblTVacuna.Location = new System.Drawing.Point(26, 151);
            this.lblTVacuna.Name = "lblTVacuna";
            this.lblTVacuna.Size = new System.Drawing.Size(54, 15);
            this.lblTVacuna.TabIndex = 8;
            this.lblTVacuna.Text = "T.Vacuna";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(26, 211);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 15);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "Fecha";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(94, 148);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(200, 23);
            this.cmbTipo.TabIndex = 14;
            // 
            // btnH
            // 
            this.btnH.AutoSize = true;
            this.btnH.Location = new System.Drawing.Point(94, 120);
            this.btnH.Name = "btnH";
            this.btnH.Size = new System.Drawing.Size(34, 19);
            this.btnH.TabIndex = 15;
            this.btnH.Text = "H";
            this.btnH.UseVisualStyleBackColor = true;
            // 
            // btnM
            // 
            this.btnM.AutoSize = true;
            this.btnM.Location = new System.Drawing.Point(134, 120);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(36, 19);
            this.btnM.TabIndex = 16;
            this.btnM.Text = "M";
            this.btnM.UseVisualStyleBackColor = true;
            // 
            // dataFUVacuna
            // 
            this.dataFUVacuna.Location = new System.Drawing.Point(94, 205);
            this.dataFUVacuna.Name = "dataFUVacuna";
            this.dataFUVacuna.Size = new System.Drawing.Size(200, 23);
            this.dataFUVacuna.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(180, 234);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Ingresar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(515, 236);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(114, 23);
            this.btnAlta.TabIndex = 19;
            this.btnAlta.Text = "Alta Paciente";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // grpPCR
            // 
            this.grpPCR.Controls.Add(this.chkInmunodepresion);
            this.grpPCR.Controls.Add(this.chkSintomas);
            this.grpPCR.Controls.Add(this.lblPCRID);
            this.grpPCR.Location = new System.Drawing.Point(651, 34);
            this.grpPCR.Name = "grpPCR";
            this.grpPCR.Size = new System.Drawing.Size(303, 196);
            this.grpPCR.TabIndex = 20;
            this.grpPCR.TabStop = false;
            this.grpPCR.Text = "Prueba PCR";
            // 
            // chkInmunodepresion
            // 
            this.chkInmunodepresion.AutoSize = true;
            this.chkInmunodepresion.Location = new System.Drawing.Point(16, 99);
            this.chkInmunodepresion.Name = "chkInmunodepresion";
            this.chkInmunodepresion.Size = new System.Drawing.Size(120, 19);
            this.chkInmunodepresion.TabIndex = 19;
            this.chkInmunodepresion.Text = "Inmunodepresion";
            this.chkInmunodepresion.UseVisualStyleBackColor = true;
            // 
            // chkSintomas
            // 
            this.chkSintomas.AutoSize = true;
            this.chkSintomas.Location = new System.Drawing.Point(16, 74);
            this.chkSintomas.Name = "chkSintomas";
            this.chkSintomas.Size = new System.Drawing.Size(75, 19);
            this.chkSintomas.TabIndex = 18;
            this.chkSintomas.Text = "Sintomas";
            this.chkSintomas.UseVisualStyleBackColor = true;
            // 
            // lblPCRID
            // 
            this.lblPCRID.AutoSize = true;
            this.lblPCRID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPCRID.Location = new System.Drawing.Point(16, 30);
            this.lblPCRID.Name = "lblPCRID";
            this.lblPCRID.Size = new System.Drawing.Size(33, 20);
            this.lblPCRID.TabIndex = 0;
            this.lblPCRID.Text = "n/a";
            // 
            // btnPCR
            // 
            this.btnPCR.Location = new System.Drawing.Point(840, 236);
            this.btnPCR.Name = "btnPCR";
            this.btnPCR.Size = new System.Drawing.Size(114, 23);
            this.btnPCR.TabIndex = 21;
            this.btnPCR.Text = "Test PCR";
            this.btnPCR.UseVisualStyleBackColor = true;
            this.btnPCR.Click += new System.EventHandler(this.btnPCR_Click);
            // 
            // lblNuevoIngreso
            // 
            this.lblNuevoIngreso.AutoSize = true;
            this.lblNuevoIngreso.Location = new System.Drawing.Point(26, 32);
            this.lblNuevoIngreso.Name = "lblNuevoIngreso";
            this.lblNuevoIngreso.Size = new System.Drawing.Size(84, 15);
            this.lblNuevoIngreso.TabIndex = 22;
            this.lblNuevoIngreso.Text = "Nuevo Ingreso";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 280);
            this.Controls.Add(this.lblNuevoIngreso);
            this.Controls.Add(this.btnPCR);
            this.Controls.Add(this.grpPCR);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataFUVacuna);
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.btnH);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtDosis);
            this.Controls.Add(this.lblDosis);
            this.Controls.Add(this.lblTVacuna);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblIngresados);
            this.Controls.Add(this.lboxIngresados);
            this.Name = "MainForm";
            this.Text = "SERVICIO DE URGENCIAS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpPCR.ResumeLayout(false);
            this.grpPCR.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboxIngresados;
        private System.Windows.Forms.Label lblIngresados;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.TextBox txtDosis;
        private System.Windows.Forms.Label lblDosis;
        private System.Windows.Forms.Label lblTVacuna;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.RadioButton btnH;
        private System.Windows.Forms.RadioButton btnM;
        private System.Windows.Forms.DateTimePicker dataFUVacuna;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.GroupBox grpPCR;
        private System.Windows.Forms.Label lblPCRID;
        private System.Windows.Forms.Button btnPCR;
        private System.Windows.Forms.CheckBox chkInmunodepresion;
        private System.Windows.Forms.CheckBox chkSintomas;
        private System.Windows.Forms.Label lblNuevoIngreso;
    }
}

