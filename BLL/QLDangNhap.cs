using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class QLDangNhap
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public int LayTaiKhoan(string user, string password)
        {
            //password = MaHoa(password);
            var tk = (from x in qlpt.ChuTros
                      where x.CMNDCT.Trim() == user && x.MatKhau.Trim() == password
                      select x).ToList();
            int a = tk.Count();
            return a;
        }

        public void DangKiTaiKhoang(string cmndct, string pass, string sdt, string daichi, string Hoten)
        {
            ChuTro ct = new ChuTro();
            ct.CMNDCT = cmndct;
            ct.MatKhau = pass;
            ct.SDT = sdt;
            ct.DiaChi = daichi;
            ct.HoTenChuTro = Hoten;

            qlpt.ChuTros.InsertOnSubmit(ct);
            qlpt.SubmitChanges();
        }
        public void DoiMK(string TenDN, string txtMatKhauCu, string txtMatKhauMoi, string txtXacNhan, Form DoiMK)
        {
            var tk = (from a in qlpt.ChuTros
                      where a.CMNDCT == TenDN
                      select a).SingleOrDefault();

            if (tk != null)
            {
                if (tk.MatKhau.Trim() == txtMatKhauCu && txtMatKhauMoi == txtXacNhan)
                {
                    tk.MatKhau = txtMatKhauMoi;
                    qlpt.SubmitChanges();
                    //BLTB.Show("Đổi mật khẩu thành công");
                    MessageBox.Show("Đổi mật khẩu thành công");
                    DoiMK.Hide();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu cũ hoặc mật khẩu mới không khớp!");
                    //BLTB.Show("Sai mật khẩu cũ hoặc mật khẩu mới không khớp!");
                }
            }
        }
        public string LayTenNV(string user, string password)
        {
            string b = "";
            var Tennv = (from p in qlpt.ChuTros
                         where p.CMNDCT.Trim() == user && p.MatKhau.Trim() == password
                         select new
                         {
                             p.HoTenChuTro                       
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.HoTenChuTro;
            }
            return b;
        }
        public string LaySDT(string user, string sdt)
        {
            string b = "";
            var sdtt = (from p in qlpt.ChuTros
                         where p.CMNDCT.Trim() == user && p.MatKhau.Trim() == sdt
                         select new
                         {
                             p.SDT
                         }).ToList();
            if (sdtt.Count() != 0)
            {
                foreach (var a in sdtt)
                    b = a.SDT;
            }
            return b;
        }
        public Boolean KiemTraTrung(string cmnd)
        {
            var ct = qlpt.ChuTros.Where(n => (n.CMNDCT == cmnd)).FirstOrDefault();
            if (ct != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
    }
}
