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
    public partial class frmQLDichVu : DevExpress.XtraEditors.XtraForm
    {
        QLDichVu qldv = new QLDichVu();
        public frmQLDichVu()
        {
            InitializeComponent();
        }

        private void frmQLDichVu_Load(object sender, EventArgs e)
        {

            loadDV();

            txtMaDV.EditValue = "";
            LamMoi_DV();
            //SinhMaDVTuDong();
            txtMaDV.Enabled = false;
            txtTenDV.Focus();
        }
        void loadDV()
        {
            gcDichVu.DataSource = qldv.LoadDichVu_BLL();

        }

        //void SinhMaDVTuDong()
        //{
        //    txtMaDV.EditValue = qldv.SinhMaDV();
        //}

        void LamMoi_DV()
        {
            txtDonGia.Text = "";
            txtTenDV.EditValue = "";
            txtDVT.EditValue = "";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string madv = txtMaDV.EditValue.ToString();
                string tendv = txtTenDV.EditValue.ToString();
                decimal dongia = Convert.ToDecimal(txtDonGia.EditValue.ToString());
                string dvt = txtDVT.EditValue.ToString();

                if (madv != string.Empty && tendv != string.Empty && txtDonGia.Text != null && dvt != string.Empty)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Dịch Vụ  " + madv + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm dịch vụ
                        if (qldv.KiemTraTrung_DV(txtMaDV.EditValue.ToString()) == true)
                        {
                            qldv.ThemDV(madv, tendv, dongia, dvt);
                            MessageBox.Show("Thêm Thành Công Dịch Vụ " + madv, "Thông báo");
                            loadDV();
                            //SinhMaDVTuDong();
                            LamMoi_DV();
                        }
                        else
                        {
                            MessageBox.Show("Mã Dịch Vụ Đã Tồn Tại", "Thông báo");
                        }
                    }
                }
                else
                {
                    if (txtTenDV.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Tên dịch vụ còn bỏ trống", "Thống báo");
                        txtTenDV.Focus();
                    }

                    if (txtDonGia.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Đơn giá còn bỏ trống", "Thống báo");
                        txtDonGia.Focus();
                    }
                    if (txtDVT.EditValue.ToString() == string.Empty)
                    {
                        MessageBox.Show("Đơn vị tính còn bỏ trống", "Thống báo");
                        txtDVT.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Dịch Vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = gvDichVu.FocusedRowHandle;
            string ma = "MaDV";
            object value = gvDichVu.GetRowCellValue(id, ma);
            try
            {

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa dịch vụ  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qldv.xoaDV(value.ToString());
                    loadDV();
                    MessageBox.Show("Xóa Thành Công dịch vụ  " + value.ToString());
                    LamMoi_DV();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa dịch vụ  " + value.ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int id = gvDichVu.FocusedRowHandle;
            string ma = "MaDV";
            object value = gvDichVu.GetRowCellValue(id, ma);
            try
            {

                string madv = txtMaDV.EditValue.ToString();
                string tendv = txtTenDV.EditValue.ToString();
                decimal dongia = Convert.ToDecimal(txtDonGia.EditValue.ToString());
                string dvt = txtDVT.EditValue.ToString();

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Dịch vụ " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    qldv.suaDV(value.ToString(), tendv, dongia, dvt);
                    loadDV();
                    LamMoi_DV();
                    MessageBox.Show("Sửa Thành Công dịch vụ " + value.ToString(), "Thông Báo");
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc sửa dịch vụ  " + value.ToString());
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi_DV();
        }

        private void gvDichVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvDichVu.RowCount != 0)
                {
                    txtMaDV.EditValue = gvDichVu.GetRowCellValue(gvDichVu.FocusedRowHandle, "MaDV").ToString();
                    txtTenDV.EditValue = gvDichVu.GetRowCellValue(gvDichVu.FocusedRowHandle, "TenDV").ToString();
                    txtDonGia.Text = gvDichVu.GetRowCellValue(gvDichVu.FocusedRowHandle, "DonGia").ToString();
                    txtDVT.EditValue = gvDichVu.GetRowCellValue(gvDichVu.FocusedRowHandle, "DonViTinh").ToString();
                }
            }
            catch
            {

            }
        }

        private void txtTenDV_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                dxErrorProvider1.SetError(ctr, "Không được bỏ trống");
                txtTenDV.Focus();
            }
            else
            {
                dxErrorProvider1.ClearErrors();
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                dxErrorProvider1.SetError(ctr, "Chỉ có số không kí tự");
                txtDonGia.Focus();
            }
            else
                dxErrorProvider1.ClearErrors();
        }

        private void txtDVT_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                dxErrorProvider1.SetError(ctr, "Không được bỏ trống");
                txtDVT.Focus();
            }
            else
            {
                dxErrorProvider1.ClearErrors();
            }
        }
    }
}