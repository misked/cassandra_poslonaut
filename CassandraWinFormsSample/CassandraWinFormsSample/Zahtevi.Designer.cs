namespace CassandraWinFormsSample
{
    partial class Zahtevi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zahtevi));
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnPrihvati = new System.Windows.Forms.Button();
            this.btnOdbij = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));
            this.listView1.Location = new System.Drawing.Point(12, 52);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 317);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnPrihvati
            // 
            this.btnPrihvati.ForeColor = System.Drawing.Color.Blue;
            this.btnPrihvati.Location = new System.Drawing.Point(223, 375);
            this.btnPrihvati.Name = "btnPrihvati";
            this.btnPrihvati.Size = new System.Drawing.Size(125, 48);
            this.btnPrihvati.TabIndex = 1;
            this.btnPrihvati.Text = "PRIHVATI";
            this.btnPrihvati.UseVisualStyleBackColor = true;
            this.btnPrihvati.Visible = false;
            this.btnPrihvati.Click += new System.EventHandler(this.btnPrihvati_Click);
            // 
            // btnOdbij
            // 
            this.btnOdbij.ForeColor = System.Drawing.Color.Red;
            this.btnOdbij.Location = new System.Drawing.Point(468, 375);
            this.btnOdbij.Name = "btnOdbij";
            this.btnOdbij.Size = new System.Drawing.Size(125, 48);
            this.btnOdbij.TabIndex = 2;
            this.btnOdbij.Text = "ODBIJ ZAHTEV";
            this.btnOdbij.UseVisualStyleBackColor = true;
            this.btnOdbij.Visible = false;
            this.btnOdbij.Click += new System.EventHandler(this.btnOdbij_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObrisi.BackgroundImage")));
            this.btnObrisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnObrisi.Location = new System.Drawing.Point(370, 375);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(73, 63);
            this.btnObrisi.TabIndex = 3;
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Visible = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "MOJI ZAHTEVI";
            // 
            // Zahtevi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(829, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnOdbij);
            this.Controls.Add(this.btnPrihvati);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Zahtevi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zahtevi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnPrihvati;
        private System.Windows.Forms.Button btnOdbij;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Label label1;
    }
}