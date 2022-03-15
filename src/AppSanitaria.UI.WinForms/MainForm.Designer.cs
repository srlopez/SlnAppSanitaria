
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
            this.listBoxIngresados = new System.Windows.Forms.ListBox();
            this.Ingresados = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
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
            this.grpPCR.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxIngresados
            // 
            this.listBoxIngresados.FormattingEnabled = true;
            this.listBoxIngresados.ItemHeight = 15;
            this.listBoxIngresados.Location = new System.Drawing.Point(28, 51);
            this.listBoxIngresados.Name = "listBoxIngresados";
            this.listBoxIngresados.Size = new System.Drawing.Size(299, 349);
            this.listBoxIngresados.TabIndex = 0;
            this.listBoxIngresados.SelectedValueChanged += new System.EventHandler(this.listBoxIngresados_SelectedValueChanged);
            // 
            // Ingresados
            // 
            this.Ingresados.AutoSize = true;
            this.Ingresados.Location = new System.Drawing.Point(28, 32);
            this.Ingresados.Name = "Ingresados";
            this.Ingresados.Size = new System.Drawing.Size(64, 15);
            this.Ingresados.TabIndex = 1;
            this.Ingresados.Text = "Ingresados";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(386, 52);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(18, 15);
            this.ID.TabIndex = 2;
            this.ID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(454, 49);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(200, 23);
            this.txtID.TabIndex = 3;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(454, 78);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(200, 23);
            this.txtEdad.TabIndex = 5;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(386, 81);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(33, 15);
            this.lblEdad.TabIndex = 4;
            this.lblEdad.Text = "Edad";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(386, 110);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(32, 15);
            this.lblSexo.TabIndex = 6;
            this.lblSexo.Text = "Sexo";
            // 
            // txtDosis
            // 
            this.txtDosis.Location = new System.Drawing.Point(454, 165);
            this.txtDosis.Name = "txtDosis";
            this.txtDosis.Size = new System.Drawing.Size(200, 23);
            this.txtDosis.TabIndex = 11;
            // 
            // lblDosis
            // 
            this.lblDosis.AutoSize = true;
            this.lblDosis.Location = new System.Drawing.Point(386, 168);
            this.lblDosis.Name = "lblDosis";
            this.lblDosis.Size = new System.Drawing.Size(35, 15);
            this.lblDosis.TabIndex = 10;
            this.lblDosis.Text = "Dosis";
            // 
            // lblTVacuna
            // 
            this.lblTVacuna.AutoSize = true;
            this.lblTVacuna.Location = new System.Drawing.Point(386, 139);
            this.lblTVacuna.Name = "lblTVacuna";
            this.lblTVacuna.Size = new System.Drawing.Size(54, 15);
            this.lblTVacuna.TabIndex = 8;
            this.lblTVacuna.Text = "T.Vacuna";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(386, 199);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 15);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "Fecha";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(454, 136);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(200, 23);
            this.cmbTipo.TabIndex = 14;
            // 
            // btnH
            // 
            this.btnH.AutoSize = true;
            this.btnH.Location = new System.Drawing.Point(454, 108);
            this.btnH.Name = "btnH";
            this.btnH.Size = new System.Drawing.Size(34, 19);
            this.btnH.TabIndex = 15;
            this.btnH.Text = "H";
            this.btnH.UseVisualStyleBackColor = true;
            // 
            // btnM
            // 
            this.btnM.AutoSize = true;
            this.btnM.Location = new System.Drawing.Point(494, 108);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(36, 19);
            this.btnM.TabIndex = 16;
            this.btnM.Text = "M";
            this.btnM.UseVisualStyleBackColor = true;
            // 
            // dataFUVacuna
            // 
            this.dataFUVacuna.Location = new System.Drawing.Point(454, 193);
            this.dataFUVacuna.Name = "dataFUVacuna";
            this.dataFUVacuna.Size = new System.Drawing.Size(200, 23);
            this.dataFUVacuna.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(540, 222);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Ingresar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(213, 408);
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
            this.grpPCR.Location = new System.Drawing.Point(386, 262);
            this.grpPCR.Name = "grpPCR";
            this.grpPCR.Size = new System.Drawing.Size(268, 137);
            this.grpPCR.TabIndex = 20;
            this.grpPCR.TabStop = false;
            this.grpPCR.Text = "Prueba PCR";
            // 
            // chkInmunodepresion
            // 
            this.chkInmunodepresion.AutoSize = true;
            this.chkInmunodepresion.Location = new System.Drawing.Point(69, 99);
            this.chkInmunodepresion.Name = "chkInmunodepresion";
            this.chkInmunodepresion.Size = new System.Drawing.Size(120, 19);
            this.chkInmunodepresion.TabIndex = 19;
            this.chkInmunodepresion.Text = "Inmunodepresion";
            this.chkInmunodepresion.UseVisualStyleBackColor = true;
            // 
            // chkSintomas
            // 
            this.chkSintomas.AutoSize = true;
            this.chkSintomas.Location = new System.Drawing.Point(69, 74);
            this.chkSintomas.Name = "chkSintomas";
            this.chkSintomas.Size = new System.Drawing.Size(75, 19);
            this.chkSintomas.TabIndex = 18;
            this.chkSintomas.Text = "Sintomas";
            this.chkSintomas.UseVisualStyleBackColor = true;
            // 
            // lblPCRID
            // 
            this.lblPCRID.AutoSize = true;
            this.lblPCRID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPCRID.Location = new System.Drawing.Point(16, 32);
            this.lblPCRID.Name = "lblPCRID";
            this.lblPCRID.Size = new System.Drawing.Size(40, 25);
            this.lblPCRID.TabIndex = 0;
            this.lblPCRID.Text = "n/a";
            // 
            // btnPCR
            // 
            this.btnPCR.Location = new System.Drawing.Point(540, 408);
            this.btnPCR.Name = "btnPCR";
            this.btnPCR.Size = new System.Drawing.Size(114, 23);
            this.btnPCR.TabIndex = 21;
            this.btnPCR.Text = "PCR";
            this.btnPCR.UseVisualStyleBackColor = true;
            this.btnPCR.Click += new System.EventHandler(this.btnPCR_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
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
            this.Controls.Add(this.ID);
            this.Controls.Add(this.Ingresados);
            this.Controls.Add(this.listBoxIngresados);
            this.Name = "MainForm";
            this.Text = "Prueba PCR";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpPCR.ResumeLayout(false);
            this.grpPCR.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxIngresados;
        private System.Windows.Forms.Label Ingresados;
        private System.Windows.Forms.Label ID;
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
    }
}

