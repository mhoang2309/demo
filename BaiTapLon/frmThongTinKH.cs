using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BaiTapLon
{
    public partial class frmThongTinKH : Form
    {
        
        public frmThongTinKH()
        {
            InitializeComponent();
        }
        clsThongTinKH thongtin = new clsThongTinKH();
        string MaTruyenVao;
        string MaTruyenVao2;
        string a;
        string fileimg = null;
        public frmThongTinKH(string ma, string ma2):this()
        {
            MaTruyenVao = ma;
            MaTruyenVao2 = ma2;
        }
        private void frmThongTinKH_Load(object sender, EventArgs e)
        {
            this.thongTinKHTableAdapter.Fill(this.phongTroDataSet.ThongTinKH);
            cbMaKH.Items.Clear();
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            dateTimeNgaySinh.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            this.Controls.Remove(btnLuu);
            this.Controls.Remove(btnUpDate);
            IEnumerable<ThongTinKH> tt = thongtin.GetThongTinKH();
            LoadMaKHComboBox(tt);
            
            

        }
        void LoadThongTinKH(IEnumerable<ThongTinKH> tt, string ma)
        {
            foreach(ThongTinKH p in tt)
            {
                if(ma == p.MaKH)
                {
                    if (p.anh != null)
                    {
                        LoadAnh3x4(p.anh);
                    }
                    else
                    {
                        anh3x4.Image = anh3x4.ErrorImage;
                    }
                    dateTimeNgaySinh.Value =Convert.ToDateTime(p.NgaySinh);
                    txtHoTen.Text = p.HoTen;
                    txtSDT.Text = p.SDT;
                    txtCMND.Text = p.CMND;
                    txtDiaChi.Text = p.DiaChi;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            cbMaKH.Enabled = false;
            cbMaKH.Text = OutMaVuaTang();
            IEnumerable<ThongTinKH> tt = thongtin.GetThongTinKH();
            foreach(ThongTinKH p in tt)
            {
                if (cbMaKH.Text == p.MaKH || cbMaKH.Text.Length < 5 || cbMaKH.Text.Length > 5)
                {
                    btnLuu.Enabled = false;
                    return;
                }
            }
            anh3x4.Image = anh3x4.ErrorImage;
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            dateTimeNgaySinh.Enabled = true;
            btnImg();
            btnLuu.Enabled = true;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtCMND.Clear();
            this.Controls.Remove(btnThem);
            this.Controls.Add(btnLuu);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void BrowseMultipleButton_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter ="Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +"All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Photos";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {

                        LoadAnh3x4(file);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            IEnumerable<ThongTinKH> tt = thongtin.GetThongTinKH();
            ThongTinKH kh = new ThongTinKH();
            kh.MaKH = cbMaKH.Text;
            MaTruyenVao = kh.MaKH;
            kh.HoTen = txtHoTen.Text;
            kh.SDT = txtSDT.Text;
            kh.CMND = txtCMND.Text;
            kh.NgaySinh = dateTimeNgaySinh.Value;
            kh.DiaChi = txtDiaChi.Text;
            if (anh3x4.Image != anh3x4.ErrorImage)
            {
                kh.anh = @"..\..\imgKH\" + kh.MaKH + ".jpg";
                SaveAnh3x4(kh.anh);

            }
            try
            {
                thongtin.MaKH = kh.MaKH;
                thongtin.HoTen = kh.HoTen;
                thongtin.SDT = kh.SDT;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            thongtin.AddThongTinKH(kh);
            this.Controls.Remove(btnLuu);
            this.Controls.Add(btnThem);
            cbMaKH.Enabled = true;
            frmThongTinKH_Load(sender, e);
        }
        void PhatSinhMaKH(IEnumerable<ThongTinKH> tt)
        {
            foreach(ThongTinKH p in tt)
            {

            }
        }
        void LoadMaKHComboBox(IEnumerable<ThongTinKH> tt)
        {  
            foreach(ThongTinKH p in tt)
            {
                cbMaKH.Items.Add(p.MaKH);
            }
            
            cbMaKH.SelectedItem = MaTruyenVao;
        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            IEnumerable<ThongTinKH> tt = thongtin.GetThongTinKH();
            a = cb.SelectedItem.ToString();
            LoadThongTinKH(tt, a);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            btnImg();
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            dateTimeNgaySinh.Enabled = true;
            this.Controls.Remove(btnSua);
            this.Controls.Add(btnUpDate);
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {

            ThongTinKH kh = new ThongTinKH();
            kh.MaKH = cbMaKH.Text;
            MaTruyenVao = kh.MaKH;
            kh.HoTen = txtHoTen.Text;
            kh.SDT = txtSDT.Text;
            kh.CMND = txtCMND.Text;
            kh.NgaySinh = dateTimeNgaySinh.Value;
            kh.DiaChi = txtDiaChi.Text;
            kh.anh = @"..\..\imgKH\" + kh.MaKH + ".jpg";
            try
            {
                thongtin.MaKH = kh.MaKH;
                thongtin.HoTen = kh.HoTen;
                thongtin.SDT = kh.SDT;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            SaveAnh3x4(kh.anh);
            thongtin.UpdateThongTinKH(kh);
            this.Controls.Remove(btnUpDate);
            this.Controls.Add(btnSua);
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            frmThongTinKH_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int hoi = 0;
            clsThongTinThue thongtinthue = new clsThongTinThue();
            IEnumerable<ThongTinThue> dk = thongtinthue.GetThongTinThue();
            foreach(ThongTinThue p in dk)
            {
                if (cbMaKH.Text == p.MaKH)
                {
                    if (hoi == 0)
                    {
                        DialogResult d = MessageBox.Show("Bạn có chắc muốn xóa luôn thông tin thuê?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (d == DialogResult.Yes)
                        {
                            thongtinthue.XoaThongTinThue1(p.MaKH);
                            hoi = 1;
                        }
                    }
                    if (hoi == 1)
                    {
                        thongtinthue.XoaThongTinThue1(p.MaKH);
                    }
                    
                }
            }
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                anh3x4.Image = anh3x4.ErrorImage;
                thongtin.XoaThongTinKH(a);
                txtCMND.Clear();
                txtDiaChi.Clear();
                txtHoTen.Clear();
                txtSDT.Clear();
                dateTimeNgaySinh.Value = Convert.ToDateTime("1900/01/01");
                frmThongTinKH_Load(sender, e);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        void btnImg()
        {
            Button btn;
            btn = new Button();
            btn.Name = "btnThemAnh";
            btn.Size = new System.Drawing.Size(100, 23);
            btn.TabIndex = 7;
            btn.Text = "Thêm ảnh 3x4";
            btn.UseVisualStyleBackColor = true;
            this.flowLayoutPanel.Controls.Add(btn);
            btn.Click += new EventHandler(BrowseMultipleButton_Click);
        }
        void LoadAnh3x4(string srt)
        {
            using(Bitmap bmb =new Bitmap(srt))
            {
                MemoryStream m = new MemoryStream();
                bmb.Save(m, ImageFormat.Bmp);
                anh3x4.Image = Image.FromStream(m);
            }
        }
        void SaveAnh3x4(string srt)
        {
            using(Bitmap bmb = (Bitmap)anh3x4.Image.Clone())
            {
                bmb.Save(srt, bmb.RawFormat);
            }
        }
        string TangMa()
        {
            int a;//số
            a = TachSo("KH001");
            IEnumerable<ThongTinKH> tt = thongtin.GetThongTinKH();

            foreach (ThongTinKH p in tt)
            {
                foreach (ThongTinKH d in tt)
                {

                    if (a == TachSo(p.MaKH))
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
                return "KH00" + TangMa();
            }
            else if (Convert.ToInt32(TangMa()) >= 10 && Convert.ToInt32(TangMa()) < 100)
            {
                // MessageBox.Show("P00" + TangMa());
                return "KH0" + TangMa();
            }
            else
            {
                //MessageBox.Show("P" + TangMa());
                return "KH" + TangMa();
            }
        }
    }
}
