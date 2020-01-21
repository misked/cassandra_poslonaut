namespace CassandraWinFormsSample
{
    partial class Pregled
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pregled));
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblPol = new System.Windows.Forms.Label();
            this.lblBrojTelefona = new System.Windows.Forms.Label();
            this.lblGodine = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodajOglas = new System.Windows.Forms.Button();
            this.btnObrisiOglas = new System.Windows.Forms.Button();
            this.btnZahtevi = new System.Windows.Forms.Button();
            this.btnSvojiZahtevi = new System.Windows.Forms.Button();
            this.btnLajk = new System.Windows.Forms.Button();
            this.btnPosaljiZahtev = new System.Windows.Forms.Button();
            this.btnBrojZahteva = new System.Windows.Forms.Button();
            this.btnKomentar = new System.Windows.Forms.Button();
            this.btnSviKomentari = new System.Windows.Forms.Button();
            this.chkVoznja = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(116, 41);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(68, 23);
            this.lblIme.TabIndex = 0;
            this.lblIme.Text = "label1";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(230, 41);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(68, 23);
            this.lblPrezime.TabIndex = 1;
            this.lblPrezime.Text = "label2";
            // 
            // lblPol
            // 
            this.lblPol.AutoSize = true;
            this.lblPol.Location = new System.Drawing.Point(230, 167);
            this.lblPol.Name = "lblPol";
            this.lblPol.Size = new System.Drawing.Size(68, 23);
            this.lblPol.TabIndex = 3;
            this.lblPol.Text = "label4";
            // 
            // lblBrojTelefona
            // 
            this.lblBrojTelefona.AutoSize = true;
            this.lblBrojTelefona.Location = new System.Drawing.Point(22, 167);
            this.lblBrojTelefona.Name = "lblBrojTelefona";
            this.lblBrojTelefona.Size = new System.Drawing.Size(68, 23);
            this.lblBrojTelefona.TabIndex = 4;
            this.lblBrojTelefona.Text = "label5";
            // 
            // lblGodine
            // 
            this.lblGodine.AutoSize = true;
            this.lblGodine.Location = new System.Drawing.Point(22, 232);
            this.lblGodine.Name = "lblGodine";
            this.lblGodine.Size = new System.Drawing.Size(68, 23);
            this.lblGodine.TabIndex = 5;
            this.lblGodine.Text = "label6";
            this.lblGodine.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lblGodine);
            this.groupBox1.Controls.Add(this.lblBrojTelefona);
            this.groupBox1.Controls.Add(this.lblPol);
            this.groupBox1.Controls.Add(this.lblPrezime);
            this.groupBox1.Controls.Add(this.lblIme);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(889, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 301);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profil";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(116, 101);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(109, 23);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.TabStop = true;
            this.lblEmail.Text = "linkLabel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(10, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 93);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 65);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(871, 363);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 33);
            this.label1.TabIndex = 8;
            this.label1.Text = "OGLASI";
            // 
            // btnDodajOglas
            // 
            this.btnDodajOglas.Location = new System.Drawing.Point(563, 452);
            this.btnDodajOglas.Name = "btnDodajOglas";
            this.btnDodajOglas.Size = new System.Drawing.Size(155, 63);
            this.btnDodajOglas.TabIndex = 9;
            this.btnDodajOglas.Text = "DODAJ OGLAS";
            this.btnDodajOglas.UseVisualStyleBackColor = true;
            this.btnDodajOglas.Visible = false;
            this.btnDodajOglas.Click += new System.EventHandler(this.btnDodajOglas_Click);
            // 
            // btnObrisiOglas
            // 
            this.btnObrisiOglas.Location = new System.Drawing.Point(728, 452);
            this.btnObrisiOglas.Name = "btnObrisiOglas";
            this.btnObrisiOglas.Size = new System.Drawing.Size(155, 63);
            this.btnObrisiOglas.TabIndex = 10;
            this.btnObrisiOglas.Text = "OBRISI SELEKTOVANI OGLAS";
            this.btnObrisiOglas.UseVisualStyleBackColor = true;
            this.btnObrisiOglas.Visible = false;
            this.btnObrisiOglas.Click += new System.EventHandler(this.btnObrisiOglas_Click);
            // 
            // btnZahtevi
            // 
            this.btnZahtevi.Location = new System.Drawing.Point(983, 372);
            this.btnZahtevi.Name = "btnZahtevi";
            this.btnZahtevi.Size = new System.Drawing.Size(155, 63);
            this.btnZahtevi.TabIndex = 12;
            this.btnZahtevi.Text = "VIDI SVE ZAHTEVE";
            this.btnZahtevi.UseVisualStyleBackColor = true;
            this.btnZahtevi.Visible = false;
            this.btnZahtevi.Click += new System.EventHandler(this.btnZahtevi_Click);
            // 
            // btnSvojiZahtevi
            // 
            this.btnSvojiZahtevi.Location = new System.Drawing.Point(983, 372);
            this.btnSvojiZahtevi.Name = "btnSvojiZahtevi";
            this.btnSvojiZahtevi.Size = new System.Drawing.Size(155, 63);
            this.btnSvojiZahtevi.TabIndex = 13;
            this.btnSvojiZahtevi.Text = "VIDI SVOJE ZAHTEVE";
            this.btnSvojiZahtevi.UseVisualStyleBackColor = true;
            this.btnSvojiZahtevi.Visible = false;
            this.btnSvojiZahtevi.Click += new System.EventHandler(this.btnSvojiZahtevi_Click);
            // 
            // btnLajk
            // 
            this.btnLajk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLajk.BackgroundImage")));
            this.btnLajk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLajk.Location = new System.Drawing.Point(85, 471);
            this.btnLajk.Name = "btnLajk";
            this.btnLajk.Size = new System.Drawing.Size(67, 63);
            this.btnLajk.TabIndex = 14;
            this.btnLajk.UseVisualStyleBackColor = true;
            this.btnLajk.Visible = false;
            this.btnLajk.Click += new System.EventHandler(this.btnLajk_Click);
            // 
            // btnPosaljiZahtev
            // 
            this.btnPosaljiZahtev.Location = new System.Drawing.Point(563, 452);
            this.btnPosaljiZahtev.Name = "btnPosaljiZahtev";
            this.btnPosaljiZahtev.Size = new System.Drawing.Size(155, 63);
            this.btnPosaljiZahtev.TabIndex = 15;
            this.btnPosaljiZahtev.Text = "POSALJI ZAHTEV SELEKTOVANJEM OGLASA";
            this.btnPosaljiZahtev.UseVisualStyleBackColor = true;
            this.btnPosaljiZahtev.Visible = false;
            this.btnPosaljiZahtev.Click += new System.EventHandler(this.btnPosaljiZahtev_Click);
            // 
            // btnBrojZahteva
            // 
            this.btnBrojZahteva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrojZahteva.Enabled = false;
            this.btnBrojZahteva.Location = new System.Drawing.Point(728, 452);
            this.btnBrojZahteva.Name = "btnBrojZahteva";
            this.btnBrojZahteva.Size = new System.Drawing.Size(155, 63);
            this.btnBrojZahteva.TabIndex = 16;
            this.btnBrojZahteva.Text = "BROJ MOGUCIH ZAHTEVA: ";
            this.btnBrojZahteva.UseVisualStyleBackColor = true;
            this.btnBrojZahteva.Visible = false;
            this.btnBrojZahteva.Click += new System.EventHandler(this.btnBrojZahteva_Click);
            // 
            // btnKomentar
            // 
            this.btnKomentar.Location = new System.Drawing.Point(158, 471);
            this.btnKomentar.Name = "btnKomentar";
            this.btnKomentar.Size = new System.Drawing.Size(155, 63);
            this.btnKomentar.TabIndex = 17;
            this.btnKomentar.Text = "DODAJ KOMENTAR";
            this.btnKomentar.UseVisualStyleBackColor = true;
            this.btnKomentar.Visible = false;
            this.btnKomentar.Click += new System.EventHandler(this.btnKomentar_Click);
            // 
            // btnSviKomentari
            // 
            this.btnSviKomentari.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSviKomentari.BackgroundImage")));
            this.btnSviKomentari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSviKomentari.Location = new System.Drawing.Point(12, 471);
            this.btnSviKomentari.Name = "btnSviKomentari";
            this.btnSviKomentari.Size = new System.Drawing.Size(67, 63);
            this.btnSviKomentari.TabIndex = 18;
            this.btnSviKomentari.UseVisualStyleBackColor = true;
            this.btnSviKomentari.Click += new System.EventHandler(this.btnSviKomentari_Click);
            // 
            // chkVoznja
            // 
            this.chkVoznja.AutoSize = true;
            this.chkVoznja.Location = new System.Drawing.Point(12, 434);
            this.chkVoznja.Name = "chkVoznja";
            this.chkVoznja.Size = new System.Drawing.Size(283, 21);
            this.chkVoznja.TabIndex = 19;
            this.chkVoznja.Text = "Samo oglasi sa organizovanom voznjom";
            this.chkVoznja.UseVisualStyleBackColor = true;
            this.chkVoznja.CheckedChanged += new System.EventHandler(this.CheckBoxZaVoznju);
            // 
            // Pregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1261, 546);
            this.Controls.Add(this.chkVoznja);
            this.Controls.Add(this.btnSviKomentari);
            this.Controls.Add(this.btnKomentar);
            this.Controls.Add(this.btnBrojZahteva);
            this.Controls.Add(this.btnPosaljiZahtev);
            this.Controls.Add(this.btnLajk);
            this.Controls.Add(this.btnSvojiZahtevi);
            this.Controls.Add(this.btnZahtevi);
            this.Controls.Add(this.btnObrisiOglas);
            this.Controls.Add(this.btnDodajOglas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pregled";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poslonaut";
            this.Load += new System.EventHandler(this.Pregled_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblPol;
        private System.Windows.Forms.Label lblBrojTelefona;
        private System.Windows.Forms.Label lblGodine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblEmail;
        private System.Windows.Forms.Button btnDodajOglas;
        private System.Windows.Forms.Button btnObrisiOglas;
        private System.Windows.Forms.Button btnZahtevi;
        private System.Windows.Forms.Button btnSvojiZahtevi;
        private System.Windows.Forms.Button btnLajk;
        private System.Windows.Forms.Button btnPosaljiZahtev;
        private System.Windows.Forms.Button btnBrojZahteva;
        private System.Windows.Forms.Button btnKomentar;
        private System.Windows.Forms.Button btnSviKomentari;
        private System.Windows.Forms.CheckBox chkVoznja;
    }
}