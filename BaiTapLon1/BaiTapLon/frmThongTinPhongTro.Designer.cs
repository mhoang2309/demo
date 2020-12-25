
namespace BaiTapLon
{
    partial class frmThongTinPhongTro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinPhongTro));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPhongDangThue = new System.Windows.Forms.Button();
            this.btnPhongTrong = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.treePhong = new System.Windows.Forms.TreeView();
            this.menuTreePhong = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thêmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwDanhSachKH = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwDanhSachPhong = new System.Windows.Forms.ListView();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.imageTreePhong = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.mởFromThôngTinKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuTreePhong.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnPhongDangThue);
            this.splitContainer1.Panel1.Controls.Add(this.btnPhongTrong);
            this.splitContainer1.Panel1.Controls.Add(this.btnAll);
            this.splitContainer1.Panel1.Controls.Add(this.treePhong);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.txtTimKiem);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.cbTimKiem);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1442, 628);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnPhongDangThue
            // 
            this.btnPhongDangThue.Location = new System.Drawing.Point(149, 5);
            this.btnPhongDangThue.Name = "btnPhongDangThue";
            this.btnPhongDangThue.Size = new System.Drawing.Size(100, 23);
            this.btnPhongDangThue.TabIndex = 5;
            this.btnPhongDangThue.Text = "Phòng đang thuê";
            this.btnPhongDangThue.UseVisualStyleBackColor = true;
            this.btnPhongDangThue.Click += new System.EventHandler(this.btnPhongDangThue_Click);
            // 
            // btnPhongTrong
            // 
            this.btnPhongTrong.Location = new System.Drawing.Point(68, 5);
            this.btnPhongTrong.Name = "btnPhongTrong";
            this.btnPhongTrong.Size = new System.Drawing.Size(75, 23);
            this.btnPhongTrong.TabIndex = 5;
            this.btnPhongTrong.Text = "Phòng trống";
            this.btnPhongTrong.UseVisualStyleBackColor = true;
            this.btnPhongTrong.Click += new System.EventHandler(this.btnPhongTrong_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(11, 5);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(51, 23);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // treePhong
            // 
            this.treePhong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treePhong.ContextMenuStrip = this.menuTreePhong;
            this.treePhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treePhong.Location = new System.Drawing.Point(4, 34);
            this.treePhong.Name = "treePhong";
            this.treePhong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treePhong.Size = new System.Drawing.Size(248, 575);
            this.treePhong.TabIndex = 0;
            this.treePhong.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePhong_AfterSelect);
            // 
            // menuTreePhong
            // 
            this.menuTreePhong.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTreePhong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởFromThôngTinKháchHàngToolStripMenuItem,
            this.thêmMớiToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuTreePhong.Name = "contextMenuStrip1";
            this.menuTreePhong.Size = new System.Drawing.Size(241, 136);
            // 
            // thêmMớiToolStripMenuItem
            // 
            this.thêmMớiToolStripMenuItem.Name = "thêmMớiToolStripMenuItem";
            this.thêmMớiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thêmMớiToolStripMenuItem.Text = "Thêm ";
            this.thêmMớiToolStripMenuItem.Click += new System.EventHandler(this.thêmMớiToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(793, 17);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTimKiem.Size = new System.Drawing.Size(213, 26);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(716, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tìm kiếm";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1172, 575);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwDanhSachKH);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(1164, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách khách hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwDanhSachKH
            // 
            this.lvwDanhSachKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDanhSachKH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwDanhSachKH.HideSelection = false;
            this.lvwDanhSachKH.Location = new System.Drawing.Point(0, 3);
            this.lvwDanhSachKH.Name = "lvwDanhSachKH";
            this.lvwDanhSachKH.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvwDanhSachKH.Size = new System.Drawing.Size(1165, 532);
            this.lvwDanhSachKH.TabIndex = 0;
            this.lvwDanhSachKH.UseCompatibleStateImageBehavior = false;
            this.lvwDanhSachKH.SelectedIndexChanged += new System.EventHandler(this.lvwDanhSachKH_SelectedIndexChanged);
            this.lvwDanhSachKH.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwDanhSachKH_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvwDanhSachPhong);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1229, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Danh sách phòng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvwDanhSachPhong
            // 
            this.lvwDanhSachPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDanhSachPhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwDanhSachPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDanhSachPhong.HideSelection = false;
            this.lvwDanhSachPhong.Location = new System.Drawing.Point(0, 3);
            this.lvwDanhSachPhong.Name = "lvwDanhSachPhong";
            this.lvwDanhSachPhong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvwDanhSachPhong.Size = new System.Drawing.Size(1230, 524);
            this.lvwDanhSachPhong.TabIndex = 0;
            this.lvwDanhSachPhong.UseCompatibleStateImageBehavior = false;
            this.lvwDanhSachPhong.View = System.Windows.Forms.View.Details;
            this.lvwDanhSachPhong.SelectedIndexChanged += new System.EventHandler(this.lvwDanhSachPhong_SelectedIndexChanged);
            this.lvwDanhSachPhong.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwDanhSachPhong_MouseDoubleClick);
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Location = new System.Drawing.Point(1007, 16);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbTimKiem.Size = new System.Drawing.Size(149, 28);
            this.cbTimKiem.TabIndex = 1;
            this.cbTimKiem.SelectedIndexChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // imageTreePhong
            // 
            this.imageTreePhong.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageTreePhong.ImageStream")));
            this.imageTreePhong.TransparentColor = System.Drawing.Color.Transparent;
            this.imageTreePhong.Images.SetKeyName(0, "phongtro.png");
            this.imageTreePhong.Images.SetKeyName(1, "phongtrolock.png");
            this.imageTreePhong.Images.SetKeyName(2, "KH.png");
            this.imageTreePhong.Images.SetKeyName(3, "KHlock.png");
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1442, 628);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1442, 648);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // mởFromThôngTinKháchHàngToolStripMenuItem
            // 
            this.mởFromThôngTinKháchHàngToolStripMenuItem.Name = "mởFromThôngTinKháchHàngToolStripMenuItem";
            this.mởFromThôngTinKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.mởFromThôngTinKháchHàngToolStripMenuItem.Text = "Mở From thông tin khách hàng";
            this.mởFromThôngTinKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.mởFromThôngTinKháchHàngToolStripMenuItem_Click);
            // 
            // frmThongTinPhongTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 648);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmThongTinPhongTro";
            this.Text = "frmThongTinPhongTro";
            this.Load += new System.EventHandler(this.frmThongTinPhongTro_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuTreePhong.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treePhong;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvwDanhSachPhong;
        private System.Windows.Forms.ListView lvwDanhSachKH;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ContextMenuStrip menuTreePhong;
        private System.Windows.Forms.ToolStripMenuItem thêmMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ImageList imageTreePhong;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Button btnPhongDangThue;
        private System.Windows.Forms.Button btnPhongTrong;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.ToolStripMenuItem mởFromThôngTinKháchHàngToolStripMenuItem;
    }
}