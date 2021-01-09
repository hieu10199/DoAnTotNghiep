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
    public partial class frmNhanPhong : DevExpress.XtraEditors.XtraForm
    {
        QLNhanPhong qlnp = new QLNhanPhong();
        QLThanhToan qltt = new QLThanhToan();
        String maphong = null;
        String tenphong = null;
        public frmNhanPhong(String ma, string ten)
        {
            maphong = ma;
            tenphong = ten;
            InitializeComponent();
            string lastID = qlnp.GetLastID();
            txtMaHD.EditValue = GenAuto.CreateID("H", lastID);
            //   txtCMNDCT.EditValue = tenDN;
        }
        public string tenDN { get; set; }
        public string tenNV { get; set; }
        public string sdt { get; set; }
        public string cmndkt { get; set; }
        public string tenkt { get; set; }
        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmNhanPhong_Load(object sender, EventArgs e)
        {
            txtCMNDCT.Enabled = false;
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            txtCMND.Enabled = false;
            txtPhong.Enabled = false;
            txtHoTenB.Enabled = false;

            txtPhong.EditValue = tenphong;
            txtCMNDCT.EditValue = tenDN;
            txtHoTen.EditValue = tenNV;
            txtSDT.EditValue = sdt;
            txtCMND.EditValue = cmndkt;
            txtHoTenB.EditValue = tenkt;
            DateTime now = DateTime.Now;
            txtNgayThue.Text = now.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn Thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLapHopDong_Click(object sender, EventArgs e)
        {
            string lastID = qltt.GetLastID();
            string mapt= GenAuto.CreateID("T", lastID);
            string mahp = txtMaHD.EditValue.ToString();
            string cmnd = txtCMND.EditValue.ToString();
            string hoten = txtHoTenB.EditValue.ToString();
            string SDT = txtSDTB.EditValue.ToString();
            DateTime ngaythuee = txtNgayThue.Value;
            decimal tiencoc = Convert.ToDecimal(txtTienCoc.EditValue.ToString());
            string phong = maphong;
            int thoihan = int.Parse(txtThoiHanHĐ.Text.ToString());
            string cmndct = txtCMNDCT.EditValue.ToString();
            string trangthai = "Chưa thu";
            if (mahp != string.Empty && cmnd != string.Empty && ngaythuee != null && tiencoc.ToString() != null && phong != string.Empty && thoihan.ToString() != null && cmndct != null )
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Lập hợp đồng  " + mahp + "?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    // thêm dịch vụ
                    if (qlnp.KiemTraTrung(txtMaHD.Text.ToString()) == true)
                    {
                        qlnp.themHopDong(mahp,cmnd,ngaythuee,tiencoc,phong,thoihan,cmndct);
                        MessageBox.Show("Thêm Thành Công Hợp đồng" + mahp, "Thông báo");
                        qltt.them(mapt,cmnd,cmndct,maphong,trangthai);
                        qlnp.SuaKhachTro(cmnd, SDT, phong);
                        qlnp.CapNhatKhach(cmnd, "Đang ở");                    
                        qlnp.CapNhaVaiTroKhach(cmnd,"Trưởng phòng");
                        qlnp.CapNhatPhong(maphong, "Đã nhận phòng");
                        
                        this.Close();
    
                    }
                    else
                    {
                        MessageBox.Show("Mã hợp đồng Đã Tồn Tại", "Thông báo");
                    }
                }
            }
        }
    }
}