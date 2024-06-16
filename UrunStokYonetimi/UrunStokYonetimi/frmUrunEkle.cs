using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace UrunStokYonetimi
{
    public partial class frmUrunEkle : Form
    {
        public frmUrunEkle()
        {
            InitializeComponent();
        }

        SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;Encrypt=True;TrustServerCertificate=True");

        private bool durum;

        private void BarkodEngelle()
        {
            durum = true;
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select barkodno from urun where barkodno = @barkodno", sqlconnection);
            command.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows || string.IsNullOrWhiteSpace(txtBarkod.Text))
            {
                durum = false;
            }
            sqlconnection.Close();
        }

        private void Kategori_getir()
        {
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select * from kategoribilgileri", sqlconnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbKat.Items.Add(reader["kategori"].ToString());
            }
            sqlconnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMarka.Items.Clear();
            cmbMarka.Text = "";
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select * from markabilgileri where kategori='" + cmbKat.SelectedItem + "'", sqlconnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbMarka.Items.Add(reader["marka"].ToString());
            }
            sqlconnection.Close();
        }

        private void frmUrunEkle_Load(object sender, EventArgs e)
        {
            Kategori_getir();
        }

        private void btnYekle_Click(object sender, EventArgs e)
        {

            BarkodEngelle();
            if (durum == true)
            {
                sqlconnection.Open();
                SqlCommand command = new SqlCommand("insert into urun(barkodno,kategori,marka,urunadi,miktar,alisfiyati,satisfiyati,tarih) values(@barkodno,@kategori,@marka,@urunadi,@miktar,@alisfiyati,@satisfiyati,@tarih)", sqlconnection);

                command.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
                command.Parameters.AddWithValue("@kategori", cmbKat.Text);
                command.Parameters.AddWithValue("@marka", cmbMarka.Text);
                command.Parameters.AddWithValue("@urunadi", txtUrunAdi.Text);
                command.Parameters.AddWithValue("@miktar", int.Parse(txtMik.Text));
                command.Parameters.AddWithValue("@alisfiyati", double.Parse(txtAf.Text));
                command.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSf.Text));
                command.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                command.ExecuteNonQuery();
                sqlconnection.Close();
                cmbMarka.Items.Clear();
                MessageBox.Show("Ürün eklendi.");
            }
            else
            {
                MessageBox.Show("Bu barkod kayıtlı.");
            }

            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox) item.Text = "";
                if (item is ComboBox) item.Text = "";
            }
        }

        private void barkodTxt_TextChanged(object sender, EventArgs e)
        {
            if (barkodTxt.Text == "")
            {
                lblMiktar.Text = "";
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox) item.Text = "";
                }
                return;
            }

            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select * from urun where barkodno like '" + barkodTxt.Text + "'", sqlconnection);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                kategoriTxt.Text = read["kategori"].ToString();
                markaTxt.Text = read["marka"].ToString();
                urunadiTxt.Text = read["urunadi"].ToString();
                lblMiktar.Text = read["miktar"].ToString();
                afTxt.Text = read["alisfiyati"].ToString();
                sftxt.Text = read["satisfiyati"].ToString();
            }
            sqlconnection.Close();
        }

        private void btnVekle_Click(object sender, EventArgs e)
        {
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("update urun set miktar = miktar + @miktar where barkodno = @barkodno", sqlconnection);
            command.Parameters.AddWithValue("@miktar", int.Parse(txtMik.Text));
            command.Parameters.AddWithValue("@barkodno", barkodTxt.Text);
            command.ExecuteNonQuery();
            sqlconnection.Close();

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox) item.Text = "";
            }

            MessageBox.Show("Var olan ürüne ekleme yapıldı.");
        }
    }
}
