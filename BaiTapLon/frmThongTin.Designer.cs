
namespace BaiTapLon
{
    partial class frmThongTin
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
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.lblDienTich = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChuThich = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwThue = new System.Windows.Forms.ListView();
            this.txtNgayTra = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwKH = new System.Windows.Forms.ListView();
            this.dateTimeNgayThue = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cbMaThue = new System.Windows.Forms.ComboBox();
            this.btnTao = new System.Windows.Forms.Button();
            this.dateTimeNgayTra = new System.Windows.Forms.DateTimePicker();
            this.cbxNgayTra = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhong.Location = new System.Drawing.Point(268, 9);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(98, 33);
            this.lblMaPhong.TabIndex = 0;
            this.lblMaPhong.Text = "label1";
            // 
            // lblDienTich
            // 
            this.lblDienTich.AutoSize = true;
            this.lblDienTich.Location = new System.Drawing.Point(11, 65);
            this.lblDienTich.Name = "lblDienTich";
            this.lblDienTich.Size = new System.Drawing.Size(51, 20);
            this.lblDienTich.TabIndex = 0;
            this.lblDienTich.Text = "label1";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(11, 123);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(51, 20);
            this.lblGia.TabIndex = 0;
            this.lblGia.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chú thich:";
            // 
            // txtChuThich
            // 
            this.txtChuThich.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChuThich.Enabled = false;
            this.txtChuThich.AutoSize = false;
            this.txtChuThich.Location = new System.Drawing.Point(10, 214);
            this.txtChuThich.MinimumSize = new System.Drawing.Size(263, 107);
            this.txtChuThich.Name = "txtChuThich";
            this.txtChuThich.Size = new System.Drawing.Size(263, 137);
            this.txtChuThich.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.txtChuThich);
            this.groupBox1.Controls.Add(this.lblDienTich);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblGia);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 363);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(329, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 270);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwThue);
            this.tabPage1.Controls.Add(this.txtNgayTra);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(451, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin thuê";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwThue
            // 
            this.lvwThue.HideSelection = false;
            this.lvwThue.Location = new System.Drawing.Point(0, 0);
            this.lvwThue.Name = "lvwThue";
            this.lvwThue.Size = new System.Drawing.Size(451, 244);
            this.lvwThue.TabIndex = 0;
            this.lvwThue.UseCompatibleStateImageBehavior = false;
            this.lvwThue.SelectedIndexChanged += new System.EventHandler(this.lvwThue_SelectedIndexChanged);
            // 
            // txtNgayTra
            // 
            this.txtNgayTra.Enabled = false;
            this.txtNgayTra.Location = new System.Drawing.Point(201, 221);
            this.txtNgayTra.Name = "txtNgayTra";
            this.txtNgayTra.Size = new System.Drawing.Size(82, 20);
            this.txtNgayTra.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvwKH);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(451, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chi tết KH";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvwKH
            // 
            this.lvwKH.HideSelection = false;
            this.lvwKH.Location = new System.Drawing.Point(0, 0);
            this.lvwKH.Name = "lvwKH";
            this.lvwKH.Size = new System.Drawing.Size(451, 249);
            this.lvwKH.TabIndex = 0;
            this.lvwKH.UseCompatibleStateImageBehavior = false;
            this.lvwKH.SelectedIndexChanged += new System.EventHandler(this.lvwKH_SelectedIndexChanged);
            this.lvwKH.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwKH_MouseDoubleClick);
            // 
            // dateTimeNgayThue
            // 
            this.dateTimeNgayThue.Enabled = false;
            this.dateTimeNgayThue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeNgayThue.Location = new System.Drawing.Point(677, 334);
            this.dateTimeNgayThue.Name = "dateTimeNgayThue";
            this.dateTimeNgayThue.Size = new System.Drawing.Size(82, 20);
            this.dateTimeNgayThue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã thuê:";
            // 
            // cbMaKH
            // 
            this.cbMaKH.Enabled = false;
            this.cbMaKH.FormattingEnabled = true;
            this.cbMaKH.Location = new System.Drawing.Point(418, 376);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(121, 21);
            this.cbMaKH.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã KH:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(612, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ngày thuê:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(621, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ngày trả:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(477, 412);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.Location = new System.Drawing.Point(366, 413);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(0, 19);
            this.lblThanhTien.TabIndex = 6;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(585, 413);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(670, 412);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cbMaThue
            // 
            this.cbMaThue.Enabled = false;
            this.cbMaThue.FormattingEnabled = true;
            this.cbMaThue.Location = new System.Drawing.Point(418, 333);
            this.cbMaThue.Name = "cbMaThue";
            this.cbMaThue.Size = new System.Drawing.Size(121, 21);
            this.cbMaThue.TabIndex = 7;
            // 
            // btnTao
            // 
            this.btnTao.Location = new System.Drawing.Point(478, 412);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(75, 23);
            this.btnTao.TabIndex = 5;
            this.btnTao.Text = "Tạo mới";
            this.btnTao.UseVisualStyleBackColor = true;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // dateTimeNgayTra
            // 
            this.dateTimeNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeNgayTra.Location = new System.Drawing.Point(677, 365);
            this.dateTimeNgayTra.Name = "dateTimeNgayTra";
            this.dateTimeNgayTra.Size = new System.Drawing.Size(82, 20);
            this.dateTimeNgayTra.TabIndex = 8;
            // 
            // cbxNgayTra
            // 
            this.cbxNgayTra.AutoSize = true;
            this.cbxNgayTra.Location = new System.Drawing.Point(677, 391);
            this.cbxNgayTra.Name = "cbxNgayTra";
            this.cbxNgayTra.Size = new System.Drawing.Size(107, 17);
            this.cbxNgayTra.TabIndex = 9;
            this.cbxNgayTra.Text = "Chưa có ngày trả";
            this.cbxNgayTra.UseVisualStyleBackColor = true;
            this.cbxNgayTra.CheckedChanged += new System.EventHandler(this.cbxNgayTra_CheckedChanged);
            // 
            // frmThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxNgayTra);
            this.Controls.Add(this.dateTimeNgayTra);
            this.Controls.Add(this.cbMaThue);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbMaKH);
            this.Controls.Add(this.lblMaPhong);
            this.Controls.Add(this.dateTimeNgayThue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmThongTin";
            this.Text = "frmThongTin";
            this.Load += new System.EventHandler(this.frmThongTin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Label lblDienTich;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChuThich;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvwThue;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvwKH;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbMaKH;
        private System.Windows.Forms.DateTimePicker dateTimeNgayThue;
        private System.Windows.Forms.TextBox txtNgayTra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cbMaThue;
        private System.Windows.Forms.Button btnTao;
        private System.Windows.Forms.DateTimePicker dateTimeNgayTra;
        private System.Windows.Forms.CheckBox cbxNgayTra;
    }
}