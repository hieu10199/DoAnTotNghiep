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
    public partial class frmThietBi : DevExpress.XtraEditors.XtraForm
    {
        QLThietBi qltb = new QLThietBi();
        public frmThietBi()
        {
            InitializeComponent();
            load();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void load()
        {
            qltb.loadCbbPhong(cbbPhong);
            gcDanhSachTB.DataSource = qltb.loadThietBi();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn Thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
        public void lammoi()
        {
            txtTenTB.EditValue = "";
            cbbPhong.SelectedValue = "";
            txtNhanHieu.EditValue = "";
            txtSoLuong.EditValue = "";
            txtTinhTrang.EditValue = "";
            dtNgayMua.Value = DateTime.Now;
            txtGia.EditValue = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string matb = txtMaTB.EditValue.ToString();
                string tentb = txtTenTB.EditValue.ToString();
                string ma = cbbPhong.SelectedValue.ToString();
                string nhanhieu = txtNhanHieu.EditValue.ToString();
                int soluong = int.Parse(txtSoLuong.Text.ToString());
                string tt = txtTinhTrang.EditValue.ToString();
                DateTime ngaymua = dtNgayMua.Value;
                decimal tien = Convert.ToDecimal(txtGia.EditValue.ToString());
                
                if (matb != string.Empty && tentb != string.Empty && ma != null && tien.ToString() != null && nhanhieu != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Thiết bị " + tentb + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm dịch vụ
                        if (qltb.KiemTraTrung(txtMaTB.EditValue.ToString()) == true)
                        {
                            qltb.themThietBi(matb,ma,tentb,nhanhieu,soluong,tt,ngaymua,tien);
                            MessageBox.Show("Thêm Thành Công  " + tentb, "Thông báo");
                            load();
                            //SinhMaLPTuDong();
                            lammoi();
                        }
                        else
                        {
                            MessageBox.Show("Mã Phiếu Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa điền đầy đủ thông tin");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Có Vấn Đề Trong Việc Thêm thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string matb = txtMaTB.EditValue.ToString();
                string tentb = txtTenTB.EditValue.ToString();
                string ma = cbbPhong.SelectedValue.ToString();
                string nhanhieu = txtNhanHieu.EditValue.ToString();
                int soluong = int.Parse(txtSoLuong.Text.ToString());
                string tt = txtTinhTrang.EditValue.ToString();
                DateTime ngaymua = dtNgayMua.Value;
                decimal tien = Convert.ToDecimal(txtGia.EditValue.ToString());

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa" + tentb + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qltb.SuaTB(matb, ma, tentb, nhanhieu, soluong, tt, ngaymua, tien);
                    load();
                    //lammoi();
                    MessageBox.Show("Sửa Thành Công " + tentb, "Thông Báo");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Có Vấn Đề Trong Việc sửa  " + txtTenPC.Text);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = gvDanhSachTB.FocusedRowHandle;
            string ma = "MaTB";
            object value = gvDanhSachTB.GetRowCellValue(id, ma);
            try
            {

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa thiết bị  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qltb.XoaThietBi(value.ToString());
                    load();
                    MessageBox.Show("Xóa Thành Công  " + value.ToString());
                    lammoi();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa " + value.ToString());
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            string lastID = qltb.GetLastID();
            txtMaTB.EditValue = GenAuto.CreateID("B", lastID);
            lammoi();
        }

        private void gvDanhSachTB_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnThem.Enabled = false;
            try
            {
                txtMaTB.EditValue = gvDanhSachTB.GetRowCellValue(gvDanhSachTB.FocusedRowHandle, "MaTB").ToString();
                txtTenTB.EditValue = gvDanhSachTB.GetRowCellValue(gvDanhSachTB.FocusedRowHandle, "TenTB").ToString();
                cbbPhong.Text = gvDanhSachTB.GetRowCellValue(gvDanhSachTB.FocusedRowHandle, "MaPhong").ToString();
                txtNhanHieu.EditValue = gvDanhSachTB.GetRowCellValue(gvDanhSachTB.FocusedRowHandle, "NhanHieu").ToString();
               txtSoLuong.EditValue = gvDanhSachTB.GetRowCellValue(gvDanhSachTB.FocusedRowHandle, "SoLuong").ToString();
                txtTinhTrang.Text = gvDanhSachTB.GetRowCellValue(gvDanhSachTB.FocusedRowHandle, "TinhTrang").ToString();
                txtGia.EditValue= gvDanhSachTB.GetRowCellValue(gvDanhSachTB.FocusedRowHandle, "Gia").ToString();
                dtNgayMua.Text = gvDanhSachTB.GetRowCellValue(gvDanhSachTB.FocusedRowHandle, "NgayMua").ToString();
            }
            catch
            {

            }
        }
    }
}