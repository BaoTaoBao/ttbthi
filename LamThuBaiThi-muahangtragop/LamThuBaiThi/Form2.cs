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

namespace LamThuBaiThi
{
    public partial class Form2 : Form
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=MuaHangTraGop;Integrated Security=True");
        SqlDataAdapter dap = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HienThiHopDong();
            HienThiComBoxKH();
            HienThiComBoxHH();
        }

        private void HienThiHopDong()
        {
            dap = new SqlDataAdapter("SELECT * FROM[dbo].[HOPDONG]", sqlcon);
            dap.Fill(ds);
            bs.DataSource = ds.Tables[0];
            txtSHD.DataBindings.Clear();
            txtSHD.DataBindings.Add("text", bs, "SOHD", true);
            NgayLap.DataBindings.Clear();
            NgayLap.DataBindings.Add("value", bs, "NGAYHD", true);
            textBoxTT.DataBindings.Clear();
            textBoxTT.DataBindings.Add("text", bs, "TRATRUOC", true);
            textBoxTHT.DataBindings.Clear();
            textBoxTHT.DataBindings.Add("text", bs, "TRAHANGTHANG", true);
            comboBoxKH.DataBindings.Clear();
            comboBoxKH.DataBindings.Add("selectedvalue", bs, "MAKH", true);
            comboBoxHH.DataBindings.Clear();
            comboBoxHH.DataBindings.Add("selectedvalue", bs, "MAHH", true);
            textBoxSLM.DataBindings.Clear();
            textBoxSLM.DataBindings.Add("text", bs, "SLMUA", true);
            textBoxKyHan.DataBindings.Clear();
            textBoxKyHan.DataBindings.Add("text", bs, "KYHAN", true);
            bindingNavigator1.BindingSource = bs;
        }

        private void txtSHD_TextChanged(object sender, EventArgs e)
        {
            KyTraThepHD();
            TinhTienTheoHD();
        }
        private void HienThiComBoxKH()
        {
            SqlDataAdapter adapKH = new SqlDataAdapter("SELECT * FROM KHACHHANG", sqlcon);
            DataTable dtbKH = new DataTable();
            adapKH.Fill(dtbKH);
            comboBoxKH.DisplayMember = "TENKH";
            comboBoxKH.ValueMember = "MAKH";
            comboBoxKH.DataSource = dtbKH;
        }
        private void HienThiComBoxHH()
        {
            SqlDataAdapter adapHH = new SqlDataAdapter("SELECT * FROM DMHH", sqlcon);
            DataTable dtbHH = new DataTable();
            adapHH.Fill(dtbHH);
            comboBoxHH.DisplayMember = "TENHH";
            comboBoxHH.ValueMember = "MAHH";
            comboBoxHH.DataSource = dtbHH;
        }
        private void KyTraThepHD()
        {
            SqlDataAdapter dapKT = new SqlDataAdapter(@"SELECT KYTRA, SOTIEN, SOHD FROM TRAGOP WHERE SOHD = N'"+ txtSHD.Text +"'", sqlcon);
            DataTable dtbKyTr = new DataTable();
            dapKT.Fill(dtbKyTr);
            dataGridView1.DataSource = dtbKyTr;
        }
        private void TinhTienTheoHD()
        {
            SqlDataAdapter dapKT = new SqlDataAdapter(@"SELECT sum(SOTIEN) FROM TRAGOP WHERE SOHD = N'" + txtSHD.Text + "'", sqlcon);
            DataTable dtbTTr = new DataTable();
            dapKT.Fill(dtbTTr);
            textBoxTongTien.Text = dtbTTr.Rows[0][0].ToString();
        }
    }
}
