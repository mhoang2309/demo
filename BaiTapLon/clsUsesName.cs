using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon
{
    public class clsUsesName:KetNoiCSDL
    {
        string uses, pass, quyen;
        public clsUsesName()
        {
            dt = GetDataContext();
        }
        public clsUsesName(string uses, string pass, string quyen)
        {
            Uses = uses;
            Pass = pass;
            Quyen = quyen;
        }

        public string Uses { get => uses;
            set
            {
                if (value == "")
                    throw new Exception("Phải nhập Uses Name!!");
                else
                    uses = value;
            }
        }

        public string Pass { get => pass;
            set
            {
                if (value == "")
                    throw new Exception("Phải nhập Pass!!");
                else
                    pass = value;
            }
        }
        public string Quyen { get => quyen; set => quyen = value; }

        public override bool Equals(object obj)
        {
            //ktra trùng mã là 2 obj bằng nhau
            return this.Uses.Equals(((clsUsesName)obj).Uses);
        }

        public DBQLPhongTroDataContext dt;
        public IEnumerable<TaiKhoan> GetTaiKhoan()
        {
            IEnumerable<TaiKhoan> p = from n in dt.TaiKhoans
                                      select n;
            return p;
        }
    }
}
