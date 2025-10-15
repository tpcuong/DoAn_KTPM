using CuahangNongduoc.BusinessObject;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.Dataset;
using System.IO;
namespace CuahangNongduoc
{
    public partial class frmSoLuongTon : Form
    {
        CHNDDataSet.SoLuongTonDataTable soLuongTonDataTable = new CHNDDataSet.SoLuongTonDataTable();
        string reportFolder = Application.StartupPath.Replace("\\bin\\Debug", "\\Report");
        public frmSoLuongTon()
        {
            InitializeComponent();
        }

        private void frmSoLuongTon_Load(object sender, EventArgs e)
        {
            var data = CuahangNongduoc.Controller.SanPhamController.LaySoLuongTon()
                .Select(r => new
                {
                    MaSanPham = r.SanPham.Id,
                    TenSanPham = r.SanPham.TenSanPham,
                    DonGiaNhap = r.SanPham.DonGiaNhap,
                    GiaBanLe = r.SanPham.GiaBanLe,
                    GiaBanSi = r.SanPham.GiaBanSi,
                    DonViTinh = r.SanPham.DonViTinh.Ten,
                    SoLuong = r.SoLuong
                }).ToList();

            soLuongTonDataTable.Clear();
            foreach (var row in data)
            {
                soLuongTonDataTable.AddSoLuongTonRow(row.MaSanPham,
                    row.TenSanPham,
                    row.DonGiaNhap,
                    row.GiaBanLe,
                    row.GiaBanSi,
                    row.DonViTinh,
                    row.SoLuong);
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsSoLuongTon";
            reportDataSource.Value = soLuongTonDataTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportFolder, "rptSoLuongTon.rdlc");

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;

            this.reportViewer.RefreshReport();
        }
    }
}