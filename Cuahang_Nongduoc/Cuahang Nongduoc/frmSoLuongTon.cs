<<<<<<< HEAD
using CuahangNongduoc.BusinessObject;
using Microsoft.Reporting.WinForms;
=======
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
<<<<<<< HEAD
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.Dataset;
using System.IO;
=======
using System.Text;
using System.Windows.Forms;

>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
namespace CuahangNongduoc
{
    public partial class frmSoLuongTon : Form
    {
<<<<<<< HEAD
        CHNDDataSet.SoLuongTonDataTable soLuongTonDataTable = new CHNDDataSet.SoLuongTonDataTable();
        string reportFolder = Application.StartupPath.Replace("\\bin\\Debug", "\\Report");
=======
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        public frmSoLuongTon()
        {
            InitializeComponent();
        }

        private void frmSoLuongTon_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
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

=======
            IList<CuahangNongduoc.BusinessObject.SoLuongTon> data = CuahangNongduoc.Controller.SanPhamController.LaySoLuongTon();
            this.SoLuongTonBindingSource.DataSource = data;
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            this.reportViewer.RefreshReport();
        }
    }
}