using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace legiabao_onthi_vetau
{
    public partial class FormQuanLiVeTau : Form
    {
        public FormQuanLiVeTau()
        {
            InitializeComponent();
        }

        private void FormQuanLiVeTau_Load(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Họ Tên: Lê Gia Bảo \n Lớp: CN21TC3.1", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThongTinVeTau f = new FormThongTinVeTau();
            f.ShowDialog();
        }
    }
}
