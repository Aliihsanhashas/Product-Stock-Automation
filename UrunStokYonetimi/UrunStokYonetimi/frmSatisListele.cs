using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UrunStokYonetimi
{
    public partial class frmSatisListele : Form
    {
        public frmSatisListele()
        {
            InitializeComponent();
        }

        // SQL bağlantısı için bağlantı dizesi
        SqlConnection sqlconnection = new SqlConnection("Data Source=DESKTOP-V5LJ1GG;Initial Catalog=StokTakip;User ID=sa;Password=314159;Encrypt=True;TrustServerCertificate=True");

        // Veri kümesi oluşturma
        DataSet ds = new DataSet();

        // Satışları listeleyen metot
        private void Satıs_Listele()
        {
            try
            {
                // SQL bağlantısını açma
                sqlconnection.Open();

                // 'satis' tablosundan veri seçme ve veri adaptörüne yükleme
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM satis", sqlconnection);

                // Veri kümesini temizleme
                ds.Clear();

                // Veri kümesine veri doldurma
                adtr.Fill(ds, "satis");

                // DataGridView kontrolüne veri atama
                dataGridView1.DataSource = ds.Tables["satis"];
            }
            catch (Exception ex)
            {
                // Hata mesajı gösterme
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                // SQL bağlantısını kapatma
                sqlconnection.Close();
            }
        }

        // Form yüklendiğinde satışları listeleyen metotu çağırma
        private void frmSatisListele_Load(object sender, EventArgs e)
        {
            Satıs_Listele();
        }
    }
}
