namespace CuahangNongduoc
{
    partial class frmNguoiDung
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvNguoiDung;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenNguoiDung;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.ComboBox cmbVaiTro;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblTenNguoiDung;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.Panel panelChucNang;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvNguoiDung = new System.Windows.Forms.DataGridView();
            this.groupBoxThongTin = new System.Windows.Forms.GroupBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenNguoiDung = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.cmbVaiTro = new System.Windows.Forms.ComboBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblTenNguoiDung = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.panelChucNang = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.groupBoxThongTin.SuspendLayout();
            this.panelChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNguoiDung
            // 
            this.dgvNguoiDung.AllowUserToAddRows = false;
            this.dgvNguoiDung.AllowUserToDeleteRows = false;
            this.dgvNguoiDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguoiDung.Location = new System.Drawing.Point(12, 280);
            this.dgvNguoiDung.MultiSelect = false;
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.ReadOnly = true;
            this.dgvNguoiDung.RowHeadersWidth = 51;
            this.dgvNguoiDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguoiDung.Size = new System.Drawing.Size(760, 210);
            this.dgvNguoiDung.TabIndex = 1;
            this.dgvNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguoiDung_CellClick);
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.Controls.Add(this.txtTenDangNhap);
            this.groupBoxThongTin.Controls.Add(this.txtMatKhau);
            this.groupBoxThongTin.Controls.Add(this.txtTenNguoiDung);
            this.groupBoxThongTin.Controls.Add(this.txtEmail);
            this.groupBoxThongTin.Controls.Add(this.txtSDT);
            this.groupBoxThongTin.Controls.Add(this.cmbVaiTro);
            this.groupBoxThongTin.Controls.Add(this.chkTrangThai);
            this.groupBoxThongTin.Controls.Add(this.lblTenDangNhap);
            this.groupBoxThongTin.Controls.Add(this.lblMatKhau);
            this.groupBoxThongTin.Controls.Add(this.lblTenNguoiDung);
            this.groupBoxThongTin.Controls.Add(this.lblEmail);
            this.groupBoxThongTin.Controls.Add(this.lblSDT);
            this.groupBoxThongTin.Controls.Add(this.lblVaiTro);
            this.groupBoxThongTin.Controls.Add(this.lblTrangThai);
            this.groupBoxThongTin.Location = new System.Drawing.Point(12, 12);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            this.groupBoxThongTin.Size = new System.Drawing.Size(380, 260);
            this.groupBoxThongTin.TabIndex = 0;
            this.groupBoxThongTin.TabStop = false;
            this.groupBoxThongTin.Text = "Thông tin người dùng";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(120, 22);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(240, 22);
            this.txtTenDangNhap.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(120, 52);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(240, 22);
            this.txtMatKhau.TabIndex = 1;
            // 
            // txtTenNguoiDung
            // 
            this.txtTenNguoiDung.Location = new System.Drawing.Point(120, 82);
            this.txtTenNguoiDung.Name = "txtTenNguoiDung";
            this.txtTenNguoiDung.Size = new System.Drawing.Size(240, 22);
            this.txtTenNguoiDung.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(120, 142);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(240, 22);
            this.txtSDT.TabIndex = 4;
            // 
            // cmbVaiTro
            // 
            this.cmbVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaiTro.Items.AddRange(new object[] {
            "Admin",
            "Nhân viên"});
            this.cmbVaiTro.Location = new System.Drawing.Point(120, 172);
            this.cmbVaiTro.Name = "cmbVaiTro";
            this.cmbVaiTro.Size = new System.Drawing.Size(240, 24);
            this.cmbVaiTro.TabIndex = 5;
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Location = new System.Drawing.Point(120, 202);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(104, 24);
            this.chkTrangThai.TabIndex = 6;
            this.chkTrangThai.Text = "Hoạt động";
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(10, 25);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(101, 16);
            this.lblTenDangNhap.TabIndex = 7;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(10, 55);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(64, 16);
            this.lblMatKhau.TabIndex = 8;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblTenNguoiDung
            // 
            this.lblTenNguoiDung.AutoSize = true;
            this.lblTenNguoiDung.Location = new System.Drawing.Point(10, 85);
            this.lblTenNguoiDung.Name = "lblTenNguoiDung";
            this.lblTenNguoiDung.Size = new System.Drawing.Size(103, 16);
            this.lblTenNguoiDung.TabIndex = 9;
            this.lblTenNguoiDung.Text = "Tên người dùng:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(10, 115);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(10, 145);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(88, 16);
            this.lblSDT.TabIndex = 11;
            this.lblSDT.Text = "Số điện thoại:";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(10, 175);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(48, 16);
            this.lblVaiTro.TabIndex = 12;
            this.lblVaiTro.Text = "Vai trò:";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(10, 205);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(70, 16);
            this.lblTrangThai.TabIndex = 13;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // panelChucNang
            // 
            this.panelChucNang.Controls.Add(this.btnThem);
            this.panelChucNang.Controls.Add(this.btnSua);
            this.panelChucNang.Controls.Add(this.btnXoa);
            this.panelChucNang.Location = new System.Drawing.Point(410, 20);
            this.panelChucNang.Name = "panelChucNang";
            this.panelChucNang.Size = new System.Drawing.Size(100, 252);
            this.panelChucNang.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(5, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(5, 50);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(5, 100);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmNguoiDung
            // 
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.groupBoxThongTin);
            this.Controls.Add(this.panelChucNang);
            this.Controls.Add(this.dgvNguoiDung);
            this.Name = "frmNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản người dùng";
            this.Load += new System.EventHandler(this.frmNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.groupBoxThongTin.ResumeLayout(false);
            this.groupBoxThongTin.PerformLayout();
            this.panelChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
