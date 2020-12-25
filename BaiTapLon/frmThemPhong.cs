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
    public partial class frmThemPhong : Form
    {
        public frmThemPhong()
        {
            InitializeComponent();
        }
        clsPhongTro thongtinphong = new clsPhongTro();
        int bien = 0;
        string TangMa()
        {
            int a;//số
            a = TachSo("P0001");
            IEnumerable<ThongTinPhong> tt = thongtinphong.GetThongTinPhong();

            foreach (ThongTinPhong p in tt)
            {
                foreach (ThongTinPhong d in tt)
                {

                    if (a == TachSo(p.MaPhong))
                    {
                        a++;
                        break;
                    }
                }
            }
            return Convert.ToString(a);
        }
        int TachSo(string input)
        {
            int i = 0;
            string[] numbers = Regex.Split(input, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    i = int.Parse(value);
                }
            }
            return i;
        }
        string OutMaVuaTang()
        {
            if (Convert.ToInt32(TangMa()) < 10)
            {
                //MessageBox.Show("P000" + TangMa());
                return "P000" + TangMa();
            }
            else if (Convert.ToInt32(TangMa()) >= 10 && Convert.ToInt32(TangMa()) < 100)
            {
                // MessageBox.Show("P00" + TangMa());
                return "P00" + TangMa();
            }
            else if (Convert.ToInt32(TangMa()) >= 100 && Convert.ToInt32(TangMa()) < 1000)
            {
                //MessageBox.Show("P0" + TangMa());
                return "P0" + TangMa();
            }
            else
            {
                //MessageBox.Show("P" + TangMa());
                return "P" + TangMa();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(btnThem);
            this.Controls.Add(btnLuu);
            txtChuThich.Enabled = true;
            txtDienTich.Enabled = true;
            txtGia.Enabled = true;
            if (txtMaPhong.Enabled == false)
            {
                thêmMãPhòngThủCôngToolStripMenuItem.Enabled = true;
                thêmMãPhòngTựĐộngToolStripMenuItem.Enabled = false;
                txtMaPhong.Text = OutMaVuaTang();
            }

        }

        private void frmThemPhong_Load(object sender, EventArgs e)
        {
            this.Controls.Remove(btnLuu);
            this.Controls.Add(btnThem);
            thêmMãPhòngThủCôngToolStripMenuItem.Enabled = true;
            thêmMãPhòngTựĐộngToolStripMenuItem.Enabled = false;
            txtMaPhong.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            IEnumerable<ThongTinPhong> tt = thongtinphong.GetThongTinPhong();
            ThongTinPhong phong = new ThongTinPhong();
            phong.MaPhong = txtMaPhong.Text;
            phong.DienTich = txtDienTich.Text;
            phong.GiaPhong = txtGia.Text;
            phong.ChuThich = txtChuThich.Text;
            try
            {
                thongtinphong.MaPhong = phong.MaPhong;
                thongtinphong.DienTich = phong.DienTich;
                thongtinphong.Gia = phong.GiaPhong;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            foreach (ThongTinPhong p in tt)
            {
                if (p.MaPhong == phong.MaPhong)
                {
                    MessageBox.Show("Phòng " + phong.MaPhong + " lỗi(trùng mã)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            thongtinphong.AddThongTinPhong(phong);

            foreach (ThongTinPhong p in tt)
            {
                if (p.MaPhong == phong.MaPhong)
                {
                    MessageBox.Show("Phòng " + p.MaPhong + " thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    txtMaPhong.Enabled = false;
                    txtGia.Enabled = false;
                    txtDienTich.Enabled = false;
                    txtChuThich.Enabled = false;
                    this.Controls.Remove(btnLuu);
                    this.Controls.Add(btnThem);
                    return;
                }
            }
            btnXoa_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtChuThich.Text = null;
            txtDienTich.Text = null;
            txtGia.Text = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblMaPhong_Click(object sender, EventArgs e)
        {
            if (bien == 0)
            {
                txtMaPhong.Enabled = true;
                thêmMãPhòngThủCôngToolStripMenuItem.Enabled = false;
                thêmMãPhòngTựĐộngToolStripMenuItem.Enabled = true;
                bien = 1;
                return;
            }
            else
            {
                txtMaPhong.Enabled = false;
                thêmMãPhòngThủCôngToolStripMenuItem.Enabled = true;
                thêmMãPhòngTựĐộngToolStripMenuItem.Enabled = false;
                bien = 0;
                return;
            }

        }

        private void thêmMãPhòngThủCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblMaPhong_Click(sender, e);
        }

        private void thêmMãPhòngTựĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblMaPhong_Click(sender, e);
        }
    }
}
