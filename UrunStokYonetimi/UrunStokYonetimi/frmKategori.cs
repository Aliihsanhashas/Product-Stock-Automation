using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UrunStokYonetimi
{
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }

        SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;Encrypt=True;TrustServerCertificate=True");

        private bool durum;

        //ayni kategoriden ekleme yapamayacagiz bunu sağlıyor.
        private void KategoriKontrol()
        {
            durum = true;
            sqlconnection.Open();
            SqlCommand command = new SqlCommand("select * from kategoribilgileri where kategori = @kategori", sqlconnection);
            command.Parameters.AddWithValue("@kategori", textBox1.Text);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                durum = false;
            }
            sqlconnection.Close();
        }

        private void frmKategori_Load(object sender, EventArgs e)
        {
            // Load event logic if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KategoriKontrol();
            if (durum)
            {
                Kategori_Ekle();
            }
            else
            {
                MessageBox.Show("Böyle bir kategori mevcut veya kategori ismi boş.");
            }
            textBox1.Text = "";
        }

        private void Kategori_Ekle()
        {
            sqlconnection.Open();
            SqlCommand cmd = new SqlCommand("insert into kategoribilgileri(kategori) values(@kategori)", sqlconnection);
            cmd.Parameters.AddWithValue("@kategori", textBox1.Text);
            cmd.ExecuteNonQuery();
            sqlconnection.Close();
            textBox1.Text = "";
            MessageBox.Show("Kategori Eklendi");
        }
    }
}
