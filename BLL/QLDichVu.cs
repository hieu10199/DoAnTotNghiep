using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QLDichVu
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();
        public QLDichVu() { }

        // load data grid view 
        public IQueryable<DichVu> LoadDichVu_BLL()
        {
            return qlpt.DichVus.Select(k => k);
        }

        // thêm dịch vụ
        public void ThemDV(string maDV, string tenDV,
            decimal giaDV, string DVT)
        {
            DichVu dv = new DichVu();
            dv.MaDV = maDV;
            dv.TenDV = tenDV;
            dv.DonGia = giaDV;
            dv.DonViTinh = DVT;

            qlpt.DichVus.InsertOnSubmit(dv);
            qlpt.SubmitChanges();
        }
        //// kiểm tra trùng DV
        public Boolean KiemTraTrung_DV(string maDV)
        {
            var dv = qlpt.DichVus.Where(n => (n.MaDV == maDV)).FirstOrDefault();
            if (dv != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        //// đếm số dv để cập nhật lại mã dv nếu cần thêm
        public string GetLastID()
        {
            DichVu tb;
            List<DichVu> dichVus = qlpt.DichVus.Select(ph => ph).ToList();

            if (qlpt.DichVus.Select(ph => ph).Count() == 0)
            {
                return "D100";
            }
            else
            {
                tb = dichVus.LastOrDefault();
            }
            return tb.MaDV;
        }

        //// sửa toàn bộ thông tin dv , trừ mã dv
        public void suaDV(string maDV, string tenDV,
            decimal giaDV, string DVT)
        {
            DichVu dv = qlpt.DichVus.Where(d => d.MaDV == maDV).FirstOrDefault();



            dv.TenDV = tenDV;
            dv.DonGia = giaDV;
            dv.DonViTinh = DVT;

            qlpt.SubmitChanges();
        }

        //// xóa dv
        public void xoaDV(string maDV)
        {
            DichVu dv = qlpt.DichVus.Where(d => d.MaDV == maDV).FirstOrDefault();
            qlpt.DichVus.DeleteOnSubmit(dv);
            qlpt.SubmitChanges();
        }
    }
}
