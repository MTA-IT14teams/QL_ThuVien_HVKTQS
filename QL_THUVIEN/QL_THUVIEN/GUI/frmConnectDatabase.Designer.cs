namespace QL_THUVIEN.GUI
{
    partial class frmConnectDatabase
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenMayChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxChonTaiKhoan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenCSDL = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(52, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerName";
            // 
            // txtTenMayChu
            // 
            this.txtTenMayChu.Location = new System.Drawing.Point(160, 42);
            this.txtTenMayChu.Name = "txtTenMayChu";
            this.txtTenMayChu.Size = new System.Drawing.Size(187, 20);
            this.txtTenMayChu.TabIndex = 1;
            this.txtTenMayChu.Text = "ADMIN-PC\\SQLSERVEREXPRESS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(52, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Authentication";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbxChonTaiKhoan
            // 
            this.cbxChonTaiKhoan.FormattingEnabled = true;
            this.cbxChonTaiKhoan.Items.AddRange(new object[] {
            "Window Authentication",
            "SQL Server Authentication"});
            this.cbxChonTaiKhoan.Location = new System.Drawing.Point(160, 94);
            this.cbxChonTaiKhoan.Name = "cbxChonTaiKhoan";
            this.cbxChonTaiKhoan.Size = new System.Drawing.Size(187, 21);
            this.cbxChonTaiKhoan.TabIndex = 3;
            this.cbxChonTaiKhoan.SelectedIndexChanged += new System.EventHandler(this.cbxChonTaiKhoan_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(52, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên Đăng Nhập";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(160, 151);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(187, 20);
            this.txtTenDangNhap.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(52, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mật Khẩu";
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(160, 204);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(187, 20);
            this.txtMK.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(52, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tên CSDL";
            // 
            // txtTenCSDL
            // 
            this.txtTenCSDL.Location = new System.Drawing.Point(160, 265);
            this.txtTenCSDL.Name = "txtTenCSDL";
            this.txtTenCSDL.Size = new System.Drawing.Size(187, 20);
            this.txtTenCSDL.TabIndex = 9;
            this.txtTenCSDL.Text = "ThuVien";
            this.txtTenCSDL.TextChanged += new System.EventHandler(this.txtTenCSDL_TextChanged);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDangNhap.Location = new System.Drawing.Point(89, 371);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangNhap.TabIndex = 10;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnThoat.Location = new System.Drawing.Point(233, 371);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmConnectDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(394, 439);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtTenCSDL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxChonTaiKhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenMayChu);
            this.Controls.Add(this.label1);
            this.Name = "frmConnectDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConnectDatabase";
            this.Load += new System.EventHandler(this.frmConnectDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenMayChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxChonTaiKhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenCSDL;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
    }
}