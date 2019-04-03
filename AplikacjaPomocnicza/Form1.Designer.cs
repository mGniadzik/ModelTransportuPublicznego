namespace AplikacjaPomocnicza
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
            this.pPowitanie = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.bAutobus = new System.Windows.Forms.Button();
            this.pAutobusStale = new System.Windows.Forms.Panel();
            this.tbVMax = new System.Windows.Forms.TextBox();
            this.tbHamowanie = new System.Windows.Forms.TextBox();
            this.tbPrzyspieszenie = new System.Windows.Forms.TextBox();
            this.tbDlugosc = new System.Windows.Forms.TextBox();
            this.tbDrzwi = new System.Windows.Forms.TextBox();
            this.tbPojemnosc = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.lVMax = new System.Windows.Forms.Label();
            this.lHamowanie = new System.Windows.Forms.Label();
            this.lPrzyspieszenie = new System.Windows.Forms.Label();
            this.lDlugosc = new System.Windows.Forms.Label();
            this.lIloscDrzwi = new System.Windows.Forms.Label();
            this.lPojemnosc = new System.Windows.Forms.Label();
            this.lId = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.pZmianaPrzyspieszenia = new System.Windows.Forms.Panel();
            this.lFileName = new System.Windows.Forms.Label();
            this.tbNazwaPliku = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.dgHamowanie = new System.Windows.Forms.DataGridView();
            this.dgPrzysp = new System.Windows.Forms.DataGridView();
            this.lPrzyspieszenieTitle = new System.Windows.Forms.Label();
            this.lHamowanieTitle = new System.Windows.Forms.Label();
            this.cProgPrzysp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSpowolnieniePrzysp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProgHamowanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSpowolnienieHamowanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPowitanie.SuspendLayout();
            this.pAutobusStale.SuspendLayout();
            this.pZmianaPrzyspieszenia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHamowanie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrzysp)).BeginInit();
            this.SuspendLayout();
            // 
            // pPowitanie
            // 
            this.pPowitanie.Controls.Add(this.welcomeLabel);
            this.pPowitanie.Controls.Add(this.bAutobus);
            this.pPowitanie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPowitanie.Location = new System.Drawing.Point(0, 0);
            this.pPowitanie.Name = "pPowitanie";
            this.pPowitanie.Size = new System.Drawing.Size(784, 561);
            this.pPowitanie.TabIndex = 0;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(345, 62);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(105, 13);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Proszę wybrać opcję";
            // 
            // bAutobus
            // 
            this.bAutobus.Location = new System.Drawing.Point(230, 93);
            this.bAutobus.Name = "bAutobus";
            this.bAutobus.Size = new System.Drawing.Size(336, 50);
            this.bAutobus.TabIndex = 0;
            this.bAutobus.Text = "Konfiguracja Autobusu";
            this.bAutobus.UseVisualStyleBackColor = true;
            this.bAutobus.Click += new System.EventHandler(this.bAutobus_Click);
            // 
            // pAutobusStale
            // 
            this.pAutobusStale.Controls.Add(this.tbVMax);
            this.pAutobusStale.Controls.Add(this.tbHamowanie);
            this.pAutobusStale.Controls.Add(this.tbPrzyspieszenie);
            this.pAutobusStale.Controls.Add(this.tbDlugosc);
            this.pAutobusStale.Controls.Add(this.tbDrzwi);
            this.pAutobusStale.Controls.Add(this.tbPojemnosc);
            this.pAutobusStale.Controls.Add(this.tbId);
            this.pAutobusStale.Controls.Add(this.lVMax);
            this.pAutobusStale.Controls.Add(this.lHamowanie);
            this.pAutobusStale.Controls.Add(this.lPrzyspieszenie);
            this.pAutobusStale.Controls.Add(this.lDlugosc);
            this.pAutobusStale.Controls.Add(this.lIloscDrzwi);
            this.pAutobusStale.Controls.Add(this.lPojemnosc);
            this.pAutobusStale.Controls.Add(this.lId);
            this.pAutobusStale.Controls.Add(this.bCancel);
            this.pAutobusStale.Controls.Add(this.bNext);
            this.pAutobusStale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAutobusStale.Location = new System.Drawing.Point(0, 0);
            this.pAutobusStale.Name = "pAutobusStale";
            this.pAutobusStale.Size = new System.Drawing.Size(784, 561);
            this.pAutobusStale.TabIndex = 3;
            this.pAutobusStale.Visible = false;
            // 
            // tbVMax
            // 
            this.tbVMax.Location = new System.Drawing.Point(174, 174);
            this.tbVMax.Name = "tbVMax";
            this.tbVMax.Size = new System.Drawing.Size(100, 20);
            this.tbVMax.TabIndex = 16;
            // 
            // tbHamowanie
            // 
            this.tbHamowanie.Location = new System.Drawing.Point(174, 148);
            this.tbHamowanie.Name = "tbHamowanie";
            this.tbHamowanie.Size = new System.Drawing.Size(100, 20);
            this.tbHamowanie.TabIndex = 15;
            // 
            // tbPrzyspieszenie
            // 
            this.tbPrzyspieszenie.Location = new System.Drawing.Point(174, 122);
            this.tbPrzyspieszenie.Name = "tbPrzyspieszenie";
            this.tbPrzyspieszenie.Size = new System.Drawing.Size(100, 20);
            this.tbPrzyspieszenie.TabIndex = 14;
            // 
            // tbDlugosc
            // 
            this.tbDlugosc.Location = new System.Drawing.Point(174, 96);
            this.tbDlugosc.Name = "tbDlugosc";
            this.tbDlugosc.Size = new System.Drawing.Size(100, 20);
            this.tbDlugosc.TabIndex = 13;
            // 
            // tbDrzwi
            // 
            this.tbDrzwi.Location = new System.Drawing.Point(174, 70);
            this.tbDrzwi.Name = "tbDrzwi";
            this.tbDrzwi.Size = new System.Drawing.Size(100, 20);
            this.tbDrzwi.TabIndex = 12;
            // 
            // tbPojemnosc
            // 
            this.tbPojemnosc.Location = new System.Drawing.Point(174, 44);
            this.tbPojemnosc.Name = "tbPojemnosc";
            this.tbPojemnosc.Size = new System.Drawing.Size(100, 20);
            this.tbPojemnosc.TabIndex = 11;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(174, 18);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(100, 20);
            this.tbId.TabIndex = 10;
            // 
            // lVMax
            // 
            this.lVMax.AutoSize = true;
            this.lVMax.Location = new System.Drawing.Point(12, 177);
            this.lVMax.Name = "lVMax";
            this.lVMax.Size = new System.Drawing.Size(113, 13);
            this.lVMax.TabIndex = 9;
            this.lVMax.Text = "Prędkość maksymalna";
            // 
            // lHamowanie
            // 
            this.lHamowanie.AutoSize = true;
            this.lHamowanie.Location = new System.Drawing.Point(12, 151);
            this.lHamowanie.Name = "lHamowanie";
            this.lHamowanie.Size = new System.Drawing.Size(156, 13);
            this.lHamowanie.TabIndex = 8;
            this.lHamowanie.Text = "Droga hamowania ze 100 km/h";
            // 
            // lPrzyspieszenie
            // 
            this.lPrzyspieszenie.AutoSize = true;
            this.lPrzyspieszenie.Location = new System.Drawing.Point(12, 125);
            this.lPrzyspieszenie.Name = "lPrzyspieszenie";
            this.lPrzyspieszenie.Size = new System.Drawing.Size(120, 13);
            this.lPrzyspieszenie.TabIndex = 7;
            this.lPrzyspieszenie.Text = "Przyspieszenie 0-100 [s]";
            // 
            // lDlugosc
            // 
            this.lDlugosc.AutoSize = true;
            this.lDlugosc.Location = new System.Drawing.Point(12, 99);
            this.lDlugosc.Name = "lDlugosc";
            this.lDlugosc.Size = new System.Drawing.Size(95, 13);
            this.lDlugosc.TabIndex = 6;
            this.lDlugosc.Text = "Długość autobusu";
            // 
            // lIloscDrzwi
            // 
            this.lIloscDrzwi.AutoSize = true;
            this.lIloscDrzwi.Location = new System.Drawing.Point(12, 73);
            this.lIloscDrzwi.Name = "lIloscDrzwi";
            this.lIloscDrzwi.Size = new System.Drawing.Size(56, 13);
            this.lIloscDrzwi.TabIndex = 5;
            this.lIloscDrzwi.Text = "Ilość drzwi";
            // 
            // lPojemnosc
            // 
            this.lPojemnosc.AutoSize = true;
            this.lPojemnosc.Location = new System.Drawing.Point(12, 47);
            this.lPojemnosc.Name = "lPojemnosc";
            this.lPojemnosc.Size = new System.Drawing.Size(120, 13);
            this.lPojemnosc.TabIndex = 3;
            this.lPojemnosc.Text = "Maksymalna pojemność";
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Location = new System.Drawing.Point(12, 21);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(64, 13);
            this.lId.TabIndex = 4;
            this.lId.Text = "Id Autobusu";
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(12, 516);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(92, 33);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Wróć do menu";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bNext
            // 
            this.bNext.Location = new System.Drawing.Point(680, 516);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(92, 33);
            this.bNext.TabIndex = 3;
            this.bNext.Text = "Dalej...";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // pZmianaPrzyspieszenia
            // 
            this.pZmianaPrzyspieszenia.Controls.Add(this.lFileName);
            this.pZmianaPrzyspieszenia.Controls.Add(this.tbNazwaPliku);
            this.pZmianaPrzyspieszenia.Controls.Add(this.bSave);
            this.pZmianaPrzyspieszenia.Controls.Add(this.bBack);
            this.pZmianaPrzyspieszenia.Controls.Add(this.dgHamowanie);
            this.pZmianaPrzyspieszenia.Controls.Add(this.dgPrzysp);
            this.pZmianaPrzyspieszenia.Controls.Add(this.lPrzyspieszenieTitle);
            this.pZmianaPrzyspieszenia.Controls.Add(this.lHamowanieTitle);
            this.pZmianaPrzyspieszenia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pZmianaPrzyspieszenia.Location = new System.Drawing.Point(0, 0);
            this.pZmianaPrzyspieszenia.Name = "pZmianaPrzyspieszenia";
            this.pZmianaPrzyspieszenia.Size = new System.Drawing.Size(784, 561);
            this.pZmianaPrzyspieszenia.TabIndex = 17;
            this.pZmianaPrzyspieszenia.Visible = false;
            // 
            // lFileName
            // 
            this.lFileName.AutoSize = true;
            this.lFileName.Location = new System.Drawing.Point(470, 507);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(96, 13);
            this.lFileName.TabIndex = 24;
            this.lFileName.Text = "Podaj nazwę pliku:";
            // 
            // tbNazwaPliku
            // 
            this.tbNazwaPliku.Location = new System.Drawing.Point(473, 523);
            this.tbNazwaPliku.Name = "tbNazwaPliku";
            this.tbNazwaPliku.Size = new System.Drawing.Size(201, 20);
            this.tbNazwaPliku.TabIndex = 23;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(680, 500);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(92, 49);
            this.bSave.TabIndex = 22;
            this.bSave.Text = "Zapisz plik...";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(12, 500);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(92, 49);
            this.bBack.TabIndex = 21;
            this.bBack.Text = "Wróć do menu";
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // dgHamowanie
            // 
            this.dgHamowanie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHamowanie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cProgHamowanie,
            this.cSpowolnienieHamowanie});
            this.dgHamowanie.Location = new System.Drawing.Point(12, 280);
            this.dgHamowanie.Name = "dgHamowanie";
            this.dgHamowanie.Size = new System.Drawing.Size(760, 214);
            this.dgHamowanie.TabIndex = 20;
            // 
            // dgPrzysp
            // 
            this.dgPrzysp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrzysp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cProgPrzysp,
            this.cSpowolnieniePrzysp});
            this.dgPrzysp.Location = new System.Drawing.Point(12, 36);
            this.dgPrzysp.Name = "dgPrzysp";
            this.dgPrzysp.Size = new System.Drawing.Size(760, 214);
            this.dgPrzysp.TabIndex = 19;
            // 
            // lPrzyspieszenieTitle
            // 
            this.lPrzyspieszenieTitle.AutoSize = true;
            this.lPrzyspieszenieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrzyspieszenieTitle.Location = new System.Drawing.Point(32, 9);
            this.lPrzyspieszenieTitle.Name = "lPrzyspieszenieTitle";
            this.lPrzyspieszenieTitle.Size = new System.Drawing.Size(136, 24);
            this.lPrzyspieszenieTitle.TabIndex = 17;
            this.lPrzyspieszenieTitle.Text = "Przyspieszenie";
            // 
            // lHamowanieTitle
            // 
            this.lHamowanieTitle.AutoSize = true;
            this.lHamowanieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lHamowanieTitle.Location = new System.Drawing.Point(32, 253);
            this.lHamowanieTitle.Name = "lHamowanieTitle";
            this.lHamowanieTitle.Size = new System.Drawing.Size(111, 24);
            this.lHamowanieTitle.TabIndex = 18;
            this.lHamowanieTitle.Text = "Hamowanie";
            // 
            // cProgPrzysp
            // 
            this.cProgPrzysp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cProgPrzysp.HeaderText = "Próg zapełnienia";
            this.cProgPrzysp.Name = "cProgPrzysp";
            // 
            // cSpowolnieniePrzysp
            // 
            this.cSpowolnieniePrzysp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cSpowolnieniePrzysp.HeaderText = "Procent spowolnienia";
            this.cSpowolnieniePrzysp.Name = "cSpowolnieniePrzysp";
            // 
            // cProgHamowanie
            // 
            this.cProgHamowanie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cProgHamowanie.HeaderText = "Próg zapełnienia";
            this.cProgHamowanie.Name = "cProgHamowanie";
            // 
            // cSpowolnienieHamowanie
            // 
            this.cSpowolnienieHamowanie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cSpowolnienieHamowanie.HeaderText = "Procent wydłużenia";
            this.cSpowolnienieHamowanie.Name = "cSpowolnienieHamowanie";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pAutobusStale);
            this.Controls.Add(this.pPowitanie);
            this.Controls.Add(this.pZmianaPrzyspieszenia);
            this.Name = "Form1";
            this.Text = "Aplikacja pomocnicza";
            this.pPowitanie.ResumeLayout(false);
            this.pPowitanie.PerformLayout();
            this.pAutobusStale.ResumeLayout(false);
            this.pAutobusStale.PerformLayout();
            this.pZmianaPrzyspieszenia.ResumeLayout(false);
            this.pZmianaPrzyspieszenia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHamowanie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrzysp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pPowitanie;
        private System.Windows.Forms.Button bAutobus;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel pAutobusStale;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.TextBox tbVMax;
        private System.Windows.Forms.TextBox tbHamowanie;
        private System.Windows.Forms.TextBox tbPrzyspieszenie;
        private System.Windows.Forms.TextBox tbDlugosc;
        private System.Windows.Forms.TextBox tbDrzwi;
        private System.Windows.Forms.TextBox tbPojemnosc;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label lVMax;
        private System.Windows.Forms.Label lHamowanie;
        private System.Windows.Forms.Label lPrzyspieszenie;
        private System.Windows.Forms.Label lDlugosc;
        private System.Windows.Forms.Label lIloscDrzwi;
        private System.Windows.Forms.Label lPojemnosc;
        private System.Windows.Forms.Label lId;
        private System.Windows.Forms.Panel pZmianaPrzyspieszenia;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.TextBox tbNazwaPliku;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.DataGridView dgHamowanie;
        private System.Windows.Forms.DataGridView dgPrzysp;
        private System.Windows.Forms.Label lPrzyspieszenieTitle;
        private System.Windows.Forms.Label lHamowanieTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProgPrzysp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSpowolnieniePrzysp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProgHamowanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSpowolnienieHamowanie;
    }
}

