using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class QLPhong
    {
        QLPhongTroDataContext qlpt = new QLPhongTroDataContext();
        //GenAuto gen = new GenAuto();
        //public void loadDataPhong(String maPhong, GridView dtgvPhong)
        //{
        //    var p = from ph in qlpt.Phongs select ph;
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Mã phòng");
        //    dt.Columns.Add("Tên phòng");
        //    dt.Columns.Add("SL Tối đa");
        //    dt.Columns.Add("Trạng thái");
        //    dt.Columns.Add("Loại Phòng");
        //    dt.Columns.Add("Số Điện");
        //    dt.Columns.Add("Số Nước");
        //    dt.Columns.Add("Diện Tích");
        //    dt.Columns.Add("Ban Công");
        //    dt.Columns.Add("Công Nợ");

        //    foreach (var tt in p)
        //    {
        //        dt.Rows.Add(tt.MaPhong, tt.TenPhong, tt.SLToiDa, tt.TrangThai, tt.MaLoaiP, tt.SoDien, tt.SoNuoc, tt.DienTich, tt.BanCong, tt.CongNo);
        //    }
        //    dtgvPhong.DataSource = dt;
        //}

        public IQueryable<Phong> loadDataPhong()
        {
            return qlpt.Phongs.Select(k => k);
        }
        public void ThemPhong(String maPhong, String tenPhong,int slToiDa, String trangThai, String maLoaiP, int soDien, int sNuoc, String dienTich, String banCong, String congNo )
        {
            Phong p = new Phong();
            p.MaPhong = maPhong;
            p.TenPhong = tenPhong;
            p.SLToiDa = slToiDa;
            p.TrangThai = trangThai;
            p.MaLoaiP = maLoaiP;
            p.SoDien = soDien;
            p.SoNuoc = sNuoc;
            p.DienTich = dienTich;
            p.BanCong = banCong;
            p.CongNo = congNo;
            qlpt.Phongs.InsertOnSubmit(p);
            qlpt.SubmitChanges();
        }

        public void XoaPhong(String maPhong)
        {
            Phong p = qlpt.Phongs.Where(t => t.MaPhong == maPhong).FirstOrDefault();
            if(p!= null)
            {
                qlpt.Phongs.DeleteOnSubmit(p);
                qlpt.SubmitChanges();
            }

        }
        public string GetLastID()
        {
            Phong p;
            List<Phong> phongs = qlpt.Phongs.Select(ph => ph).ToList();

            if (qlpt.Phongs.Select(ph => ph).Count() == 0)
            {
                return "P100";
            }
            else
            {
                p = phongs.LastOrDefault();
            }
            return p.MaPhong;


        }
        public void SuaPhong(String maPhong, String tenPhong, int slToiDa, String trangThai, String maLoaiP, int soDien, int sNuoc, String dienTich, String banCong, String congNo)
        {
            var p = (from ph in qlpt.Phongs where ph.MaPhong == maPhong select ph).SingleOrDefault();
            if (p!= null)
            {
                p.TenPhong = tenPhong;
                p.SLToiDa = slToiDa;
                p.TrangThai = trangThai;
                p.MaLoaiP = maLoaiP;
                p.SoDien = soDien;
                p.SoNuoc = sNuoc;
                p.DienTich = dienTich;
                p.BanCong = banCong;
                p.CongNo = congNo;
                qlpt.SubmitChanges();
            }
        }

        public Boolean KiemTraTrungPhong(string maP)
        {
            var lp = qlpt.Phongs.Where(n => (n.MaPhong == maP)).FirstOrDefault();
            if (lp != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        public void loadCbbLoaiPhong(ComboBox cbbMaLoaiP)
        {
            var lp = from l in qlpt.LoaiPhongs select l;
            cbbMaLoaiP.DataSource = lp;
            cbbMaLoaiP.DisplayMember = "TenLoaiP";
            cbbMaLoaiP.ValueMember = "MaLoaiP";


        }
        public string LayMaLoaiPhong(string tenLoaiP)
        {
            string b = "";

            var malp = (from p in qlpt.LoaiPhongs
                        where p.TenLoaiP.Trim() == tenLoaiP
                        select new
                        {
                            p.MaLoaiP
                        }).ToList();
            if (malp.Count() != 0)
            {
                foreach (var a in malp)
                    b = a.MaLoaiP;
            }
            return b;
        }

        public string LayTenLoaiPhong(string maLoaiP)
        {
            string b = "";

            var tenlp = (from p in qlpt.LoaiPhongs
                         where p.MaLoaiP.Trim() == maLoaiP
                         select new
                         {
                             p.TenLoaiP
                         }).ToList();
            if (tenlp.Count() != 0)
            {
                foreach (var a in tenlp)
                    b = a.TenLoaiP;
            }
            return b;
        }
    }
}
