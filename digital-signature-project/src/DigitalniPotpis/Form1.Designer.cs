namespace DigitalniPotpis
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGenerirajSimetricni = new System.Windows.Forms.Button();
            this.btnGenerirajAsimetricni = new System.Windows.Forms.Button();
            this.btnKriptirajSimetricno = new System.Windows.Forms.Button();
            this.btnKriptirajAsimetricno = new System.Windows.Forms.Button();
            this.btnDekriptirajSimetricno = new System.Windows.Forms.Button();
            this.btnDekriptirajAsimetricno = new System.Windows.Forms.Button();
            this.txtUnos = new System.Windows.Forms.TextBox();
            this.btnSpremiTekst = new System.Windows.Forms.Button();
            this.btnIzracunajSazetak = new System.Windows.Forms.Button();
            this.btnPotpisiSazetak = new System.Windows.Forms.Button();
            this.btnProvjeriPotpis = new System.Windows.Forms.Button();
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGenerirajSimetricni
            // 
            this.btnGenerirajSimetricni.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerirajSimetricni.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerirajSimetricni.Location = new System.Drawing.Point(45, 144);
            this.btnGenerirajSimetricni.Name = "btnGenerirajSimetricni";
            this.btnGenerirajSimetricni.Size = new System.Drawing.Size(118, 52);
            this.btnGenerirajSimetricni.TabIndex = 0;
            this.btnGenerirajSimetricni.Text = "Generiraj simetrične ključeve (AES)";
            this.btnGenerirajSimetricni.UseVisualStyleBackColor = false;
            this.btnGenerirajSimetricni.Click += new System.EventHandler(this.btnGenerirajSimetricni_Click);
            // 
            // btnGenerirajAsimetricni
            // 
            this.btnGenerirajAsimetricni.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerirajAsimetricni.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGenerirajAsimetricni.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerirajAsimetricni.Location = new System.Drawing.Point(45, 224);
            this.btnGenerirajAsimetricni.Name = "btnGenerirajAsimetricni";
            this.btnGenerirajAsimetricni.Size = new System.Drawing.Size(118, 52);
            this.btnGenerirajAsimetricni.TabIndex = 1;
            this.btnGenerirajAsimetricni.Text = "Generiraj asimetrične ključeve (RSA)";
            this.btnGenerirajAsimetricni.UseVisualStyleBackColor = false;
            this.btnGenerirajAsimetricni.Click += new System.EventHandler(this.btnGenerirajAsimetricni_Click);
            // 
            // btnKriptirajSimetricno
            // 
            this.btnKriptirajSimetricno.BackColor = System.Drawing.Color.Transparent;
            this.btnKriptirajSimetricno.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKriptirajSimetricno.Location = new System.Drawing.Point(238, 144);
            this.btnKriptirajSimetricno.Name = "btnKriptirajSimetricno";
            this.btnKriptirajSimetricno.Size = new System.Drawing.Size(121, 52);
            this.btnKriptirajSimetricno.TabIndex = 2;
            this.btnKriptirajSimetricno.Text = "Kriptiraj simetrično (AES)";
            this.btnKriptirajSimetricno.UseVisualStyleBackColor = false;
            this.btnKriptirajSimetricno.Click += new System.EventHandler(this.btnKriptirajSimetricno_Click);
            // 
            // btnKriptirajAsimetricno
            // 
            this.btnKriptirajAsimetricno.BackColor = System.Drawing.Color.Transparent;
            this.btnKriptirajAsimetricno.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKriptirajAsimetricno.Location = new System.Drawing.Point(239, 224);
            this.btnKriptirajAsimetricno.Name = "btnKriptirajAsimetricno";
            this.btnKriptirajAsimetricno.Size = new System.Drawing.Size(121, 52);
            this.btnKriptirajAsimetricno.TabIndex = 3;
            this.btnKriptirajAsimetricno.Text = "Kriptiraj asimetrično (RSA)";
            this.btnKriptirajAsimetricno.UseVisualStyleBackColor = false;
            this.btnKriptirajAsimetricno.Click += new System.EventHandler(this.btnKriptirajAsimetricno_Click);
            // 
            // btnDekriptirajSimetricno
            // 
            this.btnDekriptirajSimetricno.BackColor = System.Drawing.Color.Transparent;
            this.btnDekriptirajSimetricno.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDekriptirajSimetricno.Location = new System.Drawing.Point(442, 144);
            this.btnDekriptirajSimetricno.Name = "btnDekriptirajSimetricno";
            this.btnDekriptirajSimetricno.Size = new System.Drawing.Size(118, 52);
            this.btnDekriptirajSimetricno.TabIndex = 4;
            this.btnDekriptirajSimetricno.Text = "Dekriptiraj simetrično (AES)";
            this.btnDekriptirajSimetricno.UseVisualStyleBackColor = false;
            this.btnDekriptirajSimetricno.Click += new System.EventHandler(this.btnDekriptirajSimetricno_Click);
            // 
            // btnDekriptirajAsimetricno
            // 
            this.btnDekriptirajAsimetricno.BackColor = System.Drawing.Color.Transparent;
            this.btnDekriptirajAsimetricno.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDekriptirajAsimetricno.Location = new System.Drawing.Point(442, 222);
            this.btnDekriptirajAsimetricno.Name = "btnDekriptirajAsimetricno";
            this.btnDekriptirajAsimetricno.Size = new System.Drawing.Size(118, 53);
            this.btnDekriptirajAsimetricno.TabIndex = 5;
            this.btnDekriptirajAsimetricno.Text = "Dekriptiraj asimetrično (RSA)";
            this.btnDekriptirajAsimetricno.UseVisualStyleBackColor = false;
            this.btnDekriptirajAsimetricno.Click += new System.EventHandler(this.btnDekriptirajAsimetricno_Click);
            // 
            // txtUnos
            // 
            this.txtUnos.BackColor = System.Drawing.Color.White;
            this.txtUnos.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnos.Location = new System.Drawing.Point(46, 22);
            this.txtUnos.Multiline = true;
            this.txtUnos.Name = "txtUnos";
            this.txtUnos.Size = new System.Drawing.Size(515, 53);
            this.txtUnos.TabIndex = 6;
            // 
            // btnSpremiTekst
            // 
            this.btnSpremiTekst.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpremiTekst.Location = new System.Drawing.Point(46, 81);
            this.btnSpremiTekst.Name = "btnSpremiTekst";
            this.btnSpremiTekst.Size = new System.Drawing.Size(93, 29);
            this.btnSpremiTekst.TabIndex = 7;
            this.btnSpremiTekst.Text = "Spremi ";
            this.btnSpremiTekst.UseVisualStyleBackColor = true;
            this.btnSpremiTekst.Click += new System.EventHandler(this.btnSpremiTekst_Click);
            // 
            // btnIzracunajSazetak
            // 
            this.btnIzracunajSazetak.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzracunajSazetak.Location = new System.Drawing.Point(590, 309);
            this.btnIzracunajSazetak.Name = "btnIzracunajSazetak";
            this.btnIzracunajSazetak.Size = new System.Drawing.Size(118, 53);
            this.btnIzracunajSazetak.TabIndex = 8;
            this.btnIzracunajSazetak.Text = "Izračunaj sažetak";
            this.btnIzracunajSazetak.UseVisualStyleBackColor = true;
            this.btnIzracunajSazetak.Click += new System.EventHandler(this.btnIzracunajSazetak_Click);
            // 
            // btnPotpisiSazetak
            // 
            this.btnPotpisiSazetak.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotpisiSazetak.Location = new System.Drawing.Point(590, 379);
            this.btnPotpisiSazetak.Name = "btnPotpisiSazetak";
            this.btnPotpisiSazetak.Size = new System.Drawing.Size(118, 54);
            this.btnPotpisiSazetak.TabIndex = 9;
            this.btnPotpisiSazetak.Text = "Potpiši sažetak";
            this.btnPotpisiSazetak.UseVisualStyleBackColor = true;
            this.btnPotpisiSazetak.Click += new System.EventHandler(this.btnPotpisiSazetak_Click);
            // 
            // btnProvjeriPotpis
            // 
            this.btnProvjeriPotpis.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProvjeriPotpis.Location = new System.Drawing.Point(590, 449);
            this.btnProvjeriPotpis.Name = "btnProvjeriPotpis";
            this.btnProvjeriPotpis.Size = new System.Drawing.Size(118, 53);
            this.btnProvjeriPotpis.TabIndex = 10;
            this.btnProvjeriPotpis.Text = "Provjeri potpis";
            this.btnProvjeriPotpis.UseVisualStyleBackColor = true;
            this.btnProvjeriPotpis.Click += new System.EventHandler(this.btnProvjeriPotpis_Click);
            // 
            // txtTerminal
            // 
            this.txtTerminal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTerminal.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerminal.Location = new System.Drawing.Point(46, 309);
            this.txtTerminal.Multiline = true;
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.ReadOnly = true;
            this.txtTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerminal.Size = new System.Drawing.Size(514, 193);
            this.txtTerminal.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::DigitalniPotpis.Properties.Resources.cover;
            this.ClientSize = new System.Drawing.Size(854, 518);
            this.Controls.Add(this.txtTerminal);
            this.Controls.Add(this.btnProvjeriPotpis);
            this.Controls.Add(this.btnPotpisiSazetak);
            this.Controls.Add(this.btnIzracunajSazetak);
            this.Controls.Add(this.btnSpremiTekst);
            this.Controls.Add(this.txtUnos);
            this.Controls.Add(this.btnDekriptirajAsimetricno);
            this.Controls.Add(this.btnDekriptirajSimetricno);
            this.Controls.Add(this.btnKriptirajAsimetricno);
            this.Controls.Add(this.btnKriptirajSimetricno);
            this.Controls.Add(this.btnGenerirajAsimetricni);
            this.Controls.Add(this.btnGenerirajSimetricni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Digitalni potpis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerirajSimetricni;
        private System.Windows.Forms.Button btnGenerirajAsimetricni;
        private System.Windows.Forms.Button btnKriptirajSimetricno;
        private System.Windows.Forms.Button btnKriptirajAsimetricno;
        private System.Windows.Forms.Button btnDekriptirajSimetricno;
        private System.Windows.Forms.Button btnDekriptirajAsimetricno;
        private System.Windows.Forms.TextBox txtUnos;
        private System.Windows.Forms.Button btnSpremiTekst;
        private System.Windows.Forms.Button btnIzracunajSazetak;
        private System.Windows.Forms.Button btnPotpisiSazetak;
        private System.Windows.Forms.Button btnProvjeriPotpis;
        private System.Windows.Forms.TextBox txtTerminal;
    }
}

