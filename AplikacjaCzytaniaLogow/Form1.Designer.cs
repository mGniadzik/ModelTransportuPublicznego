namespace AplikacjaCzytaniaLogow
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPowitania = new System.Windows.Forms.Panel();
            this.buttonWybraniaLogow = new System.Windows.Forms.Button();
            this.labelPowitania = new System.Windows.Forms.Label();
            this.panelPowitania.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPowitania
            // 
            this.panelPowitania.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPowitania.BackColor = System.Drawing.SystemColors.Control;
            this.panelPowitania.Controls.Add(this.labelPowitania);
            this.panelPowitania.Controls.Add(this.buttonWybraniaLogow);
            this.panelPowitania.Location = new System.Drawing.Point(9, 9);
            this.panelPowitania.Margin = new System.Windows.Forms.Padding(0);
            this.panelPowitania.Name = "panelPowitania";
            this.panelPowitania.Size = new System.Drawing.Size(782, 432);
            this.panelPowitania.TabIndex = 0;
            // 
            // buttonWybraniaLogow
            // 
            this.buttonWybraniaLogow.Location = new System.Drawing.Point(251, 202);
            this.buttonWybraniaLogow.Name = "buttonWybraniaLogow";
            this.buttonWybraniaLogow.Size = new System.Drawing.Size(278, 75);
            this.buttonWybraniaLogow.TabIndex = 0;
            this.buttonWybraniaLogow.Text = "Wybierz Log...";
            this.buttonWybraniaLogow.UseVisualStyleBackColor = true;
            this.buttonWybraniaLogow.Click += new System.EventHandler(this.buttonWybraniaLogow_Click);
            // 
            // labelPowitania
            // 
            this.labelPowitania.AutoSize = true;
            this.labelPowitania.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPowitania.Location = new System.Drawing.Point(46, 101);
            this.labelPowitania.Name = "labelPowitania";
            this.labelPowitania.Size = new System.Drawing.Size(687, 48);
            this.labelPowitania.TabIndex = 1;
            this.labelPowitania.Text = "Witaj w programie do czytania logów programu Modelu Transportu Publicznego. \r\nNac" +
    "iśnij przycisk \"Wybierz Log...\", aby wybrać plik logów.";
            this.labelPowitania.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelPowitania);
            this.Name = "Form1";
            this.Text = "Czytacz Logów";
            this.panelPowitania.ResumeLayout(false);
            this.panelPowitania.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPowitania;
        private System.Windows.Forms.Label labelPowitania;
        private System.Windows.Forms.Button buttonWybraniaLogow;
    }
}

