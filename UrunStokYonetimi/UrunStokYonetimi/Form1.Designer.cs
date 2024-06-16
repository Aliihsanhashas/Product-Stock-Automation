namespace UrunStokYonetimi
{
    partial class frmSatis
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTf = new System.Windows.Forms.TextBox();
            this.txtSf = new System.Windows.Forms.TextBox();
            this.txtMik = new System.Windows.Forms.TextBox();
            this.txtUAd = new System.Windows.Forms.TextBox();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnSatısIp = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSat = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblGenelToplam = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMarka = new System.Windows.Forms.Button();
            this.btnKat = new System.Windows.Forms.Button();
            this.btnSatLis = new System.Windows.Forms.Button();
            this.btnUlis = new System.Windows.Forms.Button();
            this.btnUek = new System.Windows.Forms.Button();
            this.btnMusLis = new System.Windows.Forms.Button();
            this.btnMusEk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(247, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(640, 365);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTel);
            this.groupBox1.Controls.Add(this.txtAdSoyad);
            this.groupBox1.Controls.Add(this.txtTc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 127);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Müşteri İşlemleri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telefon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ad Soyad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "TC";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(94, 101);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 2;
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(94, 60);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(100, 20);
            this.txtAdSoyad.TabIndex = 1;
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(94, 19);
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(100, 20);
            this.txtTc.TabIndex = 0;
            this.txtTc.TextChanged += new System.EventHandler(this.txtTc_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTf);
            this.groupBox2.Controls.Add(this.txtSf);
            this.groupBox2.Controls.Add(this.txtMik);
            this.groupBox2.Controls.Add(this.txtUAd);
            this.groupBox2.Controls.Add(this.txtBarkod);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 208);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ürün İşlemleri";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Toplam Fiyat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Satış Fiyatı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Miktar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ürün Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Barkod No";
            // 
            // txtTf
            // 
            this.txtTf.Location = new System.Drawing.Point(94, 171);
            this.txtTf.Name = "txtTf";
            this.txtTf.Size = new System.Drawing.Size(100, 20);
            this.txtTf.TabIndex = 4;
            // 
            // txtSf
            // 
            this.txtSf.Location = new System.Drawing.Point(94, 131);
            this.txtSf.Name = "txtSf";
            this.txtSf.Size = new System.Drawing.Size(100, 20);
            this.txtSf.TabIndex = 3;
            this.txtSf.TextChanged += new System.EventHandler(this.txtSf_TextChanged);
            // 
            // txtMik
            // 
            this.txtMik.Location = new System.Drawing.Point(94, 94);
            this.txtMik.Name = "txtMik";
            this.txtMik.Size = new System.Drawing.Size(100, 20);
            this.txtMik.TabIndex = 2;
            this.txtMik.Text = "1";
            this.txtMik.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMik.TextChanged += new System.EventHandler(this.txtMik_TextChanged);
            // 
            // txtUAd
            // 
            this.txtUAd.Location = new System.Drawing.Point(94, 57);
            this.txtUAd.Name = "txtUAd";
            this.txtUAd.Size = new System.Drawing.Size(100, 20);
            this.txtUAd.TabIndex = 1;
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(94, 19);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(100, 20);
            this.txtBarkod.TabIndex = 0;
            this.txtBarkod.TextChanged += new System.EventHandler(this.txtBarkod_TextChanged);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSil.Location = new System.Drawing.Point(909, 170);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(114, 36);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnSatısIp
            // 
            this.btnSatısIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSatısIp.Location = new System.Drawing.Point(909, 221);
            this.btnSatısIp.Name = "btnSatısIp";
            this.btnSatısIp.Size = new System.Drawing.Size(114, 39);
            this.btnSatısIp.TabIndex = 4;
            this.btnSatısIp.Text = "Satış iptal";
            this.btnSatısIp.UseVisualStyleBackColor = true;
            this.btnSatısIp.Click += new System.EventHandler(this.btnSatısIp_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEkle.Location = new System.Drawing.Point(247, 545);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 5;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSat
            // 
            this.btnSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSat.Location = new System.Drawing.Point(807, 545);
            this.btnSat.Name = "btnSat";
            this.btnSat.Size = new System.Drawing.Size(75, 23);
            this.btnSat.TabIndex = 6;
            this.btnSat.Text = "Satış Yap";
            this.btnSat.UseVisualStyleBackColor = true;
            this.btnSat.Click += new System.EventHandler(this.btnSat_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(450, 553);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Genel Toplam";
            // 
            // lblGenelToplam
            // 
            this.lblGenelToplam.AllowDrop = true;
            this.lblGenelToplam.AutoSize = true;
            this.lblGenelToplam.Location = new System.Drawing.Point(561, 555);
            this.lblGenelToplam.Name = "lblGenelToplam";
            this.lblGenelToplam.Size = new System.Drawing.Size(0, 13);
            this.lblGenelToplam.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMarka);
            this.panel1.Controls.Add(this.btnKat);
            this.panel1.Controls.Add(this.btnSatLis);
            this.panel1.Controls.Add(this.btnUlis);
            this.panel1.Controls.Add(this.btnUek);
            this.panel1.Controls.Add(this.btnMusLis);
            this.panel1.Controls.Add(this.btnMusEk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 100);
            this.panel1.TabIndex = 9;
            // 
            // btnMarka
            // 
            this.btnMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarka.Location = new System.Drawing.Point(758, 30);
            this.btnMarka.Name = "btnMarka";
            this.btnMarka.Size = new System.Drawing.Size(119, 41);
            this.btnMarka.TabIndex = 6;
            this.btnMarka.Text = "Marka";
            this.btnMarka.UseVisualStyleBackColor = true;
            this.btnMarka.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnKat
            // 
            this.btnKat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKat.Location = new System.Drawing.Point(904, 30);
            this.btnKat.Name = "btnKat";
            this.btnKat.Size = new System.Drawing.Size(119, 41);
            this.btnKat.TabIndex = 5;
            this.btnKat.Text = "Kategori";
            this.btnKat.UseVisualStyleBackColor = true;
            this.btnKat.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSatLis
            // 
            this.btnSatLis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSatLis.Location = new System.Drawing.Point(612, 30);
            this.btnSatLis.Name = "btnSatLis";
            this.btnSatLis.Size = new System.Drawing.Size(119, 41);
            this.btnSatLis.TabIndex = 4;
            this.btnSatLis.Text = "Satışları Listeleme";
            this.btnSatLis.UseVisualStyleBackColor = true;
            this.btnSatLis.Click += new System.EventHandler(this.btnSatLis_Click);
            // 
            // btnUlis
            // 
            this.btnUlis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUlis.Location = new System.Drawing.Point(466, 30);
            this.btnUlis.Name = "btnUlis";
            this.btnUlis.Size = new System.Drawing.Size(119, 41);
            this.btnUlis.TabIndex = 3;
            this.btnUlis.Text = "Ürün Listeleme";
            this.btnUlis.UseVisualStyleBackColor = true;
            this.btnUlis.Click += new System.EventHandler(this.btnUlis_Click);
            // 
            // btnUek
            // 
            this.btnUek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUek.Location = new System.Drawing.Point(320, 30);
            this.btnUek.Name = "btnUek";
            this.btnUek.Size = new System.Drawing.Size(119, 41);
            this.btnUek.TabIndex = 2;
            this.btnUek.Text = "Ürün Ekleme";
            this.btnUek.UseVisualStyleBackColor = true;
            this.btnUek.Click += new System.EventHandler(this.btnUek_Click);
            // 
            // btnMusLis
            // 
            this.btnMusLis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusLis.Location = new System.Drawing.Point(174, 30);
            this.btnMusLis.Name = "btnMusLis";
            this.btnMusLis.Size = new System.Drawing.Size(119, 41);
            this.btnMusLis.TabIndex = 1;
            this.btnMusLis.Text = "Müşteri Listeleme";
            this.btnMusLis.UseVisualStyleBackColor = true;
            this.btnMusLis.Click += new System.EventHandler(this.btnMusLis_Click);
            // 
            // btnMusEk
            // 
            this.btnMusEk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusEk.Location = new System.Drawing.Point(28, 30);
            this.btnMusEk.Name = "btnMusEk";
            this.btnMusEk.Size = new System.Drawing.Size(119, 41);
            this.btnMusEk.TabIndex = 0;
            this.btnMusEk.Text = "Müşteri Ekle";
            this.btnMusEk.UseVisualStyleBackColor = true;
            this.btnMusEk.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1035, 590);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblGenelToplam);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSat);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnSatısIp);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmSatis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satış Sayfası";
            this.Load += new System.EventHandler(this.frmSatis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTf;
        private System.Windows.Forms.TextBox txtSf;
        private System.Windows.Forms.TextBox txtMik;
        private System.Windows.Forms.TextBox txtUAd;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnSatısIp;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblGenelToplam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSatLis;
        private System.Windows.Forms.Button btnUlis;
        private System.Windows.Forms.Button btnUek;
        private System.Windows.Forms.Button btnMusLis;
        private System.Windows.Forms.Button btnMusEk;
        private System.Windows.Forms.Button btnMarka;
        private System.Windows.Forms.Button btnKat;
    }
}

