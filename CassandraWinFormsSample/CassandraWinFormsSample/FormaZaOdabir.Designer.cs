namespace CassandraWinFormsSample
{
    partial class FormaZaOdabir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaZaOdabir));
            this.btnPotrazivac = new System.Windows.Forms.Button();
            this.btnRadnik = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPotrazivac
            // 
            this.btnPotrazivac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPotrazivac.BackgroundImage")));
            this.btnPotrazivac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPotrazivac.Location = new System.Drawing.Point(33, 99);
            this.btnPotrazivac.Name = "btnPotrazivac";
            this.btnPotrazivac.Size = new System.Drawing.Size(172, 157);
            this.btnPotrazivac.TabIndex = 0;
            this.btnPotrazivac.UseVisualStyleBackColor = true;
            this.btnPotrazivac.Click += new System.EventHandler(this.btnPotrazivac_Click);
            // 
            // btnRadnik
            // 
            this.btnRadnik.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRadnik.BackgroundImage")));
            this.btnRadnik.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRadnik.Location = new System.Drawing.Point(255, 99);
            this.btnRadnik.Name = "btnRadnik";
            this.btnRadnik.Size = new System.Drawing.Size(172, 157);
            this.btnRadnik.TabIndex = 1;
            this.btnRadnik.UseVisualStyleBackColor = true;
            this.btnRadnik.Click += new System.EventHandler(this.btnRadnik_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Logujte se kao:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "POTRAZIVAC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(288, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "RADNIK";
            // 
            // FormaZaOdabir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 338);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRadnik);
            this.Controls.Add(this.btnPotrazivac);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormaZaOdabir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dobrodosli";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPotrazivac;
        private System.Windows.Forms.Button btnRadnik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}