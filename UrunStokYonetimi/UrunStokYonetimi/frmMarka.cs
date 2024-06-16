using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UrunStokYonetimi
{
    public partial class frmMarka : Form
    {
        public frmMarka()
        {
            InitializeComponent();
        }

        SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;Encrypt=True;TrustServerCertificate=True");

        private bool durum;

        private void MarkaKontrol()
        {
            durum = true;
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select * from markabilgileri", sqlconnection);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                if (comboBox1.Text == read["kategori"].ToString() && textBox1.Text == read["marka"].ToString())
                {
                    durum = false;
                    break;
                }
            }
            sqlconnection.Close();
        }

        private void frmMarka_Load(object sender, EventArgs e)
        {
            Kategori_getir();
        }

        private void Kategori_getir()
        {
            comboBox1.Items.Clear();
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select * from kategoribilgileri", sqlconnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["kategori"].ToString());
            }
            sqlconnection.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Kategori ve Marka boş bırakılamaz.");
                return;
            }

            MarkaKontrol();

            if (durum)
            {
                Marka_Ekle();
            }
            else
            {
                MessageBox.Show("Böyle bir marka mevcut.");
            }
        }

        private void Marka_Ekle()
        {
            sqlconnection.Open();
            SqlCommand cmd = new SqlCommand("insert into markabilgileri(kategori,marka) values(@kategori, @marka)", sqlconnection);
            cmd.Parameters.AddWithValue("@kategori", comboBox1.Text);
            cmd.Parameters.AddWithValue("@marka", textBox1.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.Close();
            textBox1.Text = "";
            comboBox1.Text = "";
            MessageBox.Show("Marka Eklendi");
        }
    }
}
