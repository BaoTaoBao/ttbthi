using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace legiabao_onthi_QLBH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Họ Tên: LÊ GIA BẢO \n Lớp: CN21TC3.1", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sốNhậpXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhapXuatHangHoa f = new FormNhapXuatHangHoa();
            f.ShowDialog();
        }
    }
}
