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
using System.Globalization;

namespace GUI
{
    public partial class frmTrangChu : DevExpress.XtraEditors.XtraForm
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();
        QLDatPhong qldp = new QLDatPhong();
        QLXemTTPhongTro qlxemttpt = new QLXemTTPhongTro();
        QLKhachTro qlkt = new QLKhachTro();
        string maphong = null;
        String tenphong = null;
        DateTime dt = new DateTime();

        public List<Phong> ListPhong = new List<Phong>();
        public List<TabPage> ListTapPage = new List<TabPage>();
        public int index = 0;
        public string KT { get; set; }
        public double gt = 0;
        int temp = 0;
        QLXemTTPhongTro qltt = new QLXemTTPhongTro();
        QLThanhToan qlthanhtoan = new QLThanhToan();
        public frmTrangChu()
        {
            InitializeComponent();
        }

        public string MaPhongDangChon { get; set; }
        public string TenPhongDangChon { get; set; }

        public string tenDN { get; set; }
        public string tenCT { get; set; }
        public string sdt { get; set; }
        public string cmndkt { get; set; }

        public string tenkt { get; set; }
        public string madp { get; set; }
        public string ngaydp { get; set; }
        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            loadPhong();
            btnHuy.Enabled = false;
            btnDatPhong.Enabled = false;
            btnNhanPhong.Enabled = false;
            btnTraPhong.Enabled = false;
            btnPhieuChi.Enabled = false;
            btnDKDV.Enabled = false;
            btnThanhToan.Enabled = false;
            string formatted = dt.ToString("dd-MM-yyyy");

        }

        public class Phong
        {
            public SimpleButton btn;
            public Label lblTenPhong;
            public ToolTip tTip;
        }

        public class Tang
        {
            public List<LoaiPhong> LPhong;
        }

        public void loadPhong()
        {
            var loaiphong = (from lp in qlpt.LoaiPhongs select new { lp.MaLoaiP, lp.TenLoaiP, lp.Tang }).ToList();
            foreach (var item in loaiphong)
            {
                string tentang = item.MaLoaiP.Trim();
                TabPage tb = new TabPage(tentang);
                ListTapPage.Add(tb);
                tb.Width = grctrlDSPhong.Width - 10;
                tb.Text = item.TenLoaiP.ToString();
                tb.BackColor = Color.WhiteSmoke;

                var room = from x in qlpt.Phongs
                           join i in qlpt.LoaiPhongs on x.MaLoaiP equals i.MaLoaiP
                           where i.TenLoaiP == tb.Text
                           select new
                           {
                               x.MaPhong,
                               x.TenPhong,
                               x.TrangThai
                           };
                foreach (var a in room)
                {
                    Phong b = new Phong();
                    ListPhong.Add(b);
                    ListPhong[index].btn = new SimpleButton();
                    ListPhong[index].btn.Size = new Size(50, 50);
                    ListPhong[index].btn.BackColor = Color.Blue;
                    ListPhong[index].btn.Name = a.MaPhong.Trim();
                    ListPhong[index].btn.ImageOptions.Location = ImageLocation.MiddleCenter;
                    ListPhong[index].btn.AppearanceHovered.BackColor = Color.Gold;
                    ListPhong[index].btn.AppearancePressed.BackColor = Color.Yellow;
                    //maphong = ListPhong[index].btn.Name;

                    if (a.TrangThai.Trim() == "Trống")
                        this.ListPhong[index].btn.ImageOptions.Image = global::GUI.Properties.Resources.blue_home_icon;
                    else if (a.TrangThai.Trim() == "Đã nhận phòng")
                        this.ListPhong[index].btn.ImageOptions.Image = global::GUI.Properties.Resources.red_home_icon;
                    else if (a.TrangThai.Trim() == "Đã báo trả phòng")
                        this.ListPhong[index].btn.ImageOptions.Image = global::GUI.Properties.Resources.traphong;
                    else
                        this.ListPhong[index].btn.ImageOptions.Image = global::GUI.Properties.Resources.room_tag_icon;

                    ListPhong[index].lblTenPhong = new Label();
                    ListPhong[index].lblTenPhong.Name = a.MaPhong.ToString();
                    ListPhong[index].lblTenPhong.Size = new Size(50, 25);
                    ListPhong[index].lblTenPhong.Text = a.TenPhong.ToString();
                    ListPhong[index].lblTenPhong.BackColor = Color.WhiteSmoke;
                    ListPhong[index].lblTenPhong.Font = new Font(ListPhong[index].lblTenPhong.Font, FontStyle.Bold);

                    ListPhong[index].btn.Click += btn_Click;
                    tb.Controls.Add(ListPhong[index].lblTenPhong);
                    tb.Controls.Add(ListPhong[index].btn);

                    if (index == temp)
                    {
                        ListPhong[index].btn.Location = new Point(30, 5);
                    }
                    else
                    {
                        if (ListPhong[index - 1].btn.Location.X + 150 > tb.Width)
                        {
                            ListPhong[index].btn.Location = new Point(30, ListPhong[index - 1].btn.Location.Y + 80);
                        }
                        else
                        {
                            ListPhong[index].btn.Location = new Point(ListPhong[index - 1].btn.Location.X + 70, ListPhong[index - 1].btn.Location.Y);
                        }
                    }

                    ListPhong[index].lblTenPhong.Location = new Point(ListPhong[index].btn.Location.X, ListPhong[index].btn.Location.Y + 50);
                    ListPhong[index].lblTenPhong.TextAlign = ContentAlignment.MiddleCenter;
                    index++;
                }
                temp += room.Count();
                tb.Refresh();
                tabctrlDSPhong.Controls.Add(tb);
            }


        }

        public void DoiMauPhong(SimpleButton btnphong, List<Phong> phongg)
        {
            for (int i = 0; i <= phongg.Count - 1; i++)
            {
                if (btnphong.Name == phongg[i].btn.Name)
                {

                    phongg[i].lblTenPhong.BackColor = Color.Yellow;
                    lbTrangThai.Text = phongg[i].lblTenPhong.Text;
                    maphong = phongg[i].btn.Name;
                    tenphong = phongg[i].lblTenPhong.Text;
                }
                else
                {
                    phongg[i].lblTenPhong.BackColor = Color.WhiteSmoke;
                }
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {

            dtdstvcp.DataSource = "";
            //lbTrangThai.Text = "Trạng Thái";
            SimpleButton sb = sender as SimpleButton;

            DoiMauPhong(sb, ListPhong);
            SimpleButton btnPhong = new SimpleButton();

            //qldp.XemTTPhong(sb.Name, dtdstvcp);
            string trangthai = qlxemttpt.LayTrangThai(maphong);
            if (trangthai.Trim() == "Trống")
            {
                ttcongno();
                lblTTKhachCP.Text = trangthai.Trim();
                btnDatPhong.Enabled = true;
                btnHuy.Enabled = false;
                btnNhanPhong.Enabled = false;
                btnTraPhong.Enabled = false;
                btnPhieuChi.Enabled = false;
                btnDKDV.Enabled = false;
                
            }

            else if (trangthai.Trim() == "Đã nhận phòng" || trangthai.Trim() == "Đã báo trả phòng")
            {
                ttcongno();
                qlxemttpt.XemTTPhong(maphong, dtdstvcp);
                lblTTKhachCP.Text = trangthai.Trim();
                btnPhieuChi.Enabled = true;
                btnTraPhong.Enabled = true;
                btnDatPhong.Enabled = false;
                btnHuy.Enabled = false;
                btnNhanPhong.Enabled = false;
                btnDKDV.Enabled = true;
                
            }
            else if (trangthai.Trim() == "Đã đặt phòng")
            {
                ttcongno();
                btnPhieuChi.Enabled = false;
                lblTTKhachCP.Text = qlxemttpt.LayTrangTT(maphong);
                cmndkt = qlxemttpt.LayCMND(maphong);
                tenkt = qlxemttpt.LayTen(maphong);
                btnHuy.Enabled = true;
                btnNhanPhong.Enabled = true;
                btnTraPhong.Enabled = false;
                btnDatPhong.Enabled = false;
                btnDKDV.Enabled = false;
                
            }

           


        }
        public void ttcongno()
        {
            string trangthaicongno = qltt.LayTrangThaiCongNo(maphong);
            if (trangthaicongno.Trim() == "Chưa thu")
            {
                btnThanhToan.Enabled = true;
                txtMaPhieuThu.Text = qlxemttpt.LayMaPT(maphong);
                txtSoDien.Text = qlxemttpt.LayTienDien(maphong);
                lBThanhTien.HintText = qlthanhtoan.LayTongCongNo(maphong).ToString();
                txtSoNuoc.Text = qlxemttpt.LayTienNuoc(maphong);
                txtPhong.Text = tenphong;
                txtThang.Text = qlxemttpt.LayThang(maphong);
                txtDichVu.Text = (qlthanhtoan.LayThanhTien(maphong)).ToString();
            }
            else
            {
                btnThanhToan.Enabled = false;
                lBThanhTien.HintText = "Không có công nợ";
            }
        }


        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(maphong);
            frmPhieuDatPhong frmDP = new frmPhieuDatPhong(maphong, tenphong);
            frmDP.ShowDialog();
            tabctrlDSPhong.Controls.Clear();
            loadPhong();
        }
        DateTime today = DateTime.Now;
        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            if(DateTime.Parse(qldp.LayNgayNhanDk(maphong)) < today)
            {
                MessageBox.Show("Đã quá hạn nhận phòng" + qldp.LayNgayNhanDk(maphong));
                HuyDatPhong();

            }
            else
            {
                frmNhanPhong frmnp = new frmNhanPhong(maphong, tenphong);
                frmnp.tenDN = tenDN;
                frmnp.tenNV = tenCT;
                frmnp.sdt = sdt;
                frmnp.cmndkt = cmndkt;
                frmnp.tenkt = tenkt;
                frmnp.ShowDialog();
                tabctrlDSPhong.Controls.Clear();
                loadPhong();
            }
        }
        public void HuyDatPhong()
        {
            madp = qlxemttpt.LayMaDP(maphong);
            cmndkt = qlxemttpt.LayCMND(maphong);
            QLDatPhong qlldp = new QLDatPhong();
            qlldp.XoaChiTietDatPhongKhiHuy(madp, maphong);
            qlkt.XoaKhachTro(cmndkt);
           // qlldp.XoaChiTietKHKhiHuy(cmndkt, maphong);
            qlxemttpt.CapNhatPhong(maphong, "Trống");
            tabctrlDSPhong.Controls.Clear();
            loadPhong();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {      
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn hủy đặt phòng  " + tenphong + "?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                HuyDatPhong();
            }
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            frmTraPhong frm = new frmTraPhong(maphong, tenphong);
           // frm.cmndkt = cmndkt;
            frm.ShowDialog();
            tabctrlDSPhong.Controls.Clear();
            loadPhong();

        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            frmQLPhieuChi frm = new frmQLPhieuChi(maphong, tenphong);
            frm.ShowDialog();
        }

        private void btnThuTien_Click(object sender, EventArgs e)
        {
            ftmTinhTien frm = new ftmTinhTien();
            frm.ShowDialog();
        }

        private void btnDKDV_Click(object sender, EventArgs e)
        {
            frmChiTietDV frm = new frmChiTietDV(maphong,tenphong);
            frm.ShowDialog();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmThanhToan frm = new frmThanhToan(maphong, tenphong);
            frm.ShowDialog();
        }
    }
}