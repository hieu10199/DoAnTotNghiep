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
    public partial class frmTraPhong : DevExpress.XtraEditors.XtraForm
    {
        QLXemTTPhongTro qlxemttpt = new QLXemTTPhongTro();
        QLTraPhongcs qltp = new QLTraPhongcs();
        String maphong = null;
        String tenphong = null;
        public frmTraPhong(String ma, string ten)
        {


            maphong = ma;
            tenphong = ten;
            InitializeComponent();
            txtPhong.Text = tenphong;
            txtCMND.Text = qltp.LayCMND(maphong, "Trưởng phòng ");
            txtNgayBaoTra.Text = DateTime.Now.ToString();

            DateTime newdayy = DateTime.Now.AddDays(10);
            txtNgayTraDuKien.Text = newdayy.ToString();

            string trangthai = qlxemttpt.LayTrangThai(maphong);
            if (trangthai.Trim() == "Đã báo trả phòng")
            {
                txtMaTP.Text = qltp.LayMaTP(maphong);
            };
           

            txtPhong.Enabled = false;
            txtCMND.Enabled = false;
            txtNgayBaoTra.Enabled = false;
            txtNgayTraDuKien.Enabled = false;
            txtNgayTra.Text = "";
            string lastID = qltp.GetLastID();
            txtMaTP.Text = GenAuto.CreateID("O", lastID);
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

        private void btnBaoTraPhong_Click(object sender, EventArgs e)
        {
            string matp = txtMaTP.Text.ToString();
            string cmnd = txtCMND.Text.ToString();
            DateTime ngaybaotra = txtNgayBaoTra.Value;
            DateTime ngaytdk = txtNgayTraDuKien.Value;
            string phong = maphong;
            if (matp != string.Empty && cmnd != string.Empty && ngaybaotra != null && ngaytdk != null && cmnd != string.Empty && phong != null)
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có xác nhận báo trả phòng  " + matp + "?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (qltp.KiemTraTrung(txtMaTP.Text.ToString()) == true)
                    {
                        qltp.themTraPhong(matp, cmnd, phong, ngaybaotra, ngaytdk);
                        MessageBox.Show("Xác nhận thành công" + matp, "Thông báo");
                        qltp.CapNhatPhong(maphong, "Đã báo trả phòng");
                        qltp.chungphong(maphong, "Chuẩn bị trả phòng");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Mã Đã Tồn Tại", "Thông báo");
                    }
                }
            }
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string matp = txtMaTP.Text.ToString();
            //    DateTime nt = txtNgayTra.Value;
            //    string note = txtGhiChu.Text.ToString();
            //    decimal tiendenbu = Convert.ToDecimal(txtSoTienDenBu.Text.ToString());
            //    decimal hoantien = Convert.ToDecimal(txtTienHoanCoc.Text.ToString());
            //    DialogResult result;
            //    result = MessageBox.Show("Bạn Có Muốn trả phòng " + tenphong + " ?",
            //        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    if (result == DialogResult.Yes)
            //    {
            //        qltp.updateTraPhong(matp, nt, hoantien, tiendenbu, note);
            //        MessageBox.Show("Trả phòng Thành Công " + tenphong, "Thông Báo");
            //        qltp.CapNhatPhong(maphong, "Trống");

            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Có Vấn Đề Trong Việc trả phòng  " + tenphong);
            //}
        }
    }
}