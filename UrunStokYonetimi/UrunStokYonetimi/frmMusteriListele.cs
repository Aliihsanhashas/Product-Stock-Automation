using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UrunStokYonetimi
{
    public partial class frmMusteriListele : Form
    {
        public frmMusteriListele()
        {
            InitializeComponent();
        }

        private SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;TrustServerCertificate=True;");
        DataSet ds = new DataSet(); //Kayıtları geçici olarak tutmak için.


        private void frmMusteriListele_Load(object sender, EventArgs e)
        {
            Kayıt_Göster();

        }

        //Kayıtları datagridview getirecek olan metot.
        private void Kayıt_Göster()
        {
            sqlConnection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM Musteri", sqlConnection);
            adtr.Fill(ds, "Musteri");
            dataGridView1.DataSource = ds.Tables["Musteri"];
            sqlConnection.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtAdSoy.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtAdr.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            Musteri_Guncelle();
        }

        //Müsteri Güncelleme metodu
        private void Musteri_Guncelle()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE Musteri SET adsoyad=@adsoyad, telefon=@telefon, adres=@adres, email=@email WHERE tc=@tc", sqlConnection);
            command.Parameters.AddWithValue("@tc", txtTc.Text);
            command.Parameters.AddWithValue("@adsoyad", txtAdSoy.Text);
            command.Parameters.AddWithValue("@telefon", txtTel.Text);
            command.Parameters.AddWithValue("@adres", txtAdr.Text);
            command.Parameters.AddWithValue("@email", txtEmail.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            ds.Tables["Musteri"].Clear(); // Her işlemden sonra tabloyu temizleyip yeni kayıtlar gelecek.
            Kayıt_Göster();
            MessageBox.Show("Müşteri Kayıt güncellendi.");
            foreach (Control item in this.Controls)
            {
                // Ekleme yapıldıktan sonra textBoxları temizliyoruz.
                if (item is TextBox) item.Text = "";
            }
        }


        //Silme buton
        private void button1_Click(object sender, EventArgs e)
        {
            Musteri_Sil();
        }

        private void Musteri_Sil()
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("delete from Musteri where tc='" + dataGridView1.CurrentRow.Cells["tc"].Value.ToString() + "'", sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            ds.Tables["Musteri"].Clear();
            Kayıt_Göster();
            MessageBox.Show("kayıt Silindi");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Tc_Arama();

        }

        private void Tc_Arama()
        {
            DataTable dt = new DataTable();
            sqlConnection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM Musteri WHERE tc like '%" + textBox1.Text + "%'", sqlConnection);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }
    }
}
