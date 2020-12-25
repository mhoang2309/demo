using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon
{
    public class KetNoiCSDL
    {
        private DBQLPhongTroDataContext dt;
        public DBQLPhongTroDataContext GetDataContext()
        {
            String strKetNoi = @"Data Source=DESKTOP-5MNSNNK\SQLEXPRESS;Initial Catalog=PhongTro;Integrated Security=True";
            dt = new DBQLPhongTroDataContext(strKetNoi);
            dt.Connection.Open();
            return dt;
        }
    }
}
