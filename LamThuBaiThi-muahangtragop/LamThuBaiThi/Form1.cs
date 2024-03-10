using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamThuBaiThi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Họ tên: Nguyễn Hoài An \n Lớp: 12A13", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 F = new Form2();
            F.Show();
        }
    }
}
