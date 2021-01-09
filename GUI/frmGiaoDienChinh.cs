using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using BLL;

namespace GUI
{
    public partial class frmGiaoDienChinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmGiaoDienChinh()
        {
            InitializeComponent();
        }
        public string TenNV { get; set; }
        public string TenDN { get; set; }

        public string SDT { get; set; }

        private void frmGiaoDienChinh_Load(object sender, EventArgs e)
        {
            loaddata();
            itemTenDangNhap.Caption = TenDN;
            itemTenChuTro.Caption = TenNV;
            itemSDT.Caption = SDT;
        }
        public void loaddata()
        {
            DongTatCaCacTab();
            ///baraa.Caption = TTin;
            
            frmTrangChu xttp = new frmTrangChu();
            xttp.tenDN = TenDN;
            xttp.tenCT = TenNV;
            xttp.sdt = SDT;
            xttp.MdiParent = this;
            xttp.Show();
        }

        public void DongTatCaCacTab()
        {
            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 0; i--)
            {
                xtraTabbedMdiManager1.Pages[i].MdiChild.Close();
            }
        }

        public void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            loaddata();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn Thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                frmDangNhap frm = new frmDangNhap();
                this.Hide();
                frm.ShowDialog();
                //this.Close();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLPhong qlp = new frmQLPhong();
            qlp.MdiParent = this;
            qlp.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLKhachTro frmkt = new frmQLKhachTro();
            frmkt.MdiParent = this;
            frmkt.Show();
        }

        private void btnDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMatKhau frmdnk = new frmDoiMatKhau();
            frmdnk.TenDN = TenDN;
            frmdnk.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLDichVu frmdv = new frmQLDichVu();
            frmdv.MdiParent = this;
            frmdv.Show();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmThietBi frm = new frmThietBi();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}