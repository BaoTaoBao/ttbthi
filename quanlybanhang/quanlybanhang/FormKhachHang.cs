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

namespace quanlybanhang
{
    public partial class FormKhachHang : Form
    {
        SqlConnection Kn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True");                                                                                                                                                                                                                                                                                                                                                                                      //Tăng Tấn Bảo CN21TC3.1
        SqlDataAdapter adap = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        SqlCommand cmd = new SqlCommand();
        bool them = false;
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLBHDataSet3.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.qLBHDataSet3.KHACHHANG);
            databin();
        }
        private void databin()
        {
            string sql = "SELECT * FROM KHACHHANG";
            adap = new SqlDataAdapter(sql, Kn);
            ds.Clear();
            adap.Fill(ds);
            bs.DataSource = ds.Tables[0];
            txtmkh.DataBindings.Clear();
            txttct.DataBindings.Clear();
            txttgd.DataBindings.Clear();
            txtdc.DataBindings.Clear();
            txtemail.DataBindings.Clear();
            txtdienthoai.DataBindings.Clear();
            txtfax.DataBindings.Clear();

            txtmkh.DataBindings.Add("text", bs, "MaKhachHang", true);
            txttct.DataBindings.Add("text", bs, "TenCongTy", true);
            txttgd.DataBindings.Add("text", bs, "TenGiaoDich", true);
            txtdc.DataBindings.Add("text", bs, "DiaChi", true);
            txtemail.DataBindings.Add("text", bs, "Email", true);
            txtdienthoai.DataBindings.Add("text", bs, "DienThoai", true);
            txtfax.DataBindings.Add("text", bs, "fax", true);
            dataGridView1.DataSource = bs;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmkh.Clear();
            txttct.Clear();
            txttgd.Clear();
            txtdc.Clear();
            txtemail.Clear();
            txtdienthoai.Clear();
            txtfax.Clear();
            block(false);

            txtfax.Focus();
            txtmkh.Enabled = (true);
            txttct.Enabled = (true);
            txttgd.Enabled = (true);
            txtdc.Enabled = (true);
            txtemail.Enabled = (true);
            txtdienthoai.Enabled = (true);
            txtfax.Enabled = (true);
            them = true;     
            }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtmkh.Enabled = (true);
            txttct.Enabled = (true);
            txttgd.Enabled = (true);
            txtdc.Enabled = (true);
            txtemail.Enabled = (true);
            txtdienthoai.Enabled = (true);
            txtfax.Enabled = (true);
            block(false);
          
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                if (txtmkh.Text == string.Empty)
                {
                    MessageBox.Show("Hãy nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmkh.Focus();
                    return;
                }
                if (txttct.Text == string.Empty)
                {
                    MessageBox.Show("Hãy nhập tên công ty", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttct.Focus();
                    return;
                }
                //if (kiemtratrungma() == true)
                //{
                //    MessageBox.Show("Mã khách hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (kiemtratrungten() == true)
                {
                    MessageBox.Show("Tên khách hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                cmd = new SqlCommand(@"INSERT INTO [dbo].[KHACHHANG] ([MaKhachHang],[TenCongTy],[TenGiaoDich],[DiaChi],[Email],[DienThoai],[Fax]) VALUES (" + txtmkh.Text + ", N'" + txttct.Text + "', N'" + txttgd.Text + "', N'" + txtdc.Text + "', N'" + txtemail.Text + "', '" + txtdienthoai.Text + "', '" + txtfax.Text + "')");
                if (Kn.State == ConnectionState.Closed)Kn.Open();
                cmd.Connection = Kn;
            }
            else
            {
                
                cmd = new SqlCommand(@"UPDATE [dbo].[KHACHHANG] SET TenCongTy = N'" + txttct.Text + "', TenGiaoDich = N'" + txttgd.Text + "', DiaChi = N'" + txtdc.Text + "', Email = N'" + txtemail.Text + "',DienThoai = '" + txtdienthoai.Text + "',Fax = '" + txtfax.Text + "' WHERE MaKhachHang = " + txtmkh.Text + "");
                if (Kn.State == ConnectionState.Closed) Kn.Open();
                cmd.Connection = Kn;
            }
            
            int KQ = cmd.ExecuteNonQuery();
            if (KQ != 0)
            {
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormKhachHang_Load(sender, e);
            }
            else MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Kn.Close();
            block(true);
        }
             private bool kiemtratrungten()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT count(*)
            FROM [dbo].[KHACHHANG] WHERE tencongty = N'" + txttct.Text + "'");
            cmd.Connection = Kn;
            if (Kn.State == ConnectionState.Closed) Kn.Open();
            int Kq = (int)cmd.ExecuteScalar();
            if (Kq != 0) return true;
            return false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chác muốn xóa", "chú ý",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (kiemtramatheotenhoadon() == true)
                {
                    MessageBox.Show("có khách hàng thuộc loại này không thể xóa", "chú ý",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    SqlCommand cmd = new SqlCommand(@"DELETE [dbo].[KHAChHANG] WHERE MaKHachHang = '" + txtmkh.Text + "' AND TenCongTy = N'" + txttct.Text + "'");                                                                                                                                                                                                                                                                      //Tăng Tấn Bảo
                    if (Kn.State == ConnectionState.Closed) Kn.Open();
                    cmd.Connection = Kn;
                    int Kq = cmd.ExecuteNonQuery();
                    if (Kq != 0)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormKhachHang_Load(sender, e);
                    }
                    else MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Kn.Close();
                }
            }
        }
        private void block(bool khoa)
        {
            btnthem.Visible = (khoa);
            btnsua.Visible = (khoa);
            btnxoa.Visible = (khoa);
            btnluu.Visible = (!khoa);
            btnboqua.Visible = (!khoa);
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            FormKhachHang_Load(sender, e);
            block(true);
        }

        //private bool kiemtratrungma()
        //{
        //    SqlCommand cmd = new SqlCommand(@"SELECT count(*)
        //    FROM [dbo].[khachhang] WHERE MAkhachhang = N'" + txtmkh.Text + "'");
        //    cmd.Connection = Kn;
        //    if (Kn.State == ConnectionState.Closed) Kn.Open();
        //    int Kq = (int)cmd.ExecuteScalar();
        //    if (Kq != 0) return true;
        //    return false;
        //}
        private bool kiemtramatheotenhoadon()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT count(*)
            FROM [dbo].[hoadon] WHERE MAKHACHHANG = N'" + txtmkh.Text + "'");
            cmd.Connection = Kn;
            if (Kn.State == ConnectionState.Closed) Kn.Open();
            int Kq = (int)cmd.ExecuteScalar();
            if (Kq != 0) return true;
            return false;
        }
    }
}
