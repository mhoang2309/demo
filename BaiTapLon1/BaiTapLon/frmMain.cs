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
    public partial class frmMain : Form
    {
        clsPhongTro thongtin = new clsPhongTro();
        clsThongTinThue thongtinthue = new clsThongTinThue();
        int dem = 0;
        object chon = null;
        public frmMain()
        {
            InitializeComponent();
        }
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Controls.Remove(lblFull);
            //TaoPhongTro(30);
            flowLayoutPanel1.Controls.Clear();
            this.Controls.Remove(this.pictureBox4);
            this.Controls.Remove(this.lblNguoi);
            IEnumerable<ThongTinPhong> lsPhong = thongtin.GetThongTinPhong();
            IEnumerable<ThongTinThue> lsThue = thongtinthue.GetThongTinThue();
            LoadThongTinhPhong(lsPhong, lsThue);
        }
        /*void TaoPhongTro(int n)
        {
            FlowLayoutPanel flp;
            PictureBox ptb;
            Label lbl;
            for (int i = 1; i <= n; i++)
            {
                flp = new FlowLayoutPanel();
                ptb = new PictureBox();
                lbl = new Label();
                ptb.Image = imageListOpen.Images[0];
                ptb.Location = new System.Drawing.Point(3, 3);
                ptb.Name = i.ToString();
                ptb.Size = new System.Drawing.Size(65, 50);
                ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                ptb.TabIndex = i-1;
                ptb.TabStop = false;
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(3, 56);
                lbl.Name = i.ToString();
                lbl.Size = new System.Drawing.Size(38, 13);
                lbl.TabIndex = 2;
                lbl.Text = "Phòng "+i.ToString();
                lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                flp.Controls.Add(ptb);
                flp.Controls.Add(lbl);
                flp.Location = new System.Drawing.Point(80, 3);
                flp.Name = i.ToString();
                flp.Size = new System.Drawing.Size(71, 75);
                flp.TabIndex = 1;
                this.flowLayoutPanel1.Controls.Add(flp);
                ptb.DoubleClick += new EventHandler(ChoPhong_Click);
            }
        }*/
        private void ChoPhong_Click(object sender, EventArgs e)
        {
            PictureBox ptb = (PictureBox)sender;
            frmThongTin frmThongTin = new frmThongTin(ptb.Name);
            frmThongTin.ShowDialog();
            frmMain_Load(sender, e);
        }
        void LoadThongTinhPhong(IEnumerable<ThongTinPhong> lsPhong, IEnumerable<ThongTinThue> lsthue)
        {
            FlowLayoutPanel flp;
            PictureBox ptb;
            Label lbl;
            foreach (ThongTinPhong p in lsPhong)
            {
                flp = new FlowLayoutPanel();
                ptb = new PictureBox();
                lbl = new Label();
                ptb.Image = imageListOpen.Images[0];
                ptb.Location = new System.Drawing.Point(3, 3);
                ptb.Name = p.MaPhong;
                ptb.Size = new System.Drawing.Size(65, 50);
                ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                ptb.TabIndex = 0;
                ptb.TabStop = false;
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(3, 56);
                lbl.Name = p.MaPhong;
                lbl.Size = new System.Drawing.Size(38, 13);
                lbl.TabIndex = 2;
                lbl.Text = "Mã: " + p.MaPhong;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                flp.Controls.Add(ptb);
                flp.Controls.Add(lbl);
                flp.Location = new System.Drawing.Point(80, 3);
                flp.Name = p.MaPhong;
                flp.Size = new System.Drawing.Size(71, 75);
                flp.TabIndex = 1;
                this.flowLayoutPanel1.Controls.Add(flp);
                if(GiaTriThue(lsthue, p.MaPhong) == true)
                {
                    if (ptb.Enabled == true)
                    {
                        if (ptb.Image != imageListLock.Images[0])
                        {
                            if (dem > 0 && dem < 4)
                            {
                                ptb.Image = imageListLock.Images[0];
                            }
                            else if(dem >= 4)
                            {
                                ptb.Image = imageListLock.Images[1];
                            }
                        }

                    }
                    dem = 0;
                }
                ptb.DoubleClick += new EventHandler(ChoPhong_Click);
                ptb.Click += new EventHandler(Click);
            }
        }
        public void Click(object sender, EventArgs e)
        {
            PictureBox ptb = (PictureBox)sender;

            if (chon != sender && chon != null)
            {
                PictureBox ptb1 = (PictureBox)chon;
                ptb1.BackColor = SystemColors.Control;
                ptb.BackColor = Color.Gray;
                chon = sender;
                ThongTinPhong(ptb.Name);
                return;
            }
            else if(chon == null)
            {
                ptb.BackColor = Color.Gray;
            }
            chon = sender;
            ThongTinPhong(ptb.Name);
        }
        void ThongTinPhong(string ma)
        {
            int nguoi = 0;
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lblNguoi);
            IEnumerable<ThongTinThue> tt = thongtinthue.GetThongTinThue();
            foreach(ThongTinThue p in tt)
            {
                if(p.MaPhong == ma)
                {
                    nguoi++;
                }
            }
            this.Controls.Remove(lblFull);
            lblNguoi.Text = "Phòng có: " + Convert.ToString(nguoi)+" người";
            if (nguoi >= 4)
            {
                this.Controls.Add(lblFull);
            }
        }
        bool GiaTriThue(IEnumerable<ThongTinThue> lsthue, string ma)
        {
            
            foreach(ThongTinThue d in lsthue)
            {
                if(ma == d.MaPhong)
                {
                    dem++;
                } 
            }
            if (dem > 0)
            {
                return true;
            }
            return false;
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            frmThongTinPhongTro frmThong = new frmThongTinPhongTro();
            frmThong.ShowDialog();
            frmMain_Load(sender, e);
        }

        private void danhSáchChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDanhSach_Click(sender, e);
        }
    }
}
