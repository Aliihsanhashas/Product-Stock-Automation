using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UrunStokYonetimi
{
    public partial class frmUrunListele : Form
    {
        public frmUrunListele()
        {
            InitializeComponent();
        }

        private SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;Encrypt=True;TrustServerCertificate=True");
        DataSet dataSet = new DataSet();

        private void frmUrunListele_Load(object sender, EventArgs e)
        {
            Urunleri_Listele();
            Kategori_getir();
        }

        private void Urunleri_Listele()
        {
            try
            {
                sqlconnection.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM urun", sqlconnection);
                dataSet.Clear(); 
                adtr.Fill(dataSet, "urun");
                dataGridView1.DataSource = dataSet.Tables["urun"];
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

        private void Kategori_getir()
        {
            cmbKat.Items.Clear(); 

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;Encrypt=True;TrustServerCertificate=True"))
                {
                    sqlConnection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM kategoribilgileri", sqlConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbKat.Items.Add(reader["kategori"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            barkodTxt.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
            kategoriTxt.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            markaTxt.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
            urunadiTxt.Text = dataGridView1.CurrentRow.Cells["urunadi"].Value.ToString();
            mikTxt.Text = dataGridView1.CurrentRow.Cells["miktar"].Value.ToString();
            afTxt.Text = dataGridView1.CurrentRow.Cells["alisfiyati"].Value.ToString();
            sftxt.Text = dataGridView1.CurrentRow.Cells["satisfiyati"].Value.ToString();
        }

        private void btnGun_Click(object sender, EventArgs e)
        {
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("UPDATE urun SET urunadi=@urunadi, miktar=@miktar, alisfiyati=@alisfiyati, satisfiyati=@satisfiyati WHERE barkodno=@barkodno", sqlconnection);
            command.Parameters.AddWithValue("@barkodno", barkodTxt.Text);
            command.Parameters.AddWithValue("@urunadi", urunadiTxt.Text);
            command.Parameters.AddWithValue("@miktar", int.Parse(mikTxt.Text));
            command.Parameters.AddWithValue("@alisfiyati", double.Parse(afTxt.Text));
            command.Parameters.AddWithValue("@satisfiyati", double.Parse(sftxt.Text));
            command.ExecuteNonQuery(); 
            sqlconnection.Close();
            dataSet.Tables["urun"].Clear(); //güncelleme sonrası tabloyu yenisiyle değiştirmek için.
            Urunleri_Listele();
            MessageBox.Show("Güncelleme yapıldı.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (barkodTxt.Text != "")
            {
                sqlconnection.Open();
                SqlCommand command = new SqlCommand("UPDATE urun SET kategori=@kategori, marka=@marka WHERE barkodno=@barkodno", sqlconnection);
                command.Parameters.AddWithValue("@barkodno", barkodTxt.Text);
                command.Parameters.AddWithValue("@kategori", cmbKat.Text);
                command.Parameters.AddWithValue("@marka", cmbMar.Text);
                command.ExecuteNonQuery(); 
                sqlconnection.Close();

                MessageBox.Show("Güncelleme yapıldı.");
                dataSet.Tables["urun"].Clear(); //güncelleme sonrası tabloyu yenisiyle değiştirmek için.
                Urunleri_Listele();
            }
            else
            {
                MessageBox.Show("Barkod No yazılı değil.");
            }

            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void cmbKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMar.Items.Clear();
            cmbMar.Text = "";
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select * from markabilgileri where kategori='" + cmbKat.SelectedItem + "'", sqlconnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbMar.Items.Add(reader["marka"].ToString());
            }
            sqlconnection.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Urun_sil();
        }

        private void Urun_sil()
        {
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("delete from urun where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", sqlconnection);
            command.ExecuteNonQuery();
            sqlconnection.Close();
            dataSet.Tables["urun"].Clear();
            Urunleri_Listele();
            MessageBox.Show("kayıt Silindi");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            barkod_ara();
        }

        private void barkod_ara()
        {
            DataTable dt = new DataTable();
            sqlconnection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM urun WHERE barkodno like '%" + textBox1.Text + "%'", sqlconnection);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconnection.Close();
        }
    }
}
