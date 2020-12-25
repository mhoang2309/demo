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
    public partial class frmLogin : Form
    {
        int SolanLogin = 0;
        clsUsesName thongtin = new clsUsesName();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IEnumerable<TaiKhoan> lsTaiKhoan = thongtin.GetTaiKhoan();
            thongtin.Uses = txtUses.Text;
            thongtin.Pass = txtPass.Text;
            if (SolanLogin < 3)
                Login(lsTaiKhoan, thongtin.Uses, thongtin.Pass);
            else
                this.Close();
            
        }
        void Login(IEnumerable<TaiKhoan> lsTaiKhoan, string uses, string pass)
        {
            foreach(TaiKhoan p in lsTaiKhoan)
            {
                if (uses == Convert.ToString(p.uses) && pass == Convert.ToString(p.pass))
                {
                    thongtin.Quyen =Convert.ToString(p.quyen);
                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                    Visible = false;
                    return;
                }
            }
            SolanLogin++;
            int a = 3 - SolanLogin;
            MessageBox.Show("Thông tin sai vui lòng nhập lại!\n Số lần nhập còn lại:  " + a, "Lỗi Login", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
