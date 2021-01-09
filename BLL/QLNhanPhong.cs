using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QLNhanPhong
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public void themHopDong(string mahp, string cmnd, DateTime ngaythue, decimal tiencoc, string phong, int thoihan,string cmndct)
        {
            HopDong hd = new HopDong();
            hd.MaHopDong = mahp;
            hd.CMND = cmnd;
            hd.NgayThue = ngaythue;
            hd.TienDatCoc = tiencoc;
            hd.MaPhong = phong;
            hd.ThoiHanHopDong = thoihan;
            hd.CMNDCT = cmndct;
            
            qlpt.HopDongs.InsertOnSubmit(hd);
            qlpt.SubmitChanges();
        }

        public void CapNhatKhach(string cmnd, string trangThai)
        {
            var Ban = (from p in qlpt.KhachTros
                       join dp in qlpt.HopDongs on p.CMND equals dp.CMND
                       where p.CMND == cmnd
                       select p).SingleOrDefault();
            if (Ban != null)
            {
                Ban.TrangThai = trangThai;
                qlpt.SubmitChanges();
            }
        }
        public void CapNhaVaiTroKhach(string cmnd, string vaitro)
        {
            var Ban = (from p in qlpt.KhachTros
                       join dp in qlpt.HopDongs on p.CMND equals dp.CMND
                       where p.CMND == cmnd
                       select p).SingleOrDefault();
            if (Ban != null)
            {
                Ban.VaiTro = vaitro;
                qlpt.SubmitChanges();
            }
        }
        public void SuaKhachTro(String CMND,String sdt, String mp)
        {
            var kt = (from cm in qlpt.KhachTros where cm.CMND == CMND select cm).SingleOrDefault();
            if (kt != null)
            {
                kt.SDT = sdt;
                kt.MaPhong = mp;
                qlpt.SubmitChanges();
            }
        }
        public void CapNhatPhong(string maPhong, string trangThai)
        {
            var Ban = (from p in qlpt.Phongs
                       join dp in qlpt.HopDongs on p.MaPhong equals dp.MaPhong
                       where p.MaPhong == maPhong
                       select p).SingleOrDefault();
            if (Ban != null)
            {
                Ban.TrangThai = trangThai;
                qlpt.SubmitChanges();
            }
        }
        public Boolean KiemTraTrung(string mahd)
        {
            var lp = qlpt.HopDongs.Where(n => (n.MaHopDong == mahd)).FirstOrDefault();
            if (lp != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public string GetLastID()
        {
            HopDong tb;
            List<HopDong> hopDongs = qlpt.HopDongs.Select(ph => ph).ToList();

            if (qlpt.HopDongs.Select(ph => ph).Count() == 0)
            {
                return "H100";
            }
            else
            {
                tb = hopDongs.LastOrDefault();
            }
            return tb.MaHopDong;
        }
    }
}
