using System;
using System.Data;
using System.Data.SqlClient;

namespace CuahangNongduoc.DataLayer
{
    public class NguoiDungFactory
    {
        private DataService m_Ds = new DataService();

        public DataTable DanhSachNguoiDung()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NGUOI_DUNG");
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayNguoiDungTheoTenDangNhap(string tenDangNhap)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NGUOI_DUNG WHERE TEN_DANG_NHAP = @user");
            cmd.Parameters.Add("user", SqlDbType.VarChar, 50).Value = tenDangNhap;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayNguoiDungTheoID(string userId)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NGUOI_DUNG WHERE USER_ID = @id");
            cmd.Parameters.Add("id", SqlDbType.VarChar, 50).Value = userId;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable TimKiemNguoiDung(string tuKhoa)
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT * FROM NGUOI_DUNG
                WHERE TEN_DANG_NHAP LIKE '%' + @tuKhoa + '%'
                   OR TEN_NGUOI_DUNG LIKE '%' + @tuKhoa + '%'
                   OR VAI_TRO LIKE '%' + @tuKhoa + '%'");
            cmd.Parameters.Add("tuKhoa", SqlDbType.NVarChar, 100).Value = tuKhoa;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayNguoiDungTheoTrangThai(bool trangThai)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NGUOI_DUNG WHERE TRANG_THAI = @tt");
            cmd.Parameters.Add("tt", SqlDbType.Bit).Value = trangThai;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public bool ThemNguoiDung(string tenDangNhap, string matKhauHash, string tenNguoiDung, string vaiTro, string email, string soDienThoai, bool trangThai)
        {
            DataService ds = new DataService();

            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM NGUOI_DUNG WHERE TEN_DANG_NHAP = @TenDangNhap");
            checkCmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 100).Value = tenDangNhap;
            int count = (int)ds.ExecuteScalar(checkCmd);
            if (count > 0)
            {
                return false; 
            }

            SqlCommand cmd = new SqlCommand(@"
INSERT INTO NGUOI_DUNG 
(TEN_DANG_NHAP, MAT_KHAU_HASH, VAI_TRO, TEN_NGUOI_DUNG, EMAIL, SO_DIEN_THOAI, TRANG_THAI)
VALUES 
(@TenDangNhap, @MatKhauHash, @VaiTro, @TenNguoiDung, @Email, @SoDienThoai, @TrangThai)");

            cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 100).Value = tenDangNhap;
            cmd.Parameters.Add("@MatKhauHash", SqlDbType.NVarChar, 100).Value = matKhauHash;
            cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 50).Value = vaiTro;
            cmd.Parameters.Add("@TenNguoiDung", SqlDbType.NVarChar, 100).Value = tenNguoiDung;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
            cmd.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar, 20).Value = soDienThoai;
            cmd.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThai;

            try
            {
                return ds.ExecuteNoneQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi khi thêm người dùng: {ex.Message}");
                return false;
            }
        }


        public bool XoaNguoiDung(int userId)
        {
            DataService ds = new DataService();
            SqlCommand cmd = new SqlCommand("DELETE FROM NGUOI_DUNG WHERE ID = @id");
            cmd.Parameters.Add("id", SqlDbType.Int, 50).Value = userId;
            return ds.ExecuteNoneQuery(cmd) > 0;
        }

        public bool SuaNguoiDung(int id, string vaiTro, string tenDangNhap, string matKhauHash, string tenNguoiDung, string email, string soDienThoai, bool trangThai)
        {
            DataService ds = new DataService();
            SqlCommand cmd = new SqlCommand(@"
        UPDATE NGUOI_DUNG
        SET TEN_DANG_NHAP = @TenDangNhap,
            MAT_KHAU_HASH = @MatKhauHash,
            VAI_TRO = @VaiTro,
            TEN_NGUOI_DUNG = @TenNguoiDung,
            EMAIL = @Email,
            SO_DIEN_THOAI = @SoDienThoai,
            TRANG_THAI = @TrangThai
            
        WHERE ID = @ID");

            cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 100).Value = tenDangNhap;
            cmd.Parameters.Add("@MatKhauHash", SqlDbType.NVarChar, 100).Value = matKhauHash;
            cmd.Parameters.Add("@VaiTro", SqlDbType.NVarChar, 50).Value = vaiTro;
            cmd.Parameters.Add("@TenNguoiDung", SqlDbType.NVarChar, 100).Value = tenNguoiDung;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
            cmd.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar, 20).Value = soDienThoai;
            cmd.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThai;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

            return ds.ExecuteNoneQuery(cmd) > 0;
        }

        public static void CapNhatTrangThai(string userId, bool trangThai)
        {
            DataService ds = new DataService();
            SqlCommand cmd = new SqlCommand("UPDATE NGUOI_DUNG SET TRANG_THAI = @tt WHERE USER_ID = @id");
            cmd.Parameters.Add("tt", SqlDbType.Bit).Value = trangThai;
            cmd.Parameters.Add("id", SqlDbType.VarChar, 50).Value = userId;
            ds.ExecuteNoneQuery(cmd);
        }

        public static void CapNhatMatKhau(int userId, string matKhauHash)
        {
            DataService ds = new DataService();
            SqlCommand cmd = new SqlCommand("UPDATE NGUOI_DUNG SET MAT_KHAU_HASH = @mk WHERE USER_ID = @id");
            cmd.Parameters.Add("mk", SqlDbType.VarChar, 255).Value = matKhauHash;
            cmd.Parameters.Add("id", SqlDbType.Int).Value = userId;
            ds.ExecuteNoneQuery(cmd);
        }

        public static void CapNhatThongTin(string userId, string tenNguoiDung, string email, string soDienThoai)
        {
            DataService ds = new DataService();
            SqlCommand cmd = new SqlCommand(@"
                UPDATE NGUOI_DUNG
                SET TEN_NGUOI_DUNG = @ten, EMAIL = @email, SO_DIEN_THOAI = @sdt
                WHERE USER_ID = @id");
            cmd.Parameters.Add("ten", SqlDbType.NVarChar, 100).Value = tenNguoiDung;
            cmd.Parameters.Add("email", SqlDbType.VarChar, 100).Value = email;
            cmd.Parameters.Add("sdt", SqlDbType.VarChar, 20).Value = soDienThoai;
            cmd.Parameters.Add("id", SqlDbType.VarChar, 50).Value = userId;
            ds.ExecuteNoneQuery(cmd);
        }

        public DataRow NewRow()
        {
            return m_Ds.NewRow();
        }

        public void Add(DataRow row)
        {
            m_Ds.Rows.Add(row);
        }

        public bool Save()
        {
            return m_Ds.ExecuteNoneQuery() > 0;
        }
    }
}
