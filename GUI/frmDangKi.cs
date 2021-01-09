using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;

namespace GUI
{
    public partial class frmDangKi : DevExpress.XtraEditors.XtraForm
    {
        QLDangNhap qldn = new QLDangNhap();
        public frmDangKi()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string cmnd = txtDangNhap.Text.ToString();
            string pass = txtPass.Text.ToString();
            string sdt = txtSDT.Text.ToString();
            string diachi = txtDiaChi.Text.ToString();
            string hoten = txtHoten.Text.ToString();
            if (cmnd != string.Empty && pass != string.Empty && sdt != null && diachi != string.Empty && hoten != string.Empty)
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn đăng kí tài khoản  " + cmnd + "?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    // thêm dịch vụ
                    if (qldn.KiemTraTrung(txtDangNhap.Text.ToString()) == true)
                    {
                        qldn.DangKiTaiKhoang(cmnd, pass,sdt,diachi,hoten);
                        MessageBox.Show("Đăng kí thành công tài khoản " + cmnd, "Thông báo");
                        this.Close();
                        frmDangNhap frm = new frmDangNhap();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại", "Thông báo");
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn Thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                frmDangNhap frm = new frmDangNhap();
                frm.ShowDialog();
                this.Close();
            }
        }
    }
}