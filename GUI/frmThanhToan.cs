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
    public partial class frmThanhToan : DevExpress.XtraEditors.XtraForm
    {
        QLThanhToan qltt = new QLThanhToan();
        string maphong = null;
        string tenphong = null;
        public frmThanhToan(string map, string ten )
        {
            maphong = map;
            tenphong = ten;
            InitializeComponent();
            txtMaPhong.Text = maphong;
            txtTenPhong.Text = tenphong;
            txtMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            decimal tongtien = Convert.ToDecimal(qltt.LayTongCongNo(maphong));
            txtConNo.Text = tongtien.ToString();
        }
        public void loaddata()
        {
            gcDanhSach.DataSource = qltt.loaddataCongNo(maphong);
        }

        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbThang.SelectedItem.ToString() == "Tất cả")
            {
                loaddata();
            }
            else
            {
                int thang = int.Parse(cbbThang.SelectedIndex.ToString());
                gcDanhSach.DataSource = qltt.loaddataCongNoTheoThang(maphong,thang);
            }
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            
        }
    }
}