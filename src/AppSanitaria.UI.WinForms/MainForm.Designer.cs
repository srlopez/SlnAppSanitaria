
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
            this.SuspendLayout();
            // 
            // listBoxIngresados
            // 
            this.listBoxIngresados.FormattingEnabled = true;
            this.listBoxIngresados.ItemHeight = 15;
            this.listBoxIngresados.Location = new System.Drawing.Point(28, 51);
            this.listBoxIngresados.Name = "listBoxIngresados";
            this.listBoxIngresados.Size = new System.Drawing.Size(264, 379);
            this.listBoxIngresados.TabIndex = 0;
            // 
            // Ingresados
            // 
            this.Ingresados.AutoSize = true;
            this.Ingresados.Location = new System.Drawing.Point(28, 20);
            this.Ingresados.Name = "Ingresados";
            this.Ingresados.Size = new System.Drawing.Size(64, 15);
            this.Ingresados.TabIndex = 1;
            this.Ingresados.Text = "Ingresados";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Ingresados);
            this.Controls.Add(this.listBoxIngresados);
            this.Name = "MainForm";
            this.Text = "Prueba PCR";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxIngresados;
        private System.Windows.Forms.Label Ingresados;
    }
}

