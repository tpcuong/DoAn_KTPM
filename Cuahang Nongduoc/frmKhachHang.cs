using CuahangNongduoc.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmKhachHang : Form
    {
        CuahangNongduoc.Controller.KhachHangController ctrl = new CuahangNongduoc.Controller.KhachHangController();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {

            ctrl.HienthiKhachHangDataGridview(dataGridView, bindingNavigator);
        }
        private bool ValidateRow(DataGridViewRow dtg, DataGridView grid)
        {
            var cell = dtg.Cells["colDienThoai"];
            string sdt = cell.Value == null ? string.Empty : cell.Value.ToString().Trim();
            if (dtg.Cells["colHoTen"].Value == null || string.IsNullOrEmpty(dtg.Cells["colHoTen"].Value.ToString().Trim()))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng", "Khách hàng",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grid.CurrentCell = dtg.Cells["colHoTen"];
                grid.BeginEdit(true);
                return false;
            }
            else  if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Khách hàng",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grid.CurrentCell = cell;
                grid.BeginEdit(true);
                return false;
            }
            

            bool allDigits = true;
            foreach (char c in sdt)
            {
                if (!char.IsDigit(c))
                {
                    allDigits = false;
                    break;
                }
            }

            if (!allDigits || sdt.Length < 9 || sdt.Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ (chỉ chứa số, dài 9–11 ký tự).",
                                "Khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grid.CurrentCell = cell;
                grid.BeginEdit(true);
                return false;
            }

            return true;
        }


        private void toolLuu_Click(object sender, EventArgs e)
        {
           
            dataGridView.EndEdit(); // chốt hết dữ liệu đang edit

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Bỏ qua dòng mới
                if (row.IsNewRow) continue;

                if (!ValidateRow(row, dataGridView))
                {
                    // Gặp dòng sai là dừng luôn, bắt user sửa
                    return;
                }
            }
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            long maso = ThamSo.KhachHang;
            ThamSo.KhachHang = maso + 1;

            DataRowView row = (DataRowView)bindingNavigator.BindingSource.AddNew();
            row["ID"] = maso;
            
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "San Pham", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridView.Rows.Count > 0)
                    
                    Delete();
                else
                    MessageBox.Show("Không có dữ liệu để xóa", "San Pham", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Delete()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để xóa.",
                    "Sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var policy = new XoaMem(); // tạo 1 lần

                // Duyệt qua các dòng được chọn
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    // Bỏ qua dòng NewRow (dòng trống cuối grid)
                    if (row.IsNewRow) continue;

                    var cellValue = row.Cells["colID"].Value;
                    if (cellValue == null) continue;

                    string id = cellValue.ToString();

                    if (ThamSo.Delete(id, "KHACH_HANG", policy))
                    {
                        // Xóa luôn khỏi grid nếu muốn
                        dataGridView.Rows.Remove(row);
                    }
                }

                MessageBox.Show("Xóa thành công!", "Sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sản phẩm! " + ex.Message, "Sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Khach Hang", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

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
            if (toolTimHoTen.Checked==true)
                toolTimKhachHang.Text = "Tìm theo Họ tên";
            else
                toolTimKhachHang.Text = "Tìm theo Địa chỉ";

            toolTimKhachHang.ForeColor = Color.FromArgb(224,224,224);
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

       
    }
}