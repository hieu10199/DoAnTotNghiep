using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class QLDatPhong
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();
        public void XemTTPhong(string MaPhong, DataGridView dvgTT)
        {
            var chungphong = from kh in qlpt.DatPhongs
                             join p in qlpt.Phongs on kh.MaPhong equals p.MaPhong
                             where p.MaPhong == MaPhong 
                             select new
                             {
                                 kh.CMND,
                                 p.TenPhong,
                                 kh.NgayDat,
                                 kh.NgayDKNhan
                             };

            DataTable dt = new DataTable();
            dt.Columns.Add("CMND");
            dt.Columns.Add("Phòng");
            dt.Columns.Add("Ngày đặt");
            dt.Columns.Add("Ngày dự kiến nhận");


            foreach (var tt in chungphong)
            {
                dt.Rows.Add(tt.CMND,tt.TenPhong, tt.NgayDat,tt.NgayDKNhan);
            }
            dvgTT.DataSource = dt;
        }

        public void phieuDaPhong(String madp, String cmnd, String phong, Decimal tiencoc, DateTime NgayDat , DateTime NgayNhan)
        {
            DatPhong dp = new DatPhong();
            dp.MaDP = madp;
            dp.CMND = cmnd;
            dp.MaPhong = phong;
            dp.TienCoc = tiencoc;
            dp.NgayDat = NgayDat;
            dp.NgayDKNhan = NgayNhan;
            qlpt.DatPhongs.InsertOnSubmit(dp);
            qlpt.SubmitChanges();
        }

        public void XoaChiTietDatPhongKhiHuy(string MaDP, string maphong)
        {
            var x = (from y in qlpt.DatPhongs
                     where y.MaDP.Trim() == MaDP && y.MaPhong.Trim() ==maphong
                     select y).ToList();
            foreach (var a in x)
            {
                DatPhong c = qlpt.DatPhongs.Where(t => t.MaDP == MaDP).FirstOrDefault();
                if (c != null)
                {
                   qlpt.DatPhongs.DeleteOnSubmit(c);
                    qlpt.SubmitChanges();
                }
            }
        }
        public void XoaChiTietKHKhiHuy(string makh, string maphong)
        {
            var x = (from y in qlpt.KhachTros
                     where y.CMND.Trim() == makh && y.MaPhong.Trim() == maphong
                     select y).ToList();
            foreach (var a in x)
            {
                KhachTro kh = qlpt.KhachTros.Where(t => t.CMND == makh).FirstOrDefault();
                if (kh != null)
                {
                    qlpt.KhachTros.DeleteOnSubmit(kh);
                    qlpt.SubmitChanges();
                }
            }
        }
        public void themKhach(string cmnd, string ten, string img)
        {
            KhachTro kt = new KhachTro();
            kt.CMND = cmnd;
            kt.HoTen = ten;
            kt.HinhAnh = img;
            qlpt.KhachTros.InsertOnSubmit(kt);
            qlpt.SubmitChanges();
        }

        public void CapNhatKhach(string cmnd, string trangThai)
        {
            var Ban = (from p in qlpt.KhachTros
                       join dp in qlpt.DatPhongs on p.CMND equals dp.CMND
                       where p.CMND == cmnd
                       select p).SingleOrDefault();
            if (Ban != null)
            {
                Ban.TrangThai = trangThai;
                qlpt.SubmitChanges();
            }
        }

        public void CapNhatPhong(string maPhong, string trangThai)
        {
            var Ban = (from p in qlpt.Phongs
                       join dp in qlpt.DatPhongs on p.MaPhong equals dp.MaPhong
                       where p.MaPhong == maPhong
                       select p).SingleOrDefault();
            if (Ban != null)
            {
                Ban.TrangThai = trangThai;
                qlpt.SubmitChanges();
            }
        }
        public Boolean KiemTraTrungMa(string maDP)
        {
            var lp = qlpt.DatPhongs.Where(n => (n.MaDP == maDP)).FirstOrDefault();
            if (lp != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        public void loadCbbPhong(ComboBox cbbMaLoaiP)
        {
            var dp = from l in qlpt.Phongs
                     where l.TrangThai == "Trống"
                     select l;
            cbbMaLoaiP.DataSource = dp;
            cbbMaLoaiP.DisplayMember = "TenPhong";
            cbbMaLoaiP.ValueMember = "MaPhong";


        }
        public string LayNgayNhanDk(string mp)
        {

            var dp = from p in qlpt.DatPhongs
                     where p.MaPhong == mp
                     select p;
            foreach (var item in dp)
            {
                return item.NgayDKNhan.ToString();
            }
            return "";
        }

        public void chungphong(string maphong, string trangthai)
        {
            var chungphong = (from kh in qlpt.KhachTros
                             join p in qlpt.Phongs on kh.MaPhong equals p.MaPhong
                             where kh.MaPhong == maphong
                             select kh).ToList();
            foreach (var tt in chungphong)
            {
                tt.TrangThai = trangthai;
                qlpt.SubmitChanges();
            }
        }
        public string GetLastID()
        {
            DatPhong tb;
            List<DatPhong> datPhongs = qlpt.DatPhongs.Select(ph => ph).ToList();

            if (qlpt.DatPhongs.Select(ph => ph).Count() == 0)
            {
                return "R100";
            }
            else
            {
                tb = datPhongs.LastOrDefault();
            }
            return tb.MaDP;
        }
    }
}
