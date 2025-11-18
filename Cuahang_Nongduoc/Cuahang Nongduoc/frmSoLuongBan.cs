using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CuahangNongduoc.Controller;

namespace CuahangNongduoc
{
    public partial class frmSoLuongBan : Form
    {
        private readonly ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();

        public frmSoLuongBan()
        {
            InitializeComponent();
        }

        private void frmSoLuongBan_Load(object sender, EventArgs e)
        {
            cmbThang.SelectedIndex = DateTime.Now.Month - 1;
            numNam.Value = DateTime.Now.Year;
        }

        // ================== NÚT XEM NGÀY ==================
        private void btnXemNgay_Click(object sender, EventArgs e)
        {
            DateTime ngay = dtNgay.Value.Date;

            var data = ctrl.ChiTietPhieuBan(ngay);
            if (data == null)
            {
                MessageBox.Show("Không có dữ liệu cho ngày này.");
                return;
            }

            SetReportParameter("ngay", $"Ngày {ngay:dd/MM/yyyy}");
            LoadReportData(data);
        }

        // ================== NÚT XEM THÁNG ==================
        private void btnXemThang_Click(object sender, EventArgs e)
        {
            int thang = cmbThang.SelectedIndex + 1;
            int nam = Convert.ToInt32(numNam.Value);

            var data = ctrl.ChiTietPhieuBan(thang, nam);
            if (data == null)
            {
                MessageBox.Show("Không có dữ liệu cho tháng/năm này.");
                return;
            }

            SetReportParameter("ngay", $"Tháng {thang}/{nam}");
            LoadReportData(data);
        }

        // ================== HÀM SET THAM SỐ REPORT ==================
        private void SetReportParameter(string name, string value)
        {
            ReportParameter[] param =
            {
                new ReportParameter(name, value)
            };

            reportViewer.LocalReport.SetParameters(param);
        }

        // ================== HÀM LOAD DỮ LIỆU CHO REPORT ==================
        private void LoadReportData(object data)
        {
            // Xóa datasource cũ để tránh lỗi trùng
            reportViewer.LocalReport.DataSources.Clear();

            // Gán datasource mới
            ChiTietPhieuBanBindingSource.DataSource = data;

            reportViewer.LocalReport.DataSources.Add(
                new ReportDataSource("ChiTietPhieuBan", ChiTietPhieuBanBindingSource)
            );

            reportViewer.RefreshReport();
        }
    }
}
