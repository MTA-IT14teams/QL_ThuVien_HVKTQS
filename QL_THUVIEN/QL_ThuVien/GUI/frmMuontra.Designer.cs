namespace QL_ThuVien.GUI
{
    partial class frmMuontra
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
<<<<<<< HEAD
            this.SuspendLayout();
            // 
=======
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuontra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTra = new System.Windows.Forms.Button();
            this.btnMuon = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMDG1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuMuonTra = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnGhiNhan = new System.Windows.Forms.Button();
            this.dateTra = new System.Windows.Forms.DateTimePicker();
            this.dateHtra = new System.Windows.Forms.DateTimePicker();
            this.dateLap = new System.Windows.Forms.DateTimePicker();
            this.txtMTT = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMDG2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoPMT = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvChiTietMuon = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuonTra)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMuon)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTra);
            this.groupBox1.Controls.Add(this.btnMuon);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtLoai);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtNgaySinh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenDG);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMDG1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 240);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin độc giả";
            // 
            // btnTra
            // 
            this.btnTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTra.Image = ((System.Drawing.Image)(resources.GetObject("btnTra.Image")));
            this.btnTra.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTra.Location = new System.Drawing.Point(389, 170);
            this.btnTra.Name = "btnTra";
            this.btnTra.Size = new System.Drawing.Size(65, 60);
            this.btnTra.TabIndex = 22;
            this.btnTra.Text = "Trả sách";
            this.btnTra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTra.UseVisualStyleBackColor = true;
            this.btnTra.Click += new System.EventHandler(this.btnTra_Click);
            // 
            // btnMuon
            // 
            this.btnMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuon.Image = ((System.Drawing.Image)(resources.GetObject("btnMuon.Image")));
            this.btnMuon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMuon.Location = new System.Drawing.Point(279, 170);
            this.btnMuon.Name = "btnMuon";
            this.btnMuon.Size = new System.Drawing.Size(65, 60);
            this.btnMuon.TabIndex = 22;
            this.btnMuon.Text = "Mượn sách";
            this.btnMuon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMuon.UseVisualStyleBackColor = true;
            this.btnMuon.Click += new System.EventHandler(this.btnMuon_Click);
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Image = ((System.Drawing.Image)(resources.GetObject("btnXem.Image")));
            this.btnXem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXem.Location = new System.Drawing.Point(65, 170);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(65, 60);
            this.btnXem.TabIndex = 22;
            this.btnXem.Text = "Xem";
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click_1);
            // 
            // txtSDT
            // 
            this.txtSDT.Enabled = false;
            this.txtSDT.Location = new System.Drawing.Point(269, 45);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(175, 21);
            this.txtSDT.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Số điện thoại";
            // 
            // txtLoai
            // 
            this.txtLoai.Enabled = false;
            this.txtLoai.Location = new System.Drawing.Point(269, 144);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(175, 21);
            this.txtLoai.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Loại độc giả";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbNu);
            this.groupBox3.Controls.Add(this.rdbNam);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(269, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 45);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Giới tính";
            // 
            // rdbNu
            // 
            this.rdbNu.AutoSize = true;
            this.rdbNu.Location = new System.Drawing.Point(73, 16);
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Size = new System.Drawing.Size(41, 19);
            this.rdbNu.TabIndex = 1;
            this.rdbNu.TabStop = true;
            this.rdbNu.Text = "Nữ";
            this.rdbNu.UseVisualStyleBackColor = true;
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.Location = new System.Drawing.Point(6, 16);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Size = new System.Drawing.Size(52, 19);
            this.rdbNam.TabIndex = 0;
            this.rdbNam.TabStop = true;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UseVisualStyleBackColor = true;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Enabled = false;
            this.txtNgaySinh.Location = new System.Drawing.Point(55, 144);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(175, 21);
            this.txtNgaySinh.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ngày sinh";
            // 
            // txtTenDG
            // 
            this.txtTenDG.Enabled = false;
            this.txtTenDG.Location = new System.Drawing.Point(55, 93);
            this.txtTenDG.Name = "txtTenDG";
            this.txtTenDG.Size = new System.Drawing.Size(175, 21);
            this.txtTenDG.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên độc giả";
            // 
            // txtMDG1
            // 
            this.txtMDG1.Location = new System.Drawing.Point(55, 45);
            this.txtMDG1.MaxLength = 10;
            this.txtMDG1.Name = "txtMDG1";
            this.txtMDG1.Size = new System.Drawing.Size(175, 21);
            this.txtMDG1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mã độc giả";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvPhieuMuonTra);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(21, 275);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 247);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Phiếu mượn trả";
            // 
            // dgvPhieuMuonTra
            // 
            this.dgvPhieuMuonTra.AllowUserToAddRows = false;
            this.dgvPhieuMuonTra.AllowUserToDeleteRows = false;
            this.dgvPhieuMuonTra.AllowUserToResizeColumns = false;
            this.dgvPhieuMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuMuonTra.Location = new System.Drawing.Point(3, 17);
            this.dgvPhieuMuonTra.MultiSelect = false;
            this.dgvPhieuMuonTra.Name = "dgvPhieuMuonTra";
            this.dgvPhieuMuonTra.ReadOnly = true;
            this.dgvPhieuMuonTra.RowHeadersVisible = false;
            this.dgvPhieuMuonTra.Size = new System.Drawing.Size(504, 227);
            this.dgvPhieuMuonTra.TabIndex = 5;
            this.dgvPhieuMuonTra.TabStop = false;
            this.dgvPhieuMuonTra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuMuonTra_CellClick_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnGhiNhan);
            this.groupBox2.Controls.Add(this.dateTra);
            this.groupBox2.Controls.Add(this.dateHtra);
            this.groupBox2.Controls.Add(this.dateLap);
            this.groupBox2.Controls.Add(this.txtMTT);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtMDG2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSoPMT);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(562, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 240);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phiếu mượn trả";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXoa.Location = new System.Drawing.Point(390, 171);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(65, 60);
            this.btnXoa.TabIndex = 22;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSua.Location = new System.Drawing.Point(280, 171);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(65, 60);
            this.btnSua.TabIndex = 22;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnGhiNhan
            // 
            this.btnGhiNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhiNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnGhiNhan.Image")));
            this.btnGhiNhan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGhiNhan.Location = new System.Drawing.Point(49, 171);
            this.btnGhiNhan.Name = "btnGhiNhan";
            this.btnGhiNhan.Size = new System.Drawing.Size(65, 60);
            this.btnGhiNhan.TabIndex = 22;
            this.btnGhiNhan.Text = "Ghi nhận";
            this.btnGhiNhan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGhiNhan.UseVisualStyleBackColor = true;
            this.btnGhiNhan.Click += new System.EventHandler(this.btnGhiNhan_Click);
            // 
            // dateTra
            // 
            this.dateTra.CustomFormat = " ";
            this.dateTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTra.Location = new System.Drawing.Point(280, 91);
            this.dateTra.Name = "dateTra";
            this.dateTra.Size = new System.Drawing.Size(175, 21);
            this.dateTra.TabIndex = 32;
            this.dateTra.ValueChanged += new System.EventHandler(this.dateTra_ValueChanged);
            // 
            // dateHtra
            // 
            this.dateHtra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateHtra.Location = new System.Drawing.Point(49, 142);
            this.dateHtra.Name = "dateHtra";
            this.dateHtra.Size = new System.Drawing.Size(175, 21);
            this.dateHtra.TabIndex = 31;
            // 
            // dateLap
            // 
            this.dateLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateLap.Location = new System.Drawing.Point(49, 91);
            this.dateLap.Name = "dateLap";
            this.dateLap.Size = new System.Drawing.Size(175, 21);
            this.dateLap.TabIndex = 30;
            this.dateLap.ValueChanged += new System.EventHandler(this.dateLap_ValueChanged);
            // 
            // txtMTT
            // 
            this.txtMTT.Location = new System.Drawing.Point(280, 142);
            this.txtMTT.MaxLength = 10;
            this.txtMTT.Name = "txtMTT";
            this.txtMTT.Size = new System.Drawing.Size(175, 21);
            this.txtMTT.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(277, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Mã thủ thư";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(277, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Ngày trả";
            // 
            // txtMDG2
            // 
            this.txtMDG2.Location = new System.Drawing.Point(280, 46);
            this.txtMDG2.MaxLength = 10;
            this.txtMDG2.Name = "txtMDG2";
            this.txtMDG2.Size = new System.Drawing.Size(175, 21);
            this.txtMDG2.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(277, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Mã độc giả";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Ngày hẹn trả";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Ngày lập";
            // 
            // txtSoPMT
            // 
            this.txtSoPMT.Location = new System.Drawing.Point(49, 46);
            this.txtSoPMT.MaxLength = 10;
            this.txtSoPMT.Name = "txtSoPMT";
            this.txtSoPMT.Size = new System.Drawing.Size(175, 21);
            this.txtSoPMT.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Số phiếu mượn trả";
            // 
            // dgvChiTietMuon
            // 
            this.dgvChiTietMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietMuon.Location = new System.Drawing.Point(3, 17);
            this.dgvChiTietMuon.Name = "dgvChiTietMuon";
            this.dgvChiTietMuon.Size = new System.Drawing.Size(470, 223);
            this.dgvChiTietMuon.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvChiTietMuon);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(562, 279);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(476, 243);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chi tiết phiếu";
            // 
>>>>>>> QL_MuonTra
            // frmMuontra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1051, 607);
            this.Name = "frmMuontra";
            this.Text = "Quản Lý Mượn Trả";
=======
            this.ClientSize = new System.Drawing.Size(1077, 539);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMuontra";
            this.Text = "Quản Lý Mượn Trả";
            this.Load += new System.EventHandler(this.frmMuontra_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuonTra)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMuon)).EndInit();
            this.groupBox5.ResumeLayout(false);
>>>>>>> QL_MuonTra
            this.ResumeLayout(false);

        }

        #endregion

<<<<<<< HEAD
=======
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTra;
        private System.Windows.Forms.Button btnMuon;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbNu;
        private System.Windows.Forms.RadioButton rdbNam;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenDG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMDG1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvPhieuMuonTra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnGhiNhan;
        private System.Windows.Forms.DateTimePicker dateTra;
        private System.Windows.Forms.DateTimePicker dateHtra;
        private System.Windows.Forms.DateTimePicker dateLap;
        private System.Windows.Forms.TextBox txtMTT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMDG2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoPMT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvChiTietMuon;
        private System.Windows.Forms.GroupBox groupBox5;
>>>>>>> QL_MuonTra
    }
}