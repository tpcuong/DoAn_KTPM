using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CuahangNongduoc.DataLayer
{
    public class SanPhamFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachSanPham()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SAN_PHAM");
            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable TimMaSanPham(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SAN_PHAM WHERE ID LIKE '%' + @id + '%'");
            cmd.Parameters.Add("id", OleDbType.VarChar).Value = id;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable TimTenSanPham(String ten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SAN_PHAM WHERE TEN_SAN_PHAM LIKE '%' + @ten + '%'");
            cmd.Parameters.Add("ten", OleDbType.VarChar).Value = ten;
            m_Ds.Load(cmd);

            return m_Ds;
        }


        public DataTable LaySanPham(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SAN_PHAM WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LaySoLuongTon()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.ID, SP.TEN_SAN_PHAM, SP.DON_GIA_NHAP, SP.GIA_BAN_SI, SP.GIA_BAN_LE, SP.ID_DON_VI_TINH , SP.SO_LUONG , SUM(MA.SO_LUONG) AS SO_LUONG_TON "
                + " FROM SAN_PHAM SP INNER JOIN MA_SAN_PHAM MA ON SP.ID = MA.ID_SAN_PHAM "
                + " GROUP BY SP.ID, SP.TEN_SAN_PHAM, SP.DON_GIA_NHAP, SP.GIA_BAN_SI, SP.GIA_BAN_LE, SP.ID_DON_VI_TINH, SP.SO_LUONG");
            m_Ds.Load(cmd);
            return m_Ds;
        }

        // thêm
        public DataTable LaySoLuongTon(DateTime tuNgay, DateTime denNgay)
        {
            // iif(điều kiện, giá trị nếu đúng, giá trị nếu sai)
            string query = $@"
                SELECT 
                SP.ID, 
                SP.TEN_SAN_PHAM, 
                SP.ID_DON_VI_TINH,
                (
                    (SELECT IIF(ISNULL(SUM(MA.SO_LUONG)),0,SUM(MA.SO_LUONG))
                    FROM MA_SAN_PHAM AS MA
                    WHERE MA.ID_SAN_PHAM = SP.ID
                    AND MA.NGAY_NHAP < @tuNgay)
                    -
                    (SELECT IIF(ISNULL(SUM(CT.SO_LUONG)),0,SUM(CT.SO_LUONG))
                    FROM PHIEU_BAN AS PB
                    INNER JOIN CHI_TIET_PHIEU_BAN AS CT ON PB.ID = CT.ID_PHIEU_BAN
                    WHERE CT.ID_MA_SAN_PHAM = SP.ID
                    AND PB.NGAY_BAN < @tuNgay) 
                ) AS TON_DAU,

                (
                    SELECT IIF(ISNULL(SUM(MA.SO_LUONG)),0,SUM(MA.SO_LUONG))
                    FROM MA_SAN_PHAM AS MA
                    WHERE MA.ID_SAN_PHAM = SP.ID
                    AND MA.NGAY_NHAP BETWEEN @tuNgay AND @denNgay
                ) AS NHAP_TRONG_KY,

                (
                    SELECT IIF(ISNULL(SUM(CT.SO_LUONG)),0,SUM(CT.SO_LUONG))
                    FROM PHIEU_BAN AS PB
                    INNER JOIN CHI_TIET_PHIEU_BAN AS CT ON PB.ID = CT.ID_PHIEU_BAN
                    WHERE CT.ID_MA_SAN_PHAM = SP.ID
                    AND PB.NGAY_BAN BETWEEN @tuNgay AND @denNgay
                ) AS XUAT_TRONG_KY,

                (
                    (SELECT IIF(ISNULL(SUM(MA.SO_LUONG)),0,SUM(MA.SO_LUONG))
                    FROM MA_SAN_PHAM AS MA
                    WHERE MA.ID_SAN_PHAM = SP.ID
                    AND MA.NGAY_NHAP < @tuNgay)
                    -
                    (SELECT IIF(ISNULL(SUM(CT.SO_LUONG)),0,SUM(CT.SO_LUONG))
                    FROM PHIEU_BAN AS PB
                    INNER JOIN CHI_TIET_PHIEU_BAN AS CT ON PB.ID = CT.ID_PHIEU_BAN
                    WHERE CT.ID_MA_SAN_PHAM = SP.ID
                    AND PB.NGAY_BAN < @tuNgay)
                    +
                    (SELECT IIF(ISNULL(SUM(MA.SO_LUONG)),0,SUM(MA.SO_LUONG))
                    FROM MA_SAN_PHAM AS MA
                    WHERE MA.ID_SAN_PHAM = SP.ID
                    AND MA.NGAY_NHAP BETWEEN @tuNgay AND @denNgay)
                    -
                    (SELECT IIF(ISNULL(SUM(CT.SO_LUONG)),0,SUM(CT.SO_LUONG)) 
                    FROM PHIEU_BAN AS PB
                    INNER JOIN CHI_TIET_PHIEU_BAN AS CT ON PB.ID = CT.ID_PHIEU_BAN
                    WHERE CT.ID_MA_SAN_PHAM = SP.ID
                    AND PB.NGAY_BAN BETWEEN @tuNgay AND @denNgay)
                ) AS TON_CUOI

                FROM SAN_PHAM AS SP;";

            OleDbCommand cmd = new OleDbCommand(query);
            cmd.Parameters.AddWithValue("@tuNgay", tuNgay);
            cmd.Parameters.AddWithValue("@denNgay", denNgay);
            m_Ds.Load(cmd);
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
        public bool Save()
        {
            return m_Ds.ExecuteNoneQuery() > 0;
        }
    }
}
