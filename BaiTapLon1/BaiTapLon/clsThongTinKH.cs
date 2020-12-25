using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon
{
    public class clsThongTinKH:KetNoiCSDL
    {
        string maKH, hoTen, sDT, cMND, diaChi, anh;
        DateTime ngaySinh;
      
        public clsThongTinKH()
        {
            dt = GetDataContext();
        }
        public clsThongTinKH(string ma, string hoten, string sdt, string cmnd, DateTime ngaysinh, string diachi, string anh)
        {
            MaKH = ma;
            HoTen = hoten;
            SDT = sdt;
            CMND = cmnd;
            NgaySinh = ngaysinh;
            DiaChi = diachi;
            Anh = anh;
        }

        public string Anh
        {
            get => anh;
            set
            {

                anh = value;
            }
        }
        public string MaKH { get => maKH;
            set {
                if (value == "")
                    throw new Exception("Phải nhập Mã Khách Hàng!!");
                else
                    maKH = value;
            }
        }
        public string HoTen { get => hoTen;
            set {
                if (value == "")
                    throw new Exception("Phải nhập Họ và Tên!!");
                else
                    hoTen = value;
            }
        }
        public string SDT { get => sDT;
            set
            {
                if (value == "")
                    throw new Exception("Phải nhập SDT!!");
                else
                    sDT = value;
            } 
        }
        public string CMND { get => cMND; set => cMND = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DBQLPhongTroDataContext dt;
        public override bool Equals(object obj)
        {
            //ktra trùng mã là 2 obj bằng nhau
            return this.MaKH.Equals(((clsThongTinKH)obj).MaKH);
        }
        public IEnumerable<ThongTinKH> GetThongTinKH()
        {
            IEnumerable<ThongTinKH> p = from n in dt.ThongTinKHs
                                          select n;
            return p;
        }
        public void AddThongTinKH(ThongTinKH newKH)
        {
            System.Data.Common.DbTransaction kh = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = kh;
                dt.ThongTinKHs.InsertOnSubmit(newKH);
                dt.SubmitChanges();
                dt.Transaction.Commit();
            }
            catch
            {
                dt.Transaction.Rollback();
            }
        }
        public void UpdateThongTinKH(ThongTinKH updateKH)
        {
            /* using (var db = new DBQLPhongTroDataContext())
             {
                     ThongTinKH tt = db.ThongTinKHs.Single(x => x.MaKH == ma);
                     tt.HoTen = hoten;
                     tt.SDT = sdt;
                     tt.NgaySinh = ngay;
                     tt.CMND = cmnd;
                     tt.DiaChi = diachi;
                     tt.anh = anh;
                     db.SubmitChanges();
                     return ;
             }*/
            System.Data.Common.DbTransaction myKH = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myKH;
                IQueryable<ThongTinKH> tam = (from n in dt.ThongTinKHs
                                              where n.MaKH == updateKH.MaKH
                                              select n);
                //thầy mới sửa 4 field các ban có thể sửa thêm
                if (tam.First().MaKH.Length > 0)
                {

                    tam.First().HoTen = updateKH.HoTen;
                    tam.First().SDT = updateKH.SDT;
                    tam.First().CMND = updateKH.CMND;
                    tam.First().DiaChi = updateKH.DiaChi;
                    tam.First().anh = updateKH.anh;

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
        public void XoaThongTinKH(string ma)
        {
            using(var db = new DBQLPhongTroDataContext())
            {
                ThongTinKH tt = db.ThongTinKHs.Single(x => x.MaKH == ma);
                db.ThongTinKHs.DeleteOnSubmit(tt);
                db.SubmitChanges();
            }
        }
        public IEnumerable<ThongTinKH> TimKiemTen(string ten)
        {
            IEnumerable<ThongTinKH> p = from n in dt.ThongTinKHs
                                        where n.HoTen.StartsWith(ten)
                                        select n;
            return p;
        }
        public IEnumerable<ThongTinKH> TimKiemMa(string ma)
        {
            IEnumerable<ThongTinKH> p = from n in dt.ThongTinKHs
                                        where n.MaKH.StartsWith(ma)
                                        select n;
            return p;
        }
    }
}
