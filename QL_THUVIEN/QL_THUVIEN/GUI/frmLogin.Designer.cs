namespace QL_ThuVien.GUI
{
    partial class frmLogin
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cbSaveInfo = new System.Windows.Forms.CheckBox();
            this.cbShowPass = new System.Windows.Forms.CheckBox();
            this.lbForgetAccount = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(12, 184);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(245, 22);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(13, 224);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(245, 22);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.UseSystemPasswordChar = true;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(13, 279);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(244, 33);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cbSaveInfo
            // 
            this.cbSaveInfo.AutoSize = true;
            this.cbSaveInfo.Checked = true;
            this.cbSaveInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSaveInfo.Location = new System.Drawing.Point(7, 343);
            this.cbSaveInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cbSaveInfo.Name = "cbSaveInfo";
            this.cbSaveInfo.Size = new System.Drawing.Size(115, 21);
            this.cbSaveInfo.TabIndex = 3;
            this.cbSaveInfo.Text = "Nhớ tài khoản";
            this.cbSaveInfo.UseVisualStyleBackColor = true;
            this.cbSaveInfo.CheckedChanged += new System.EventHandler(this.cbSaveInfo_CheckedChanged);
            // 
            // cbShowPass
            // 
            this.cbShowPass.AutoSize = true;
            this.cbShowPass.Location = new System.Drawing.Point(145, 342);
            this.cbShowPass.Margin = new System.Windows.Forms.Padding(4);
            this.cbShowPass.Name = "cbShowPass";
            this.cbShowPass.Size = new System.Drawing.Size(113, 20);
            this.cbShowPass.TabIndex = 4;
            this.cbShowPass.Text = "Hiện Mật Khẩu";
            this.cbShowPass.UseVisualStyleBackColor = true;
            this.cbShowPass.CheckedChanged += new System.EventHandler(this.cbShowPass_CheckedChanged);
            // 
            // lbForgetAccount
            // 
            this.lbForgetAccount.AutoSize = true;
            this.lbForgetAccount.Location = new System.Drawing.Point(140, 250);
            this.lbForgetAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbForgetAccount.Name = "lbForgetAccount";
            this.lbForgetAccount.Size = new System.Drawing.Size(118, 16);
            this.lbForgetAccount.TabIndex = 5;
            this.lbForgetAccount.TabStop = true;
            this.lbForgetAccount.Text = "Quyên Tài Khoản?";
            this.lbForgetAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbForgetAccount_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_ThuVien.Properties.Resources.if_simpline_27_2305630;
            this.pictureBox1.Location = new System.Drawing.Point(56, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 380);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbForgetAccount);
            this.Controls.Add(this.cbShowPass);
            this.Controls.Add(this.cbSaveInfo);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox cbSaveInfo;
        private System.Windows.Forms.CheckBox cbShowPass;
        private System.Windows.Forms.LinkLabel lbForgetAccount;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}