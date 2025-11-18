using CuahangNongduoc.Controller;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmThanhToan : Form
    {
        private const string COL_ID = "ID";
        private const string COL_NGAY_THANH_TOAN = "NGAY_THANH_TOAN";
        private const string COL_TONG_TIEN = "TONG_TIEN";

        private KhachHangController ctrlKH = new KhachHangController();
        private PhieuThanhToanController ctrl = new PhieuThanhToanController();

        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            ctrlKH.HienthiChungAutoComboBox(cmbKhachHang);
            ctrlKH.HienthiKhachHangChungDataGridviewComboBox(colKhachHang);
            ctrl.HienthiPhieuThanhToan(bindingNavigator, dataGridView, cmbKhachHang, txtMaPhieu, dtNgayThanhToan, numTongTien, txtGhiChu);

            bindingNavigator.BindingSource.AddingNew += new AddingNewEventHandler(BindingSource_AddingNew);
        }

        void BindingSource_AddingNew(object sender, AddingNewEventArgs e) { }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            long maphieu = ThamSo.LayMaPhieuThanhToan();
            ThamSo.GanMaPhieuThanhToan(maphieu + 1);

            DataRow row = ctrl.NewRow();
            row[COL_ID] = maphieu;
            row[COL_NGAY_THANH_TOAN] = DateTime.Now.Date;
            row[COL_TONG_TIEN] = numTongTien.Value;

            ctrl.Add(row);
            bindingNavigator.BindingSource.MoveLast();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa phiếu thanh toán này không?",
                "Phieu Thanh Toan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Focus();
            bindingNavigator.BindingSource.MoveNext();
            ctrl.Save();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolIn_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            if (row == null) return;

            PhieuThanhToanController ctrlTT = new PhieuThanhToanController();
            string ma_phieu = row[COL_ID].ToString();
            var ph = ctrlTT.LayPhieuThanhToan(ma_phieu);

            frmInPhieuThanhToan phieuThanhToanForm = new frmInPhieuThanhToan(ph);
            phieuThanhToanForm.Show();
        }

        private void toolTimKiem_Click(object sender, EventArgs e)
        {
            frmTimPhieuThu timPhieuThuForm = new frmTimPhieuThu();
            Point p = PointToScreen(toolTimKiem.Bounds.Location);
            p.X += toolTimKiem.Width;
            p.Y += toolTimKiem.Height;
            timPhieuThuForm.Location = p;

            timPhieuThuForm.ShowDialog();

            if (timPhieuThuForm.DialogResult == DialogResult.OK)
            {
                // Truyền trực tiếp 2 tham số rời
                ctrl.TimPhieuThanhToan(
                    bindingNavigator,
                    dataGridView,
                    cmbKhachHang,
                    txtMaPhieu,
                    dtNgayThanhToan,
                    numTongTien,
                    txtGhiChu,
                    timPhieuThuForm.cmbKhachHang.SelectedValue?.ToString(),
                    timPhieuThuForm.dtNgayThu.Value.Date
                );
            }
        }
        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show(
                "Bạn chắc chắn xóa phiếu thanh toán này không?",
                "Phieu Thanh Toan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) == DialogResult.No)
            {
                e.Cancel = true; // Hủy xóa
            }
        }

        public class TimPhieuThanhToanParams
        {
            public string KhachHangID { get; set; }
            public DateTime NgayThu { get; set; }
        }

    }
}
