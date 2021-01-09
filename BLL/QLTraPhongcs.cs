using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QLTraPhongcs
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public void themTraPhong(string matp, string cmmn, string mp, DateTime nbt, DateTime ntdk)
        {
            TraPhong tp = new TraPhong();
            tp.MaTraP = matp;
            tp.CMND = cmmn;
            tp.MaPhong = mp;
            tp.NgayBaoTra = nbt;
            tp.NgayTPDK = ntdk;

            qlpt.TraPhongs.InsertOnSubmit(tp);
            qlpt.SubmitChanges();
        }

        public void updateTraPhong(string matp, DateTime nt, decimal hoantien, decimal tiendb, string note)
        {
            TraPhong tp = qlpt.TraPhongs.Where(d => d.MaTraP == matp).FirstOrDefault();
            tp.NgayTra = nt;
            tp.HoanTienCoc = hoantien;
            tp.TienDenBu = tiendb;
            tp.GhiChu = note;
            qlpt.SubmitChanges();
        }

        public string GetLastID()
        {
            TraPhong tb;
            List<TraPhong> traPhongs = qlpt.TraPhongs.Select(ph => ph).ToList();

            if (qlpt.TraPhongs.Select(ph => ph).Count() == 0)
            {
                return "O100";
            }
            else
            {
                tb = traPhongs.LastOrDefault();
            }
            return tb.MaTraP;
        }

        public Boolean KiemTraTrung(string matp)
        {
            var dv = qlpt.TraPhongs.Where(n => (n.MaTraP == matp)).FirstOrDefault();
            if (dv != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void CapNhatPhong(string MaPhong, string trangThai)
        {

            var p = (from a in qlpt.Phongs
                     where a.MaPhong == MaPhong
                     select a).SingleOrDefault();
            if (p != null)
            {
                p.TrangThai = trangThai;
                qlpt.SubmitChanges();
            }
        }

        public string LayMaTP(string mp)
        {

            var tphong = from tp in qlpt.TraPhongs
                         join p in qlpt.Phongs on tp.MaPhong equals p.MaPhong
                         where tp.MaPhong == mp
                         select tp;
            foreach (var item in tphong)
            {
                return item.MaTraP.Trim();
            }
            return "";
        }

        public string LayCMND(string map, string vaitro)
        {

            var phong = from kt in qlpt.KhachTros
                        join p in qlpt.DatPhongs on kt.MaPhong equals p.MaPhong
                        where kt.VaiTro == vaitro && kt.MaPhong== map
                        select p;
            foreach (var item in phong)
            {
                return item.CMND.Trim();
            }
            return ""; 
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



    }
}
