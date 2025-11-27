using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuahangNongduoc.Template_Pattern
{
    public abstract class BanHangTemplate
    {
        protected IFormBanHang Form;

        public BanHangTemplate(IFormBanHang form)
        {
            this.Form = form;
        }

        public void XuatHang(string idSP, decimal soLuong)
        {
            KiemTraNgay();
            var ds = ChonDanhSachLo(idSP, soLuong);
            TaoChiTiet(ds);

            // Gọi lại hàm của FORM
            Form.XuLyDataGrid();
            Form.CapNhatTongTien();
        }

        protected abstract List<XuatLoDTO> ChonDanhSachLo(string idSP, decimal soLuong);

        protected virtual void TaoChiTiet(List<XuatLoDTO> ds)
        {
            foreach (var item in ds)
            {
                DataRow row = Form.CtrlChiTiet.NewRow();
                row["ID_MA_SAN_PHAM"] = item.Lo.Id;
                row["ID_PHIEU_BAN"] = Form.MaPhieu; row["DON_GIA"] = item.DonGia;
                row["SO_LUONG"] = item.SoLuongXuat;
                row["THANH_TIEN"] = item.DonGia * item.SoLuongXuat;
                row["NGAY_HET_HAN"] = item.Lo.NgayHetHan;

                Form.CtrlChiTiet.Add(row);
            }
        }

        protected virtual void KiemTraNgay()
        {
            if (Form.NgayLapPhieu.Date != DateTime.Now.Date)
            {
                MessageBox.Show("Ngày lập phiếu bị sai!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Form.SetNgayLapPhieu(DateTime.Now);
            }
        }
    }
        
    
}
