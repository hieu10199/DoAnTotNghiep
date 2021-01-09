using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class QLThietBi
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public IQueryable<ThietBi> loadThietBi()
        {
            return from tb in qlpt.ThietBis select tb; 
        }

        public void themThietBi(string matb, string maphong, string tentb, string nh, int sl, string tt, DateTime nm, decimal gia)
        {
            ThietBi tb = new ThietBi();
            tb.MaTB = matb;
            tb.TenTB = tentb;
            tb.MaPhong = maphong;
            tb.NhanHieu = nh;
            tb.SoLuong = sl;
            tb.TinhTrang = tt;
            tb.NgayMua = nm;
            tb.Gia = gia;
            qlpt.ThietBis.InsertOnSubmit(tb);
            qlpt.SubmitChanges();
        }
        public Boolean KiemTraTrung(string matb)
        {
            var dv = qlpt.ThietBis.Where(n => (n.MaTB == matb)).FirstOrDefault();
            if (dv != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void XoaThietBi(String maTB)
        {
            ThietBi p = qlpt.ThietBis.Where(t => t.MaTB == maTB).FirstOrDefault();
            if (p != null)
            {
                qlpt.ThietBis.DeleteOnSubmit(p);
                qlpt.SubmitChanges();
            }
        }
        public void SuaTB(string matb, string maphong, string tentb, string nh, int sl, string tt, DateTime nm, decimal gia)
        {
            var tb = (from t in qlpt.ThietBis where t.MaTB == matb select t).SingleOrDefault();
            if (tb != null)
            {
                tb.TenTB = tentb;
                tb.MaPhong = maphong;
                tb.NhanHieu = nh;
                tb.SoLuong = sl;
                tb.TinhTrang = tt;
                tb.NgayMua = nm;
                tb.Gia = gia;
                qlpt.SubmitChanges();
            }
        }
        public string GetLastID()
        {
            ThietBi tb;
            List<ThietBi> phieuChis = qlpt.ThietBis.Select(ph => ph).ToList();

            if (qlpt.ThietBis.Select(ph => ph).Count() == 0)
            {
                return "B100";
            }
            else
            {
                tb = phieuChis.LastOrDefault();
            }
            return tb.MaTB;
        }

        public void loadCbbPhong(ComboBox cbbMaLoaiP)
        {
            var p = from l in qlpt.Phongs select l;
            cbbMaLoaiP.DataSource = p;
            cbbMaLoaiP.DisplayMember = "TenPhong";
            cbbMaLoaiP.ValueMember = "MaPhong";
        }
    } 
}
