using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using CuahangNongduoc.DataLayer;

namespace CuahangNongduoc.BusinessLayer
{
    public class NguoiDungController
    {
        NguoiDungFactory m_NguoiDung = new NguoiDungFactory();

        public DataTable DanhSachNguoiDung()
        {
            return m_NguoiDung.DanhSachNguoiDung();
        }

        public DataTable LayNguoiDungTheoTenDangNhap(string tenDangNhap)
        {
            return m_NguoiDung.LayNguoiDungTheoTenDangNhap(tenDangNhap);
        }

        public bool ThemNguoiDung(string tenDangNhap, string matKhauHash, string tenNguoiDung, string vaiTro, string soDienThoai, string email, bool trangThai)
        {
            return m_NguoiDung.ThemNguoiDung(tenDangNhap, matKhauHash, tenNguoiDung, vaiTro, soDienThoai, email, trangThai);
        }

        public bool XoaNguoiDung(int userId)
        {
            return m_NguoiDung.XoaNguoiDung(userId);
        }

        public bool SuaNguoiDung(int id, string vaiTro, string tenDangNhap, string matKhauHash, string tenNguoiDung, string email, string soDienThoai, bool trangThai)
        {
            return m_NguoiDung.SuaNguoiDung(id, vaiTro, tenDangNhap, matKhauHash, tenNguoiDung, email, soDienThoai, trangThai);
        }

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau, out string vaiTro, out string tenNguoiDung)
        {
            vaiTro = "";
            tenNguoiDung = "";
            DataTable dt = m_NguoiDung.LayNguoiDungTheoTenDangNhap(tenDangNhap);
            if (dt.Rows.Count == 0) return false;
            if (!(bool)dt.Rows[0]["TRANG_THAI"]) return false;

            string hashMatKhau = dt.Rows[0]["MAT_KHAU_HASH"].ToString();
            string inputHash = HashSHA256(matKhau);

            if (string.Equals(hashMatKhau, inputHash, StringComparison.OrdinalIgnoreCase))
            {
                vaiTro = dt.Rows[0]["VAI_TRO"].ToString();
                tenNguoiDung = dt.Rows[0]["TEN_NGUOI_DUNG"].ToString();
                return true;
            }
            return false;
        }

        public void CapNhatTrangThai(string userId, bool trangThai)
        {
            NguoiDungFactory.CapNhatTrangThai(userId, trangThai);
        }

        public bool CapNhatMatKhau(int userId, string matKhauMoi)
        {
            string hash = HashSHA256(matKhauMoi);
            NguoiDungFactory.CapNhatMatKhau(userId, hash);
            return true;
        }

        public void CapNhatThongTin(string userId, string tenNguoiDung, string email, string soDienThoai)
        {
            NguoiDungFactory.CapNhatThongTin(userId, tenNguoiDung, email, soDienThoai);
        }


        private string HashSHA256(string text)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
