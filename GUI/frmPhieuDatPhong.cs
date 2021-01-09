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
    public partial class frmPhieuDatPhong : DevExpress.XtraEditors.XtraForm
    {
        QLDatPhong qldp = new QLDatPhong();
        QLXemTTPhongTro qlxttpt = new QLXemTTPhongTro();
        String maphong= null;
        String tenphong = null;

        public string ngaydp { get; set; }

        public frmPhieuDatPhong()
        {
            InitializeComponent();
            txtMaPhong.SelectedText = tenphong;       
            // qldp.loadCbbPhong(cbbPhong);

        }
        public frmPhieuDatPhong(String ma, string ten)
        {
            maphong = ma;
            tenphong = ten;
            InitializeComponent();
            string lastID = qldp.GetLastID();
            txtMaDP.EditValue = GenAuto.CreateID("R", lastID);
            //qldp.loadCbbPhong(cbbPhong);
            //cbbPhong.SelectedText = ma;
        }
        
        public string MaPhongDangChon { get; set; }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn Thoát không?","Thông báo" ,MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                Close();
            }
        }

        //private void panelControl2_Paint(object sender, PaintEventArgs e)
        //{
        //    txtMaPhong.SelectedText = maphong;
        //    //MessageBox.Show(maphong);
        //}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //txtMaPhong.SelectedText = maphong;
            string madp = txtMaDP.EditValue.ToString();
            string cnmd= txtCMND.EditValue.ToString();
            string ten = txtHoTen.EditValue.ToString();
            //string phong = txtMaPhong.EditValue.ToString();
            string phong = maphong;
            decimal tiencoc = Convert.ToDecimal(txtTienCoc.EditValue.ToString());
            DateTime ngaydat = dtNgayDat.Value;
            DateTime ngaynhan = dtNgayNhanP.Value;
            DateTime dt = new DateTime();
            dt.ToString("dd/MM/yyyy");
            string img = Image.FromFile("E:\\Imgae\\ThieuHinh.jpg").ToString();

            if (madp != string.Empty && cnmd != string.Empty && phong != string.Empty && txtTienCoc.Text != null && dtNgayDat.Text != string.Empty)
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn đặt phòng  " + phong + "?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    // thêm dịch vụ
                    if (qldp.KiemTraTrungMa(txtMaDP.EditValue.ToString()) == true)
                    {
                        qldp.themKhach(cnmd,ten,img);
                        qldp.phieuDaPhong(madp, cnmd, phong, tiencoc,ngaydat,ngaynhan);
                        MessageBox.Show("Đặt phòng " + phong + "Thành công!", "Thông báo");
                        qldp.CapNhatPhong(phong, "Đã đặt phòng");
                        qldp.CapNhatKhach(cnmd, "Đang đặt phòng");
                        
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Mã Dịch Vụ Đã Tồn Tại", "Thông báo");
                    }
                }
            }          
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {
            txtMaPhong.Text = tenphong;
        }
    }
}