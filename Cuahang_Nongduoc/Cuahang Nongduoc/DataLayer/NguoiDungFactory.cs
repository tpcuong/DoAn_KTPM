using System;
using System.Data;
using System.Data.SqlClient;

namespace CuahangNongduoc.DataLayer
{
    public class NguoiDungFactory
    {
        private DataService m_Ds = new DataService();
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;

        public DataTable DanhSachNguoiDung()
        {
            DataService.OpenConnection();

            string sql = "SELECT * FROM NGUOI_DUNG";
            adapter = new SqlDataAdapter(sql, DataService.m_ConnectString);
            builder = new SqlCommandBuilder(adapter);

            m_Ds.Clear();
            adapter.Fill(m_Ds);
            return m_Ds;
        }

        public DataRow NewRow()
        {
            return m_Ds.NewRow();
        }

        public void Add(DataRow row)
        {
            m_Ds.Rows.Add(row);
        }

        public DataTable LayNguoiDungTheoTenDangNhap(string tenDangNhap)
        {
            DataService.OpenConnection();

            string sql = "SELECT * FROM NGUOI_DUNG WHERE TEN_DANG_NHAP = @TenDangNhap";
            adapter = new SqlDataAdapter(sql, DataService.m_ConnectString);
            adapter.SelectCommand.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            builder = new SqlCommandBuilder(adapter);

            m_Ds.Clear();
            adapter.Fill(m_Ds);
            return m_Ds;
        }

        public bool Save()
        {
            if (adapter == null) return false;
            try
            {
                adapter.Update(m_Ds);
                m_Ds.AcceptChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
