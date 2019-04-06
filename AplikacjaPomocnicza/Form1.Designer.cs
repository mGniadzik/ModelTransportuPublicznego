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
            this.bPrzejazdy = new System.Windows.Forms.Button();
            this.bKonfiguracjaPrzystanku = new System.Windows.Forms.Button();
            this.bPrzystanek = new System.Windows.Forms.Button();
            this.bKonfiguracjaAutobusu = new System.Windows.Forms.Button();
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
            this.bSave = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.dgHamowanie = new System.Windows.Forms.DataGridView();
            this.cProgHamowanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSpowolnienieHamowanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrzysp = new System.Windows.Forms.DataGridView();
            this.cProgPrzysp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSpowolnieniePrzysp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lPrzyspieszenieTitle = new System.Windows.Forms.Label();
            this.lHamowanieTitle = new System.Windows.Forms.Label();
            this.pPrzystanekStale = new System.Windows.Forms.Panel();
            this.bMenuPrzystanek = new System.Windows.Forms.Button();
            this.bNextPrzystanek = new System.Windows.Forms.Button();
            this.tbPojemnoscPasazerow = new System.Windows.Forms.TextBox();
            this.tbDlugoscZatoki = new System.Windows.Forms.TextBox();
            this.tbPosY = new System.Windows.Forms.TextBox();
            this.tbPosX = new System.Windows.Forms.TextBox();
            this.tbNazwaPrzystanku = new System.Windows.Forms.TextBox();
            this.lMaksymalnaIloscPas = new System.Windows.Forms.Label();
            this.lDlugoscZatoki = new System.Windows.Forms.Label();
            this.lPosY = new System.Windows.Forms.Label();
            this.lPosX = new System.Windows.Forms.Label();
            this.lNazwaPrzystanku = new System.Windows.Forms.Label();
            this.pPrzystanekProgi = new System.Windows.Forms.Panel();
            this.bZapiszDoPliku = new System.Windows.Forms.Button();
            this.bBackMenu = new System.Windows.Forms.Button();
            this.dgProgiPrzystanekAutobusy = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lPrzystanekProgiAutobusy = new System.Windows.Forms.Label();
            this.lPrzystanekProgiPasazerowie = new System.Windows.Forms.Label();
            this.lPrzystanekProgiKolory = new System.Windows.Forms.Label();
            this.dgProgiPrzystanekPasazerowie = new System.Windows.Forms.DataGridView();
            this.cProgPrzystanek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKolor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPowitanie.SuspendLayout();
            this.pAutobusStale.SuspendLayout();
            this.pZmianaPrzyspieszenia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHamowanie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrzysp)).BeginInit();
            this.pPrzystanekStale.SuspendLayout();
            this.pPrzystanekProgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProgiPrzystanekAutobusy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProgiPrzystanekPasazerowie)).BeginInit();
            this.SuspendLayout();
            // 
            // pPowitanie
            // 
            this.pPowitanie.Controls.Add(this.bPrzejazdy);
            this.pPowitanie.Controls.Add(this.bKonfiguracjaPrzystanku);
            this.pPowitanie.Controls.Add(this.bPrzystanek);
            this.pPowitanie.Controls.Add(this.bKonfiguracjaAutobusu);
            this.pPowitanie.Controls.Add(this.welcomeLabel);
            this.pPowitanie.Controls.Add(this.bAutobus);
            this.pPowitanie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPowitanie.Location = new System.Drawing.Point(0, 0);
            this.pPowitanie.Name = "pPowitanie";
            this.pPowitanie.Size = new System.Drawing.Size(784, 561);
            this.pPowitanie.TabIndex = 0;
            // 
            // bPrzejazdy
            // 
            this.bPrzejazdy.Location = new System.Drawing.Point(230, 319);
            this.bPrzejazdy.Name = "bPrzejazdy";
            this.bPrzejazdy.Size = new System.Drawing.Size(336, 50);
            this.bPrzejazdy.TabIndex = 4;
            this.bPrzejazdy.Text = "Konfiguracja przejazdów";
            this.bPrzejazdy.UseVisualStyleBackColor = true;
            // 
            // bKonfiguracjaPrzystanku
            // 
            this.bKonfiguracjaPrzystanku.Location = new System.Drawing.Point(230, 263);
            this.bKonfiguracjaPrzystanku.Name = "bKonfiguracjaPrzystanku";
            this.bKonfiguracjaPrzystanku.Size = new System.Drawing.Size(336, 50);
            this.bKonfiguracjaPrzystanku.TabIndex = 3;
            this.bKonfiguracjaPrzystanku.Text = "Konfiguracja przystanku";
            this.bKonfiguracjaPrzystanku.UseVisualStyleBackColor = true;
            this.bKonfiguracjaPrzystanku.Click += new System.EventHandler(this.BKonfiguracjaPrzystanku_Click);
            // 
            // bPrzystanek
            // 
            this.bPrzystanek.Location = new System.Drawing.Point(230, 207);
            this.bPrzystanek.Name = "bPrzystanek";
            this.bPrzystanek.Size = new System.Drawing.Size(336, 50);
            this.bPrzystanek.TabIndex = 2;
            this.bPrzystanek.Text = "Stwórz przystanek";
            this.bPrzystanek.UseVisualStyleBackColor = true;
            this.bPrzystanek.Click += new System.EventHandler(this.BPrzystanek_Click);
            // 
            // bKonfiguracjaAutobusu
            // 
            this.bKonfiguracjaAutobusu.Location = new System.Drawing.Point(230, 151);
            this.bKonfiguracjaAutobusu.Name = "bKonfiguracjaAutobusu";
            this.bKonfiguracjaAutobusu.Size = new System.Drawing.Size(336, 50);
            this.bKonfiguracjaAutobusu.TabIndex = 1;
            this.bKonfiguracjaAutobusu.Text = "Konfiguracja Autobusu";
            this.bKonfiguracjaAutobusu.UseVisualStyleBackColor = true;
            this.bKonfiguracjaAutobusu.Click += new System.EventHandler(this.BKonfiguracja_Click);
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
            this.bAutobus.Text = "Stwórz autobus";
            this.bAutobus.UseVisualStyleBackColor = true;
            this.bAutobus.Click += new System.EventHandler(this.BAutobus_Click);
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
            this.bCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // bNext
            // 
            this.bNext.Location = new System.Drawing.Point(680, 516);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(92, 33);
            this.bNext.TabIndex = 3;
            this.bNext.Text = "Dalej...";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.BNext_Click);
            // 
            // pZmianaPrzyspieszenia
            // 
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
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(680, 500);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(92, 49);
            this.bSave.TabIndex = 22;
            this.bSave.Text = "Zapisz plik...";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(12, 500);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(92, 49);
            this.bBack.TabIndex = 21;
            this.bBack.Text = "Wróć do menu";
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.BBack_Click);
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
            // pPrzystanekStale
            // 
            this.pPrzystanekStale.Controls.Add(this.bMenuPrzystanek);
            this.pPrzystanekStale.Controls.Add(this.bNextPrzystanek);
            this.pPrzystanekStale.Controls.Add(this.tbPojemnoscPasazerow);
            this.pPrzystanekStale.Controls.Add(this.tbDlugoscZatoki);
            this.pPrzystanekStale.Controls.Add(this.tbPosY);
            this.pPrzystanekStale.Controls.Add(this.tbPosX);
            this.pPrzystanekStale.Controls.Add(this.tbNazwaPrzystanku);
            this.pPrzystanekStale.Controls.Add(this.lMaksymalnaIloscPas);
            this.pPrzystanekStale.Controls.Add(this.lDlugoscZatoki);
            this.pPrzystanekStale.Controls.Add(this.lPosY);
            this.pPrzystanekStale.Controls.Add(this.lPosX);
            this.pPrzystanekStale.Controls.Add(this.lNazwaPrzystanku);
            this.pPrzystanekStale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPrzystanekStale.Location = new System.Drawing.Point(0, 0);
            this.pPrzystanekStale.Name = "pPrzystanekStale";
            this.pPrzystanekStale.Size = new System.Drawing.Size(784, 561);
            this.pPrzystanekStale.TabIndex = 18;
            this.pPrzystanekStale.Visible = false;
            // 
            // bMenuPrzystanek
            // 
            this.bMenuPrzystanek.Location = new System.Drawing.Point(12, 512);
            this.bMenuPrzystanek.Name = "bMenuPrzystanek";
            this.bMenuPrzystanek.Size = new System.Drawing.Size(75, 37);
            this.bMenuPrzystanek.TabIndex = 11;
            this.bMenuPrzystanek.Text = "Wróć do menu";
            this.bMenuPrzystanek.UseVisualStyleBackColor = true;
            this.bMenuPrzystanek.Click += new System.EventHandler(this.BMenuPrzystanek_Click);
            // 
            // bNextPrzystanek
            // 
            this.bNextPrzystanek.Location = new System.Drawing.Point(697, 513);
            this.bNextPrzystanek.Name = "bNextPrzystanek";
            this.bNextPrzystanek.Size = new System.Drawing.Size(75, 36);
            this.bNextPrzystanek.TabIndex = 10;
            this.bNextPrzystanek.Text = "Dalej...";
            this.bNextPrzystanek.UseVisualStyleBackColor = true;
            this.bNextPrzystanek.Click += new System.EventHandler(this.BNextPrzystanek_Click);
            // 
            // tbPojemnoscPasazerow
            // 
            this.tbPojemnoscPasazerow.Location = new System.Drawing.Point(215, 125);
            this.tbPojemnoscPasazerow.Name = "tbPojemnoscPasazerow";
            this.tbPojemnoscPasazerow.Size = new System.Drawing.Size(100, 20);
            this.tbPojemnoscPasazerow.TabIndex = 9;
            // 
            // tbDlugoscZatoki
            // 
            this.tbDlugoscZatoki.Location = new System.Drawing.Point(215, 96);
            this.tbDlugoscZatoki.Name = "tbDlugoscZatoki";
            this.tbDlugoscZatoki.Size = new System.Drawing.Size(100, 20);
            this.tbDlugoscZatoki.TabIndex = 8;
            // 
            // tbPosY
            // 
            this.tbPosY.Location = new System.Drawing.Point(215, 67);
            this.tbPosY.Name = "tbPosY";
            this.tbPosY.Size = new System.Drawing.Size(100, 20);
            this.tbPosY.TabIndex = 7;
            // 
            // tbPosX
            // 
            this.tbPosX.Location = new System.Drawing.Point(215, 36);
            this.tbPosX.Name = "tbPosX";
            this.tbPosX.Size = new System.Drawing.Size(100, 20);
            this.tbPosX.TabIndex = 6;
            // 
            // tbNazwaPrzystanku
            // 
            this.tbNazwaPrzystanku.Location = new System.Drawing.Point(215, 10);
            this.tbNazwaPrzystanku.Name = "tbNazwaPrzystanku";
            this.tbNazwaPrzystanku.Size = new System.Drawing.Size(100, 20);
            this.tbNazwaPrzystanku.TabIndex = 5;
            // 
            // lMaksymalnaIloscPas
            // 
            this.lMaksymalnaIloscPas.AutoSize = true;
            this.lMaksymalnaIloscPas.Location = new System.Drawing.Point(12, 125);
            this.lMaksymalnaIloscPas.Name = "lMaksymalnaIloscPas";
            this.lMaksymalnaIloscPas.Size = new System.Drawing.Size(174, 13);
            this.lMaksymalnaIloscPas.TabIndex = 4;
            this.lMaksymalnaIloscPas.Text = "Maksymalna pojemność pasażerów";
            // 
            // lDlugoscZatoki
            // 
            this.lDlugoscZatoki.AutoSize = true;
            this.lDlugoscZatoki.Location = new System.Drawing.Point(12, 99);
            this.lDlugoscZatoki.Name = "lDlugoscZatoki";
            this.lDlugoscZatoki.Size = new System.Drawing.Size(79, 13);
            this.lDlugoscZatoki.TabIndex = 3;
            this.lDlugoscZatoki.Text = "Długość zatoki";
            // 
            // lPosY
            // 
            this.lPosY.AutoSize = true;
            this.lPosY.Location = new System.Drawing.Point(12, 73);
            this.lPosY.Name = "lPosY";
            this.lPosY.Size = new System.Drawing.Size(108, 13);
            this.lPosY.TabIndex = 2;
            this.lPosY.Text = "Pozycja przystanku Y";
            // 
            // lPosX
            // 
            this.lPosX.AutoSize = true;
            this.lPosX.Location = new System.Drawing.Point(12, 47);
            this.lPosX.Name = "lPosX";
            this.lPosX.Size = new System.Drawing.Size(108, 13);
            this.lPosX.TabIndex = 1;
            this.lPosX.Text = "Pozycja przystanku X";
            // 
            // lNazwaPrzystanku
            // 
            this.lNazwaPrzystanku.AutoSize = true;
            this.lNazwaPrzystanku.Location = new System.Drawing.Point(12, 17);
            this.lNazwaPrzystanku.Name = "lNazwaPrzystanku";
            this.lNazwaPrzystanku.Size = new System.Drawing.Size(94, 13);
            this.lNazwaPrzystanku.TabIndex = 0;
            this.lNazwaPrzystanku.Text = "Nazwa przystanku";
            // 
            // pPrzystanekProgi
            // 
            this.pPrzystanekProgi.Controls.Add(this.bZapiszDoPliku);
            this.pPrzystanekProgi.Controls.Add(this.bBackMenu);
            this.pPrzystanekProgi.Controls.Add(this.dgProgiPrzystanekAutobusy);
            this.pPrzystanekProgi.Controls.Add(this.lPrzystanekProgiAutobusy);
            this.pPrzystanekProgi.Controls.Add(this.lPrzystanekProgiPasazerowie);
            this.pPrzystanekProgi.Controls.Add(this.lPrzystanekProgiKolory);
            this.pPrzystanekProgi.Controls.Add(this.dgProgiPrzystanekPasazerowie);
            this.pPrzystanekProgi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPrzystanekProgi.Location = new System.Drawing.Point(0, 0);
            this.pPrzystanekProgi.Name = "pPrzystanekProgi";
            this.pPrzystanekProgi.Size = new System.Drawing.Size(784, 561);
            this.pPrzystanekProgi.TabIndex = 19;
            this.pPrzystanekProgi.Visible = false;
            // 
            // bZapiszDoPliku
            // 
            this.bZapiszDoPliku.Location = new System.Drawing.Point(697, 514);
            this.bZapiszDoPliku.Name = "bZapiszDoPliku";
            this.bZapiszDoPliku.Size = new System.Drawing.Size(75, 37);
            this.bZapiszDoPliku.TabIndex = 26;
            this.bZapiszDoPliku.Text = "Zapisz...";
            this.bZapiszDoPliku.UseVisualStyleBackColor = true;
            this.bZapiszDoPliku.Click += new System.EventHandler(this.BZapiszDoPliku_Click);
            // 
            // bBackMenu
            // 
            this.bBackMenu.Location = new System.Drawing.Point(12, 512);
            this.bBackMenu.Name = "bBackMenu";
            this.bBackMenu.Size = new System.Drawing.Size(75, 37);
            this.bBackMenu.TabIndex = 25;
            this.bBackMenu.Text = "Wróć do menu";
            this.bBackMenu.UseVisualStyleBackColor = true;
            this.bBackMenu.Click += new System.EventHandler(this.BBackMenu_Click);
            // 
            // dgProgiPrzystanekAutobusy
            // 
            this.dgProgiPrzystanekAutobusy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProgiPrzystanekAutobusy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgProgiPrzystanekAutobusy.Location = new System.Drawing.Point(12, 290);
            this.dgProgiPrzystanekAutobusy.Name = "dgProgiPrzystanekAutobusy";
            this.dgProgiPrzystanekAutobusy.Size = new System.Drawing.Size(760, 187);
            this.dgProgiPrzystanekAutobusy.TabIndex = 24;
            this.dgProgiPrzystanekAutobusy.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.dgProgiPrzystanekAutobusy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DgProgiPrzystanekAutobusy_KeyUp);
            this.dgProgiPrzystanekAutobusy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgProgiPrzystanekAutobusy_MouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Próg zapełnienia";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Kolor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // lPrzystanekProgiAutobusy
            // 
            this.lPrzystanekProgiAutobusy.AutoSize = true;
            this.lPrzystanekProgiAutobusy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrzystanekProgiAutobusy.Location = new System.Drawing.Point(12, 263);
            this.lPrzystanekProgiAutobusy.Name = "lPrzystanekProgiAutobusy";
            this.lPrzystanekProgiAutobusy.Size = new System.Drawing.Size(89, 24);
            this.lPrzystanekProgiAutobusy.TabIndex = 23;
            this.lPrzystanekProgiAutobusy.Text = "Autobusy";
            // 
            // lPrzystanekProgiPasazerowie
            // 
            this.lPrzystanekProgiPasazerowie.AutoSize = true;
            this.lPrzystanekProgiPasazerowie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrzystanekProgiPasazerowie.Location = new System.Drawing.Point(12, 36);
            this.lPrzystanekProgiPasazerowie.Name = "lPrzystanekProgiPasazerowie";
            this.lPrzystanekProgiPasazerowie.Size = new System.Drawing.Size(117, 24);
            this.lPrzystanekProgiPasazerowie.TabIndex = 22;
            this.lPrzystanekProgiPasazerowie.Text = "Pasażerowie";
            // 
            // lPrzystanekProgiKolory
            // 
            this.lPrzystanekProgiKolory.AutoSize = true;
            this.lPrzystanekProgiKolory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrzystanekProgiKolory.Location = new System.Drawing.Point(12, 9);
            this.lPrzystanekProgiKolory.Name = "lPrzystanekProgiKolory";
            this.lPrzystanekProgiKolory.Size = new System.Drawing.Size(504, 24);
            this.lPrzystanekProgiKolory.TabIndex = 21;
            this.lPrzystanekProgiKolory.Text = "Progi oraz kolory występujące przy zapełnieniu przystanku:";
            // 
            // dgProgiPrzystanekPasazerowie
            // 
            this.dgProgiPrzystanekPasazerowie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProgiPrzystanekPasazerowie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cProgPrzystanek,
            this.cKolor});
            this.dgProgiPrzystanekPasazerowie.Location = new System.Drawing.Point(12, 63);
            this.dgProgiPrzystanekPasazerowie.Name = "dgProgiPrzystanekPasazerowie";
            this.dgProgiPrzystanekPasazerowie.Size = new System.Drawing.Size(760, 187);
            this.dgProgiPrzystanekPasazerowie.TabIndex = 20;
            this.dgProgiPrzystanekPasazerowie.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgProgiPrzystanek_CellDoubleClick);
            this.dgProgiPrzystanekPasazerowie.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DgProgiPrzystanekPasazerowie_KeyUp);
            this.dgProgiPrzystanekPasazerowie.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgProgiPrzystanekPasazerowie_MouseClick);
            // 
            // cProgPrzystanek
            // 
            this.cProgPrzystanek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cProgPrzystanek.HeaderText = "Próg zapełnienia";
            this.cProgPrzystanek.Name = "cProgPrzystanek";
            // 
            // cKolor
            // 
            this.cKolor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cKolor.HeaderText = "Kolor";
            this.cKolor.Name = "cKolor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pPrzystanekStale);
            this.Controls.Add(this.pPowitanie);
            this.Controls.Add(this.pZmianaPrzyspieszenia);
            this.Controls.Add(this.pAutobusStale);
            this.Controls.Add(this.pPrzystanekProgi);
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
            this.pPrzystanekStale.ResumeLayout(false);
            this.pPrzystanekStale.PerformLayout();
            this.pPrzystanekProgi.ResumeLayout(false);
            this.pPrzystanekProgi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProgiPrzystanekAutobusy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProgiPrzystanekPasazerowie)).EndInit();
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
        private System.Windows.Forms.Button bKonfiguracjaAutobusu;
        private System.Windows.Forms.Button bPrzejazdy;
        private System.Windows.Forms.Button bKonfiguracjaPrzystanku;
        private System.Windows.Forms.Button bPrzystanek;
        private System.Windows.Forms.Panel pPrzystanekStale;
        private System.Windows.Forms.Button bMenuPrzystanek;
        private System.Windows.Forms.Button bNextPrzystanek;
        private System.Windows.Forms.TextBox tbPojemnoscPasazerow;
        private System.Windows.Forms.TextBox tbDlugoscZatoki;
        private System.Windows.Forms.TextBox tbPosY;
        private System.Windows.Forms.TextBox tbPosX;
        private System.Windows.Forms.TextBox tbNazwaPrzystanku;
        private System.Windows.Forms.Label lMaksymalnaIloscPas;
        private System.Windows.Forms.Label lDlugoscZatoki;
        private System.Windows.Forms.Label lPosY;
        private System.Windows.Forms.Label lPosX;
        private System.Windows.Forms.Label lNazwaPrzystanku;
        private System.Windows.Forms.Panel pPrzystanekProgi;
        private System.Windows.Forms.DataGridView dgProgiPrzystanekPasazerowie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProgPrzystanek;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKolor;
        private System.Windows.Forms.Label lPrzystanekProgiKolory;
        private System.Windows.Forms.Button bZapiszDoPliku;
        private System.Windows.Forms.Button bBackMenu;
        private System.Windows.Forms.DataGridView dgProgiPrzystanekAutobusy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lPrzystanekProgiAutobusy;
        private System.Windows.Forms.Label lPrzystanekProgiPasazerowie;
    }
}

