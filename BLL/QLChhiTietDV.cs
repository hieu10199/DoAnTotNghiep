using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class QLChhiTietDV
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public void themctdc(string mactdv, string madv,string maphong, int soluong, DateTime nbd, DateTime nkt, decimal tong)
        {
            CTDV c = new CTDV();
            c.MaCTDV = mactdv;
            c.MaDV = madv;
            c.MaPhong = maphong;
            c.SoLuong = soluong;
            c.NgayBD = nbd;
            c.NgayKT = nkt;
            c.TongTCTDV = tong;
            qlpt.CTDVs.InsertOnSubmit(c);
            qlpt.SubmitChanges();
        }

        public Boolean KiemTraTrung(string mactdv)
        {
            var lp = qlpt.CTDVs.Where(n => (n.MaCTDV == mactdv)).FirstOrDefault();
            if (lp != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public string GetLastID()
        {
            CTDV tb;
            List<CTDV> cTDVs = qlpt.CTDVs.Select(ph => ph).ToList();

            if (qlpt.CTDVs.Select(ph => ph).Count() == 0)
            {
                return "V100";
            }
            else
            {
                tb = cTDVs.LastOrDefault();
            }
            return tb.MaCTDV;
        }
        public void loadCbbDV(ComboBox cbb)
        {
            var dv = from d in qlpt.DichVus select d;
            cbb.DataSource = dv;
            cbb.DisplayMember = "TenDV";
            cbb.ValueMember = "MaDV";
        }
        public string LayGiaDichVu(string madich)
        {
            var lp = from l in qlpt.DichVus
                     where l.MaDV == madich
                     select l;
            foreach (var item in lp)
            {
                return item.DonGia.ToString();
            }
            return "";
        }
    }
}
