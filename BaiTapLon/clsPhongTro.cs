using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon
{
    public class clsPhongTro:KetNoiCSDL
    {
        string maPhong, dienTich, gia, chuThich;

        public clsPhongTro()
        {
            dt = GetDataContext();
        }
        public clsPhongTro(string ma, string dientich, string gia, string chuthich)
        {
            MaPhong = ma;
            DienTich = dientich;
            Gia = gia;
            ChuThich = chuthich;
        }

        public string MaPhong { get => maPhong;
            set 
            {
                if (value == "")
                    throw new Exception("Phải nhập Mã Phòng!!");
                else
                    maPhong = value;
            }
        }
        public string DienTich { get => dienTich; 
            set 
                {
                if (value == "")
                    throw new Exception("Phải nhập Diện Tích Phòng!!");
                else
                    maPhong = value;
            }
        }
        public string Gia { get => gia;
            set
            {
                if (value == "")
                    throw new Exception("Phải nhập Giá Phòng!!");
                else
                    gia = value;
            }
        }
        public string ChuThich { get => chuThich; set => chuThich = value; }
        
        public override bool Equals(object obj)
        {
            //ktra trùng mã là 2 obj bằng nhau
            return this.MaPhong.Equals(((clsPhongTro)obj).MaPhong);
        }
        public DBQLPhongTroDataContext dt;
        public IEnumerable<ThongTinPhong> GetThongTinPhong()
        {
            IEnumerable<ThongTinPhong> p = from n in dt.ThongTinPhongs
                                           select n;
            return p;
        }
        public void AddThongTinPhong(ThongTinPhong newPhong)
        {
            System.Data.Common.DbTransaction Phong = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = Phong;
                dt.ThongTinPhongs.InsertOnSubmit(newPhong);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch
            {
                dt.Transaction.Rollback();
            }
        }
        public void UpdateThongTinPhong(ThongTinPhong updatePhong)
        {
            System.Data.Common.DbTransaction myPhong = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myPhong;
                IQueryable<ThongTinPhong> tam = (from n in dt.ThongTinPhongs
                                              where n.MaPhong == updatePhong.MaPhong
                                              select n);
                //thầy mới sửa 4 field các ban có thể sửa thêm
                if (tam.First().MaPhong.Length > 0)
                {

                    tam.First().DienTich = updatePhong.DienTich;
                    tam.First().GiaPhong = updatePhong.GiaPhong;
                    tam.First().ChuThich = updatePhong.ChuThich;
                    dt.SubmitChanges();
                    dt.Transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                //throw new Exception(ex.Message+"sua");
            }
        }
        public void XoaThongTinPhong(string ma)
        {
            using (var db = new DBQLPhongTroDataContext())
            {
                ThongTinPhong tt = db.ThongTinPhongs.Single(x => x.MaPhong == ma);
                db.ThongTinPhongs.DeleteOnSubmit(tt);
                db.SubmitChanges();
            }
        }
    }
}
