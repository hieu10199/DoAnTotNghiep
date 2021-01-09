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
    public partial class frmQLPhong : DevExpress.XtraEditors.XtraForm
    {
        QLLoaiPhong qllp = new QLLoaiPhong();
        QLPhong qlp = new QLPhong();
        //GenAuto gen = new GenAuto();
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public string KT { get; set; }
        public frmQLPhong()
        {
            InitializeComponent();
        }
        public class Phong
        {
            public SimpleButton btn;
            public Label lbl;
            public Label lblSCN;
            public Label lblTT;
        }
        public List<Phong> Lban = new List<Phong>();
        public List<TabPage> Ltabpage = new List<TabPage>();
        public int i = 0;

        private void frmQLPhong_Load(object sender, EventArgs e)
        {
            //Phòng
            loadPhong();
            txtMaPhong.EditValue = "P100";

            //Loại phòng
            loadLP();
            //SinhMaLPTuDong();
            txtMaLoaiP.Enabled = false;
            txtTenLoaiP.Focus();
        }

       
        //Phòng
        public void loadPhong()
        {
            qlp.loadCbbLoaiPhong(cbbLoaiPhong);
            gvPhong.DataSource = qlp.loadDataPhong();
            txtMaPhong.Enabled = false;
        }

        void LamMoi_P()
        {
            //SinhMaPTuDong();
            loadPhong();
            txtTenPhong.Text = "";
            txtDienTich.EditValue = "";
            txtSLToida.EditValue = "";
            txtTrangThai.EditValue = "";
            txtSoDien.EditValue = "";
            txtSoNuocCu.EditValue = "";
            cbbLoaiPhong.Text = "";
            txtBanCong.EditValue = "";
            txtCongNo.EditValue = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string map = txtMaPhong.Text.ToString();
                string tenp = txtTenPhong.Text.ToString();
                int sltoida = int.Parse(txtSLToida.Text.ToString());
                string tt = txtTrangThai.Text.ToString();
                string maloaip = cbbLoaiPhong.SelectedValue.ToString();
                int sodien = int.Parse(txtSoDien.Text.ToString());
                int sonuoc = int.Parse(txtSoNuocCu.Text.ToString());
                string dientich = txtDienTich.Text.ToString();
                string bancong = txtBanCong.Text.ToString();
                string congno = txtCongNo.Text.ToString();

                if (map != string.Empty && tenp != string.Empty && txtSLToida.Text != null && tt != null && maloaip != string.Empty && txtSoDien.Text != null && txtSoNuocCu.Text != null && dientich !=null  && bancong != null && congno != null)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm phòng  " + map + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm dịch vụ
                        if (qlp.KiemTraTrungPhong(txtMaLoaiP.Text.ToString()) == true)
                        {
                            qlp.ThemPhong(map, tenp, sltoida,tt,maloaip,sodien,sonuoc,dientich,bancong,congno);
                            MessageBox.Show("Thêm Thành Công Loại Phòng " + map, "Thông báo");
                            loadPhong();
                            //SinhMaLPTuDong();
                            LamMoi_P();
                        }
                        else
                        {
                            MessageBox.Show("Mã Dịch Vụ Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {
                    if (txtTenPhong.Text.ToString() == string.Empty)
                    {
                        MessageBox.Show("Tên loại phòng còn bỏ trống", "Thống báo");
                        txtTenPhong.Focus();
                    }
                    if (txtSLToida.Text.ToString() == string.Empty)
                    {
                        MessageBox.Show("Số lượng tối đa phòng còn bỏ trống", "Thống báo");
                        txtSLToida.Focus();
                    }
                    if (txtTrangThai.Text.ToString() == string.Empty)
                    {
                        MessageBox.Show("Trạng thái còn bỏ trống", "Thống báo");
                        txtTrangThai.Focus();
                    }
                    if (cbbLoaiPhong.Text.ToString() == string.Empty)
                    {
                        MessageBox.Show("Loại phòng còn bỏ trống", "Thống báo");
                        cbbLoaiPhong.Focus();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView2.RowCount != 0)
                {
                    txtMaPhong.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaPhong").ToString();
                    txtTenPhong.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TenPhong").ToString();
                    txtSLToida.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SLToiDa").ToString();
                    txtTrangThai.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TrangThai").ToString();
                    cbbLoaiPhong.SelectedValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaLoaiP").ToString();
                    txtSoDien.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SoDien").ToString();
                    txtSoNuocCu.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SoNuoc").ToString();
                    txtDienTich.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DienTich").ToString();
                    txtBanCong.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "BanCong").ToString();
                    txtCongNo.EditValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "CongNo").ToString();
                }
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = gridView2.FocusedRowHandle;
            string ma = "MaPhong";
            object value = gridView2.GetRowCellValue(id, ma);
            try
            {

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa phòng  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qlp.XoaPhong(value.ToString());
                    loadPhong();
                    MessageBox.Show("Xóa Thành Công phòng  " + value.ToString());
                    //LamMoi_LP();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa phòng  " + value.ToString());
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int id = gridView2.FocusedRowHandle;
            string ma = "MaPhong";
            object value = gridView2.GetRowCellValue(id, ma);
            try
            {

                string map = txtMaPhong.EditValue.ToString();
                string tenp = txtTenPhong.EditValue.ToString();
                int sltoida = int.Parse(txtSLToida.Text.ToString());
                string tt = txtTrangThai.Text.ToString();
                string maloaip = cbbLoaiPhong.SelectedValue.ToString();
                int sodien = int.Parse(txtSoDien.Text.ToString());
                int sonuoc = int.Parse(txtSoNuocCu.Text.ToString());
                string dientich = txtDienTich.Text.ToString();
                string bancong = txtBanCong.Text.ToString();
                string congno = txtCongNo.Text.ToString();

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa phòng " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qlp.SuaPhong(value.ToString(), tenp,sltoida,tt,maloaip,sodien,sonuoc,dientich,bancong,congno);
                    loadPhong();
                    //LamMoi_LP();
                    MessageBox.Show("Sửa Thành Công loại phòng " + value.ToString(), "Thông Báo");


                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc sửa loại phòng  " + value.ToString());
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            //lay lasyID
            //Xong truyen vao tham so thu 2
            string lastID = qlp.GetLastID();
            txtMaPhong.EditValue = GenAuto.CreateID("P", lastID);
            LamMoi_P();
        }
        //Loại phòng
        void loadLP()
        {
            gcLoaiPhong.DataSource = qllp.LoadLoaiPhong_BLL();

        }

        void LamMoi_LP()
        {
            //SinhMaLPTuDong();
            loadLP();
            txtGiaPhong.Text = "";
            txtTenLoaiP.EditValue = "";
            txtTang.EditValue = "";
            txtMoTa.EditValue = "";
        }

        private void btnThemLoaiP_Click(object sender, EventArgs e)
        {
            try
            {
                string malp = txtMaLoaiP.EditValue.ToString();
                string tenlp = txtTenLoaiP.EditValue.ToString();
                int tang = int.Parse(txtTang.EditValue.ToString());
                decimal dongia = Convert.ToDecimal(txtGiaPhong.EditValue.ToString());
                string mota = txtMoTa.EditValue.ToString();

                if (malp != string.Empty && tenlp != string.Empty && txtTang.Text != null && txtGiaPhong.Text != null && mota != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm loại phòng  " + malp + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm dịch vụ
                        if (qllp.KiemTraTrung_LP(txtMaLoaiP.EditValue.ToString()) == true)
                        {
                            qllp.ThemLoaiPhong(malp, tenlp, tang, dongia, mota);
                            MessageBox.Show("Thêm Thành Công Loại Phòng " + malp, "Thông báo");
                            loadLP();
                            //SinhMaLPTuDong();
                            LamMoi_LP();
                        }
                        else
                        {
                            MessageBox.Show("Mã Dịch Vụ Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {
                    if (txtTenLoaiP.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Tên loại phòng còn bỏ trống", "Thống báo");
                        txtTenLoaiP.Focus();
                    }
                    if (txtTang.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Tầng còn bỏ trống", "Thống báo");
                        txtTang.Focus();
                    }
                    if (txtGiaPhong.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Đơn giá còn bỏ trống", "Thống báo");
                        txtGiaPhong.Focus();
                    }
                    if (txtMoTa.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Mô tả còn bỏ trống", "Thống báo");
                        txtMoTa.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Loại Phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void gvLoaiPhong_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtMoTa.EditValue = "";
            try
            {
                if (gvLoaiPhong.RowCount != 0)
                {
                    txtMaLoaiP.EditValue = gvLoaiPhong.GetRowCellValue(gvLoaiPhong.FocusedRowHandle, "MaLoaiP").ToString();
                    txtTenLoaiP.EditValue = gvLoaiPhong.GetRowCellValue(gvLoaiPhong.FocusedRowHandle, "TenLoaiP").ToString();
                    txtTang.EditValue = gvLoaiPhong.GetRowCellValue(gvLoaiPhong.FocusedRowHandle, "Tang").ToString();
                    txtGiaPhong.EditValue = gvLoaiPhong.GetRowCellValue(gvLoaiPhong.FocusedRowHandle, "GiaPhong").ToString();
                    txtMoTa.EditValue = gvLoaiPhong.GetRowCellValue(gvLoaiPhong.FocusedRowHandle, "MoTa").ToString();
                }
            }
            catch { }
        }

        private void btnXoaLoaiP_Click(object sender, EventArgs e)
        {
            int id = gvLoaiPhong.FocusedRowHandle;
            string ma = "MaLoaiP";
            object value = gvLoaiPhong.GetRowCellValue(id, ma);
            try
            {

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Loại phòng  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qllp.xoaLP(value.ToString());
                    loadLP();
                    MessageBox.Show("Xóa Thành Công Loại phòng  " + value.ToString());
                    LamMoi_LP();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa loại phòng  " + value.ToString());
            }
        }

        private void btnSuaLoaiP_Click(object sender, EventArgs e)
        {
            int id = gvLoaiPhong.FocusedRowHandle;
            string ma = "MaLoaiP";
            object value = gvLoaiPhong.GetRowCellValue(id, ma);
            try
            {

                string malp = txtMaLoaiP.EditValue.ToString();
                string tenlp = txtTenLoaiP.EditValue.ToString();
                int tang = int.Parse(txtTang.EditValue.ToString());
                decimal dongia = Convert.ToDecimal(txtGiaPhong.EditValue.ToString());
                string mota = txtMoTa.EditValue.ToString();

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa loại phòng " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qllp.suaLP(value.ToString(), tenlp, tang, dongia, mota);
                    loadLP();
                    LamMoi_LP();
                    MessageBox.Show("Sửa Thành Công loại phòng " + value.ToString(), "Thông Báo");


                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc sửa loại phòng  " + value.ToString());
            }
        }

        private void btnLamMoiLoaiP_Click(object sender, EventArgs e)
        {
            LamMoi_LP();
            string lastID = qllp.GetLastID();
            txtMaLoaiP.EditValue = GenAuto.CreateID("L", lastID);
            LamMoi_P();
        }

        private void txtTenLoaiP_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                dxErrorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenLoaiP.Focus();
            }
            else
            {
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtTang_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtGiaPhong_Leave(object sender, EventArgs e)
        {

            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                dxErrorProvider1.SetError(ctr, "Không được bỏ trống");
                txtGiaPhong.Focus();
            }
            else
            {
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtTang_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                dxErrorProvider1.SetError(ctr, "Chỉ có số không kí tự");
                txtTang.Focus();
            }
            else
                dxErrorProvider1.ClearErrors();
        }
    }
}