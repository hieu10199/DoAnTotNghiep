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
using GUI;
using BLL;

namespace GUI
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        QLDangNhap qldn = new QLDangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public string TenNVDangChon { get; set; }
        public string TenTK { get; set; }

        public string SDTTK {get; set;}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tendn = txtUsername.TextValue;
            string pass = txtPassword.TextValue;
            if (qldn.LayTaiKhoan(tendn,pass) == 1)
            {
                TenNVDangChon = qldn.LayTenNV(txtUsername.TextValue, txtPassword.TextValue);
                SDTTK = qldn.LaySDT(txtUsername.TextValue, txtPassword.TextValue);
                TenTK = txtUsername.TextValue;
                MessageBox.Show("Đăng nhập thành công!");
                frmGiaoDienChinh frm = new frmGiaoDienChinh();
                frm.TenDN = TenTK;
                frm.TenNV = TenNVDangChon;
                frm.SDT = SDTTK;
                this.Hide();
                frm.ShowDialog();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn Thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            frmDangKi frm = new frmDangKi();
            frm.ShowDialog();
            this.Hide();
        }
    }
}