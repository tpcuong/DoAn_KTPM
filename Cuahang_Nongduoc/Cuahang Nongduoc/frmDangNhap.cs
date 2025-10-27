using System;
using System.Data;
using System.Windows.Forms;
using CuahangNongduoc.BusinessLayer;

namespace CuahangNongduoc
{
    public partial class frmDangNhap : Form
    {
        NguoiDungController nguoiDungCtrl = new NguoiDungController();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vaiTro, tenNguoiDung;

            if (nguoiDungCtrl.KiemTraDangNhap(tenDangNhap, matKhau, out vaiTro, out tenNguoiDung))
            {
                this.Hide();
                frmMain main = new frmMain(vaiTro, tenNguoiDung);
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}