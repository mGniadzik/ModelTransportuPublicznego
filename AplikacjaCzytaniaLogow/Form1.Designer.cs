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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelPowitania = new System.Windows.Forms.Panel();
            this.labelPowitania = new System.Windows.Forms.Label();
            this.buttonWybraniaLogow = new System.Windows.Forms.Button();
            this.panelWykresu = new System.Windows.Forms.Panel();
            this.usunWszystkiePrzejazdyB = new System.Windows.Forms.Button();
            this.dodajWszystkiePrzejazdyB = new System.Windows.Forms.Button();
            this.powrotB = new System.Windows.Forms.Button();
            this.linieCB = new System.Windows.Forms.ComboBox();
            this.usunPrzejazdB = new System.Windows.Forms.Button();
            this.usunPrzejazdCB = new System.Windows.Forms.ComboBox();
            this.wybierzLinieB = new System.Windows.Forms.Button();
            this.dodajPrzejazdCB = new System.Windows.Forms.ComboBox();
            this.dodajPrzejazdB = new System.Windows.Forms.Button();
            this.wykresP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelPowitania.SuspendLayout();
            this.panelWykresu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresP)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPowitania
            // 
            this.panelPowitania.BackColor = System.Drawing.SystemColors.Control;
            this.panelPowitania.Controls.Add(this.labelPowitania);
            this.panelPowitania.Controls.Add(this.buttonWybraniaLogow);
            this.panelPowitania.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPowitania.Location = new System.Drawing.Point(0, 0);
            this.panelPowitania.Margin = new System.Windows.Forms.Padding(0);
            this.panelPowitania.Name = "panelPowitania";
            this.panelPowitania.Size = new System.Drawing.Size(800, 450);
            this.panelPowitania.TabIndex = 0;
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
            // panelWykresu
            // 
            this.panelWykresu.Controls.Add(this.usunWszystkiePrzejazdyB);
            this.panelWykresu.Controls.Add(this.dodajWszystkiePrzejazdyB);
            this.panelWykresu.Controls.Add(this.powrotB);
            this.panelWykresu.Controls.Add(this.linieCB);
            this.panelWykresu.Controls.Add(this.usunPrzejazdB);
            this.panelWykresu.Controls.Add(this.usunPrzejazdCB);
            this.panelWykresu.Controls.Add(this.wybierzLinieB);
            this.panelWykresu.Controls.Add(this.dodajPrzejazdCB);
            this.panelWykresu.Controls.Add(this.dodajPrzejazdB);
            this.panelWykresu.Controls.Add(this.wykresP);
            this.panelWykresu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWykresu.Location = new System.Drawing.Point(0, 0);
            this.panelWykresu.Name = "panelWykresu";
            this.panelWykresu.Size = new System.Drawing.Size(800, 450);
            this.panelWykresu.TabIndex = 2;
            this.panelWykresu.Visible = false;
            // 
            // usunWszystkiePrzejazdyB
            // 
            this.usunWszystkiePrzejazdyB.Location = new System.Drawing.Point(437, 66);
            this.usunWszystkiePrzejazdyB.Name = "usunWszystkiePrzejazdyB";
            this.usunWszystkiePrzejazdyB.Size = new System.Drawing.Size(198, 32);
            this.usunWszystkiePrzejazdyB.TabIndex = 9;
            this.usunWszystkiePrzejazdyB.Text = "Usuń wszystkie przejazdy";
            this.usunWszystkiePrzejazdyB.UseVisualStyleBackColor = true;
            this.usunWszystkiePrzejazdyB.Click += new System.EventHandler(this.usunWszystkiePrzejazdyB_Click);
            // 
            // dodajWszystkiePrzejazdyB
            // 
            this.dodajWszystkiePrzejazdyB.Location = new System.Drawing.Point(437, 24);
            this.dodajWszystkiePrzejazdyB.Name = "dodajWszystkiePrzejazdyB";
            this.dodajWszystkiePrzejazdyB.Size = new System.Drawing.Size(198, 33);
            this.dodajWszystkiePrzejazdyB.TabIndex = 8;
            this.dodajWszystkiePrzejazdyB.Text = "Dodaj wyszystkie przejazdy";
            this.dodajWszystkiePrzejazdyB.UseVisualStyleBackColor = true;
            this.dodajWszystkiePrzejazdyB.Click += new System.EventHandler(this.dodajWszystkiePrzejazdyB_Click);
            // 
            // powrotB
            // 
            this.powrotB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.powrotB.Location = new System.Drawing.Point(661, 12);
            this.powrotB.Name = "powrotB";
            this.powrotB.Size = new System.Drawing.Size(127, 104);
            this.powrotB.TabIndex = 7;
            this.powrotB.Text = "Powrót do ekranu powitania";
            this.powrotB.UseVisualStyleBackColor = true;
            this.powrotB.Click += new System.EventHandler(this.button4_Click);
            // 
            // linieCB
            // 
            this.linieCB.FormattingEnabled = true;
            this.linieCB.Location = new System.Drawing.Point(219, 12);
            this.linieCB.Name = "linieCB";
            this.linieCB.Size = new System.Drawing.Size(194, 21);
            this.linieCB.TabIndex = 6;
            // 
            // usunPrzejazdB
            // 
            this.usunPrzejazdB.Location = new System.Drawing.Point(5, 83);
            this.usunPrzejazdB.Name = "usunPrzejazdB";
            this.usunPrzejazdB.Size = new System.Drawing.Size(196, 33);
            this.usunPrzejazdB.TabIndex = 5;
            this.usunPrzejazdB.Text = "Usuń przejazd";
            this.usunPrzejazdB.UseVisualStyleBackColor = true;
            this.usunPrzejazdB.Click += new System.EventHandler(this.usunPrzejazdB_Click);
            // 
            // usunPrzejazdCB
            // 
            this.usunPrzejazdCB.FormattingEnabled = true;
            this.usunPrzejazdCB.Location = new System.Drawing.Point(219, 90);
            this.usunPrzejazdCB.Name = "usunPrzejazdCB";
            this.usunPrzejazdCB.Size = new System.Drawing.Size(194, 21);
            this.usunPrzejazdCB.TabIndex = 4;
            // 
            // wybierzLinieB
            // 
            this.wybierzLinieB.Location = new System.Drawing.Point(3, 5);
            this.wybierzLinieB.Name = "wybierzLinieB";
            this.wybierzLinieB.Size = new System.Drawing.Size(198, 33);
            this.wybierzLinieB.TabIndex = 3;
            this.wybierzLinieB.Text = "Wybierz linie";
            this.wybierzLinieB.UseVisualStyleBackColor = true;
            this.wybierzLinieB.Click += new System.EventHandler(this.wybierzLinieB_Click);
            // 
            // dodajPrzejazdCB
            // 
            this.dodajPrzejazdCB.FormattingEnabled = true;
            this.dodajPrzejazdCB.Location = new System.Drawing.Point(219, 51);
            this.dodajPrzejazdCB.Name = "dodajPrzejazdCB";
            this.dodajPrzejazdCB.Size = new System.Drawing.Size(194, 21);
            this.dodajPrzejazdCB.TabIndex = 2;
            // 
            // dodajPrzejazdB
            // 
            this.dodajPrzejazdB.Location = new System.Drawing.Point(3, 44);
            this.dodajPrzejazdB.Name = "dodajPrzejazdB";
            this.dodajPrzejazdB.Size = new System.Drawing.Size(198, 33);
            this.dodajPrzejazdB.TabIndex = 1;
            this.dodajPrzejazdB.Text = "Dodaj przejazd";
            this.dodajPrzejazdB.UseVisualStyleBackColor = true;
            this.dodajPrzejazdB.Click += new System.EventHandler(this.dodajPrzejazdB_Click);
            // 
            // wykresP
            // 
            this.wykresP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.Name = "ChartArea1";
            this.wykresP.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.wykresP.Legends.Add(legend5);
            this.wykresP.Location = new System.Drawing.Point(3, 131);
            this.wykresP.Name = "wykresP";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.wykresP.Series.Add(series5);
            this.wykresP.Size = new System.Drawing.Size(794, 316);
            this.wykresP.TabIndex = 0;
            this.wykresP.Text = "Wykres";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelWykresu);
            this.Controls.Add(this.panelPowitania);
            this.Name = "Form1";
            this.Text = "Czytacz Logów";
            this.panelPowitania.ResumeLayout(false);
            this.panelPowitania.PerformLayout();
            this.panelWykresu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wykresP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPowitania;
        private System.Windows.Forms.Label labelPowitania;
        private System.Windows.Forms.Button buttonWybraniaLogow;
        private System.Windows.Forms.Panel panelWykresu;
        private System.Windows.Forms.DataVisualization.Charting.Chart wykresP;
        private System.Windows.Forms.Button dodajPrzejazdB;
        private System.Windows.Forms.ComboBox linieCB;
        private System.Windows.Forms.Button usunPrzejazdB;
        private System.Windows.Forms.ComboBox usunPrzejazdCB;
        private System.Windows.Forms.Button wybierzLinieB;
        private System.Windows.Forms.ComboBox dodajPrzejazdCB;
        private System.Windows.Forms.Button powrotB;
        private System.Windows.Forms.Button usunWszystkiePrzejazdyB;
        private System.Windows.Forms.Button dodajWszystkiePrzejazdyB;
    }
}

