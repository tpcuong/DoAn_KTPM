using CuahangNongduoc.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Template_Pattern
{
    public interface  IFormBanHang
    {
        DateTime NgayLapPhieu { get; }
        string MaPhieu { get; }

        ChiTietPhieuBanController CtrlChiTiet { get; }
        MaSanPhamController CtrlMaSanPham { get; }

        void XuLyDataGrid();
        void CapNhatTongTien();
        void SetNgayLapPhieu(DateTime dt);
    }
}
