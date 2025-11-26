using CuahangNongduoc.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Template_Pattern
{
    public class BanHangFIFO : BanHangTemplate
    {
        private Dictionary<string, decimal> soLuongLo = new Dictionary<string, decimal>();

        public BanHangFIFO(IFormBanHang form) : base(form) { }


        protected override List<XuatLoDTO> ChonDanhSachLo(string idSP, decimal soLuong)
        {
            if (Form == null)
                throw new Exception("Form NULL");

            if (Form.CtrlMaSanPham == null)
                throw new Exception("CtrlMaSanPham NULL");

            if (idSP == null)
                throw new Exception("idSP NULL");
            var dsLo = Form.CtrlMaSanPham.LayDanhSachMaSanPham(idSP);
            List<XuatLoDTO> result = new List<XuatLoDTO>();

            decimal canXuat = soLuong;

            foreach (var lo in dsLo)
            {
                if (canXuat <= 0) break;

                if (!soLuongLo.ContainsKey(lo.Id))
                    soLuongLo[lo.Id] = lo.SoLuong;

                decimal ton = soLuongLo[lo.Id];
                decimal slXuat = Math.Min(ton, canXuat);

                if (slXuat > 0)
                {
                    result.Add(new XuatLoDTO()
                    {
                        Lo = lo,
                        SoLuongXuat = slXuat,
                        DonGia = lo.SanPham.GiaBinhQuan
                    });

                    soLuongLo[lo.Id] -= slXuat;
                    canXuat -= slXuat;
                }
            }

            return result;
        }
    }
}
