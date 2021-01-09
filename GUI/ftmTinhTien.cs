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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class ftmTinhTien : DevExpress.XtraEditors.XtraForm
    {
        QLThanhToan qltt = new QLThanhToan();
        int index = 0;
        public ftmTinhTien()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {

            gcDanhSach.DataSource = qltt.loaddata();
        }

        private void gcDanhSach_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            gvDanhSach.AddNewRow();
        }
        private void gvDanhSach_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                    popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
            }
            catch { }
        }
        private void gcDanhSach_ProcessGridKey(object sender, KeyEventArgs e)
        {
        }
        public void suaTT()
        {

        }
        private void gvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            index = e.FocusedRowHandle;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gcDanhSach.DataSource = qltt.loaddata();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void gvDanhSach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try {

                string mapt = gvDanhSach.GetRowCellValue(gvDanhSach.FocusedRowHandle, "MaPhieuThu").ToString();
                string maphong = gvDanhSach.GetRowCellValue(gvDanhSach.FocusedRowHandle, "MaPhong").ToString();
                DateTime ngayvao = DateTime.Parse(qltt.LayNgayVao(maphong));
                DateTime ngaythanhtoan = DateTime.Now.AddDays(3);

                TimeSpan tong = ngaythanhtoan - ngayvao;
                int date = tong.Days;
                int thang = int.Parse(ngaythanhtoan.Month.ToString() + ngaythanhtoan.Year.ToString());
                int sdm = int.Parse(gvDanhSach.GetRowCellValue(gvDanhSach.FocusedRowHandle, "SoDienMoi").ToString());
                int snm = int.Parse(gvDanhSach.GetRowCellValue(gvDanhSach.FocusedRowHandle, "SoNuocMoi").ToString());
                int sdc = int.Parse(qltt.LaSoDienCu(maphong));
                int snc = int.Parse(qltt.LaSoDienNuoc(maphong));
                int tongtiendien = (sdm - sdc) * 3000;
                int tongtiennuoc = (snm - snc) * 5000;

                decimal giapong = Convert.ToDecimal(qltt.LayGiaPhong(maphong));
                MessageBox.Show(giapong.ToString());
                //gia dịch vụ
                decimal dichvu = Convert.ToDecimal(qltt.LayThanhTien(maphong));
                int d = (int)dichvu;
                string madv = qltt.LayMaCTDV(maphong);
                int t = (int)giapong;
                //Giá có ban công  + thêm 100k
                int bancong = 0;
                if (qltt.LayGiBanCong(maphong) == "Có")
                {
                    bancong = 100000;
                }
                MessageBox.Show(snm.ToString());
                //Tính tổng tiền
                int tongtien = tongtiendien + tongtiennuoc + bancong + t + d;

                qltt.suaTT(mapt, sdm, tongtiendien, snm, tongtien, ngaythanhtoan, thang, tongtiennuoc, madv);

            }
            catch
            {

            }
        }
    }
}