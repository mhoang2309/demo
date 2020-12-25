using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon
{
    public class clsThongTinThue:KetNoiCSDL
    {
        string maThue, maKH, maPhong;
        DateTime ngayThue, ngayTra;
        public clsThongTinThue()
        {
            dt = GetDataContext();
        }
        public clsThongTinThue(string ma, string makh, string maphong, DateTime ngaythue, DateTime ngaytra)
        {
            MaThue = ma;
            MaKH = makh;
            MaPhong = maphong;
            NgayThue = ngaythue;
            NgayTra = ngaytra;
        }

        public string MaThue { get => maThue;
            set {
                if (value == "")
                    throw new Exception("Phải nhập Mã Thue!!");
                else
                    maThue = value;
            } 
        }
        public string MaKH { get => maKH;
            set
            {
                if (value == "")
                    throw new Exception("Phải nhập Mã KH!!");
                else
                    maKH = value;
            }
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
        public DateTime NgayThue { get => ngayThue; set => ngayThue = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public bool TinhTrang(string ma, DateTime ngaythue, DateTime ngaytra)
        {
            if (ngaytra != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DBQLPhongTroDataContext dt;
        public override bool Equals(object obj)
        {
            //ktra trùng mã là 2 obj bằng nhau
            return this.MaThue.Equals(((clsThongTinThue)obj).MaThue);
        }
        public IEnumerable<ThongTinThue> GetThongTinThue()
        {
            IEnumerable<ThongTinThue> p = from n in dt.ThongTinThues
                                           select n;
            return p;
        }
        public void AddThongTinThue(ThongTinThue newThue)
        {
            System.Data.Common.DbTransaction Thue = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = Thue;
                dt.ThongTinThues.InsertOnSubmit(newThue);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch
            {
                dt.Transaction.Rollback();
            }
        }
        public void UpdateThongTinThue(ThongTinThue updateThue)
        {
            System.Data.Common.DbTransaction myThue = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myThue;
                IQueryable<ThongTinThue> tam = (from n in dt.ThongTinThues
                                              where n.MaThue == updateThue.MaThue
                                              select n);
                //thầy mới sửa 4 field các ban có thể sửa thêm
                if (tam.First().MaThue.Length > 0)
                {
                    tam.First().MaKH = updateThue.MaKH;
                    tam.First().MaPhong = updateThue.MaPhong;
                    tam.First().NgayThue = updateThue.NgayThue;
                    tam.First().NgayTra = updateThue.NgayTra;
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
        public void XoaThongTinThue1(string ma)
        {
            using (var db = new DBQLPhongTroDataContext())
            {
                ThongTinThue tt = db.ThongTinThues.Single(x => x.MaKH == ma);
                db.ThongTinThues.DeleteOnSubmit(tt);
                db.SubmitChanges();

            }
        }
        public void XoaThongTinThue(string ma)
        {
            using (var db = new DBQLPhongTroDataContext())
            {
                ThongTinThue tt = db.ThongTinThues.Single(x => x.MaThue == ma);
                db.ThongTinThues.DeleteOnSubmit(tt);
                db.SubmitChanges();
                
            }
        }
        public void XoaThongTinThuemaphong(string ma)
        {
            using (var db = new DBQLPhongTroDataContext())
            {
                ThongTinThue tt = db.ThongTinThues.Single(x => x.MaPhong == ma);
                db.ThongTinThues.DeleteOnSubmit(tt);
                db.SubmitChanges();
            }
        }
    }
}
