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

namespace legiabao_onthi_QLBH
{
    public partial class FormNhapXuatHangHoa : Form
    {
        SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=NXHangHoa;Integrated Security=True");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public FormNhapXuatHangHoa()
        {
            InitializeComponent();
        }

        private void FormNhapXuatHangHoa_Load(object sender, EventArgs e)
        {
            thuchiendatabinding();
            TaocboKhacHang();
        }
        private void thuchiendatabinding()
        {
            adapter = new SqlDataAdapter("SELECT * FROM NHAPXUAT", kn);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            txtSNX.DataBindings.Clear();
            txtSNX.DataBindings.Add("text", bs, "SoNX", true);
            txtLOAI.DataBindings.Clear();
            txtLOAI.DataBindings.Add("text", bs, "Loai", true);
            cboKH.DataBindings.Clear();
            cboKH.DataBindings.Add("SELECTEDVALUE", bs, "MaKH", true);
            datetime.DataBindings.Clear();
            datetime.DataBindings.Add("value", bs, "Ngay", true);
            bindingNavigator1.BindingSource = bs;
        }
        private void TaocboKhacHang()
        {
            SqlDataAdapter adapterKH = new SqlDataAdapter("SELECT * FROM KHACHHANG", kn);
            DataTable dtbKH = new DataTable();
            adapterKH.Fill(dtbKH);
            cboKH.DisplayMember = "HoTen";
            cboKH.ValueMember = "MaKH";
            cboKH.DataSource = dtbKH;
        }
        private void chitietnhapxuat()
        {
            SqlDataAdapter adapterCT = new SqlDataAdapter(@"SELECT        dbo.HANGHOA.TenHang, dbo.CTNHAPXUAT.DonGia, dbo.CTNHAPXUAT.SoLuong, dbo.CTNHAPXUAT.DonGia * dbo.CTNHAPXUAT.SoLuong AS Thanhtien, dbo.CTNHAPXUAT.SoNX FROM            dbo.CTNHAPXUAT INNER JOIN                   dbo.HANGHOA ON dbo.CTNHAPXUAT.MaHH = dbo.HANGHOA.MaHH 
WHERE        (dbo.CTNHAPXUAT.SoNX = N'" + txtSNX.Text + "')",kn);
            DataTable dtbCT = new DataTable();
            adapterCT.Fill(dtbCT);
            dataGridView1.DataSource = dtbCT;
        }
        private void tongtien()
        {
            SqlDataAdapter adapterTT = new SqlDataAdapter(@"SELECT        sum(dbo.CTNHAPXUAT.SoLuong * dbo.CTNHAPXUAT.DonGia) AS tongtien
FROM            dbo.CTNHAPXUAT INNER JOIN
                         dbo.HANGHOA ON dbo.CTNHAPXUAT.MaHH = dbo.HANGHOA.MaHH
WHERE (dbo.CTNHAPXUAT.SoNX = N'"+ txtSNX.Text +"')",kn);
            DataTable dtbTT = new DataTable();
            adapterTT.Fill(dtbTT);
            txtTongTien.Text = dtbTT.Rows[0][0].ToString();
        }
        private void txtSNX_TextChanged(object sender, EventArgs e)
        {
            chitietnhapxuat();
            tongtien();
        }
    }
}
