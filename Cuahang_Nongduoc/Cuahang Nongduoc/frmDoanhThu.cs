using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Controller;
using CuahangNongduoc.DataSet;
using Microsoft.Reporting.WinForms;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static CuahangNongduoc.DataSet.CHNDDataSet;

namespace CuahangNongduoc
{
    public partial class frmDoanhThu : Form
    {
        CHNDDataSet.DoanhThuDataTable doanhThuDataTable = new CHNDDataSet.DoanhThuDataTable();
        string reportFolder = Application.StartupPath.Replace("\\bin\\Debug", "\\Report");
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            cmbThang.SelectedIndex = DateTime.Now.Month - 1;
            numNam.Value = DateTime.Now.Year;
        }

        private void btnXemThang_Click(object sender, EventArgs e)
        {
            string thang = (cmbThang.SelectedIndex + 1).ToString();
            string nam = numNam.Value.ToString();

            PhieuBanController ctrlPB = new PhieuBanController();
            var data = ctrlPB.LayDoanhThuTheoThang(cmbThang.SelectedIndex + 1, ((int)numNam.Value));
            
            
            doanhThuDataTable.Clear();
            doanhThuDataTable.AddDoanhThuRow(data.TongDoanhThu,
                    data.TongGiamGia,
                    data.TongDichVu,
                    data.TongTienNhap,
                    data.TongTienChi,
                    data.TongThuKH,
                    data.LoiNhuan,
                    data.TongDoanhThu-data.TongThuKH
                   );
           
            SetUpReport("tháng "+thang+"/"+nam);
        }

        private void btnXemNgay_Click(object sender, EventArgs e)
        {
            PhieuBanController ctrlPB = new PhieuBanController();
            var data = ctrlPB.LayDoanhThuTheoNgay(dtpNgay.Value);
            if (data == null)
            {
                MessageBox.Show("Không có dữ liệu doanh thu cho thời gian này!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                doanhThuDataTable.Clear();
                doanhThuDataTable.AddDoanhThuRow(data.TongDoanhThu,
                        data.TongGiamGia,
                        data.TongDichVu,
                        data.TongTienNhap,
                        data.TongTienChi,
                        data.TongThuKH,
                        data.LoiNhuan,
                        data.TongDoanhThu - data.TongThuKH
                       );

                SetUpReport(dtpNgay.Value.ToString("dd/MM/yyyy"));
            }
        }

        public void SetUpReport(string thoigian) 
        {
            reportViewer.Reset();
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            CuahangNongduoc.BusinessObject.CuaHang ch = ThamSo.LayCuaHang();

            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("thoi_gian", "Thời gian: " + thoigian));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_cua_hang", "Tên cửa hàng: " + ch.TenCuaHang));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dia_chi", "Địa chỉ: " + ch.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dien_thoai", "Điện thoại: " + ch.DienThoai));

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DoanhThu";
            reportDataSource.Value = doanhThuDataTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportFolder, "rptDoanhThu.rdlc");

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            this.reportViewer.LocalReport.SetParameters(param);
            this.reportViewer.RefreshReport();
        }

        private void btnXemNam_Click(object sender, EventArgs e)
        {
            reportViewer.Reset();
            string nam = numNam.Value.ToString();

            PhieuBanController ctrlPB = new PhieuBanController();
            var data = ctrlPB.LayDoanhThuTheoNam(((int)numNam.Value)).ToList();

            doanhThuDataTable.Clear();
            foreach (var row in data)
            {
                doanhThuDataTable.AddDoanhThuRow(row.TongDoanhThu,
                        row.TongGiamGia,
                        row.TongDichVu,
                        row.TongTienNhap,
                        row.TongTienChi,
                        row.TongThuKH,
                        row.LoiNhuan,
                        row.TongDoanhThu - row.TongThuKH
                       );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsDoanhThu";
            reportDataSource.Value = doanhThuDataTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportFolder, "rptDoanhThuTheoNam.rdlc");

            ReportParameter reportParameter = new ReportParameter("thoi_gian", "Thời gian: năm " + numNam.Value);
            reportViewer.LocalReport.SetParameters(reportParameter);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            
            this.reportViewer.RefreshReport();
        }
    }
}