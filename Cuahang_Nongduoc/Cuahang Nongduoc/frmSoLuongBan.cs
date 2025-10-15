<<<<<<< HEAD
using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Controller;
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
=======
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Controller;
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8

namespace CuahangNongduoc
{
    public partial class frmSoLuongBan : Form
    {
        public frmSoLuongBan()
        {
            InitializeComponent();
<<<<<<< HEAD
            //reportViewer.LocalReport.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence);
=======
            reportViewer.LocalReport.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence);
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        }

        private void frmSoLuongBan_Load(object sender, EventArgs e)
        {
            cmbThang.SelectedIndex = DateTime.Now.Month - 1;
            numNam.Value = DateTime.Now.Year;
        }

        ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();

<<<<<<< HEAD

=======
        
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        private void btnXemNgay_Click(object sender, EventArgs e)
        {
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ngay", "Ngày " + dtNgay.Value.Date.ToString("dd/MM/yyyy")));

            this.reportViewer.LocalReport.SetParameters(param);

<<<<<<< HEAD
            var data = ctrl.ChiTietPhieuBan(dtNgay.Value.Date)
                .Select(r => new
                {
                    MaSanPham = r.MaSanPham.Id,
                    r.DonGia,
                    r.SoLuong,
                    r.ThanhTien
                }); ;
            this.ChiTietPhieuBanBindingSource.DataSource = data;

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
=======
            this.ChiTietPhieuBanBindingSource.DataSource = ctrl.ChiTietPhieuBan(dtNgay.Value.Date);
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            this.reportViewer.RefreshReport();
        }

        private void btnXemThang_Click(object sender, EventArgs e)
        {
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ngay",
                "Tháng " + Convert.ToString(cmbThang.SelectedIndex + 1) + "/" + numNam.Value.ToString()));

            this.reportViewer.LocalReport.SetParameters(param);

<<<<<<< HEAD
            var data = ctrl.ChiTietPhieuBan(cmbThang.SelectedIndex + 1, Convert.ToInt32(numNam.Value))
                .Select(r => new
                {
                    MaSanPham = r.MaSanPham.Id,
                    r.DonGia,
                    r.SoLuong,
                    r.ThanhTien
                });
            this.ChiTietPhieuBanBindingSource.DataSource = data;

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }


=======

            this.ChiTietPhieuBanBindingSource.DataSource = ctrl.ChiTietPhieuBan(cmbThang.SelectedIndex + 1, Convert.ToInt32(numNam.Value));
            this.reportViewer.RefreshReport();
        }

      
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
    }
}