<<<<<<< HEAD
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
=======
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
using System.Text;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmInPhieuBan : Form
    {
        CuahangNongduoc.BusinessObject.PhieuBan m_PhieuBan;
        public frmInPhieuBan(CuahangNongduoc.BusinessObject.PhieuBan ph)
        {
            InitializeComponent();
<<<<<<< HEAD
            //reportViewer.LocalReport.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence);
=======
            reportViewer.LocalReport.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence);
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            this.reportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            m_PhieuBan = ph;
        }

        void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
<<<<<<< HEAD
            //e.DataSources.Clear();
            //e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CuahangNongduoc_BusinessObject_ChiTietPhieuBan", m_PhieuBan.ChiTiet));
            var chiTietPB = m_PhieuBan.ChiTiet.Select(r => new
            {
                MaSanPham = r.MaSanPham.SanPham.TenSanPham,
                r.SoLuong,
                r.DonGia,
                r.ThanhTien
            }).ToList();

            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CuahangNongduoc_BusinessObject_ChiTietPhieuBan", chiTietPB));
=======
            e.DataSources.Clear();
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CuahangNongduoc_BusinessObject_ChiTietPhieuBan", m_PhieuBan.ChiTiet));
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        }

        private void frmInPhieuBan_Load(object sender, EventArgs e)
        {
            Num2Str num = new Num2Str();
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            CuahangNongduoc.BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_cua_hang", ch.TenCuaHang));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dia_chi", ch.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dien_thoai", ch.DienThoai));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("bang_chu", num.NumberToString(m_PhieuBan.TongTien.ToString())));

<<<<<<< HEAD
            //ma, khach, dchi, dt, ngayban, tt, da tra, con no

            var data = new
            {
                Id = m_PhieuBan.Id,
                KhachHang = m_PhieuBan.KhachHang.HoTen,
                DiaChi = m_PhieuBan.KhachHang.DiaChi,
                DienThoai = m_PhieuBan.KhachHang.DienThoai,
                NgayBan = m_PhieuBan.NgayBan,
                TongTien = m_PhieuBan.TongTien,
                DaTra = m_PhieuBan.DaTra,
                ConNo = m_PhieuBan.ConNo
            };
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("DiaChi_KH", data.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("DienThoai_KH", data.DienThoai));

            this.reportViewer.LocalReport.SetParameters(param);
            this.PhieuBanBindingSource.DataSource = data;

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }

=======
            this.reportViewer.LocalReport.SetParameters(param);
            this.PhieuBanBindingSource.DataSource = m_PhieuBan;
            this.reportViewer.RefreshReport();
        }
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
    }
}