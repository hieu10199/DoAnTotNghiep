using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class QLKhachTro
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();

        public IQueryable<KhachTro> loadDataKhach()
        {
            return qlpt.KhachTros.Select(k => k);
        }

        public void ThemKhachTro(String CMND, String hten, DateTime ns, String gt, String nn, String sdt, String img, String dc, String mp, String vt, String tt )
        {
            KhachTro kt = new KhachTro();
            kt.CMND = CMND;
            kt.HoTen = hten;
            kt.NgaySinh = ns;
            kt.GioiTinh = gt;
            kt.NgheNghiep = nn;
            kt.SDT = sdt;
            kt.HinhAnh = img;
            kt.DiaChiThuongTru = dc;
            kt.MaPhong = mp;
            kt.VaiTro = vt;
            kt.TrangThai = tt;
            qlpt.KhachTros.InsertOnSubmit(kt);
            qlpt.SubmitChanges();
        }

        public void XoaKhachTro(String cmnd)
        {
            KhachTro kt = qlpt.KhachTros.Where(t => t.CMND == cmnd).FirstOrDefault();
            if (kt != null)
            {
                qlpt.KhachTros.DeleteOnSubmit(kt);
                qlpt.SubmitChanges();
            }

        }
        public void SuaKhachTro(String CMND, String hten, DateTime ns, String gt, String nn, String sdt, String img, String dc, String mp, String vt, String tt)
        {
            var kt = (from cm in qlpt.KhachTros where cm.CMND== CMND select cm).SingleOrDefault();
            if (kt != null)
            {
                kt.HoTen = hten;
                kt.NgaySinh = ns;
                kt.GioiTinh = gt;
                kt.NgheNghiep = nn;
                kt.SDT = sdt;
                kt.HinhAnh = img;
                kt.DiaChiThuongTru = dc;
                kt.MaPhong = mp;
                kt.VaiTro = vt;
                kt.TrangThai = tt;
                qlpt.SubmitChanges();
            }
        }
        public Boolean KiemTraTrungKT(string cmnd)
        {
            var kt = qlpt.KhachTros.Where(n => (n.CMND == cmnd)).FirstOrDefault();
            if (kt != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        public void loadCbbLoaiPhong(ComboBox cbbP)
        {
            var p = from ph in qlpt.Phongs select ph;
            cbbP.DataSource = p;
            cbbP.DisplayMember = "TenPhong";
            cbbP.ValueMember = "MaPhong";


        }
        public void LayHinhAnh(string cmnd, PictureBox PicThucAn)
        {

            var hinhAnh = from h in qlpt.KhachTros
                          where h.CMND == cmnd
                          select h;
            foreach (var item in hinhAnh)
            {
                try
                {
                    if (item.HinhAnh.Trim() != "No Image")
                    {
                        PicThucAn.Image = Image.FromFile(item.HinhAnh);
                        PicThucAn.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                        PicThucAn.Image = Image.FromFile("E:\\Imgae\\ThieuHinh.jpg");
                }
                catch
                {
                    PicThucAn.Image = Image.FromFile("E:\\Imgae\\ThieuHinh.jpg");
                }
            }
        }
        public string LayHinhAnh2(string cmnd)
        {
            var HA = from h in qlpt.KhachTros
                     where h.CMND.Trim() == cmnd.Trim()
                     select h;
            foreach (var item in HA)
            {
                if (item.HinhAnh == null)
                    return "No Image";
                return item.HinhAnh.ToString().Trim();
            }
            return "";
        }
        public void LayHinhAnh3(string link, PictureBox PicThucAn)
        {

            try
            {
                PicThucAn.Image = Image.FromFile(link);
            }
            catch
            {
                PicThucAn.Image = Image.FromFile("E:\\Imgae\\ThieuHinh.jpg");
            }

        }
        public int LaySoLuongPhong(string map)
        {
            int soluong = 0;
            var phong = from p in qlpt.Phongs
                        select p;
            foreach (var item in phong)
            {
                soluong = (int)item.SLToiDa;
            }
            return soluong;
        }

        public bool kiemtraSLPhong(string maphong, int soluong)
        {
            var chungphong = (from kh in qlpt.KhachTros
                              join p in qlpt.Phongs on kh.MaPhong equals p.MaPhong
                              where kh.MaPhong == maphong
                              select kh).Count();
            if(chungphong < soluong)
            {
                return true;
            }
            return false;

        }


    }
}
