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
    public partial class frmChiTietDV : DevExpress.XtraEditors.XtraForm
    {
        QLChhiTietDV ctdv = new QLChhiTietDV();
        string maphong = null;
        string tenphong = null;

        public frmChiTietDV(String ma, string ten)
        {
            maphong = ma;
            tenphong = ten;
            
            InitializeComponent();
            txtPhong.Text = ten;
            ctdv.loadCbbDV(cbbDV);
            dtNgayBD.Text = DateTime.Now.ToString();

            DateTime newdayy = DateTime.Now.AddDays(+30);
            dtNgayKT.Text = newdayy.ToString();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string mact = txtMaCTDV.Text;
            string phong = maphong;
            string dichvu = cbbDV.SelectedValue.ToString();
            int soluong = int.Parse(txtSoLuong.Text.ToString());
            DateTime nbd = dtNgayBD.Value;
            DateTime nkt = dtNgayKT.Value;
            decimal dongia = decimal.Parse(ctdv.LayGiaDichVu(dichvu));
            decimal thanhtien = dongia * soluong;
            txtThanhTien.Text = thanhtien.ToString();
            decimal tongtien = Convert.ToDecimal(txtThanhTien.Text.ToString());
            if (mact != string.Empty)
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn đăng kí dịch vụ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    // thêm dịch vụ
                    if (ctdv.KiemTraTrung(txtMaCTDV.Text.ToString()) == true)
                    {
                        ctdv.themctdc(mact, dichvu, phong, soluong, nbd, nkt, tongtien);
                        MessageBox.Show("Đăng kí Thành Công!", "Thông báo");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mã hợp đồng Đã Tồn Tại", "Thông báo");
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
                Close();
            }
        }
    }
}