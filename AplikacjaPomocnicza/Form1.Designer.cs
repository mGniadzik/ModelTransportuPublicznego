namespace AplikacjaPomocnicza
{
    partial class AplikacjaPomocnicza
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
            this.bFirma = new System.Windows.Forms.Button();
            this.bLinia = new System.Windows.Forms.Button();
            this.bPrzejazdy = new System.Windows.Forms.Button();
            this.bPrzystanek = new System.Windows.Forms.Button();
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
            this.msAutobus = new System.Windows.Forms.MenuStrip();
            this.msAutobusPlik = new System.Windows.Forms.ToolStripMenuItem();
            this.msAutobusZapisz = new System.Windows.Forms.ToolStripMenuItem();
            this.msAutobusZapiszJako = new System.Windows.Forms.ToolStripMenuItem();
            this.msAutobusWczytaj = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pPrzejazdy = new System.Windows.Forms.Panel();
            this.pPrzejazdyDane = new System.Windows.Forms.Panel();
            this.BPrzejazdDalej = new System.Windows.Forms.Button();
            this.BPrzejazdMenu = new System.Windows.Forms.Button();
            this.lPrzyplywyPasazerow = new System.Windows.Forms.Label();
            this.tbPrzyplywyPasazerow = new System.Windows.Forms.TextBox();
            this.tbMapaTerenu = new System.Windows.Forms.TextBox();
            this.lMapaTerenu = new System.Windows.Forms.Label();
            this.pPrzejazdyUstawianie = new System.Windows.Forms.Panel();
            this.dgPrzejazdy = new System.Windows.Forms.DataGridView();
            this.cPrzejazdCzas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrzejazdFirma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrzejazdLinia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrzejazdAutobus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lPrzejazdTytul = new System.Windows.Forms.Label();
            this.BMenu = new System.Windows.Forms.Button();
            this.msPrzejazdy = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszJakoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pAutobus = new System.Windows.Forms.Panel();
            this.pPrzystanek = new System.Windows.Forms.Panel();
            this.msPrzystanek = new System.Windows.Forms.MenuStrip();
            this.msPrzystanekPlik = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrzystanekZapisz = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrzystanekZapiszJako = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrzystanekWczytaj = new System.Windows.Forms.ToolStripMenuItem();
            this.pFirma = new System.Windows.Forms.Panel();
            this.msFirma = new System.Windows.Forms.MenuStrip();
            this.msFirmaPlik = new System.Windows.Forms.ToolStripMenuItem();
            this.msFirmaPlikZapisz = new System.Windows.Forms.ToolStripMenuItem();
            this.msFirmaPlikZapiszJako = new System.Windows.Forms.ToolStripMenuItem();
            this.msFirmaPlikWczytaj = new System.Windows.Forms.ToolStripMenuItem();
            this.pFirmaStaleLinie = new System.Windows.Forms.Panel();
            this.dgFirmaLinia = new System.Windows.Forms.DataGridView();
            this.cIDLinii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSciezkaPliku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tbFirmaKierowcy = new System.Windows.Forms.TextBox();
            this.bFirmaStaleMenu = new System.Windows.Forms.Button();
            this.tbFirmaNazwa = new System.Windows.Forms.TextBox();
            this.lFirmaKierowcy = new System.Windows.Forms.Label();
            this.lFirmaNazwa = new System.Windows.Forms.Label();
            this.lFirmaStaleTytul = new System.Windows.Forms.Label();
            this.pFirmaTabor = new System.Windows.Forms.Panel();
            this.bFirmaZapisz = new System.Windows.Forms.Button();
            this.bFirmaTaborMenu = new System.Windows.Forms.Button();
            this.dgFirmaTabor = new System.Windows.Forms.DataGridView();
            this.cFirmaTaborSciezkaPliku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFirmaTaborLiczba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lFirmaTaborTytul = new System.Windows.Forms.Label();
            this.pLinia = new System.Windows.Forms.Panel();
            this.msLinia = new System.Windows.Forms.MenuStrip();
            this.msLiniaPlik = new System.Windows.Forms.ToolStripMenuItem();
            this.msLiniaPlikZapisz = new System.Windows.Forms.ToolStripMenuItem();
            this.msLiniaPlikZapiszJako = new System.Windows.Forms.ToolStripMenuItem();
            this.msLiniaPlikWczytaj = new System.Windows.Forms.ToolStripMenuItem();
            this.pLiniaDane = new System.Windows.Forms.Panel();
            this.bLiniaZapisz = new System.Windows.Forms.Button();
            this.bLiniaMenu = new System.Windows.Forms.Button();
            this.dgLiniaDane = new System.Windows.Forms.DataGridView();
            this.cNazwaPrzystanku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLiniaPrzystanek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCzasDojazdu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbLiniaId = new System.Windows.Forms.TextBox();
            this.bLiniaId = new System.Windows.Forms.Label();
            this.bLiniaTytul = new System.Windows.Forms.Label();
            this.pPowitanie.SuspendLayout();
            this.pAutobusStale.SuspendLayout();
            this.msAutobus.SuspendLayout();
            this.pZmianaPrzyspieszenia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHamowanie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrzysp)).BeginInit();
            this.pPrzystanekStale.SuspendLayout();
            this.pPrzystanekProgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProgiPrzystanekAutobusy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProgiPrzystanekPasazerowie)).BeginInit();
            this.pPrzejazdy.SuspendLayout();
            this.pPrzejazdyDane.SuspendLayout();
            this.pPrzejazdyUstawianie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrzejazdy)).BeginInit();
            this.msPrzejazdy.SuspendLayout();
            this.pAutobus.SuspendLayout();
            this.pPrzystanek.SuspendLayout();
            this.msPrzystanek.SuspendLayout();
            this.pFirma.SuspendLayout();
            this.msFirma.SuspendLayout();
            this.pFirmaStaleLinie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFirmaLinia)).BeginInit();
            this.pFirmaTabor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFirmaTabor)).BeginInit();
            this.pLinia.SuspendLayout();
            this.msLinia.SuspendLayout();
            this.pLiniaDane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLiniaDane)).BeginInit();
            this.SuspendLayout();
            // 
            // pPowitanie
            // 
            this.pPowitanie.Controls.Add(this.bFirma);
            this.pPowitanie.Controls.Add(this.bLinia);
            this.pPowitanie.Controls.Add(this.bPrzejazdy);
            this.pPowitanie.Controls.Add(this.bPrzystanek);
            this.pPowitanie.Controls.Add(this.welcomeLabel);
            this.pPowitanie.Controls.Add(this.bAutobus);
            this.pPowitanie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPowitanie.Location = new System.Drawing.Point(0, 0);
            this.pPowitanie.Name = "pPowitanie";
            this.pPowitanie.Size = new System.Drawing.Size(784, 561);
            this.pPowitanie.TabIndex = 0;
            // 
            // bFirma
            // 
            this.bFirma.Location = new System.Drawing.Point(230, 261);
            this.bFirma.Name = "bFirma";
            this.bFirma.Size = new System.Drawing.Size(336, 50);
            this.bFirma.TabIndex = 6;
            this.bFirma.Text = "Stwórz firmę";
            this.bFirma.UseVisualStyleBackColor = true;
            this.bFirma.Click += new System.EventHandler(this.BFirma_Click);
            // 
            // bLinia
            // 
            this.bLinia.Location = new System.Drawing.Point(230, 205);
            this.bLinia.Name = "bLinia";
            this.bLinia.Size = new System.Drawing.Size(336, 50);
            this.bLinia.TabIndex = 5;
            this.bLinia.Text = "Stwórz linię";
            this.bLinia.UseVisualStyleBackColor = true;
            this.bLinia.Click += new System.EventHandler(this.BLinia_Click);
            // 
            // bPrzejazdy
            // 
            this.bPrzejazdy.Location = new System.Drawing.Point(230, 317);
            this.bPrzejazdy.Name = "bPrzejazdy";
            this.bPrzejazdy.Size = new System.Drawing.Size(336, 50);
            this.bPrzejazdy.TabIndex = 4;
            this.bPrzejazdy.Text = "Konfiguracja przejazdów";
            this.bPrzejazdy.UseVisualStyleBackColor = true;
            this.bPrzejazdy.Click += new System.EventHandler(this.BPrzejazdy_Click);
            // 
            // bPrzystanek
            // 
            this.bPrzystanek.Location = new System.Drawing.Point(230, 149);
            this.bPrzystanek.Name = "bPrzystanek";
            this.bPrzystanek.Size = new System.Drawing.Size(336, 50);
            this.bPrzystanek.TabIndex = 2;
            this.bPrzystanek.Text = "Stwórz przystanek";
            this.bPrzystanek.UseVisualStyleBackColor = true;
            this.bPrzystanek.Click += new System.EventHandler(this.BPrzystanek_Click);
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
            this.tbVMax.Location = new System.Drawing.Point(174, 185);
            this.tbVMax.Name = "tbVMax";
            this.tbVMax.Size = new System.Drawing.Size(100, 20);
            this.tbVMax.TabIndex = 16;
            // 
            // tbHamowanie
            // 
            this.tbHamowanie.Location = new System.Drawing.Point(174, 161);
            this.tbHamowanie.Name = "tbHamowanie";
            this.tbHamowanie.Size = new System.Drawing.Size(100, 20);
            this.tbHamowanie.TabIndex = 15;
            // 
            // tbPrzyspieszenie
            // 
            this.tbPrzyspieszenie.Location = new System.Drawing.Point(174, 135);
            this.tbPrzyspieszenie.Name = "tbPrzyspieszenie";
            this.tbPrzyspieszenie.Size = new System.Drawing.Size(100, 20);
            this.tbPrzyspieszenie.TabIndex = 14;
            // 
            // tbDlugosc
            // 
            this.tbDlugosc.Location = new System.Drawing.Point(174, 109);
            this.tbDlugosc.Name = "tbDlugosc";
            this.tbDlugosc.Size = new System.Drawing.Size(100, 20);
            this.tbDlugosc.TabIndex = 13;
            // 
            // tbDrzwi
            // 
            this.tbDrzwi.Location = new System.Drawing.Point(174, 83);
            this.tbDrzwi.Name = "tbDrzwi";
            this.tbDrzwi.Size = new System.Drawing.Size(100, 20);
            this.tbDrzwi.TabIndex = 12;
            // 
            // tbPojemnosc
            // 
            this.tbPojemnosc.Location = new System.Drawing.Point(174, 57);
            this.tbPojemnosc.Name = "tbPojemnosc";
            this.tbPojemnosc.Size = new System.Drawing.Size(100, 20);
            this.tbPojemnosc.TabIndex = 11;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(174, 28);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(100, 20);
            this.tbId.TabIndex = 10;
            // 
            // lVMax
            // 
            this.lVMax.AutoSize = true;
            this.lVMax.Location = new System.Drawing.Point(12, 188);
            this.lVMax.Name = "lVMax";
            this.lVMax.Size = new System.Drawing.Size(113, 13);
            this.lVMax.TabIndex = 9;
            this.lVMax.Text = "Prędkość maksymalna";
            // 
            // lHamowanie
            // 
            this.lHamowanie.AutoSize = true;
            this.lHamowanie.Location = new System.Drawing.Point(9, 164);
            this.lHamowanie.Name = "lHamowanie";
            this.lHamowanie.Size = new System.Drawing.Size(156, 13);
            this.lHamowanie.TabIndex = 8;
            this.lHamowanie.Text = "Droga hamowania ze 100 km/h";
            // 
            // lPrzyspieszenie
            // 
            this.lPrzyspieszenie.AutoSize = true;
            this.lPrzyspieszenie.Location = new System.Drawing.Point(9, 138);
            this.lPrzyspieszenie.Name = "lPrzyspieszenie";
            this.lPrzyspieszenie.Size = new System.Drawing.Size(120, 13);
            this.lPrzyspieszenie.TabIndex = 7;
            this.lPrzyspieszenie.Text = "Przyspieszenie 0-100 [s]";
            // 
            // lDlugosc
            // 
            this.lDlugosc.AutoSize = true;
            this.lDlugosc.Location = new System.Drawing.Point(12, 112);
            this.lDlugosc.Name = "lDlugosc";
            this.lDlugosc.Size = new System.Drawing.Size(95, 13);
            this.lDlugosc.TabIndex = 6;
            this.lDlugosc.Text = "Długość autobusu";
            // 
            // lIloscDrzwi
            // 
            this.lIloscDrzwi.AutoSize = true;
            this.lIloscDrzwi.Location = new System.Drawing.Point(12, 86);
            this.lIloscDrzwi.Name = "lIloscDrzwi";
            this.lIloscDrzwi.Size = new System.Drawing.Size(56, 13);
            this.lIloscDrzwi.TabIndex = 5;
            this.lIloscDrzwi.Text = "Ilość drzwi";
            // 
            // lPojemnosc
            // 
            this.lPojemnosc.AutoSize = true;
            this.lPojemnosc.Location = new System.Drawing.Point(12, 60);
            this.lPojemnosc.Name = "lPojemnosc";
            this.lPojemnosc.Size = new System.Drawing.Size(120, 13);
            this.lPojemnosc.TabIndex = 3;
            this.lPojemnosc.Text = "Maksymalna pojemność";
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Location = new System.Drawing.Point(12, 31);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(64, 13);
            this.lId.TabIndex = 4;
            this.lId.Text = "Id Autobusu";
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(12, 518);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(92, 33);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Wróć do menu";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // bNext
            // 
            this.bNext.Location = new System.Drawing.Point(680, 518);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(92, 33);
            this.bNext.TabIndex = 3;
            this.bNext.Text = "Dalej...";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.BNext_Click);
            // 
            // msAutobus
            // 
            this.msAutobus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msAutobusPlik});
            this.msAutobus.Location = new System.Drawing.Point(0, 0);
            this.msAutobus.Name = "msAutobus";
            this.msAutobus.Size = new System.Drawing.Size(784, 24);
            this.msAutobus.TabIndex = 17;
            this.msAutobus.Text = "menuStrip2";
            // 
            // msAutobusPlik
            // 
            this.msAutobusPlik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msAutobusZapisz,
            this.msAutobusZapiszJako,
            this.msAutobusWczytaj});
            this.msAutobusPlik.Name = "msAutobusPlik";
            this.msAutobusPlik.Size = new System.Drawing.Size(38, 20);
            this.msAutobusPlik.Text = "Plik";
            // 
            // msAutobusZapisz
            // 
            this.msAutobusZapisz.Enabled = false;
            this.msAutobusZapisz.Name = "msAutobusZapisz";
            this.msAutobusZapisz.Size = new System.Drawing.Size(132, 22);
            this.msAutobusZapisz.Text = "Zapisz";
            this.msAutobusZapisz.Click += new System.EventHandler(this.MsAutobusZapisz_Click);
            // 
            // msAutobusZapiszJako
            // 
            this.msAutobusZapiszJako.Enabled = false;
            this.msAutobusZapiszJako.Name = "msAutobusZapiszJako";
            this.msAutobusZapiszJako.Size = new System.Drawing.Size(132, 22);
            this.msAutobusZapiszJako.Text = "Zapisz jako";
            this.msAutobusZapiszJako.Click += new System.EventHandler(this.MsAutobusZapiszJako_Click);
            // 
            // msAutobusWczytaj
            // 
            this.msAutobusWczytaj.Name = "msAutobusWczytaj";
            this.msAutobusWczytaj.Size = new System.Drawing.Size(132, 22);
            this.msAutobusWczytaj.Text = "Wczytaj ";
            this.msAutobusWczytaj.Click += new System.EventHandler(this.MsAutobusWczytaj_Click);
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
            this.bSave.Location = new System.Drawing.Point(697, 510);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 39);
            this.bSave.TabIndex = 22;
            this.bSave.Text = "Zapisz plik...";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(12, 512);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(75, 37);
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
            this.dgHamowanie.Location = new System.Drawing.Point(12, 290);
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
            this.dgPrzysp.Location = new System.Drawing.Point(12, 47);
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
            this.lPrzyspieszenieTitle.Location = new System.Drawing.Point(11, 20);
            this.lPrzyspieszenieTitle.Name = "lPrzyspieszenieTitle";
            this.lPrzyspieszenieTitle.Size = new System.Drawing.Size(136, 24);
            this.lPrzyspieszenieTitle.TabIndex = 17;
            this.lPrzyspieszenieTitle.Text = "Przyspieszenie";
            // 
            // lHamowanieTitle
            // 
            this.lHamowanieTitle.AutoSize = true;
            this.lHamowanieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lHamowanieTitle.Location = new System.Drawing.Point(11, 263);
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
            this.pPrzystanekStale.Location = new System.Drawing.Point(0, 24);
            this.pPrzystanekStale.Name = "pPrzystanekStale";
            this.pPrzystanekStale.Size = new System.Drawing.Size(784, 537);
            this.pPrzystanekStale.TabIndex = 18;
            this.pPrzystanekStale.Visible = false;
            // 
            // bMenuPrzystanek
            // 
            this.bMenuPrzystanek.Location = new System.Drawing.Point(12, 488);
            this.bMenuPrzystanek.Name = "bMenuPrzystanek";
            this.bMenuPrzystanek.Size = new System.Drawing.Size(75, 37);
            this.bMenuPrzystanek.TabIndex = 11;
            this.bMenuPrzystanek.Text = "Wróć do menu";
            this.bMenuPrzystanek.UseVisualStyleBackColor = true;
            this.bMenuPrzystanek.Click += new System.EventHandler(this.BMenuPrzystanek_Click);
            // 
            // bNextPrzystanek
            // 
            this.bNextPrzystanek.Location = new System.Drawing.Point(697, 488);
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
            this.pPrzystanekProgi.Location = new System.Drawing.Point(0, 24);
            this.pPrzystanekProgi.Name = "pPrzystanekProgi";
            this.pPrzystanekProgi.Size = new System.Drawing.Size(784, 537);
            this.pPrzystanekProgi.TabIndex = 19;
            this.pPrzystanekProgi.Visible = false;
            // 
            // bZapiszDoPliku
            // 
            this.bZapiszDoPliku.Location = new System.Drawing.Point(697, 492);
            this.bZapiszDoPliku.Name = "bZapiszDoPliku";
            this.bZapiszDoPliku.Size = new System.Drawing.Size(75, 37);
            this.bZapiszDoPliku.TabIndex = 26;
            this.bZapiszDoPliku.Text = "Zapisz...";
            this.bZapiszDoPliku.UseVisualStyleBackColor = true;
            this.bZapiszDoPliku.Click += new System.EventHandler(this.BZapiszDoPliku_Click);
            // 
            // bBackMenu
            // 
            this.bBackMenu.Location = new System.Drawing.Point(12, 490);
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
            // pPrzejazdy
            // 
            this.pPrzejazdy.Controls.Add(this.pPrzejazdyDane);
            this.pPrzejazdy.Controls.Add(this.pPrzejazdyUstawianie);
            this.pPrzejazdy.Controls.Add(this.msPrzejazdy);
            this.pPrzejazdy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPrzejazdy.Location = new System.Drawing.Point(0, 0);
            this.pPrzejazdy.Name = "pPrzejazdy";
            this.pPrzejazdy.Size = new System.Drawing.Size(784, 561);
            this.pPrzejazdy.TabIndex = 20;
            this.pPrzejazdy.Visible = false;
            // 
            // pPrzejazdyDane
            // 
            this.pPrzejazdyDane.Controls.Add(this.BPrzejazdDalej);
            this.pPrzejazdyDane.Controls.Add(this.BPrzejazdMenu);
            this.pPrzejazdyDane.Controls.Add(this.lPrzyplywyPasazerow);
            this.pPrzejazdyDane.Controls.Add(this.tbPrzyplywyPasazerow);
            this.pPrzejazdyDane.Controls.Add(this.tbMapaTerenu);
            this.pPrzejazdyDane.Controls.Add(this.lMapaTerenu);
            this.pPrzejazdyDane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPrzejazdyDane.Location = new System.Drawing.Point(0, 24);
            this.pPrzejazdyDane.Name = "pPrzejazdyDane";
            this.pPrzejazdyDane.Size = new System.Drawing.Size(784, 537);
            this.pPrzejazdyDane.TabIndex = 6;
            // 
            // BPrzejazdDalej
            // 
            this.BPrzejazdDalej.Location = new System.Drawing.Point(697, 486);
            this.BPrzejazdDalej.Name = "BPrzejazdDalej";
            this.BPrzejazdDalej.Size = new System.Drawing.Size(75, 39);
            this.BPrzejazdDalej.TabIndex = 5;
            this.BPrzejazdDalej.Text = "Dalej...";
            this.BPrzejazdDalej.UseVisualStyleBackColor = true;
            this.BPrzejazdDalej.Click += new System.EventHandler(this.BPrzejazdDalej_Click);
            // 
            // BPrzejazdMenu
            // 
            this.BPrzejazdMenu.Location = new System.Drawing.Point(9, 487);
            this.BPrzejazdMenu.Name = "BPrzejazdMenu";
            this.BPrzejazdMenu.Size = new System.Drawing.Size(75, 38);
            this.BPrzejazdMenu.TabIndex = 4;
            this.BPrzejazdMenu.Text = "Wróć do menu";
            this.BPrzejazdMenu.UseVisualStyleBackColor = true;
            // 
            // lPrzyplywyPasazerow
            // 
            this.lPrzyplywyPasazerow.AutoSize = true;
            this.lPrzyplywyPasazerow.Location = new System.Drawing.Point(13, 49);
            this.lPrzyplywyPasazerow.Name = "lPrzyplywyPasazerow";
            this.lPrzyplywyPasazerow.Size = new System.Drawing.Size(109, 13);
            this.lPrzyplywyPasazerow.TabIndex = 3;
            this.lPrzyplywyPasazerow.Text = "Przypływy pasażerów";
            // 
            // tbPrzyplywyPasazerow
            // 
            this.tbPrzyplywyPasazerow.Location = new System.Drawing.Point(126, 44);
            this.tbPrzyplywyPasazerow.Name = "tbPrzyplywyPasazerow";
            this.tbPrzyplywyPasazerow.Size = new System.Drawing.Size(100, 20);
            this.tbPrzyplywyPasazerow.TabIndex = 2;
            // 
            // tbMapaTerenu
            // 
            this.tbMapaTerenu.Location = new System.Drawing.Point(126, 10);
            this.tbMapaTerenu.Name = "tbMapaTerenu";
            this.tbMapaTerenu.Size = new System.Drawing.Size(100, 20);
            this.tbMapaTerenu.TabIndex = 1;
            // 
            // lMapaTerenu
            // 
            this.lMapaTerenu.AutoSize = true;
            this.lMapaTerenu.Location = new System.Drawing.Point(20, 13);
            this.lMapaTerenu.Name = "lMapaTerenu";
            this.lMapaTerenu.Size = new System.Drawing.Size(67, 13);
            this.lMapaTerenu.TabIndex = 0;
            this.lMapaTerenu.Text = "Mapa terenu";
            // 
            // pPrzejazdyUstawianie
            // 
            this.pPrzejazdyUstawianie.Controls.Add(this.dgPrzejazdy);
            this.pPrzejazdyUstawianie.Controls.Add(this.lPrzejazdTytul);
            this.pPrzejazdyUstawianie.Controls.Add(this.BMenu);
            this.pPrzejazdyUstawianie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPrzejazdyUstawianie.Location = new System.Drawing.Point(0, 24);
            this.pPrzejazdyUstawianie.Name = "pPrzejazdyUstawianie";
            this.pPrzejazdyUstawianie.Size = new System.Drawing.Size(784, 537);
            this.pPrzejazdyUstawianie.TabIndex = 5;
            // 
            // dgPrzejazdy
            // 
            this.dgPrzejazdy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrzejazdy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPrzejazdCzas,
            this.cPrzejazdFirma,
            this.cPrzejazdLinia,
            this.cPrzejazdAutobus});
            this.dgPrzejazdy.Location = new System.Drawing.Point(15, 31);
            this.dgPrzejazdy.Name = "dgPrzejazdy";
            this.dgPrzejazdy.Size = new System.Drawing.Size(757, 444);
            this.dgPrzejazdy.TabIndex = 0;
            // 
            // cPrzejazdCzas
            // 
            this.cPrzejazdCzas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPrzejazdCzas.HeaderText = "Czas rozpoczęcia";
            this.cPrzejazdCzas.Name = "cPrzejazdCzas";
            // 
            // cPrzejazdFirma
            // 
            this.cPrzejazdFirma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPrzejazdFirma.HeaderText = "Firma obsługująca przejazd";
            this.cPrzejazdFirma.Name = "cPrzejazdFirma";
            // 
            // cPrzejazdLinia
            // 
            this.cPrzejazdLinia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPrzejazdLinia.HeaderText = "Linia przejazdu";
            this.cPrzejazdLinia.Name = "cPrzejazdLinia";
            // 
            // cPrzejazdAutobus
            // 
            this.cPrzejazdAutobus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cPrzejazdAutobus.HeaderText = "Autobus wykonujący przejazd (opcjonalne)";
            this.cPrzejazdAutobus.Name = "cPrzejazdAutobus";
            // 
            // lPrzejazdTytul
            // 
            this.lPrzejazdTytul.AutoSize = true;
            this.lPrzejazdTytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPrzejazdTytul.Location = new System.Drawing.Point(5, 4);
            this.lPrzejazdTytul.Name = "lPrzejazdTytul";
            this.lPrzejazdTytul.Size = new System.Drawing.Size(96, 24);
            this.lPrzejazdTytul.TabIndex = 1;
            this.lPrzejazdTytul.Text = "Przejazdy:";
            // 
            // BMenu
            // 
            this.BMenu.Location = new System.Drawing.Point(322, 488);
            this.BMenu.Name = "BMenu";
            this.BMenu.Size = new System.Drawing.Size(103, 37);
            this.BMenu.TabIndex = 2;
            this.BMenu.Text = "Wróć do menu";
            this.BMenu.UseVisualStyleBackColor = true;
            // 
            // msPrzejazdy
            // 
            this.msPrzejazdy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem});
            this.msPrzejazdy.Location = new System.Drawing.Point(0, 0);
            this.msPrzejazdy.Name = "msPrzejazdy";
            this.msPrzejazdy.Size = new System.Drawing.Size(784, 24);
            this.msPrzejazdy.TabIndex = 4;
            this.msPrzejazdy.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zapiszToolStripMenuItem,
            this.zapiszJakoToolStripMenuItem,
            this.wczytajToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            // 
            // zapiszJakoToolStripMenuItem
            // 
            this.zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
            this.zapiszJakoToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.zapiszJakoToolStripMenuItem.Text = "Zapisz jako";
            // 
            // wczytajToolStripMenuItem
            // 
            this.wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            this.wczytajToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.wczytajToolStripMenuItem.Text = "Wczytaj";
            // 
            // pAutobus
            // 
            this.pAutobus.Controls.Add(this.msAutobus);
            this.pAutobus.Controls.Add(this.pAutobusStale);
            this.pAutobus.Controls.Add(this.pZmianaPrzyspieszenia);
            this.pAutobus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAutobus.Location = new System.Drawing.Point(0, 0);
            this.pAutobus.Name = "pAutobus";
            this.pAutobus.Size = new System.Drawing.Size(784, 561);
            this.pAutobus.TabIndex = 21;
            this.pAutobus.Visible = false;
            // 
            // pPrzystanek
            // 
            this.pPrzystanek.Controls.Add(this.pPrzystanekStale);
            this.pPrzystanek.Controls.Add(this.pPrzystanekProgi);
            this.pPrzystanek.Controls.Add(this.msPrzystanek);
            this.pPrzystanek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPrzystanek.Location = new System.Drawing.Point(0, 0);
            this.pPrzystanek.Name = "pPrzystanek";
            this.pPrzystanek.Size = new System.Drawing.Size(784, 561);
            this.pPrzystanek.TabIndex = 22;
            this.pPrzystanek.Visible = false;
            // 
            // msPrzystanek
            // 
            this.msPrzystanek.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msPrzystanekPlik});
            this.msPrzystanek.Location = new System.Drawing.Point(0, 0);
            this.msPrzystanek.Name = "msPrzystanek";
            this.msPrzystanek.Size = new System.Drawing.Size(784, 24);
            this.msPrzystanek.TabIndex = 20;
            this.msPrzystanek.Text = "menuStrip1";
            // 
            // msPrzystanekPlik
            // 
            this.msPrzystanekPlik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msPrzystanekZapisz,
            this.msPrzystanekZapiszJako,
            this.msPrzystanekWczytaj});
            this.msPrzystanekPlik.Name = "msPrzystanekPlik";
            this.msPrzystanekPlik.Size = new System.Drawing.Size(38, 20);
            this.msPrzystanekPlik.Text = "Plik";
            // 
            // msPrzystanekZapisz
            // 
            this.msPrzystanekZapisz.Enabled = false;
            this.msPrzystanekZapisz.Name = "msPrzystanekZapisz";
            this.msPrzystanekZapisz.Size = new System.Drawing.Size(132, 22);
            this.msPrzystanekZapisz.Text = "Zapisz";
            this.msPrzystanekZapisz.Click += new System.EventHandler(this.MsPrzystanekZapisz_Click);
            // 
            // msPrzystanekZapiszJako
            // 
            this.msPrzystanekZapiszJako.Enabled = false;
            this.msPrzystanekZapiszJako.Name = "msPrzystanekZapiszJako";
            this.msPrzystanekZapiszJako.Size = new System.Drawing.Size(132, 22);
            this.msPrzystanekZapiszJako.Text = "Zapisz jako";
            this.msPrzystanekZapiszJako.Click += new System.EventHandler(this.MsPrzystanekZapiszJako_Click);
            // 
            // msPrzystanekWczytaj
            // 
            this.msPrzystanekWczytaj.Name = "msPrzystanekWczytaj";
            this.msPrzystanekWczytaj.Size = new System.Drawing.Size(132, 22);
            this.msPrzystanekWczytaj.Text = "Wczytaj";
            this.msPrzystanekWczytaj.Click += new System.EventHandler(this.WczytajToolStripMenuItem1_Click);
            // 
            // pFirma
            // 
            this.pFirma.Controls.Add(this.msFirma);
            this.pFirma.Controls.Add(this.pFirmaStaleLinie);
            this.pFirma.Controls.Add(this.pFirmaTabor);
            this.pFirma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFirma.Location = new System.Drawing.Point(0, 0);
            this.pFirma.Name = "pFirma";
            this.pFirma.Size = new System.Drawing.Size(784, 561);
            this.pFirma.TabIndex = 23;
            // 
            // msFirma
            // 
            this.msFirma.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFirmaPlik});
            this.msFirma.Location = new System.Drawing.Point(0, 0);
            this.msFirma.Name = "msFirma";
            this.msFirma.Size = new System.Drawing.Size(784, 24);
            this.msFirma.TabIndex = 2;
            this.msFirma.Text = "menuStrip1";
            // 
            // msFirmaPlik
            // 
            this.msFirmaPlik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFirmaPlikZapisz,
            this.msFirmaPlikZapiszJako,
            this.msFirmaPlikWczytaj});
            this.msFirmaPlik.Name = "msFirmaPlik";
            this.msFirmaPlik.Size = new System.Drawing.Size(38, 20);
            this.msFirmaPlik.Text = "Plik";
            // 
            // msFirmaPlikZapisz
            // 
            this.msFirmaPlikZapisz.Name = "msFirmaPlikZapisz";
            this.msFirmaPlikZapisz.Size = new System.Drawing.Size(132, 22);
            this.msFirmaPlikZapisz.Text = "Zapisz";
            // 
            // msFirmaPlikZapiszJako
            // 
            this.msFirmaPlikZapiszJako.Name = "msFirmaPlikZapiszJako";
            this.msFirmaPlikZapiszJako.Size = new System.Drawing.Size(132, 22);
            this.msFirmaPlikZapiszJako.Text = "Zapisz jako";
            // 
            // msFirmaPlikWczytaj
            // 
            this.msFirmaPlikWczytaj.Name = "msFirmaPlikWczytaj";
            this.msFirmaPlikWczytaj.Size = new System.Drawing.Size(132, 22);
            this.msFirmaPlikWczytaj.Text = "Wczytaj";
            // 
            // pFirmaStaleLinie
            // 
            this.pFirmaStaleLinie.Controls.Add(this.dgFirmaLinia);
            this.pFirmaStaleLinie.Controls.Add(this.button1);
            this.pFirmaStaleLinie.Controls.Add(this.tbFirmaKierowcy);
            this.pFirmaStaleLinie.Controls.Add(this.bFirmaStaleMenu);
            this.pFirmaStaleLinie.Controls.Add(this.tbFirmaNazwa);
            this.pFirmaStaleLinie.Controls.Add(this.lFirmaKierowcy);
            this.pFirmaStaleLinie.Controls.Add(this.lFirmaNazwa);
            this.pFirmaStaleLinie.Controls.Add(this.lFirmaStaleTytul);
            this.pFirmaStaleLinie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFirmaStaleLinie.Location = new System.Drawing.Point(0, 0);
            this.pFirmaStaleLinie.Name = "pFirmaStaleLinie";
            this.pFirmaStaleLinie.Size = new System.Drawing.Size(784, 561);
            this.pFirmaStaleLinie.TabIndex = 0;
            // 
            // dgFirmaLinia
            // 
            this.dgFirmaLinia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFirmaLinia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cIDLinii,
            this.cSciezkaPliku});
            this.dgFirmaLinia.Location = new System.Drawing.Point(12, 123);
            this.dgFirmaLinia.Name = "dgFirmaLinia";
            this.dgFirmaLinia.Size = new System.Drawing.Size(760, 378);
            this.dgFirmaLinia.TabIndex = 8;
            // 
            // cIDLinii
            // 
            this.cIDLinii.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cIDLinii.HeaderText = "Id linii";
            this.cIDLinii.Name = "cIDLinii";
            // 
            // cSciezkaPliku
            // 
            this.cSciezkaPliku.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cSciezkaPliku.HeaderText = "Scieżka pliku";
            this.cSciezkaPliku.Name = "cSciezkaPliku";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Dalej...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tbFirmaKierowcy
            // 
            this.tbFirmaKierowcy.Location = new System.Drawing.Point(113, 91);
            this.tbFirmaKierowcy.Name = "tbFirmaKierowcy";
            this.tbFirmaKierowcy.Size = new System.Drawing.Size(100, 20);
            this.tbFirmaKierowcy.TabIndex = 6;
            // 
            // bFirmaStaleMenu
            // 
            this.bFirmaStaleMenu.Location = new System.Drawing.Point(16, 505);
            this.bFirmaStaleMenu.Name = "bFirmaStaleMenu";
            this.bFirmaStaleMenu.Size = new System.Drawing.Size(75, 42);
            this.bFirmaStaleMenu.TabIndex = 4;
            this.bFirmaStaleMenu.Text = "Wróć do menu";
            this.bFirmaStaleMenu.UseVisualStyleBackColor = true;
            // 
            // tbFirmaNazwa
            // 
            this.tbFirmaNazwa.Location = new System.Drawing.Point(113, 65);
            this.tbFirmaNazwa.Name = "tbFirmaNazwa";
            this.tbFirmaNazwa.Size = new System.Drawing.Size(100, 20);
            this.tbFirmaNazwa.TabIndex = 3;
            // 
            // lFirmaKierowcy
            // 
            this.lFirmaKierowcy.AutoSize = true;
            this.lFirmaKierowcy.Location = new System.Drawing.Point(13, 94);
            this.lFirmaKierowcy.Name = "lFirmaKierowcy";
            this.lFirmaKierowcy.Size = new System.Drawing.Size(92, 13);
            this.lFirmaKierowcy.TabIndex = 2;
            this.lFirmaKierowcy.Text = "Liczba kierowców";
            // 
            // lFirmaNazwa
            // 
            this.lFirmaNazwa.AutoSize = true;
            this.lFirmaNazwa.Location = new System.Drawing.Point(12, 68);
            this.lFirmaNazwa.Name = "lFirmaNazwa";
            this.lFirmaNazwa.Size = new System.Drawing.Size(64, 13);
            this.lFirmaNazwa.TabIndex = 1;
            this.lFirmaNazwa.Text = "Nazwa firmy";
            // 
            // lFirmaStaleTytul
            // 
            this.lFirmaStaleTytul.AutoSize = true;
            this.lFirmaStaleTytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFirmaStaleTytul.Location = new System.Drawing.Point(20, 20);
            this.lFirmaStaleTytul.Name = "lFirmaStaleTytul";
            this.lFirmaStaleTytul.Size = new System.Drawing.Size(99, 24);
            this.lFirmaStaleTytul.TabIndex = 0;
            this.lFirmaStaleTytul.Text = "Stałe firmy";
            // 
            // pFirmaTabor
            // 
            this.pFirmaTabor.Controls.Add(this.bFirmaZapisz);
            this.pFirmaTabor.Controls.Add(this.bFirmaTaborMenu);
            this.pFirmaTabor.Controls.Add(this.dgFirmaTabor);
            this.pFirmaTabor.Controls.Add(this.lFirmaTaborTytul);
            this.pFirmaTabor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFirmaTabor.Location = new System.Drawing.Point(0, 0);
            this.pFirmaTabor.Name = "pFirmaTabor";
            this.pFirmaTabor.Size = new System.Drawing.Size(784, 561);
            this.pFirmaTabor.TabIndex = 1;
            // 
            // bFirmaZapisz
            // 
            this.bFirmaZapisz.Location = new System.Drawing.Point(697, 505);
            this.bFirmaZapisz.Name = "bFirmaZapisz";
            this.bFirmaZapisz.Size = new System.Drawing.Size(75, 41);
            this.bFirmaZapisz.TabIndex = 3;
            this.bFirmaZapisz.Text = "Zapisz do pliku";
            this.bFirmaZapisz.UseVisualStyleBackColor = true;
            // 
            // bFirmaTaborMenu
            // 
            this.bFirmaTaborMenu.Location = new System.Drawing.Point(12, 505);
            this.bFirmaTaborMenu.Name = "bFirmaTaborMenu";
            this.bFirmaTaborMenu.Size = new System.Drawing.Size(75, 41);
            this.bFirmaTaborMenu.TabIndex = 2;
            this.bFirmaTaborMenu.Text = "Wróć do menu";
            this.bFirmaTaborMenu.UseVisualStyleBackColor = true;
            // 
            // dgFirmaTabor
            // 
            this.dgFirmaTabor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFirmaTabor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cFirmaTaborSciezkaPliku,
            this.cFirmaTaborLiczba});
            this.dgFirmaTabor.Location = new System.Drawing.Point(12, 62);
            this.dgFirmaTabor.Name = "dgFirmaTabor";
            this.dgFirmaTabor.Size = new System.Drawing.Size(760, 431);
            this.dgFirmaTabor.TabIndex = 1;
            // 
            // cFirmaTaborSciezkaPliku
            // 
            this.cFirmaTaborSciezkaPliku.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cFirmaTaborSciezkaPliku.HeaderText = "Scieżka pliku";
            this.cFirmaTaborSciezkaPliku.Name = "cFirmaTaborSciezkaPliku";
            // 
            // cFirmaTaborLiczba
            // 
            this.cFirmaTaborLiczba.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cFirmaTaborLiczba.HeaderText = "Liczba pojazdów";
            this.cFirmaTaborLiczba.Name = "cFirmaTaborLiczba";
            // 
            // lFirmaTaborTytul
            // 
            this.lFirmaTaborTytul.AutoSize = true;
            this.lFirmaTaborTytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFirmaTaborTytul.Location = new System.Drawing.Point(9, 31);
            this.lFirmaTaborTytul.Name = "lFirmaTaborTytul";
            this.lFirmaTaborTytul.Size = new System.Drawing.Size(104, 24);
            this.lFirmaTaborTytul.TabIndex = 0;
            this.lFirmaTaborTytul.Text = "Tabor firmy";
            // 
            // pLinia
            // 
            this.pLinia.Controls.Add(this.msLinia);
            this.pLinia.Controls.Add(this.pLiniaDane);
            this.pLinia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLinia.Location = new System.Drawing.Point(0, 0);
            this.pLinia.Name = "pLinia";
            this.pLinia.Size = new System.Drawing.Size(784, 561);
            this.pLinia.TabIndex = 0;
            // 
            // msLinia
            // 
            this.msLinia.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msLiniaPlik});
            this.msLinia.Location = new System.Drawing.Point(0, 0);
            this.msLinia.Name = "msLinia";
            this.msLinia.Size = new System.Drawing.Size(784, 24);
            this.msLinia.TabIndex = 1;
            this.msLinia.Text = "menuStrip1";
            // 
            // msLiniaPlik
            // 
            this.msLiniaPlik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msLiniaPlikZapisz,
            this.msLiniaPlikZapiszJako,
            this.msLiniaPlikWczytaj});
            this.msLiniaPlik.Name = "msLiniaPlik";
            this.msLiniaPlik.Size = new System.Drawing.Size(38, 20);
            this.msLiniaPlik.Text = "Plik";
            // 
            // msLiniaPlikZapisz
            // 
            this.msLiniaPlikZapisz.Name = "msLiniaPlikZapisz";
            this.msLiniaPlikZapisz.Size = new System.Drawing.Size(132, 22);
            this.msLiniaPlikZapisz.Text = "Zapisz";
            // 
            // msLiniaPlikZapiszJako
            // 
            this.msLiniaPlikZapiszJako.Name = "msLiniaPlikZapiszJako";
            this.msLiniaPlikZapiszJako.Size = new System.Drawing.Size(132, 22);
            this.msLiniaPlikZapiszJako.Text = "Zapisz jako";
            // 
            // msLiniaPlikWczytaj
            // 
            this.msLiniaPlikWczytaj.Name = "msLiniaPlikWczytaj";
            this.msLiniaPlikWczytaj.Size = new System.Drawing.Size(132, 22);
            this.msLiniaPlikWczytaj.Text = "Wczytaj";
            // 
            // pLiniaDane
            // 
            this.pLiniaDane.Controls.Add(this.bLiniaZapisz);
            this.pLiniaDane.Controls.Add(this.bLiniaMenu);
            this.pLiniaDane.Controls.Add(this.dgLiniaDane);
            this.pLiniaDane.Controls.Add(this.tbLiniaId);
            this.pLiniaDane.Controls.Add(this.bLiniaId);
            this.pLiniaDane.Controls.Add(this.bLiniaTytul);
            this.pLiniaDane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLiniaDane.Location = new System.Drawing.Point(0, 0);
            this.pLiniaDane.Name = "pLiniaDane";
            this.pLiniaDane.Size = new System.Drawing.Size(784, 561);
            this.pLiniaDane.TabIndex = 0;
            // 
            // bLiniaZapisz
            // 
            this.bLiniaZapisz.Location = new System.Drawing.Point(697, 510);
            this.bLiniaZapisz.Name = "bLiniaZapisz";
            this.bLiniaZapisz.Size = new System.Drawing.Size(75, 44);
            this.bLiniaZapisz.TabIndex = 5;
            this.bLiniaZapisz.Text = "Zapisz do pliku";
            this.bLiniaZapisz.UseVisualStyleBackColor = true;
            // 
            // bLiniaMenu
            // 
            this.bLiniaMenu.Location = new System.Drawing.Point(12, 507);
            this.bLiniaMenu.Name = "bLiniaMenu";
            this.bLiniaMenu.Size = new System.Drawing.Size(75, 44);
            this.bLiniaMenu.TabIndex = 4;
            this.bLiniaMenu.Text = "Wróć do menu";
            this.bLiniaMenu.UseVisualStyleBackColor = true;
            // 
            // dgLiniaDane
            // 
            this.dgLiniaDane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLiniaDane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNazwaPrzystanku,
            this.cLiniaPrzystanek,
            this.cCzasDojazdu});
            this.dgLiniaDane.Location = new System.Drawing.Point(9, 102);
            this.dgLiniaDane.Name = "dgLiniaDane";
            this.dgLiniaDane.Size = new System.Drawing.Size(763, 397);
            this.dgLiniaDane.TabIndex = 3;
            // 
            // cNazwaPrzystanku
            // 
            this.cNazwaPrzystanku.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cNazwaPrzystanku.HeaderText = "Nazwa przystanku";
            this.cNazwaPrzystanku.Name = "cNazwaPrzystanku";
            // 
            // cLiniaPrzystanek
            // 
            this.cLiniaPrzystanek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cLiniaPrzystanek.HeaderText = "Przystanek";
            this.cLiniaPrzystanek.Name = "cLiniaPrzystanek";
            // 
            // cCzasDojazdu
            // 
            this.cCzasDojazdu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cCzasDojazdu.HeaderText = "Czas dojazdu";
            this.cCzasDojazdu.Name = "cCzasDojazdu";
            // 
            // tbLiniaId
            // 
            this.tbLiniaId.Location = new System.Drawing.Point(51, 70);
            this.tbLiniaId.Name = "tbLiniaId";
            this.tbLiniaId.Size = new System.Drawing.Size(100, 20);
            this.tbLiniaId.TabIndex = 2;
            // 
            // bLiniaId
            // 
            this.bLiniaId.AutoSize = true;
            this.bLiniaId.Location = new System.Drawing.Point(12, 73);
            this.bLiniaId.Name = "bLiniaId";
            this.bLiniaId.Size = new System.Drawing.Size(33, 13);
            this.bLiniaId.TabIndex = 1;
            this.bLiniaId.Text = "Id linii";
            // 
            // bLiniaTytul
            // 
            this.bLiniaTytul.AutoSize = true;
            this.bLiniaTytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bLiniaTytul.Location = new System.Drawing.Point(12, 36);
            this.bLiniaTytul.Name = "bLiniaTytul";
            this.bLiniaTytul.Size = new System.Drawing.Size(87, 24);
            this.bLiniaTytul.TabIndex = 0;
            this.bLiniaTytul.Text = "Dane linii";
            // 
            // AplikacjaPomocnicza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pPowitanie);
            this.Controls.Add(this.pLinia);
            this.Controls.Add(this.pPrzejazdy);
            this.Controls.Add(this.pFirma);
            this.Controls.Add(this.pPrzystanek);
            this.Controls.Add(this.pAutobus);
            this.MainMenuStrip = this.msPrzejazdy;
            this.Name = "AplikacjaPomocnicza";
            this.Text = "Aplikacja pomocnicza";
            this.pPowitanie.ResumeLayout(false);
            this.pPowitanie.PerformLayout();
            this.pAutobusStale.ResumeLayout(false);
            this.pAutobusStale.PerformLayout();
            this.msAutobus.ResumeLayout(false);
            this.msAutobus.PerformLayout();
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
            this.pPrzejazdy.ResumeLayout(false);
            this.pPrzejazdy.PerformLayout();
            this.pPrzejazdyDane.ResumeLayout(false);
            this.pPrzejazdyDane.PerformLayout();
            this.pPrzejazdyUstawianie.ResumeLayout(false);
            this.pPrzejazdyUstawianie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrzejazdy)).EndInit();
            this.msPrzejazdy.ResumeLayout(false);
            this.msPrzejazdy.PerformLayout();
            this.pAutobus.ResumeLayout(false);
            this.pAutobus.PerformLayout();
            this.pPrzystanek.ResumeLayout(false);
            this.pPrzystanek.PerformLayout();
            this.msPrzystanek.ResumeLayout(false);
            this.msPrzystanek.PerformLayout();
            this.pFirma.ResumeLayout(false);
            this.pFirma.PerformLayout();
            this.msFirma.ResumeLayout(false);
            this.msFirma.PerformLayout();
            this.pFirmaStaleLinie.ResumeLayout(false);
            this.pFirmaStaleLinie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFirmaLinia)).EndInit();
            this.pFirmaTabor.ResumeLayout(false);
            this.pFirmaTabor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFirmaTabor)).EndInit();
            this.pLinia.ResumeLayout(false);
            this.pLinia.PerformLayout();
            this.msLinia.ResumeLayout(false);
            this.msLinia.PerformLayout();
            this.pLiniaDane.ResumeLayout(false);
            this.pLiniaDane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLiniaDane)).EndInit();
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
        private System.Windows.Forms.Button bPrzejazdy;
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
        private System.Windows.Forms.Panel pPrzejazdy;
        private System.Windows.Forms.DataGridView dgPrzejazdy;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrzejazdCzas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrzejazdFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrzejazdLinia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrzejazdAutobus;
        private System.Windows.Forms.Label lPrzejazdTytul;
        private System.Windows.Forms.Button BMenu;
        private System.Windows.Forms.MenuStrip msPrzejazdy;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszJakoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajToolStripMenuItem;
        private System.Windows.Forms.MenuStrip msAutobus;
        private System.Windows.Forms.ToolStripMenuItem msAutobusPlik;
        private System.Windows.Forms.ToolStripMenuItem msAutobusZapisz;
        private System.Windows.Forms.ToolStripMenuItem msAutobusZapiszJako;
        private System.Windows.Forms.ToolStripMenuItem msAutobusWczytaj;
        private System.Windows.Forms.Panel pAutobus;
        private System.Windows.Forms.Panel pPrzystanek;
        private System.Windows.Forms.MenuStrip msPrzystanek;
        private System.Windows.Forms.ToolStripMenuItem msPrzystanekPlik;
        private System.Windows.Forms.ToolStripMenuItem msPrzystanekZapisz;
        private System.Windows.Forms.ToolStripMenuItem msPrzystanekZapiszJako;
        private System.Windows.Forms.ToolStripMenuItem msPrzystanekWczytaj;
        private System.Windows.Forms.Panel pPrzejazdyUstawianie;
        private System.Windows.Forms.Panel pPrzejazdyDane;
        private System.Windows.Forms.Label lPrzyplywyPasazerow;
        private System.Windows.Forms.TextBox tbPrzyplywyPasazerow;
        private System.Windows.Forms.TextBox tbMapaTerenu;
        private System.Windows.Forms.Label lMapaTerenu;
        private System.Windows.Forms.Button BPrzejazdDalej;
        private System.Windows.Forms.Button BPrzejazdMenu;
        private System.Windows.Forms.Button bFirma;
        private System.Windows.Forms.Button bLinia;
        private System.Windows.Forms.Panel pFirma;
        private System.Windows.Forms.Panel pFirmaStaleLinie;
        private System.Windows.Forms.Panel pLinia;
        private System.Windows.Forms.Panel pFirmaTabor;
        private System.Windows.Forms.Panel pLiniaDane;
        private System.Windows.Forms.TextBox tbFirmaKierowcy;
        private System.Windows.Forms.Button bFirmaStaleMenu;
        private System.Windows.Forms.TextBox tbFirmaNazwa;
        private System.Windows.Forms.Label lFirmaKierowcy;
        private System.Windows.Forms.Label lFirmaNazwa;
        private System.Windows.Forms.Label lFirmaStaleTytul;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgFirmaLinia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIDLinii;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSciezkaPliku;
        private System.Windows.Forms.MenuStrip msFirma;
        private System.Windows.Forms.ToolStripMenuItem msFirmaPlik;
        private System.Windows.Forms.ToolStripMenuItem msFirmaPlikZapisz;
        private System.Windows.Forms.ToolStripMenuItem msFirmaPlikZapiszJako;
        private System.Windows.Forms.ToolStripMenuItem msFirmaPlikWczytaj;
        private System.Windows.Forms.Label lFirmaTaborTytul;
        private System.Windows.Forms.Button bFirmaZapisz;
        private System.Windows.Forms.Button bFirmaTaborMenu;
        private System.Windows.Forms.DataGridView dgFirmaTabor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFirmaTaborSciezkaPliku;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFirmaTaborLiczba;
        private System.Windows.Forms.MenuStrip msLinia;
        private System.Windows.Forms.ToolStripMenuItem msLiniaPlik;
        private System.Windows.Forms.ToolStripMenuItem msLiniaPlikZapisz;
        private System.Windows.Forms.ToolStripMenuItem msLiniaPlikZapiszJako;
        private System.Windows.Forms.ToolStripMenuItem msLiniaPlikWczytaj;
        private System.Windows.Forms.Label bLiniaTytul;
        private System.Windows.Forms.Label bLiniaId;
        private System.Windows.Forms.TextBox tbLiniaId;
        private System.Windows.Forms.Button bLiniaZapisz;
        private System.Windows.Forms.Button bLiniaMenu;
        private System.Windows.Forms.DataGridView dgLiniaDane;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNazwaPrzystanku;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLiniaPrzystanek;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCzasDojazdu;
    }
}

