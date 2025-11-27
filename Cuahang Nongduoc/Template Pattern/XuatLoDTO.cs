using CuahangNongduoc.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuahangNongduoc.Template_Pattern
{
    public class XuatLoDTO
    {

        private String m_IdPhieuBan;
        public String IdPhieuBan
        {
            get { return m_IdPhieuBan; }
            set { m_IdPhieuBan = value; }
        }

        private MaSanPham m_Lo;
        public MaSanPham Lo
        {
            get { return m_Lo; }
            set { m_Lo = value; }
        }

        private Decimal m_SoLuongXuat;
        public Decimal SoLuongXuat
        {
            get { return m_SoLuongXuat; }
            set { m_SoLuongXuat = value; }
        }
        private Decimal m_DonGia;
        public Decimal DonGia
        {
            get { return m_DonGia; }
            set { m_DonGia = value; }
        }
    }
}
