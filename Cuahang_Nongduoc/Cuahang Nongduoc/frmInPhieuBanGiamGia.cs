using CuahangNongduoc.Controller;
using CuahangNongduoc.DataSet;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CuahangNongduoc.DataSet.CHNDDataSet;

namespace CuahangNongduoc
{
    public partial class frmInPhieuBanGiamGia : Form
    {
        CHNDDataSet.PhieuBanGiamGiaDataTable phieuBanGiamGiaTable = new CHNDDataSet.PhieuBanGiamGiaDataTable();
        string reportFolder = Application.StartupPath.Replace("\\bin\\Debug", "\\Report");
        public frmInPhieuBanGiamGia()
        {
            InitializeComponent();
        }

        private void frmInPhieuBanGiamGia_Load(object sender, EventArgs e)
        {

        }
        PhieuBanController ctrl = new PhieuBanController();
        private void btnXemNgay_Click(object sender, EventArgs e)
        {
            var data = ctrl.LayPhieuBan(dtpTuNgay.Value, dtpDenNgay.Value).Select(r => new
            {
                r.Id,
                KhachHang = r.KhachHang.HoTen,
                r.NgayBan,
                r.GiamGia,
                r.PhiDichVu,
                TongTienCuoi = r.TongTien + r.PhiDichVu - r.GiamGia,
                //r.ChiTiet,
                r.TongTien,
                r.DaTra,
                r.ConNo
            }).ToList();

            phieuBanGiamGiaTable.Clear();
            foreach (var row in data)
            {
                //phieuBanDataTable.AddPhieuBanRow(row.Id,
                //    row.KhachHang,
                //    row.NgayBan,
                //    row.TongTienCuoi,
                //    row.DaTra,
                //    row.ConNo,
                //    row.GiamGia,
                //    row.PhiDichVu,
                //    row.TongTien);
            }
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsPhieuBanGiamGia";
            reportDataSource.Value = phieuBanGiamGiaTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportFolder, "rptDsPhieuBanGiamGia.rdlc");

            ReportParameter reportParameter = new ReportParameter("ngay", "Từ ngày: " + dtpTuNgay.Text + " - Đến ngày: " + dtpDenNgay.Text);
            reportViewer.LocalReport.SetParameters(reportParameter);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }
    }
}
