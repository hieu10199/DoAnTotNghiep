using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QLLoaiPhong
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public QLLoaiPhong() { }

        // load data grid view 
        public IQueryable<LoaiPhong> LoadLoaiPhong_BLL()
        {
            return qlpt.LoaiPhongs.Select(k => k);
        }

        // thêm dịch vụ
        public void ThemLoaiPhong(string maLP, string tenLP,
            int tang, decimal giaLP, string moTa)
        {
            LoaiPhong lp = new LoaiPhong();
            lp.MaLoaiP = maLP;
            lp.TenLoaiP = tenLP;
            lp.Tang = tang;
            lp.GiaPhong = giaLP;
            lp.MoTa = moTa;

            qlpt.LoaiPhongs.InsertOnSubmit(lp);
            qlpt.SubmitChanges();
        }
        //// kiểm tra trùng DV
        public Boolean KiemTraTrung_LP(string maLP)
        {
            var lp = qlpt.LoaiPhongs.Where(n => (n.MaLoaiP == maLP)).FirstOrDefault();
            if (lp != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public string GetLastID()
        {
            LoaiPhong tb;
            List<LoaiPhong> loaiPhongs = qlpt.LoaiPhongs.Select(ph => ph).ToList();

            if (qlpt.LoaiPhongs.Select(ph => ph).Count() == 0)
            {
                return "L100";
            }
            else
            {
                tb = loaiPhongs.LastOrDefault();
            }
            return tb.MaLoaiP;
        }
        //// đếm số dv để cập nhật lại mã dv nếu cần thêm

        //// sửa toàn bộ thông tin dv , trừ mã dv
        public void suaLP(string maLP, string tenLP,
            int tang, decimal giaLP, string moTa)
        {

            LoaiPhong lp = qlpt.LoaiPhongs.Where(n => (n.MaLoaiP == maLP)).FirstOrDefault();

            lp.MaLoaiP = maLP;
            lp.TenLoaiP = tenLP;
            lp.Tang = tang;
            lp.GiaPhong = giaLP;
            lp.MoTa = moTa;

            qlpt.SubmitChanges();
        }

        //// xóa dv
        public void xoaLP(string maLP)
        {
            LoaiPhong lp = qlpt.LoaiPhongs.Where(d => d.MaLoaiP == maLP).FirstOrDefault();
            qlpt.LoaiPhongs.DeleteOnSubmit(lp);
            qlpt.SubmitChanges();
        }
    }
}
