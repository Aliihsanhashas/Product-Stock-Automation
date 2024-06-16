using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace UrunStokYonetimi
{
    public partial class frmMusteriEkle : Form
    {
        public frmMusteriEkle()
        {
            InitializeComponent();
        }
        //Sql bağlantımızı yaptıpımız kısım.
        private SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;TrustServerCertificate=True;"); 

        private void frmMusteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("insert into Musteri(tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)", sqlConnection);
            command.Parameters.AddWithValue("@tc", txtTc.Text);
            command.Parameters.AddWithValue("@adsoyad", txtAdSoy.Text);
            command.Parameters.AddWithValue("@telefon", txtTel.Text);
            command.Parameters.AddWithValue("@adres", txtAdr.Text);
            command.Parameters.AddWithValue("@email", txtEmail.Text);
            command.ExecuteNonQuery(); // Ekleme işlemini onaylıyoruz.
            sqlConnection.Close();
            MessageBox.Show("Müşteri Kayıt Edildi.");
            foreach (Control item in this.Controls)  
            {
                //Ekleme yapıldıktan sonra textBoxları temizliyoruz.
                if (item is TextBox) item.Text = "";
            }
        }
    }
}
