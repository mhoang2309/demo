using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmThongTin : Form
    {
        public frmThongTin()
        {
            InitializeComponent();
        }
        string maphong;
        string maKH;
        string maThue;
        string numtang;
        string strma;
        string maThueXoa;
        public frmThongTin(string ma) : this()
        {
            maphong = ma;
        }
        clsPhongTro thongtinphong = new clsPhongTro();
        clsThongTinThue thongtinthue = new clsThongTinThue();
        clsThongTinKH thongtinkh = new clsThongTinKH();
        private void frmThongTin_Load(object sender, EventArgs e)
        {
            lvwKH.Items.Clear();
            lvwThue.Items.Clear();
            this.Controls.Remove(dateTimeNgayTra);
            this.Controls.Remove(btnThem);
            this.Controls.Add(btnTao);
            btnXoa.Enabled = false;
            lvwThue.Columns.Clear();
            IEnumerable<ThongTinPhong> ds = thongtinphong.GetThongTinPhong();
            IEnumerable<ThongTinThue> dsthue = thongtinthue.GetThongTinThue();
            IEnumerable<ThongTinKH> dsKH = thongtinkh.GetThongTinKH();
            lblMaPhong.Text ="Mã phong: "+maphong;
            CreateColumnThue(lvwThue);
            CreateColumnKH(lvwKH);
            LoadMaKHComboBox(dsKH);

            if (KiemTra(maphong) == false)
            {
                btnTao.Enabled = false;
            }
            string makh = null;
            foreach (ThongTinPhong p in ds)
            {
                if (p.MaPhong == maphong)
                {
                    lblDienTich.Text ="Diện tích: "+ p.DienTich+ " m²";
                    lblGia.Text ="Giá phòng: "+ p.GiaPhong+"/Tháng";
                    txtChuThich.Text = p.ChuThich;
                    LoadDSThue(dsthue, lvwThue, p.MaPhong);
                    
                }
            }
            foreach(ThongTinThue p in dsthue)
            {
                if (makh != p.MaKH && p.MaPhong == maphong)
                {
                    LoadDSKH(dsKH, lvwKH, p.MaKH);
                    makh = p.MaKH;
                }

            }

        }
        void CreateColumnThue(ListView lvw)
        {
            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
            lvw.Columns.Add("Mã Thuê", 80);
            lvw.Columns.Add("Mã KH", 80);
            lvw.Columns.Add("Mã Phòng", 80);
            lvw.Columns.Add("Ngày thuê", 100);
            lvw.Columns.Add("Ngày trả", 100);
        }
        void LoadDSThue(IEnumerable<ThongTinThue> ds, ListView lvw, string ma)
        {

            ListViewItem lvwItem;
            foreach (ThongTinThue p in ds)
            {
                if(ma == p.MaPhong)
                {
                    lvwItem = new ListViewItem();
                    lvwItem.Text = p.MaThue;
                    lvwItem.SubItems.Add(p.MaKH);
                    lvwItem.SubItems.Add(p.MaPhong);
                    lvwItem.SubItems.Add(Convert.ToString(p.NgayThue));
                    lvwItem.SubItems.Add(Convert.ToString(p.NgayTra));
                    lvwItem.Tag = p;
                    lvw.Items.Add(lvwItem);
                }

            }
        }
        void CreateColumnKH(ListView lvw)
        {
            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
            lvw.Columns.Add("Mã KH", 80);
            lvw.Columns.Add("Họ và tên", 100);
            lvw.Columns.Add("SDT", 80);
            lvw.Columns.Add("CMND", 80);
            lvw.Columns.Add("Ngày sinh", 80);
            lvw.Columns.Add("Địa chỉ", 300);
        }
        void LoadDSKH(IEnumerable<ThongTinKH> dsKH, ListView lvw, string ma)//load danh sách khách hàng
        {
            ListViewItem lvwItem;
            foreach (ThongTinKH p in dsKH)
            {
                if (ma == p.MaKH)
                {
                    lvwItem = new ListViewItem();
                    lvwItem.Text = p.MaKH;
                    lvwItem.SubItems.Add(p.HoTen);
                    lvwItem.SubItems.Add(p.SDT);
                    lvwItem.SubItems.Add(p.CMND);
                    lvwItem.SubItems.Add(Convert.ToString(p.NgaySinh));
                    lvwItem.SubItems.Add(p.DiaChi);
                    lvwItem.Tag = p;
                    lvw.Items.Add(lvwItem);
                }
            }
        }

        private void lvwKH_SelectedIndexChanged(object sender, EventArgs e)//SelectedIndexChanged listview khách hàng
        {
            IEnumerable<ThongTinKH> dsKH = thongtinkh.GetThongTinKH();
            IEnumerable<ThongTinThue> dsThue = thongtinthue.GetThongTinThue();
            ThongTinKH kh = null;
            btnXoa.Enabled = false;
            if (lvwKH.SelectedItems.Count > 0)
            {
                kh = (ThongTinKH)lvwKH.SelectedItems[0].Tag;
                maKH = kh.MaKH;
                cbMaKH.Text = kh.MaKH;

                cbMaThue.Items.Clear();
                foreach (ThongTinThue p in dsThue)
                {
                    if (kh.MaKH == p.MaKH && p.MaPhong == maphong)
                    {
                        cbMaThue.Items.Add(p.MaThue);
                        
                    }

                }
                cbMaThue.SelectedIndex = 0;
                cbMaThue.Enabled = true;
                //cbMaKH.Enabled = false;
            }
            //txtNgayTra.Clear();

            LoadMaKHComboBox(dsKH);
            //strma = cbMaKH.Text;
            //TaoAnh3x4();

        }

        private void lvwKH_MouseDoubleClick(object sender, MouseEventArgs e)//click list khách hàng
        {
            ThongTinKH kh = null;
            if (lvwKH.SelectedItems.Count > 0)
            {
                string tam = null;
                kh = (ThongTinKH)lvwKH.SelectedItems[0].Tag;
                IEnumerable<ThongTinThue> tt = thongtinthue.GetThongTinThue();
                foreach(ThongTinThue p in tt)
                {
                    if (p.MaKH == kh.MaKH)
                    {
                        tam = p.MaThue;
                        break;
                    }
                }
                frmThongTinKH frmThongTinKH1 = new frmThongTinKH(kh.MaKH,tam);
                frmThongTinKH1.ShowDialog();
                //this.Dispose();
                /*frmThongTinPhongTro frmThongTinPhongTro = new frmThongTinPhongTro();
                frmThongTinPhongTro.ShowDialog();*/
                frmThongTin_Load(sender, e);

            }
        }
        void LoadMaThueComboBox(IEnumerable<ThongTinThue> tt)//combobox mã thuê
        {
            cbMaThue.Items.Clear();
            foreach (ThongTinThue p in tt)
            {
                cbMaThue.Items.Add(p.MaThue);
            }

            cbMaThue.SelectedItem = maThue;
        }
        void LoadMaKHComboBox(IEnumerable<ThongTinKH> tt)//combobox mã khách hàng
        {
            cbMaKH.Items.Clear();
            foreach (ThongTinKH p in tt)
            {
                cbMaKH.Items.Add(p.MaKH);
            }

            cbMaKH.SelectedItem = maKH;
        }

        private void lvwThue_SelectedIndexChanged(object sender, EventArgs e)//SelectedIndexChanged listview thuê
        {
            this.Controls.Add(dateTimeNgayTra);
            IEnumerable<ThongTinThue> dsthue = thongtinthue.GetThongTinThue();
            IEnumerable<ThongTinKH> dsKH = thongtinkh.GetThongTinKH();
            ThongTinThue thue = null;
            btnXoa.Enabled = true;
            //this.Controls.Remove(Anh3x4);
            if (lvwThue.SelectedItems.Count > 0)
            {
                thue = (ThongTinThue)lvwThue.SelectedItems[0].Tag;
                cbMaThue.Text = thue.MaThue;
                maThue = thue.MaThue;
                maKH = thue.MaKH;
                dateTimeNgayThue.Value = thue.NgayThue;
                if(thue.NgayTra == null)
                {
                    this.Controls.Remove(dateTimeNgayTra);
                }
                else
                {
                    dateTimeNgayTra.Value = (DateTime)thue.NgayTra;
                }
                
            }
            cbMaThue.Enabled = false;
            cbMaKH.Enabled = false;
            LoadMaThueComboBox(dsthue);
            LoadMaKHComboBox(dsKH);
        }
        string TangMa()
        {
            int a;//số
            a = TachSo("T0001");
            IEnumerable<ThongTinThue> tt = thongtinthue.GetThongTinThue();

            foreach(ThongTinThue p in tt)
            {
                foreach(ThongTinThue d in tt)
                {
                    
                    if (a == TachSo(p.MaThue))
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
                //MessageBox.Show("T000" + TangMa());
                return "T000" + TangMa();
            }
            else if (Convert.ToInt32(TangMa()) >= 10 && Convert.ToInt32(TangMa()) < 100)
            {
               // MessageBox.Show("T00" + TangMa());
                return "T00" + TangMa();
            }
            else if (Convert.ToInt32(TangMa()) >= 100 && Convert.ToInt32(TangMa()) < 1000)
            {
                //MessageBox.Show("T0" + TangMa());
                return "T0" + TangMa();
            }
            else
            {
                //MessageBox.Show("T" + TangMa());
                return "T" + TangMa();
            }     
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        void TaoAnh3x4()
        {
            IEnumerable<ThongTinKH> tt = thongtinkh.GetThongTinKH();
            PictureBox anh3x4 = new PictureBox();
            anh3x4.Location = new System.Drawing.Point(717, 1);
            anh3x4.Name = "anh3x4";
            anh3x4.Size = new System.Drawing.Size(84, 74);
            anh3x4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            anh3x4.TabIndex = 0;
            anh3x4.TabStop = false;
            this.Controls.Add(anh3x4);

                foreach (ThongTinKH d in tt)
                {
                    if (d.MaKH == strma)
                    {
                        using (Bitmap bmb = new Bitmap(d.anh))
                        {
                            MemoryStream m = new MemoryStream();
                            bmb.Save(m, ImageFormat.Bmp);
                            anh3x4.Image = Image.FromStream(m);
                        }
                    }

                }

 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra(maphong) == true)
            {
                // IEnumerable<ThongTinThue> tt = thongtinthue.GetThongTinThue();
                DateTime value = DateTime.Today;
                ThongTinThue thue = new ThongTinThue();
                thue.MaThue = OutMaVuaTang();
                thue.MaPhong = maphong;
                if (cbMaKH.Text == "")
                {
                    MessageBox.Show("Phải Nhập Mã KH", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                thue.MaKH = cbMaKH.Text;
                thue.NgayThue = dateTimeNgayThue.Value;
                if (cbxNgayTra.Checked == true)
                {
                    thue.NgayTra = null;
                }
                else
                {
                    thue.NgayTra = dateTimeNgayTra.Value;
                }

                thongtinthue.AddThongTinThue(thue);
                frmThongTin_Load(sender, e);
                return;
            }
         MessageBox.Show("Phòng đầy không thêm được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

        }
        bool KiemTra(string ma)
        {
            int kiemtra = 0;
            IEnumerable<ThongTinThue> tt = thongtinthue.GetThongTinThue();
            foreach (ThongTinThue p in tt)
            {
                if (p.MaPhong == ma)
                {
                    kiemtra++;
                }
            }
            if (kiemtra < 4)
            {
                return true;
            }
            return false;
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            if (cbxNgayTra.Checked == true)
            {
                this.Controls.Remove(dateTimeNgayTra);
            }
            else
            {
                this.Controls.Add(dateTimeNgayTra);
                dateTimeNgayTra.Enabled = true;
            }
            cbMaKH.Enabled = true;
            this.Controls.Add(btnThem);
            this.Controls.Remove(btnTao);
            dateTimeNgayThue.Enabled = true;
            txtNgayTra.Enabled = true;
            cbMaThue.Items.Clear();
            cbMaThue.Items.Add(OutMaVuaTang());
            cbMaThue.SelectedIndex = 0;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            clsThongTinThue thongtinthue1 = new clsThongTinThue();
            DialogResult r = MessageBox.Show("Bạn có chắc xóa", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if(r == DialogResult.Yes)
            {
                thongtinthue1.XoaThongTinThue(cbMaThue.Text);
                thongtinthue = thongtinthue1;
                frmThongTin_Load(sender, e);
            }
            if(KiemTra(maphong) == true)
            {
                btnTao.Enabled = true;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void cbxNgayTra_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxNgayTra.Checked == true)
            {
                this.Controls.Remove(dateTimeNgayTra);
            }
            else
            {
                this.Controls.Add(dateTimeNgayTra);
                dateTimeNgayTra.Enabled = true;
            }
        }
    }
}
