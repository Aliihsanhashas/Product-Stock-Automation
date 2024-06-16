using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UrunStokYonetimi
{
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
            txtTc.TextChanged += new EventHandler(txtTc_TextChanged);
            txtBarkod.TextChanged += new EventHandler(txtBarkod_TextChanged);
       
        }

        SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;Encrypt=True;TrustServerCertificate=True");
        DataSet ds = new DataSet();
        bool durum;

        private void Barkod_Kontrol()
        {
            durum = true;
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select * from sepet",sqlconnection);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                if (txtBarkod.Text == read["barkodno"].ToString())
                {
                    durum = true;
                }
            }
            sqlconnection.Close();
        }
        

        private void Sepet_Listele()
        {
            try
            {
                sqlconnection.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM sepet", sqlconnection);
                ds.Clear();
                adtr.Fill(ds, "sepet");
                dataGridView1.DataSource = ds.Tables["sepet"];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
            
        }

        private void Tc_Arama()
        {
            if (string.IsNullOrEmpty(txtTc.Text))
            {
                txtAdSoyad.Text = "";
                txtTel.Text = "";
                return;
            }

            try
            {
                sqlconnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Musteri WHERE tc LIKE @tc", sqlconnection))
                {
                    command.Parameters.AddWithValue("@tc", "%" + txtTc.Text + "%");
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            txtAdSoyad.Text = read["adsoyad"].ToString();
                            txtTel.Text = read["telefon"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        private void Barkod_Ara()
        {
            if (string.IsNullOrEmpty(txtBarkod.Text))
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox && item != txtMik)
                    {
                        item.Text = "";
                    }
                }
                return;
            }

            try
            {
                sqlconnection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM urun WHERE barkodno LIKE @barkodno", sqlconnection))
                {
                    command.Parameters.AddWithValue("@barkodno", "%" + txtBarkod.Text + "%");
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            txtUAd.Text = read["urunadi"].ToString();
                            txtSf.Text = read["satisfiyati"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        private void Sepete_Ekle()
        {
            sqlconnection.Open();
            SqlCommand command;
            if (Barkod_Zaten_Eklendi())
            {
                command = new SqlCommand("UPDATE sepet SET miktar = miktar + @miktar, toplamfiyat = miktar * satisfiyati WHERE barkodno = @barkodno", sqlconnection);
            }
            else
            {
                command = new SqlCommand("INSERT INTO sepet(tc, adsoyad, telefon, barkodno, urunadi, miktar, satisfiyati, toplamfiyat, tarih) VALUES (@tc, @adsoyad, @telefon, @barkodno, @urunadi, @miktar, @satisfiyati, @toplamfiyat, @tarih)", sqlconnection);
            }

            command.Parameters.AddWithValue("@tc", txtTc.Text);
            command.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            command.Parameters.AddWithValue("@telefon", txtTel.Text);
            command.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
            command.Parameters.AddWithValue("@urunadi", txtUAd.Text);
            command.Parameters.AddWithValue("@miktar", int.Parse(txtMik.Text));
            command.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSf.Text));
            command.Parameters.AddWithValue("@toplamfiyat", double.Parse(txtTf.Text));
            command.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            command.ExecuteNonQuery();
            sqlconnection.Close();
            txtMik.Text = "1";
            ds.Tables["sepet"].Clear();
            Sepet_Listele();
            hesapla();
            Temizle();
        }

        private bool Barkod_Zaten_Eklendi()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM sepet WHERE barkodno = @barkodno", sqlconnection);
            command.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }

        private void Temizle()
        {
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox textBox && item != txtMik)
                {
                    textBox.Text = "";
                }
            }
        }

        private void Urun_sil()
        {
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("delete from sepet where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", sqlconnection);
            command.ExecuteNonQuery();
            sqlconnection.Close();
            MessageBox.Show("Ürün silindi");
            ds.Tables["sepet"].Clear();
            Sepet_Listele();
            hesapla();
        }


        private void UrunSatis_Iptal()
        {
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("delete from sepet ", sqlconnection);
            command.ExecuteNonQuery();
            sqlconnection.Close();
            MessageBox.Show("Ürün silindi");
            ds.Tables["sepet"].Clear();
            Sepet_Listele();
            hesapla();
        }

        //Genel toplam hesaplayan metot.
        private void hesapla()
        {
            try
            {
                sqlconnection.Open();
                SqlCommand command = new SqlCommand("select sum(toplamfiyat) from sepet", sqlconnection);
                lblGenelToplam.Text = command.ExecuteScalar() + "TL";
            }
            catch (Exception ex) { }
            }



        private void button5_Click(object sender, EventArgs e)
        {
            frmMusteriEkle frmMusteriEkle = new frmMusteriEkle();
            frmMusteriEkle.ShowDialog();
        }

        private void btnMusLis_Click(object sender, EventArgs e)
        {
            frmMusteriListele frm = new frmMusteriListele();
            frm.ShowDialog();
        }

        private void btnUek_Click(object sender, EventArgs e)
        {
            frmUrunEkle frmUrun = new frmUrunEkle();
            frmUrun.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategori frmKategori = new frmKategori();
            frmKategori.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMarka frmMarka = new frmMarka();
            frmMarka.ShowDialog();
        }

        private void btnUlis_Click(object sender, EventArgs e)
        {
            frmUrunListele frmUrun = new frmUrunListele();
            frmUrun.ShowDialog();
        }

        private void frmSatis_Load(object sender, EventArgs e)
        {
            Sepet_Listele();
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            Tc_Arama();
        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            Barkod_Ara();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Sepete_Ekle();
        }

        //Sepet fiyatı hesaplıyoruz.
        private void txtMik_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTf.Text = (double.Parse(txtMik.Text) * double.Parse(txtSf.Text)).ToString();
            }
            catch (Exception ex)
            {
               
            }
        }

        //Sepet fiyatı hesaplıyoruz.
        private void txtSf_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTf.Text = (double.Parse(txtMik.Text) * double.Parse(txtSf.Text)).ToString();
            }
            catch (Exception ex)
            {
                
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Urun_sil();
        }

        private void btnSatısIp_Click(object sender, EventArgs e)
        {
            UrunSatis_Iptal();
        }

        private void btnSatLis_Click(object sender, EventArgs e)
        {
            frmSatisListele frmSatisListele = new frmSatisListele();
            frmSatisListele.ShowDialog();
        }

        private void btnSat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (sqlconnection.State == ConnectionState.Closed)
                    {
                        sqlconnection.Open();
                    }

                    SqlCommand command = new SqlCommand("INSERT INTO satis(tc, adsoyad, telefon, barkodno, urunadi, miktar, satisfiyat, toplamfiyat, tarih) VALUES (@tc, @adsoyad, @telefon, @barkodno, @urunadi, @miktar, @satisfiyat, @toplamfiyat, @tarih)", sqlconnection);

                    command.Parameters.AddWithValue("@tc", txtTc.Text);
                    command.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                    command.Parameters.AddWithValue("@telefon", txtTel.Text);
                    command.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                    command.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                    command.Parameters.AddWithValue("@miktar", int.Parse(dataGridView1.Rows[i].Cells["miktar"].Value.ToString()));
                    command.Parameters.AddWithValue("@satisfiyat", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                    command.Parameters.AddWithValue("@toplamfiyat", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyat"].Value.ToString()));
                    command.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    command.ExecuteNonQuery();

                    SqlCommand command2 = new SqlCommand("update urun set miktar = miktar - @miktar where barkodno = @barkodno", sqlconnection);
                    command2.Parameters.AddWithValue("@miktar", int.Parse(dataGridView1.Rows[i].Cells["miktar"].Value.ToString()));
                    command2.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                    command2.ExecuteNonQuery();
                }

                SqlCommand command3 = new SqlCommand("delete from sepet", sqlconnection);
                command3.ExecuteNonQuery();

                MessageBox.Show("Satış başarılı");

                ds.Tables["sepet"].Clear();
                Sepet_Listele();
                hesapla();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (sqlconnection.State == ConnectionState.Open)
                {
                    sqlconnection.Close();
                }
            }
        }

    }
}
