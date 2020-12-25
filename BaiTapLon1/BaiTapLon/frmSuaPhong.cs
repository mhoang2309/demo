using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmSuaPhong : Form
    {
        string maPhongTruyenVao;
        string maThueTruyenVao;
        string ma, ma2;
        clsPhongTro thongtinphong = new clsPhongTro();
        public frmSuaPhong(string ma, string ma2)
        {
            InitializeComponent();
            maPhongTruyenVao = ma;
            maThueTruyenVao = ma2;
        }

        private void frmSuaPhong_Load(object sender, EventArgs e)
        {
            xulygiatri(maPhongTruyenVao);
            Loadtxt(ma);
        }
        void Loadtxt( string ma)
        {
            IEnumerable<ThongTinPhong> phong = thongtinphong.GetThongTinPhong();
            foreach (ThongTinPhong p in phong)
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
        void xulygiatri(string input)
        {
            string[] m = Regex.Split(input, @"\D+ ");
            foreach (string value in m)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ma = value;
                }
            }   
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ThongTinPhong phong = new ThongTinPhong();
            phong.MaPhong = ma;
            phong.DienTich = txtDienTich.Text;
            phong.ChuThich = txtChuThich.Text;
            phong.GiaPhong = txtGia.Text;
            try
            {
                thongtinphong.DienTich = phong.DienTich;
                thongtinphong.Gia = phong.GiaPhong;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            thongtinphong.UpdateThongTinPhong(phong);
            this.Controls.Remove(btnCapNhat);
            this.Controls.Add(btnSua);
            txtChuThich.Enabled = false;
            txtDienTich.Enabled = false;
            txtGia.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtChuThich.Enabled = true;
            txtDienTich.Enabled = true;
            txtGia.Enabled = true;
            this.Controls.Remove(btnSua);
            this.Controls.Add(btnCapNhat);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            clsThongTinThue thongtinthue = new clsThongTinThue();
            IEnumerable<ThongTinThue> dk = thongtinthue.GetThongTinThue();
            foreach (ThongTinThue p in dk)
            {
                if (ma == p.MaPhong)
                {
                    DialogResult d = MessageBox.Show("Bạn có chắc muốn xóa luôn thông tin thuê?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (d == DialogResult.Yes)
                    {
                        thongtinthue.XoaThongTinThue(maThueTruyenVao);
                    }
                }
            }
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                thongtinphong.XoaThongTinPhong(ma);
                txtChuThich.Clear();
                txtDienTich.Clear();
                txtGia.Clear();
                txtMaPhong.Clear();
                return;
            }
        }
    }
}
