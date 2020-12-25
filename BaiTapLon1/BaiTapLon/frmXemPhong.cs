using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmXemPhong : Form
    {
        string ma;
        public frmXemPhong(string maPhong)
        {
            ma = maPhong;
            InitializeComponent();
        }

        private void XemPhong_Load(object sender, EventArgs e)
        {
            clsPhongTro thongtin = new clsPhongTro();
            IEnumerable<ThongTinPhong> tt = thongtin.GetThongTinPhong();
            foreach(ThongTinPhong p in tt)
            {
                if (p.MaPhong == ma)
                {
                    txtMaPhong.Text = p.MaPhong;
                    txtGia.Text = p.GiaPhong;
                    txtDienTich.Text = p.DienTich;
                    txtChuThich.Text = p.ChuThich;
                }
            }
        }
    }
}
