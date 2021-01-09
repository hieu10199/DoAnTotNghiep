using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QLThanhToan
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public IQueryable<PhieuThuTien> loaddata()
        {
            return from ph in qlpt.PhieuThuTiens select ph;
        }

        public IQueryable<PhieuThuTien> loaddataCongNo(string maphong)
        {
            return from ph in qlpt.PhieuThuTiens
                   join p in qlpt.Phongs on ph.MaPhong equals p.MaPhong
                   where ph.MaPhong == maphong
                   select ph;
        }
        public IQueryable<PhieuThuTien> loaddataCongNoTheoThang(string maphong, int thang)
        {
            return from ph in qlpt.PhieuThuTiens
                   join p in qlpt.Phongs on ph.MaPhong equals p.MaPhong 
                   where ph.MaPhong == maphong && ph.Thang/10000 ==thang
            select ph;
        }

        public void them(string mapt, string cmnd, string cmndct, string phong, string trangthai )
        {
            PhieuThuTien ptt = new PhieuThuTien();
            ptt.MaPhieuThu = mapt;
            ptt.CMND = cmnd;
            ptt.CMNDCT = cmndct;
            ptt.MaPhong = phong;
            ptt.TrangThai = trangthai;

            qlpt.PhieuThuTiens.InsertOnSubmit(ptt);
            qlpt.SubmitChanges();
        }
        public Boolean KiemTraTrung(string mapt)
        {
            var dv = qlpt.PhieuThuTiens.Where(n => (n.MaCTDV == mapt)).FirstOrDefault();
            if (dv != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public string GetLastID()
        {
            PhieuThuTien p;
            List<PhieuThuTien> phieuThuTiens = qlpt.PhieuThuTiens.Select(ph => ph).ToList();

            if (qlpt.PhieuThuTiens.Select(ph => ph).Count() == 0)
            {
                return "T100";
            }
            else
            {
                p = phieuThuTiens.LastOrDefault();
            }
            return p.MaPhieuThu;

        }

        public void suaTT(string mapt, int sdm,decimal tongtiendien, int snm, decimal tt, DateTime ngaythu, int thang, decimal tnuoc, string madv )
        {
            PhieuThuTien dv = qlpt.PhieuThuTiens.Where(d => d.MaPhieuThu == mapt).FirstOrDefault();
            dv.SoDienMoi = sdm;
            dv.TienDien = tongtiendien;
            dv.SoNuocMoi = snm;
            dv.TienNuoc = tnuoc;
            dv.TongTien = tt;
            dv.NgayThu = ngaythu;
            dv.Thang = thang;
            dv.MaCTDV = madv;
            qlpt.SubmitChanges();
        }
        public string LaSoDienCu(string maphong)
        {
            var dp = from p in qlpt.Phongs
                     where p.MaPhong == maphong
                     select p;
            foreach (var item in dp)
            {
                return item.SoDien.ToString();
            }
            return "";
        }
        public string LaSoDienNuoc(string maphong)
        {

            var dp = from p in qlpt.Phongs
                     where p.MaPhong == maphong
                     select p;
            foreach (var item in dp)
            {
                return item.SoNuoc.ToString();
            }
            return "";
        }

        public void CapNhatDien(string maPhong, int sodien)
        {
            var Ban = (from p in qlpt.Phongs
                       join dp in qlpt.PhieuThuTiens on p.MaPhong equals dp.MaPhong
                       where p.MaPhong == maPhong
                       select p).SingleOrDefault();
            if (Ban != null)
            {
                Ban.SoDien = sodien;
                qlpt.SubmitChanges();
            }
        }
        public void CapNhatDienMoi(string mapt, int sodien)
        {
            var Ban = (from pt in qlpt.PhieuThuTiens
                       where pt.MaPhieuThu == mapt
                       select pt).SingleOrDefault();
            if (Ban != null)
            {
                Ban.SoDienMoi = sodien;
                qlpt.SubmitChanges();
            }
        }
        public void CapNhatNuoc(string maPhong, int sonuoc)
        {
            var Ban = (from p in qlpt.Phongs
                       join dp in qlpt.PhieuThuTiens on p.MaPhong equals dp.MaPhong
                       where p.MaPhong == maPhong
                       select p).SingleOrDefault();
            if (Ban != null)
            {
                Ban.SoNuoc = sonuoc;
                qlpt.SubmitChanges();
            }
        }

        public decimal LayGiaPhong(string maphong)
        {
            decimal tong = 0;
            var lp = from l in qlpt.LoaiPhongs
                     join p in qlpt.Phongs on l.MaLoaiP equals p.MaLoaiP
                     where p.MaPhong == maphong
                     select l;
            foreach (var item in lp)
            {
                tong = Convert.ToDecimal(item.GiaPhong);
            }
            return tong ;
        }

        public string LayGiBanCong(string maphong)
        {
            var lp = from p in qlpt.Phongs
                     where p.MaPhong == maphong
                     select p;
            foreach (var item in lp)
            {
                return item.BanCong.ToString();
            }
            return "";
        }

        public string LayNgayVao(string maphong)
        {
            var lp = from p in qlpt.HopDongs
                     where p.MaPhong == maphong
                     select p;
            foreach (var item in lp)
            {
                return item.NgayThue.ToString();
            }
            return "";
        }
        public decimal LayThanhTien(string maphong)
        {
            decimal tong = 0;
            var lp = from d in qlpt.CTDVs 
                     join p in qlpt.Phongs on d.MaPhong equals p.MaPhong
                     where p.MaPhong == maphong
                     select d;
            foreach (var item in lp)
            {
                tong = tong + Convert.ToDecimal(item.TongTCTDV);
            }
            return tong;
        }
        public string LayMaCTDV(string map)
        {

            var phong = from d in qlpt.CTDVs
                        join p in qlpt.Phongs on d.MaPhong equals p.MaPhong
                        where p.MaPhong == map
                        select d;
            foreach (var item in phong)
            {
                return item.MaCTDV.Trim();
            }
            return "";
        }
        public string LayTrangThai(string maphong)
        {
            var ptt = from a in qlpt.PhieuThuTiens
                       join ph in qlpt.Phongs on a.MaPhong equals ph.MaPhong
                       where a.MaPhong == maphong
                       select a;
            foreach (var item in ptt)
            {
                return item.TrangThai.Trim();
            }
            return "";
        }
        public void CapNhatTrangThai(string mapt, string trangThai)
        {

            var p = (from a in qlpt.PhieuThuTiens
                     where a.MaPhong == mapt
                     select a).SingleOrDefault();
            if (p != null)
            {
                p.TrangThai = trangThai;
                qlpt.SubmitChanges();
            }
        }

        public decimal LayTongCongNo(string maphong)
        {
            decimal tong = 0;
            var lp = from d in qlpt.PhieuThuTiens
                     join p in qlpt.Phongs on d.MaPhong equals p.MaPhong
                     where d.MaPhong == maphong
                     select d;
            foreach (var item in lp)
            {
                tong = tong + Convert.ToDecimal(item.TongTien);
            }
            return tong;
        }
    }
}
