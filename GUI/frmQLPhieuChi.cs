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
    public partial class frmQLPhieuChi : DevExpress.XtraEditors.XtraForm
    {
        QLPhieuChi qlpc = new QLPhieuChi();
        string maphong = null;
        string tenphong = null;
        public frmQLPhieuChi(string ma, string ten)
        {
            //txtMaPc.Enabled = false;
            //txtPhong.Enabled = false;
            maphong = ma;
            tenphong = ten;
            InitializeComponent();
            txtPhong.EditValue = tenphong;
            txtMaPc.Enabled = false;
            txtPhong.Enabled = false;
            btnThem.Enabled = false;
        }
        public void load()
        {
            gcPhieuChi.DataSource = qlpc.loadPhieuChi(maphong);
        }
        private void frmQLPhieuChi_Load(object sender, EventArgs e)
        {
            load();
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
            txtTenPC.Text = "";
            txtSoTien.Text = "";
            txtLiDo.Text = "";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            string lastID = qlpc.GetLastID();
            txtMaPc.EditValue = GenAuto.CreateID("C", lastID);
            lammoi();
        }

        private void gvPhieuChi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnThem.Enabled = false;
            try
            {
                txtMaPc.EditValue = gvPhieuChi.GetRowCellValue(gvPhieuChi.FocusedRowHandle, "MaPC").ToString();
                txtTenPC.EditValue = gvPhieuChi.GetRowCellValue(gvPhieuChi.FocusedRowHandle, "TenPC").ToString();
                txtPhong.EditValue = gvPhieuChi.GetRowCellValue(gvPhieuChi.FocusedRowHandle, "MaPhong").ToString();
                txtLiDo.EditValue = gvPhieuChi.GetRowCellValue(gvPhieuChi.FocusedRowHandle, "LyDo").ToString();
                txtSoTien.EditValue = gvPhieuChi.GetRowCellValue(gvPhieuChi.FocusedRowHandle, "SoTien").ToString();
                dtNgayChi.Text = gvPhieuChi.GetRowCellValue(gvPhieuChi.FocusedRowHandle, "NgayChi").ToString();
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string mapc = txtMaPc.EditValue.ToString();
                string tenpc = txtTenPC.EditValue.ToString();
                string ma = maphong;
                decimal tien = Convert.ToDecimal(txtSoTien.EditValue.ToString());
                string mota = txtLiDo.EditValue.ToString();
                dtNgayChi.Text = DateTime.Now.ToString();
                DateTime ngay = DateTime.Now;

                if (mapc != string.Empty && tenpc != string.Empty && ma != null && tien.ToString() != null && mota != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Lỗi  " + tenpc + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm dịch vụ
                        if (qlpc.KiemTraTrung(txtMaPc.EditValue.ToString()) == true)
                        {
                            qlpc.themPhieuPhat(mapc,ma,tenpc,ngay,tien,mota);
                            MessageBox.Show("Thêm Thành Công  " + tenpc, "Thông báo");
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
                    if (txtMaPc.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Mã phiếu còn bỏ trống", "Thống báo");
                        txtMaPc.Focus();
                    }
                    if (txtTenPC.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Tên phiếu còn bỏ trống", "Thống báo");
                        txtTenPC.Focus();
                    }
                    if (txtPhong.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Phòng còn bỏ trống", "Thống báo");
                        txtPhong.Focus();
                    }
                    if (txtSoTien.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Mô tả còn bỏ trống", "Thống báo");
                        txtSoTien.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Phiếu phạt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = gvPhieuChi.FocusedRowHandle;
            string ma = "MaPC";
            object value = gvPhieuChi.GetRowCellValue(id, ma);
            try
            {

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa phiếu  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qlpc.xoaPhieuPhat(value.ToString());
                    load();
                    MessageBox.Show("Xóa Thành Công  " + value.ToString());
                    lammoi();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa phiếu  " + value.ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            { 
                string mapc = txtMaPc.EditValue.ToString();
                string tenpc = txtTenPC.EditValue.ToString();
                string ma = txtPhong.EditValue.ToString();
                decimal tien = Convert.ToDecimal(txtSoTien.EditValue.ToString());
                string mota = txtLiDo.EditValue.ToString();
                //dtNgayChi.Text = DateTime.Now.ToString();
                DateTime ngay = DateTime.Now;

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa" + tenpc + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qlpc.SuaPC(mapc,ma,tenpc,ngay,tien, mota);
                    load();
                    lammoi();
                    MessageBox.Show("Sửa Thành Công " + tenpc, "Thông Báo");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Có Vấn Đề Trong Việc sửa  " + txtTenPC.Text);
            }
        }
    }
}