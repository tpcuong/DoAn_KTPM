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
    public partial class frmNhaCungCap : Form
    {
        CuahangNongduoc.Controller.NhaCungCapController ctrl = new CuahangNongduoc.Controller.NhaCungCapController();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Nha Cung Cap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Nha Cung Cap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    var policy = new XoaMem();

                    DataGridViewRow row = dataGridView.SelectedRows[0];
                    string id = row.Cells["colId"].Value.ToString();
                    if (ThamSo.Delete(id, "NHA_CUNG_CAP", policy))
                    {
                        MessageBox.Show("Xóa thành công!", "Phieu Ban Nhap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmNhaCungCap_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }

                }

                //bindingNavigator.BindingSource.RemoveCurrent();
            }
        }
        void Allow(bool allow) // Thêm mới hàm này 
        {
            dataGridView.Enabled = allow;
            bindingNavigatorDeleteItem.Enabled = !allow;
            toolLuu.Enabled = allow;
            bindingNavigatorAddNewItem.Enabled = !allow;
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
            Allow(false);

        }
        long masoTemp;
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Allow(true);
            long maso = ThamSo.NhaCungCap;
            masoTemp = maso;

            DataRowView row = (DataRowView)bindingNavigator.BindingSource.AddNew();
            row["ID"] = maso;
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            ThamSo.NhaCungCap = masoTemp + 1;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["colHoTen"].Value == null || row.Cells["colHoTen"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Họ tê nhà cung cấp không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bindingNavigatorPositionItem.Focus();
                    return;
                }
                else
                {

                    bindingNavigatorPositionItem.Focus();
                    ctrl.Save();
                }
            }
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolTimNhaCungCap_Enter(object sender, EventArgs e)
        {
            toolTimNhaCungCap.Text = "";
            toolTimNhaCungCap.ForeColor = Color.Black;
        }

        private void toolTimNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (toolTimHoTen.Checked)
                {
                    ctrl.TimHoTen(toolTimNhaCungCap.Text);
                }
                else
                {
                    ctrl.TimDiaChi(toolTimNhaCungCap.Text);
                }
            }
        }

        private void toolTimNhaCungCap_Leave(object sender, EventArgs e)
        {
            if (toolTimHoTen.Checked == true)
                toolTimNhaCungCap.Text = "Tìm theo Nhà cung cấp";
            else
                toolTimNhaCungCap.Text = "Tìm theo Địa chỉ";

            toolTimNhaCungCap.ForeColor = Color.FromArgb(224, 224, 224);
        }

        private void toolTimHoTen_Click(object sender, EventArgs e)
        {
            toolTimDiaChi.Checked = !toolTimDiaChi.Checked;
            toolTimHoTen.Checked = !toolTimDiaChi.Checked;
            toolTimNhaCungCap.Text = "Tìm theo Nhà cung cấp";
            bindingNavigator.Focus();
        }

        private void toolTimDiaChi_Click(object sender, EventArgs e)
        {
            toolTimHoTen.Checked = !toolTimHoTen.Checked;
            toolTimDiaChi.Checked = !toolTimHoTen.Checked;
            toolTimNhaCungCap.Text = "Tìm theo Địa chỉ";
            bindingNavigator.Focus();
        }
    }
}