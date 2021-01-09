namespace GUI
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDoiMK = new DevExpress.XtraEditors.SimpleButton();
            this.txtXacNhanMatKhau = new JTextBox.JTextBox();
            this.txtMatKhauMoi = new JTextBox.JTextBox();
            this.txtMatKhauCu = new JTextBox.JTextBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(388, 454);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.groupControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 53);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(384, 399);
            this.panelControl3.TabIndex = 13;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImageOptions.Image = global::GUI.Properties.Resources.secrecy_icon1;
            this.groupControl1.Controls.Add(this.btnThoat);
            this.groupControl1.Controls.Add(this.pictureBox3);
            this.groupControl1.Controls.Add(this.pictureBox2);
            this.groupControl1.Controls.Add(this.pictureBox1);
            this.groupControl1.Controls.Add(this.btnDoiMK);
            this.groupControl1.Controls.Add(this.txtXacNhanMatKhau);
            this.groupControl1.Controls.Add(this.txtMatKhauMoi);
            this.groupControl1.Controls.Add(this.txtMatKhauCu);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(380, 395);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Thông tin đổi mật khẩu";
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(145, 335);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 40);
            this.btnThoat.TabIndex = 27;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GUI.Properties.Resources.PassWordOke_335_47x47;
            this.pictureBox3.Location = new System.Drawing.Point(34, 226);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 49);
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI.Properties.Resources.PassWordOld_335_47x47;
            this.pictureBox2.Location = new System.Drawing.Point(34, 141);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 50);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.PassWordNew_335_47x47;
            this.pictureBox1.Location = new System.Drawing.Point(34, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 59);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMK.Appearance.Options.UseFont = true;
            this.btnDoiMK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDoiMK.ImageOptions.Image")));
            this.btnDoiMK.Location = new System.Drawing.Point(103, 287);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(164, 42);
            this.btnDoiMK.TabIndex = 23;
            this.btnDoiMK.Text = "Đổi Mật Khẩu";
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.AutoSize = true;
            this.txtXacNhanMatKhau.BorderColor = System.Drawing.Color.Black;
            this.txtXacNhanMatKhau.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtXacNhanMatKhau.Hint = "Nhâp lại mật khảu mới";
            this.txtXacNhanMatKhau.IsPassword = false;
            this.txtXacNhanMatKhau.Length = 0;
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(103, 226);
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.OnFocus = System.Drawing.Color.DarkGray;
            this.txtXacNhanMatKhau.OnlyChar = false;
            this.txtXacNhanMatKhau.OnlyNumber = false;
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(252, 39);
            this.txtXacNhanMatKhau.TabIndex = 2;
            this.txtXacNhanMatKhau.TextValue = "Nhâp lại mật khảu mới";
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.AutoSize = true;
            this.txtMatKhauMoi.BorderColor = System.Drawing.Color.Black;
            this.txtMatKhauMoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMatKhauMoi.Hint = "Mật khẩu mới";
            this.txtMatKhauMoi.IsPassword = false;
            this.txtMatKhauMoi.Length = 0;
            this.txtMatKhauMoi.Location = new System.Drawing.Point(103, 141);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.OnFocus = System.Drawing.Color.DarkGray;
            this.txtMatKhauMoi.OnlyChar = false;
            this.txtMatKhauMoi.OnlyNumber = false;
            this.txtMatKhauMoi.Size = new System.Drawing.Size(252, 39);
            this.txtMatKhauMoi.TabIndex = 1;
            this.txtMatKhauMoi.TextValue = "Mật khẩu mới";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.AutoSize = true;
            this.txtMatKhauCu.BorderColor = System.Drawing.Color.Black;
            this.txtMatKhauCu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMatKhauCu.Hint = "Mật khẩu cũ";
            this.txtMatKhauCu.IsPassword = false;
            this.txtMatKhauCu.Length = 0;
            this.txtMatKhauCu.Location = new System.Drawing.Point(103, 66);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.OnFocus = System.Drawing.Color.DarkGray;
            this.txtMatKhauCu.OnlyChar = false;
            this.txtMatKhauCu.OnlyNumber = false;
            this.txtMatKhauCu.Size = new System.Drawing.Size(252, 39);
            this.txtMatKhauCu.TabIndex = 0;
            this.txtMatKhauCu.TextValue = "Mật khẩu cũ";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(384, 51);
            this.panelControl2.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.DarkCyan;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(380, 47);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "ĐỔI MẬT KHẨU";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 454);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoiMatKhau";
            this.Text = "frmDoiMatKhau";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton btnDoiMK;
        private JTextBox.JTextBox txtXacNhanMatKhau;
        private JTextBox.JTextBox txtMatKhauMoi;
        private JTextBox.JTextBox txtMatKhauCu;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}