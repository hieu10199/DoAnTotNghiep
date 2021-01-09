using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QLPhieuChi
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public IQueryable<PhieuChi> loadPhieuChi(string maphong)
        {
            return from pc in qlpt.PhieuChis
                   join p in qlpt.Phongs on pc.MaPhong equals p.MaPhong
                   where pc.MaPhong == maphong
                   select pc;
        }
        public void themPhieuPhat(string mapp, string maphong, string tenphieuphat, DateTime ngayChi, decimal tien,string lydo)       
        {
            PhieuChi pc = new PhieuChi();
            pc.MaPC = mapp;
            pc.TenPC = tenphieuphat;
            pc.MaPhong = maphong;
            pc.NgayChi = ngayChi;
            pc.SoTien = tien;
            pc.LyDo = lydo;
            qlpt.PhieuChis.InsertOnSubmit(pc);
            qlpt.SubmitChanges();
        }
        public Boolean KiemTraTrung(string mapc)
        {
            var dv = qlpt.PhieuChis.Where(n => (n.MaPC == mapc)).FirstOrDefault();
            if (dv != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void xoaPhieuPhat(String maPC)
        {
            PhieuChi p = qlpt.PhieuChis.Where(t => t.MaPC == maPC).FirstOrDefault();
            if (p != null)
            {
                qlpt.PhieuChis.DeleteOnSubmit(p);
                qlpt.SubmitChanges();
            }

        }
        public void SuaPC(string mapp, string maphong, string tenphieuphat, DateTime ngayChi, decimal tien, string lydo)
        {
            var pc = (from ph in qlpt.PhieuChis where ph.MaPC == mapp select ph).SingleOrDefault();
            if (pc != null)
            {
                pc.TenPC = tenphieuphat;
                pc.MaPhong = maphong;
                pc.NgayChi = ngayChi;
                pc.SoTien = tien;
                pc.LyDo = lydo;
                qlpt.SubmitChanges();
            }
        }
        public string GetLastID()
        {
            PhieuChi pc;
            List<PhieuChi> phieuChis = qlpt.PhieuChis.Select(ph => ph).ToList();

            if (qlpt.PhieuChis.Select(ph => ph).Count() == 0)
            {
                return "C100";
            }
            else
            {
                pc = phieuChis.LastOrDefault();
            }
            return pc.MaPC;
        }
    }
}
