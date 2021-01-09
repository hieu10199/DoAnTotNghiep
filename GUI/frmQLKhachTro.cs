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
    public partial class frmQLKhachTro : DevExpress.XtraEditors.XtraForm
    {
        QLKhachTro qlkt = new QLKhachTro();
        public string MaPhongDangChon { get; set; }

        public frmQLKhachTro()
        {
            InitializeComponent();
        }

        private void frmQLKhachTro_Load(object sender, EventArgs e)
        {
            loadKhach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string cmnd = txtCMND.Text.ToString();
                string hoten = txtHoTen.Text.ToString();
                DateTime ngaysinh = dtNgaySinh.Value;
                string gioitinh = cbbGioiTinh.Text.ToString();
                string nghengiep = txtNgheNghiep.Text.ToString();
                string img = txtLinkHA.Text.ToString();
                string sdt = txtSDT.Text.ToString();
                string diachi = txtDiaChi.Text.ToString();
                string phong = cbbPhong.SelectedValue.ToString();
                string vaitro = txtVaiTro.Text.ToString();
                string trangthai = txtTrangThai.Text.ToString();
                int soluong = qlkt.LaySoLuongPhong(phong);
                if (cmnd != string.Empty && hoten != string.Empty && ngaysinh != null && gioitinh != null && nghengiep != string.Empty && sdt != null && diachi != null && phong != null && vaitro != null && trangthai != null)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Khách trọ  " + cmnd + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        if (qlkt.kiemtraSLPhong(phong,soluong) == true)
                        {
                            if (qlkt.KiemTraTrungKT(txtCMND.Text.ToString()) == true)
                            {
                                qlkt.ThemKhachTro(cmnd, hoten, ngaysinh, gioitinh, nghengiep, sdt, img, diachi, phong, vaitro, trangthai);
                                MessageBox.Show("Thêm Thành Công Khách " + cmnd, "Thông báo");
                                loadKhach();
                            }
                            else
                            {
                                MessageBox.Show("Mã Dịch Vụ Đã Tồn Tại", "Thông báo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phòng đã đạt số lượng tối đa " + soluong+" người/phòng" );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void loadKhach()
        {
            gcDskt.DataSource = qlkt.loadDataKhach();
            qlkt.loadCbbLoaiPhong(cbbPhong);


        }

        private void gvDSKT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtCMND.EditValue = "";
            txtHoTen.EditValue = "";
            dtNgaySinh.Text = "";
            cbbGioiTinh.SelectedItem = "";
            txtNgheNghiep.Text = "";
            txtSDT.EditValue = "";
            txtDiaChi.EditValue = "";
            cbbPhong.SelectedValue = "";
            txtVaiTro.EditValue = "";
            txtTrangThai.EditValue = "";           
            try
            {

                if (gvDSKT.RowCount != 0)
                {
                    txtCMND.EditValue = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "CMND").ToString();
                    txtHoTen.EditValue = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "HoTen").ToString();
                    txtSDT.EditValue = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "SDT").ToString();                  
                    cbbPhong.SelectedValue = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "MaPhong").ToString();
                    txtVaiTro.EditValue = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "VaiTro").ToString();
                    txtTrangThai.EditValue = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "TrangThai").ToString();
                    dtNgaySinh.Text = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "NgaySinh").ToString();
                    cbbGioiTinh.Text = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "GioiTinh").ToString();
                    txtDiaChi.EditValue = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "DiaChiThuongTru").ToString();
                    txtNgheNghiep.Text = gvDSKT.GetRowCellValue(gvDSKT.FocusedRowHandle, "NgheNghiep").ToString();
                    

                    qlkt.LayHinhAnh(MaPhongDangChon, pbHA);
                        
                    txtLinkHA.Text = qlkt.LayHinhAnh2(txtCMND.Text.Trim());
                }
               else
                {
                    

                }
            }
            catch
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int id = gvDSKT.FocusedRowHandle;
            string ma = "CMND";
            object value = gvDSKT.GetRowCellValue(id, ma);
            try
            {

                string cmnd = txtCMND.Text.ToString();
                string hoten = txtHoTen.Text.ToString();
                DateTime ngaysinh = dtNgaySinh.Value;
                string gioitinh = cbbGioiTinh.Text.ToString();
                string nghengiep = txtNgheNghiep.Text.ToString();
                string img = txtLinkHA.Text.ToString();
                string sdt = txtSDT.Text.ToString();
                string diachi = txtDiaChi.Text.ToString();
                string phong = cbbPhong.SelectedValue.ToString();
                string vaitro = txtVaiTro.Text.ToString();
                string trangthai = txtTrangThai.Text.ToString();

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Thông tin khách " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qlkt.SuaKhachTro(value.ToString(), hoten, ngaysinh, gioitinh, nghengiep, sdt, img, diachi, phong, vaitro, trangthai);
                    loadKhach();
                    //LamMoi_LP();
                    MessageBox.Show("Sửa Thành Công thông tin khách " + value.ToString(), "Thông Báo");
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc sửa thông tin khách  " + value.ToString());
            }
        }

        private void txtLinkHA_TextChanged(object sender, EventArgs e)
        {
            qlkt.LayHinhAnh3(txtLinkHA.Text, pbHA);
        }

        private void btnDuyetHA_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLinkHA.Text = openFileDialog1.FileName;
                pbHA.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = gvDSKT.FocusedRowHandle;
            string ma = "CMND";
            object value = gvDSKT.GetRowCellValue(id, ma);
            try
            {

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Khách " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qlkt.XoaKhachTro(value.ToString());
                    loadKhach();
                    MessageBox.Show("Xóa Thành Công khách  " + value.ToString());
                    //LamMoi_LP();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa khách  " + value.ToString());
            }

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadKhach();
            txtCMND.Text = "";
            txtHoTen.Text = "";
            dtNgaySinh.Text = "";
            cbbGioiTinh.Text = "";
            txtNgheNghiep.Text = "";
            txtLinkHA.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            cbbPhong.Text = "";
            txtVaiTro.Text= "";
            txtTrangThai.Text = "";
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            txtLinkHA.Text = "Không có hình";
            pbHA.Image = Image.FromFile("E:\\Imgae\\ThieuHinh.jpg");
        }
    }
}