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

namespace CRUDMahasiswaADO
{
    public partial class Report : Form
    {
        static string connectionString = "Data Source=DESKTOP-NJJMEDV\\DZAKWAN;Initial Catalog=DBAkademikADO;User ID=sa;Password=Akunawan2006";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlDataAdapter da;
        DataTable dtMahasiswa;
        string prodi { get; set; }
        DateTime tglmasuk { get; set; }

        // Langkah 16 - ubah constructor pakai DAL
        DAL dbLogic = new DAL();

        public Report(string Prodi, DateTime TglMasuk)
        {
            InitializeComponent();

            prodi = Prodi;
            tglmasuk = TglMasuk;

            try
            {
                DataTable dtMahasiswa = dbLogic.getDataRekap(prodi, tglmasuk);

                LaporanMahasiswa listMahasiswa = new LaporanMahasiswa();
                listMahasiswa.SetDataSource(dtMahasiswa);
                crystalReportViewer1.ReportSource = listMahasiswa;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                //simpanLog(ex.Message);
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }
    }
}