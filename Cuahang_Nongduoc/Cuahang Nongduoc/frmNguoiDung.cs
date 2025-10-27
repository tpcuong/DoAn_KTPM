using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.BusinessLayer;

namespace CuahangNongduoc
{
    public partial class frmNguoiDung : Form
    {
        NguoiDungController ctrl = new NguoiDungController();

        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvNguoiDung.DataSource = ctrl.DanhSachNguoiDung();
            dgvNguoiDung.Columns["ID"].HeaderText = "Mã người dùng";
            dgvNguoiDung.Columns["TEN_DANG_NHAP"].HeaderText = "Tên đăng nhập";
            dgvNguoiDung.Columns["MAT_KHAU_HASH"].HeaderText = "Mật khẩu";
            dgvNguoiDung.Columns["VAI_TRO"].HeaderText = "Vai trò";
            dgvNguoiDung.Columns["TEN_NGUOI_DUNG"].HeaderText = "Tên người dùng";
            dgvNguoiDung.Columns["EMAIL"].HeaderText = "Email";
            dgvNguoiDung.Columns["SO_DIEN_THOAI"].HeaderText = "Số điện thoại";
            dgvNguoiDung.Columns["TRANG_THAI"].HeaderText = "Trạng thái";

            // Ẩn cột mật khẩu nếu muốn
            dgvNguoiDung.Columns["MAT_KHAU_HASH"].Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenNguoiDung.Text))
            {
                MessageBox.Show("Tên người dùng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNguoiDung.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbVaiTro.Text))
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVaiTro.Focus();
                return;
            }

            string matKhauDaMaHoa = HashSHA256(txtMatKhau.Text.Trim());

            try
            {
                if (ctrl.ThemNguoiDung(
                    txtTenDangNhap.Text.Trim(),
                    matKhauDaMaHoa,
                    txtTenNguoiDung.Text.Trim(),
                    cmbVaiTro.Text,
                    txtEmail.Text.Trim(),
                    txtSDT.Text.Trim(),
                    chkTrangThai.Checked))
                {
                    LoadData();
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm người dùng thất bại! Tên đăng nhập có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null) return;
            string matKhauDaMaHoa = HashSHA256(txtMatKhau.Text.Trim());

            int id = Convert.ToInt32(dgvNguoiDung.CurrentRow.Cells["ID"].Value);
            if (ctrl.SuaNguoiDung(id,
                cmbVaiTro.Text,
                txtTenDangNhap.Text.Trim(),
                matKhauDaMaHoa,
                txtTenNguoiDung.Text.Trim(),
                txtEmail.Text.Trim(),
                txtSDT.Text.Trim(),
                chkTrangThai.Checked))
            {
                LoadData();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvNguoiDung.CurrentRow.Cells["ID"].Value);
            if (ctrl.XoaNguoiDung(id))
            {
                LoadData();
                MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguoiDung.Rows[e.RowIndex];

                txtTenDangNhap.Text = row.Cells["Ten_Dang_Nhap"].Value.ToString();
                txtTenNguoiDung.Text = row.Cells["Ten_Nguoi_Dung"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSDT.Text = row.Cells["So_Dien_Thoai"].Value.ToString();

                string role = row.Cells["Vai_Tro"].Value.ToString();
                cmbVaiTro.SelectedIndex = role == "Admin" ? 0 : 1;
                txtMatKhau.Text = row.Cells["MAT_KHAU_HASH"].Value.ToString();
                chkTrangThai.Checked = Convert.ToBoolean(row.Cells["Trang_Thai"].Value);
            }
        }

        private string HashSHA256(string text)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
