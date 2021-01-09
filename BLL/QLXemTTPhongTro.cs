using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{

    public class QLXemTTPhongTro
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();
        public void XemTTPhong(string MaPhong, DataGridView dvgTT)
        {
            var chungphong = from kh in qlpt.KhachTros
                             join p in qlpt.Phongs on kh.MaPhong equals p.MaPhong
                             where kh.MaPhong == MaPhong
                             select new
                             {
                                 p.MaPhong,
                                 p.TenPhong,
                                 kh.CMND,
                                 kh.NgaySinh,
                                 kh.HoTen,
                                 kh.VaiTro,
                                 kh.TrangThai
                             };

            DataTable dt = new DataTable();
            dt.Columns.Add("CMND");
            dt.Columns.Add("Họ tên");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Vai trò");
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Phòng");



            foreach (var tt in chungphong)
            {
                dt.Rows.Add(tt.CMND, tt.HoTen, tt.NgaySinh, tt.VaiTro, tt.TrangThai, tt.TenPhong);
            }
            dvgTT.DataSource = dt;
        }



        public int TimSoTang()
        {
            var tim = from p in qlpt.LoaiPhongs
                      select p.Tang;
            return tim.Count();
        }

        public string LayTrangThai(string mp)
        {

            var phong = from p in qlpt.Phongs
                        where p.MaPhong == mp
                        select p;
            foreach (var item in phong)
            {
                return item.TrangThai.Trim();
            }
            return "";
        }
        
        public string LayTrangTT(string map)
        {
            DateTime dt= new DateTime();
            dt.ToString("dd/MM/yyyy");
            var dp = from ddp in qlpt.DatPhongs
                        where ddp.MaPhong == map
                        select ddp;
            foreach (var item in dp)
            {
                return "Số CMND: "+item.CMND.Trim() + " - Phòng: "+ item.MaPhong.Trim() + "\n Ngày đặt: " + item.NgayDat.ToString() + "\n Ngày DK Nhận: " + item.NgayDKNhan.ToString();
            }
            return "";
        }
        public string LayCMND(string map)
        {

            var phong = from p in qlpt.DatPhongs
                        where p.MaPhong == map
                        select p;
            foreach (var item in phong)
            {
                return item.CMND.Trim();
            }
            return "";
        }
        public string LayTen(string map)
        {

            var phong = from p in qlpt.DatPhongs
                        join kh in qlpt.KhachTros on p.CMND equals kh.CMND
                        where p.MaPhong == map
                        select kh;
            foreach (var item in phong)
            {
                return item.HoTen.Trim();
            }
            return "";
        }
        public string LayMaDP(string map)
        {

            var phong = from p in qlpt.DatPhongs
                        where p.MaPhong == map
                        select p;
            foreach (var item in phong)
            {
                return item.MaDP.Trim();
            }
            return "";
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

        public void loadThanhToan(string maphong, string mapt, string tongtien)
        {
            var tt = from t in qlpt.PhieuThuTiens
                     join p in qlpt.Phongs on t.MaPhong equals p.MaPhong
                     where t.MaPhong == maphong
                     select t;
            foreach(var item in tt)
            {
                mapt = item.MaPhieuThu.Trim();
            }
        }

        public string LayMaPT(string map)
        {

            var phong = from t in qlpt.PhieuThuTiens 
                        join p in qlpt.DatPhongs on t.MaPhong equals p.MaPhong
                        where p.MaPhong == map
                        select t;
            foreach (var item in phong)
            {
                return item.MaPhieuThu.Trim();
            }
            return "";
        }
        public string LayTienDien(string map)
        {

            var phong = from t in qlpt.PhieuThuTiens
                        join p in qlpt.DatPhongs on t.MaPhong equals p.MaPhong
                        where p.MaPhong == map
                        select t;
            foreach (var item in phong)
            {
                return item.TienDien.ToString();
            }
            return "";
        }
        public string LayTienNuoc(string map)
        {

            var phong = from t in qlpt.PhieuThuTiens
                        join p in qlpt.DatPhongs on t.MaPhong equals p.MaPhong
                        where p.MaPhong == map
                        select t;
            foreach (var item in phong)
            {
                return item.TienNuoc.ToString();
            }
            return "";
        }
        public string tongtien(string map)
        {

            var phong = from t in qlpt.PhieuThuTiens
                        join p in qlpt.DatPhongs on t.MaPhong equals p.MaPhong
                        where p.MaPhong == map
                        select t;
            foreach (var item in phong)
            {
                return item.TongTien.ToString();
            }
            return "";
        }
        public string LayThang(string map)
        {

            var phong = from t in qlpt.PhieuThuTiens
                        join p in qlpt.DatPhongs on t.MaPhong equals p.MaPhong
                        where p.MaPhong == map
                        select t;
            foreach (var item in phong)
            {
                return item.Thang.ToString();
            }
            return "";
        }
        public string LayTrangThaiCongNo(string maphong)
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


    }
}
