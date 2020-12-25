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
    public partial class frmThongTinPhongTro : Form
    {
        public frmThongTinPhongTro()
        {
            InitializeComponent();
        }
        TreeNode nGoc;
        clsPhongTro thongtinphong = new clsPhongTro();
        clsThongTinKH thongtinKH = new clsThongTinKH();
        clsThongTinThue thongtinthue = new clsThongTinThue();
        string giatriPhong;
        string giatrithue=null;
        string ma, ma2;
        private void frmThongTinPhongTro_Load(object sender, EventArgs e)
        {
            clsPhongTro thongtinphong = new clsPhongTro();
            clsThongTinKH thongtinKH = new clsThongTinKH();
            clsThongTinThue thongtinthue = new clsThongTinThue();
            IEnumerable<ThongTinPhong> dsPhong = thongtinphong.GetThongTinPhong();
            IEnumerable<ThongTinKH> dsKH = thongtinKH.GetThongTinKH();
            cbTimKiem.Items.Clear();
            LoadTree(dsPhong);
            CreateColumnPhong(lvwDanhSachPhong);
            LoadDSPhong(dsPhong, lvwDanhSachPhong);
            CreateColumnKH(lvwDanhSachKH);
            LoadDSKH(dsKH, lvwDanhSachKH);
            comboboxTimKiem();
        }
        void LoadTreeViewToCSDL(IEnumerable<ThongTinPhong> lsAllPhong, ListView lvw)
        {
            lvw.Items.Clear();
            ListViewItem lvwItem;
            foreach(ThongTinPhong p in lsAllPhong)
            {
                lvwItem = new ListViewItem();
                lvwItem.Text = p.MaPhong;
                lvwItem.SubItems.Add(p.DienTich);
                lvwItem.SubItems.Add(p.GiaPhong);
                lvwItem.SubItems.Add(p.ChuThich);
                lvwItem.Tag = p;
                lvw.Items.Add(lvwItem);
            }
        }
        void LoadTree(IEnumerable<ThongTinPhong> dsPhong)
        {
            treePhong.ImageList = imageTreePhong;
            IEnumerable<ThongTinThue> dsKH = thongtinthue.GetThongTinThue();
            foreach(ThongTinPhong p in dsPhong)
            {
                nGoc = new TreeNode("Mã: " + p.MaPhong);
                nGoc.Tag = p.MaPhong;
                nGoc.ImageIndex = 1;
                nGoc.SelectedImageIndex = 0;
                LoadDanhSachKH(dsKH, nGoc, p.MaPhong);
                treePhong.Nodes.Add(nGoc);
            }
            treePhong.ExpandAll();
        }
        void LoadDanhSachKH(IEnumerable<ThongTinThue> dsKH, TreeNode nPhong, string ma)
        {
            TreeNode nKHCon;
            foreach(ThongTinThue d in dsKH)
            {
                if(ma == Convert.ToString(d.MaPhong))
                {
                    nKHCon = new TreeNode("Mã " + d.MaKH);
                    nKHCon.Name = d.MaKH;
                    nKHCon.Tag = d.MaThue;
                    nKHCon.ImageIndex = 3;
                    nKHCon.SelectedImageIndex = 2;
                    nPhong.Nodes.Add(nKHCon);
                }
            }
        }

        private void treePhong_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvwDanhSachKH.Items.Clear();
            if (treePhong.SelectedNode != null)
            {
                IEnumerable<ThongTinKH> dsKH = thongtinKH.GetThongTinKH();
                IEnumerable<ThongTinThue> thue = thongtinthue.GetThongTinThue();
                giatriPhong = e.Node.Text;
                if (treePhong.SelectedNode.Level == 0)
                {
                    xulygiatri(e.Node.Text);
                    foreach (ThongTinThue p in thue)
                    {
                        if (p.MaPhong == ma)
                        {
                            foreach (ThongTinKH k in dsKH)
                            {
                                if (k.MaKH == p.MaKH)
                                {
                                    ListViewItem lvwItem;
                                    lvwItem = new ListViewItem();
                                    lvwItem.Text = k.MaKH;
                                    lvwItem.SubItems.Add(k.HoTen);
                                    lvwItem.SubItems.Add(k.SDT);
                                    lvwItem.SubItems.Add(k.CMND);
                                    lvwItem.SubItems.Add(Convert.ToString(k.NgaySinh));
                                    lvwItem.SubItems.Add(k.DiaChi);
                                    lvwItem.Tag = k;
                                    lvwDanhSachKH.Items.Add(lvwItem);
                                }
                            }
                        }
                    }
                }
                if (treePhong.SelectedNode.Level == 1)
                {
                    giatrithue =Convert.ToString(e.Node.Tag);
                    
                    ListViewItem lvwItem;
       
                        foreach (ThongTinKH p in dsKH)
                        {
                            if(Convert.ToString(e.Node.Name) == p.MaKH)
                            {
                                lvwItem = new ListViewItem();
                                lvwItem.Text = p.MaKH;
                                lvwItem.SubItems.Add(p.HoTen);
                                lvwItem.SubItems.Add(p.SDT);
                                lvwItem.SubItems.Add(p.CMND);
                                lvwItem.SubItems.Add(Convert.ToString(p.NgaySinh));
                                lvwItem.SubItems.Add(p.DiaChi);
                                lvwItem.Tag = p;
                                lvwDanhSachKH.Items.Add(lvwItem);
                            }
                        }
                       
                }
            }
        }

        private void lvwDanhSachPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongTinPhong Phong = null;
            if (lvwDanhSachKH.SelectedItems.Count > 0)
            {
                Phong = (ThongTinPhong)lvwDanhSachPhong.SelectedItems[0].Tag;
            }
        }
        void LoadDSPhong(IEnumerable<ThongTinPhong> dsphong, ListView lvw)
        {
            lvw.Items.Clear();
            ListViewItem lvwItem;
            foreach(ThongTinPhong p in dsphong)
            {
                lvwItem = new ListViewItem();
                lvwItem.Text = p.MaPhong;
                lvwItem.SubItems.Add(p.DienTich);
                lvwItem.SubItems.Add(p.GiaPhong);
                lvwItem.SubItems.Add(p.ChuThich);
                lvwItem.Tag = p;
                lvw.Items.Add(lvwItem);
            }
        }
        void LoadDSKH(IEnumerable<ThongTinKH> dsKH, ListView lvw)
        {
            lvw.Items.Clear();
            ListViewItem lvwItem;
            foreach (ThongTinKH p in dsKH)
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
        void CreateColumnPhong(ListView lvw)
        {
            lvw.Columns.Clear();
            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
            lvw.Columns.Add("Mã Phòng", 100);
            lvw.Columns.Add("Diện Tính m²", 100);
            lvw.Columns.Add("Giá/tháng", 100);
            lvw.Columns.Add("Chú thích",845);
        }
        void CreateColumnKH(ListView lvw)
        {
            lvw.Columns.Clear();
            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
            lvw.Columns.Add("Mã KH", 100);
            lvw.Columns.Add("Họ và tên", 200);
            lvw.Columns.Add("SDT", 100);
            lvw.Columns.Add("CMND", 100);
            lvw.Columns.Add("Ngày sinh", 100);
            lvw.Columns.Add("Địa chỉ", 645);
        }

        private void lvwDanhSachKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThongTinKH kh = null;
            if(lvwDanhSachKH.SelectedItems.Count > 0)
            {
                kh = (ThongTinKH)lvwDanhSachKH.SelectedItems[0].Tag;
            }
        }

        private void lvwDanhSachKH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ThongTinKH kh = null;
            if (lvwDanhSachKH.SelectedItems.Count > 0)
            {
                kh = (ThongTinKH)lvwDanhSachKH.SelectedItems[0].Tag;
                frmThongTinKH frmThongTinKH = new frmThongTinKH(kh.MaKH,giatrithue);
                frmThongTinKH.ShowDialog();
                frmThongTinPhongTro_Load(sender, e);
                /*this.Dispose();
                frmThongTinPhongTro frmThongTinPhongTro = new frmThongTinPhongTro();
                frmThongTinPhongTro.ShowDialog();*/
                
            }
        }
        private void lvwDanhSachPhong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ThongTinPhong Phong = null;
            if (lvwDanhSachPhong.SelectedItems.Count > 0)
            {
                Phong = (ThongTinPhong)lvwDanhSachPhong.SelectedItems[0].Tag;
                frmXemPhong frmXemPhong = new frmXemPhong(Phong.MaPhong);
                frmXemPhong.ShowDialog();
                frmThongTinPhongTro_Load(sender, e);
                /*this.Dispose();
                frmThongTinPhongTro frmThongTinPhongTro = new frmThongTinPhongTro();
                frmThongTinPhongTro.ShowDialog();*/

            }
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xulygiatri(giatriPhong);
            xulygiatri2(ma);
            if (ma2 == "P")
            {
                frmThemPhong frmThemPhong = new frmThemPhong();
                frmThemPhong.ShowDialog();
                loadlaidulieu();
                return;
            }
            else if (ma2 == "KH")
            {
                frmThongTinKH frmThongTinKH = new frmThongTinKH(ma,giatrithue);
                frmThongTinKH.ShowDialog();
                loadlaidulieu();
                return;
            }

        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xulygiatri(giatriPhong);
            xulygiatri2(ma);
            if (ma2 == "P")
            {
                frmSuaPhong frmSuaPhong = new frmSuaPhong(giatriPhong, giatrithue);
                frmSuaPhong.ShowDialog();
                loadlaidulieu();
                loadlaidulieu();
                return;
            }
            else if (ma2 == "KH")
            {
                frmThongTinKH frmThongTinKH = new frmThongTinKH(ma,giatrithue);
                frmThongTinKH.ShowDialog();
                loadlaidulieu();
                return;
            }

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsThongTinThue thongtinthue = new clsThongTinThue();
            IEnumerable<ThongTinThue> dk = thongtinthue.GetThongTinThue();
            xulygiatri(giatriPhong);
            foreach (ThongTinThue p in dk)
            {
                if (ma == p.MaPhong || ma == p.MaKH)
                {
                    DialogResult d = MessageBox.Show("Cần phải xoát thông tin thêu!\nBạn có muốn xóa thông tin thuê: "+giatrithue+" ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (d == DialogResult.Yes)
                        break;
                    return;
                }
            }
            DialogResult r = MessageBox.Show("Bạn có chắc muốn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                xulygiatri2(ma);
                if (ma2 == "P")
                {
                    IEnumerable<ThongTinThue> tt = thongtinthue.GetThongTinThue();
                    foreach(ThongTinThue p in tt)
                    {
                        if (ma == p.MaPhong)
                        {
                            thongtinthue.XoaThongTinThuemaphong(ma);
                        }
                    }
                    thongtinphong.XoaThongTinPhong(ma);
                    loadlaidulieu();
                    return;
                }
                else if (ma2 == "KH")
                {
                    thongtinthue.XoaThongTinThue(giatrithue);
                    thongtinKH.XoaThongTinKH(ma);
                    loadlaidulieu();
                    return;
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
        void xulygiatri2(string input)
        {
            string[] m = Regex.Split(input, @"0");
            string value = m[0];
            ma2 = value;
        }
        void loadlaidulieu()
        {
            IEnumerable<ThongTinPhong> dsPhong = thongtinphong.GetThongTinPhong();
            IEnumerable<ThongTinKH> dsKH = thongtinKH.GetThongTinKH();
            treePhong.Nodes.Clear();
            LoadTree(dsPhong);
            LoadDSPhong(dsPhong, lvwDanhSachPhong);
            LoadDSKH(dsKH, lvwDanhSachKH);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            IEnumerable<ThongTinPhong> dsPhong = thongtinphong.GetThongTinPhong();
            treePhong.Nodes.Clear();
            LoadTree(dsPhong);
        }

        private void btnPhongTrong_Click(object sender, EventArgs e)
        {
            treePhong.Nodes.Clear();
            IEnumerable<ThongTinThue> thue = thongtinthue.GetThongTinThue();
            IEnumerable<ThongTinPhong> phong = thongtinphong.GetThongTinPhong();
            int tam = 0;
            lvwDanhSachPhong.Items.Clear();
            ListViewItem lvwItem;
            foreach (ThongTinPhong p in phong)
            {
                foreach(ThongTinThue t in thue)
                {
                    if(p.MaPhong == t.MaPhong)
                    {
                        tam = 1;
                        break;
                    }
                    tam = 0;
                }
                if (tam == 0)
                {
                    treePhong.ImageList = imageTreePhong;
                    nGoc = new TreeNode("Mã: " + p.MaPhong);
                    nGoc.Tag = p.MaPhong;
                    nGoc.ImageIndex = 1;
                    nGoc.SelectedImageIndex = 0;
                    treePhong.Nodes.Add(nGoc);
                    lvwItem = new ListViewItem();
                    lvwItem.Text = p.MaPhong;
                    lvwItem.SubItems.Add(p.DienTich);
                    lvwItem.SubItems.Add(p.GiaPhong);
                    lvwItem.SubItems.Add(p.ChuThich);
                    lvwItem.Tag = p;
                    lvwDanhSachPhong.Items.Add(lvwItem);
                    tam = 1;
                }
            }
        }

        private void btnPhongDangThue_Click(object sender, EventArgs e)
        {
            treePhong.Nodes.Clear();
            IEnumerable<ThongTinThue> thue = thongtinthue.GetThongTinThue();
            IEnumerable<ThongTinPhong> phong = thongtinphong.GetThongTinPhong();
            IEnumerable<ThongTinKH> dsKH = thongtinKH.GetThongTinKH();
            lvwDanhSachPhong.Items.Clear();
            lvwDanhSachKH.Items.Clear();
            ListViewItem lvwItem;
            foreach (ThongTinPhong p in phong)
            {
                foreach (ThongTinThue t in thue)
                {
                    if (p.MaPhong == t.MaPhong)
                    {
                        treePhong.ImageList = imageTreePhong;
                        nGoc = new TreeNode("Mã: " + p.MaPhong);
                        nGoc.Tag = p.MaPhong;
                        nGoc.ImageIndex = 1;
                        nGoc.SelectedImageIndex = 0;
                        LoadDanhSachKH(thue, nGoc, p.MaPhong);
                        treePhong.Nodes.Add(nGoc);
                        lvwItem = new ListViewItem();
                        lvwItem.Text = p.MaPhong;
                        lvwItem.SubItems.Add(p.DienTich);
                        lvwItem.SubItems.Add(p.GiaPhong);
                        lvwItem.SubItems.Add(p.ChuThich);
                        lvwItem.Tag = p;
                        lvwDanhSachPhong.Items.Add(lvwItem);
                        break;
                    }
                }
            }

            LoadDSKH(dsKH, lvwDanhSachKH);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(cbTimKiem.SelectedIndex == 0)
            {
                lvwDanhSachKH.Items.Clear();
                IEnumerable<ThongTinKH> dsKHtimkiem = thongtinKH.TimKiemTen(txtTimKiem.Text);
                IEnumerable<ThongTinKH> tt = thongtinKH.GetThongTinKH();
                if (txtTimKiem.Text != null)
                {
                    foreach (ThongTinKH p in dsKHtimkiem)
                    {
                        foreach (ThongTinKH d in tt)
                        {
                            if (d.MaKH == p.MaKH)
                            {
                                /*ListViewItem lvwItem = new ListViewItem();
                                lvwItem.Text = d.HoTen;
                                lvwItem.SubItems.Add(d.HoTen);
                                listView1.Items.Add(lvwItem);*/

                                CreateColumnKH(lvwDanhSachKH);
                                LoadDSKH(dsKHtimkiem, lvwDanhSachKH);
                                return;
                            }
                        }
                    }
                }
                lvwDanhSachKH.Items.Clear();
            } 
            else if(cbTimKiem.SelectedIndex == 1)
            {
                lvwDanhSachKH.Items.Clear();
                IEnumerable<ThongTinKH> dsKHtimkiem = thongtinKH.TimKiemMa(txtTimKiem.Text);
                IEnumerable<ThongTinKH> tt = thongtinKH.GetThongTinKH();
                if (txtTimKiem.Text != null)
                {
                    foreach (ThongTinKH p in dsKHtimkiem)
                    {
                        foreach (ThongTinKH d in tt)
                        {
                            if (d.MaKH == p.MaKH)
                            {
                                /*ListViewItem lvwItem = new ListViewItem();
                                lvwItem.Text = d.HoTen;
                                lvwItem.SubItems.Add(d.HoTen);
                                listView1.Items.Add(lvwItem);*/

                                CreateColumnKH(lvwDanhSachKH);
                                LoadDSKH(dsKHtimkiem, lvwDanhSachKH);
                                return;
                            }
                        }
                    }
                }
                lvwDanhSachKH.Items.Clear();
            }
        }

        void comboboxTimKiem()
        {
            cbTimKiem.Items.Add("Tìm theo họ và tên");
            cbTimKiem.Items.Add("Tìm theo mã");
            cbTimKiem.SelectedIndex = 0;
        }

        private void thêmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinKH frmThongTinKH = new frmThongTinKH();
            frmThongTinKH.ShowDialog();
            frmThongTinPhongTro_Load(sender, e);
        }

        private void xóaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mởFromThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinKH frmThongTinKH = new frmThongTinKH();
            frmThongTinKH.ShowDialog();
            frmThongTinPhongTro_Load(sender, e);
        }

        void LoadDSKH1(IEnumerable<ThongTinKH> dsKH, ListView lvw)
        {
            lvw.Items.Clear();
            ListViewItem lvwItem;
            foreach (ThongTinKH p in dsKH)
            {
                lvwItem = new ListViewItem();
                lvwItem.Text = p.HoTen;
                lvwItem.SubItems.Add(p.HoTen);
                lvwItem.Tag = p;
                lvw.Items.Add(lvwItem);
            }
        }
    }
}
