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
using System.Text;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmInPhieuThanhToan : Form
    {
        CuahangNongduoc.BusinessObject.PhieuThanhToan m_PhieuThanhToan;
        public frmInPhieuThanhToan(CuahangNongduoc.BusinessObject.PhieuThanhToan ph)
        {
            InitializeComponent();
            m_PhieuThanhToan = ph;
        }

        private void frmPhieuThanhToan_Load(object sender, EventArgs e)
        {
            Num2Str num = new Num2Str();
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            CuahangNongduoc.BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_cua_hang", ch.TenCuaHang));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dia_chi", ch.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dien_thoai", ch.DienThoai));

            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("bang_chu", num.NumberToString(m_PhieuThanhToan.TongTien.ToString())));

<<<<<<< HEAD


            var data = new
            {
                m_PhieuThanhToan.Id,
                m_PhieuThanhToan.NgayThanhToan,
                m_PhieuThanhToan.TongTien,
                m_PhieuThanhToan.GhiChu,
                KhachHang = m_PhieuThanhToan.KhachHang.HoTen,
                DienThoai = m_PhieuThanhToan.KhachHang.DienThoai,
                DiaChi = m_PhieuThanhToan.KhachHang.DiaChi
            };

            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("DienThoai_KH", data.DienThoai));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("DiaChi_KH", data.DiaChi));

            this.reportViewer.LocalReport.SetParameters(param);
            this.PhieuThanhToanBindingSource.DataSource = data;

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
=======
            this.reportViewer.LocalReport.SetParameters(param);
            this.PhieuThanhToanBindingSource.DataSource = m_PhieuThanhToan; 
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            this.reportViewer.RefreshReport();
        }
    }
}