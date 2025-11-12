using CuahangNongduoc.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmKhachHang : Form
    {
        CuahangNongduoc.Controller.KhachHangController ctrl = new CuahangNongduoc.Controller.KhachHangController();

        const string COL_ID = "ID";
        const string COL_TEN = "HO_TEN";
        const string COL_DIACHI = "DIA_CHI";
        const string COL_SDT = "DIEN_THOAI";

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ctrl.HienthiKhachHangDataGridview(dataGridView, bindingNavigator);

            RestoreDataBindings();

            txtMaKH.ReadOnly = true;
            Allow(false);
            try
            {
                ThamSo.KhachHang = ctrl.GetMaxKhachHangID() + 1;
            }
            catch (Exception)
            {
                ThamSo.KhachHang = 1;
            }
        }

        #region "Các hàm trợ giúp (Helper Methods)"

        void Allow(bool allow) // Thêm mới hàm này 
        {
            dataGridView.Enabled = !allow;
            bindingNavigatorDeleteItem.Enabled = !allow;
            toolLuu.Enabled = allow;
            bindingNavigatorAddNewItem.Enabled = !allow;
            btnAdd.Enabled = allow;
            btnRemove.Enabled = allow;

        }
        void TxtReset()
        {
            txtHoTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }
        private void RestoreDataBindings()
        {
            txtMaKH.DataBindings.Clear();
            txtHoTenKH.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtSDT.DataBindings.Clear();

            txtMaKH.DataBindings.Add("Text", bindingNavigator.BindingSource, COL_ID);
            txtHoTenKH.DataBindings.Add("Text", bindingNavigator.BindingSource, COL_TEN);
            txtDiaChi.DataBindings.Add("Text", bindingNavigator.BindingSource, COL_DIACHI);
            txtSDT.DataBindings.Add("Text", bindingNavigator.BindingSource, COL_SDT);
        }

        #endregion

        #region "Các sự kiện Click"
        long maTemp;
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            TxtReset(); 
            Allow(true);
            long maso = ThamSo.KhachHang;
            maTemp = maso;
            txtMaKH.Text = maso.ToString();
            txtHoTenKH.Focus();
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {

            try
            {
                ThamSo.NhaCungCap = maTemp + 1;

                        bindingNavigatorPositionItem.Focus();
                        ctrl.Save();
                    
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaKhachHangHienTai()
        {
            try
            {
                if (txtHoTenKH.Text.Trim() == "")
                {
                    MessageBox.Show("Họ tên Đại lý không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTenKH.Focus();
                    return;
                }
                // 1. Xóa khỏi BindingSource (UI)
                bindingNavigator.BindingSource.RemoveCurrent();

                // 2. Lưu (DELETE) xuống DB
                ctrl.Save();

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. RESET LẠI ID TỰ TĂNG
                try
                {
                    ThamSo.KhachHang = ctrl.GetMaxKhachHangID() + 1;
                }
                catch (Exception)
                {
                    ThamSo.KhachHang = 1; // Nếu bảng rỗng
                }
            }
            catch (SqlException ex)
            {
                // 4. Bắt lỗi khóa ngoại
                if (ex.Number == 547)
                {
                    MessageBox.Show("Không thể xóa khách hàng này.\n\nLý do: Khách hàng đã có phát sinh 'Phiếu Bán' hoặc 'Phiếu Thanh Toán' trong lịch sử.", "Lỗi Ràng Buộc Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Tải lại dữ liệu để phục hồi
                    ctrl.HienthiKhachHangDataGridview(dataGridView, bindingNavigator);
                    RestoreDataBindings();
                }
                else
                {
                    MessageBox.Show("Lỗi SQL khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀM 2: SỬA LẠI NÚT XÓA TRÊN THANH CÔNG CỤ
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {

                var policy = new XoaMem();

              
                string id = txtMaKH.Text;
                ThamSo.Delete(id, "KHACH_HANG", policy);

                MessageBox.Show("Xóa thành công!", "Phieu chi ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmKhachHang_Load(sender, e);
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        // HÀM 3: SỬA LẠI SỰ KIỆN XÓA TRÊN DATAGRIDVIEW
        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Khach Hang", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Ngăn DataGridView tự xóa (vì nó không Save)
                e.Cancel = true;
                // Gọi hàm xóa chính của chúng ta (có Save và Reset ID)
                XoaKhachHangHienTai();
            }
            else
            {
                // Nếu người dùng chọn "No", cũng hủy
                e.Cancel = true;
            }
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Các sự kiện Tìm kiếm"

        private void toolTimHoTen_Click(object sender, EventArgs e)
        {
            toolTimDiaChi.Checked = !toolTimDiaChi.Checked;
            toolTimHoTen.Checked = !toolTimDiaChi.Checked;
            toolTimKhachHang.Text = "Tìm theo Họ tên";
            bindingNavigator.Focus();
        }

        private void toolTimDiaChi_Click(object sender, EventArgs e)
        {
            toolTimHoTen.Checked = !toolTimHoTen.Checked;
            toolTimDiaChi.Checked = !toolTimHoTen.Checked;
            toolTimKhachHang.Text = "Tìm theo Địa chỉ";
            bindingNavigator.Focus();
        }

        private void toolTimKhachHang_Enter(object sender, EventArgs e)
        {
            toolTimKhachHang.Text = "";
            toolTimKhachHang.ForeColor = Color.Black;
        }

        private void toolTimKhachHang_Leave(object sender, EventArgs e)
        {
            if (toolTimHoTen.Checked == true)
                toolTimKhachHang.Text = "Tìm theo Họ tên";
            else
                toolTimKhachHang.Text = "Tìm theo Địa chỉ";

            toolTimKhachHang.ForeColor = Color.FromArgb(224, 224, 224);
        }

        private void toolTimKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (toolTimHoTen.Checked)
                    ctrl.TimHoTen(toolTimKhachHang.Text, false);
                else
                    ctrl.TimDiaChi(toolTimKhachHang.Text, false);
            }
        }


        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            bindingNavigatorDeleteItem_Click(sender, e);    
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtHoTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Họ tên Khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenKH.Focus();
                return;
            }
            DataRow row = ctrl.NewRow();
            row["ID"] = txtMaKH.Text;
            row["HO_TEN"] = txtHoTenKH.Text;
            row["DIA_CHI"] = txtDiaChi.Text;
            row["DIEN_THOAI"] = txtSDT;
            row["LOAI_KH"] = 0;
            ctrl.Add(row);
        }
    }
}