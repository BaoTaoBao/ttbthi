using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace legiabao_onthi_vetau
{
    public partial class FormThongTinVeTau : Form
    {
        SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QLVeTau;Integrated Security=True");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public FormThongTinVeTau()
        {
            InitializeComponent();
        }

        private void FormThongTinVeTau_Load(object sender, EventArgs e)
        {
            thuchiendatabinding();
            TaocboTuyenTau();
        }
        private void thuchiendatabinding()
        {
            adapter = new SqlDataAdapter("SELECT * FROM TAU", kn);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            txtMatau.DataBindings.Clear();
            txtMatau.DataBindings.Add("text", bs, "matau", true);
            txtTenTau.DataBindings.Clear();
            txtTenTau.DataBindings.Add("text", bs, "tentau", true);
            cboTuyenTau.DataBindings.Clear();
            cboTuyenTau.DataBindings.Add("selectedvalue", bs, "matuyen", true);
            txtGiaVe.DataBindings.Clear();
            txtGiaVe.DataBindings.Add("text", bs, "giave", true);
            bindingNavigator1.BindingSource = bs;
        }
        private void TaocboTuyenTau()
        {
            SqlDataAdapter adapterTT = new SqlDataAdapter("SELECT * FROM tuyentau ", kn);
            DataTable dtbTT = new DataTable();
            adapterTT.Fill(dtbTT);
            cboTuyenTau.DisplayMember = "tentuyen";
            cboTuyenTau.ValueMember = "matuyen";
            cboTuyenTau.DataSource = dtbTT;
        }
        private void Thongtintau()
        {
            SqlDataAdapter adapterKH = new SqlDataAdapter(@"SELECT        dbo.CHITIETVETAU.mave, dbo.LOAIVE.maloaive, dbo.CHITIETVETAU.ngaykh, dbo.KHACHHANG.makh, dbo.KHACHHANG.tenkh, dbo.KHACHHANG.dienthoai, 
                         dbo.TAU.giave + dbo.TAU.giave * dbo.LOAIVE.phuthu AS [gia ve thuc te]
FROM            dbo.TAU INNER JOIN
                         dbo.CHITIETVETAU ON dbo.TAU.matau = dbo.CHITIETVETAU.matau INNER JOIN
                         dbo.LOAIVE ON dbo.CHITIETVETAU.maloaive = dbo.LOAIVE.maloaive INNER JOIN
                         dbo.KHACHHANG ON dbo.CHITIETVETAU.makh = dbo.KHACHHANG.makh
WHERE        (dbo.CHITIETVETAU.matau = N'" + txtMatau.Text + "')", kn);
            DataTable dtbKH = new DataTable();
            adapterKH.Fill(dtbKH);
            dataGridView1.DataSource = dtbKH;
        }
        private void tong()
        {
            SqlDataAdapter adapterTONG = new SqlDataAdapter(@"SELECT        COUNT(dbo.KHACHHANG.makh) INNER JOIN
                         dbo.CHITIETVETAU ON dbo.TAU.matau = dbo.CHITIETVETAU.matau INNER JOIN
                         dbo.LOAIVE ON dbo.CHITIETVETAU.maloaive = dbo.LOAIVE.maloaive INNER JOIN
                         dbo.KHACHHANG ON dbo.CHITIETVETAU.makh = dbo.KHACHHANG.makh
WHERE        (dbo.CHITIETVETAU.mave = N'" + txtMatau.Text + "')", kn);
            DataTable dtbT = new DataTable();
            adapterTONG.Fill(dtbT);
            txtTSK.Text = dtbT.Rows[0][0].ToString();
        }

        private void txtMatau_TextChanged(object sender, EventArgs e)
        {
            Thongtintau();
            tong();
        }
    }
}