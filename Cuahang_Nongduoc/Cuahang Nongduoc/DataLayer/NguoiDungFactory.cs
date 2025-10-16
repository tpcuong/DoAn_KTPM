using System;
using System.Data;
using System.Data.OleDb;

namespace CuahangNongduoc.DataLayer
{
    public class NguoiDungFactory
    {
        DataService m_Ds = new DataService();

        public void LoadSchema()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NGUOI_DUNG WHERE USER_ID = '-1'");
            m_Ds.Load(cmd);
        }

        public DataTable DanhSachNguoiDung()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NGUOI_DUNG");
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayNguoiDungTheoTenDangNhap(string tenDangNhap)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NGUOI_DUNG WHERE TEN_DANG_NHAP = @user");
            cmd.Parameters.Add("user", OleDbType.VarChar, 50).Value = tenDangNhap;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayNguoiDungTheoID(string userId)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NGUOI_DUNG WHERE USER_ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = userId;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public static void CapNhatTrangThai(string userId, bool trangThai)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("UPDATE NGUOI_DUNG SET TRANG_THAI = @tt WHERE USER_ID = @id");
            cmd.Parameters.Add("tt", OleDbType.Boolean).Value = trangThai;
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = userId;
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
