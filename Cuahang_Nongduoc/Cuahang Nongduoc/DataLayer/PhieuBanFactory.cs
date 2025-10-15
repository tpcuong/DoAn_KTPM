using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Text;
=======
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
using System.Data;
using System.Data.OleDb;

namespace CuahangNongduoc.DataLayer
{
    public class PhieuBanFactory
    {
<<<<<<< HEAD
        DataService m_Ds = new DataService();

        public DataTable TimPhieuBan(String idKh, DateTime dt)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_BAN WHERE NGAY_BAN = @ngay AND ID_KHACH_HANG=@kh");
            cmd.Parameters.Add("ngay", OleDbType.Date).Value = dt;
            cmd.Parameters.Add("kh", OleDbType.VarChar).Value = idKh;

            m_Ds.Load(cmd);

=======
        private readonly DataService m_Ds = new DataService();

        public DataTable TimPhieuBan(string idKh, DateTime dt)
        {
            OleDbCommand cmd = new OleDbCommand(
                "SELECT * FROM PHIEU_BAN WHERE NGAY_BAN = @ngay AND ID_KHACH_HANG = @kh");
            cmd.Parameters.Add("ngay", OleDbType.Date).Value = dt;
            cmd.Parameters.Add("kh", OleDbType.VarChar, 50).Value = idKh;

            m_Ds.Load(cmd);
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            return m_Ds;
        }

        public DataTable DanhsachPhieuBanLe()
        {
<<<<<<< HEAD
            OleDbCommand cmd = new OleDbCommand("SELECT PB.* FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=FALSE");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuBanSi()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.* FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=TRUE");
            m_Ds.Load(cmd);

            return m_Ds;
        }


        public DataTable LayPhieuBan(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_BAN WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
=======
            OleDbCommand cmd = new OleDbCommand(
                @"SELECT PB.* 
                  FROM PHIEU_BAN PB 
                  INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG = KH.ID 
                  WHERE KH.LOAI_KH = FALSE");
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable DanhsachPhieuBanSi()
        {
            OleDbCommand cmd = new OleDbCommand(
                @"SELECT PB.* 
                  FROM PHIEU_BAN PB 
                  INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG = KH.ID 
                  WHERE KH.LOAI_KH = TRUE");
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayPhieuBan(string id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_BAN WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            m_Ds.Load(cmd);
            return m_Ds;
        }

<<<<<<< HEAD

        public DataTable LayChiTietPhieuBan(String idPhieuBan)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_BAN WHERE ID_PHIEU_BAN = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = idPhieuBan;
=======
        public DataTable LayChiTietPhieuBan(string idPhieuBan)
        {
            OleDbCommand cmd = new OleDbCommand(
                "SELECT * FROM CHI_TIET_PHIEU_BAN WHERE ID_PHIEU_BAN = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = idPhieuBan;
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            m_Ds.Load(cmd);
            return m_Ds;
        }

<<<<<<< HEAD
        public static long LayConNo(String kh, int thang, int nam)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(CON_NO) FROM PHIEU_BAN WHERE ID_KHACH_HANG = @kh AND MONTH(NGAY_BAN)=@thang AND YEAR(NGAY_BAN)= @nam");
=======
        public static long LayConNo(string kh, int thang, int nam)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand(
                @"SELECT SUM(CON_NO) 
                  FROM PHIEU_BAN 
                  WHERE ID_KHACH_HANG = @kh 
                        AND MONTH(NGAY_BAN) = @thang 
                        AND YEAR(NGAY_BAN) = @nam");
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            cmd.Parameters.Add("kh", OleDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("thang", OleDbType.Integer).Value = thang;
            cmd.Parameters.Add("nam", OleDbType.Integer).Value = nam;

            object obj = ds.ExecuteScalar(cmd);
<<<<<<< HEAD
            if (obj == null)
                return 0;
            else
                return Convert.ToInt64(obj);
=======
            if (obj == null || obj == DBNull.Value)
                return 0;
            return Convert.ToInt64(obj);
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        }

        public static int LaySoPhieu()
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM PHIEU_BAN");
<<<<<<< HEAD
            
            object obj = ds.ExecuteScalar(cmd);
            if (obj == null)
                return 0;
            else
                return Convert.ToInt32(obj);
        }
        
=======

            object obj = ds.ExecuteScalar(cmd);
            if (obj == null || obj == DBNull.Value)
                return 0;
            return Convert.ToInt32(obj);
        }
        public bool InsertPhieuBan(string id, string idKhachHang, DateTime ngayBan,
            long tongTien, long daTra, long conNo, long phiDichVu, long giamGia)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand(
                @"INSERT INTO PHIEU_BAN 
                    (ID, ID_KHACH_HANG, NGAY_BAN, TONG_TIEN, DA_TRA, CON_NO, PHI_DICH_VU, GIAM_GIA)
                  VALUES 
                    (@id, @idKhachHang, @ngayBan, @tongTien, @daTra, @conNo, @phiDichVu, @giamGia)");

            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
            cmd.Parameters.Add("idKhachHang", OleDbType.VarChar, 50).Value = idKhachHang;
            cmd.Parameters.Add("ngayBan", OleDbType.Date).Value = ngayBan;
            cmd.Parameters.Add("tongTien", OleDbType.BigInt).Value = tongTien;
            cmd.Parameters.Add("daTra", OleDbType.BigInt).Value = daTra;
            cmd.Parameters.Add("conNo", OleDbType.BigInt).Value = conNo;
            cmd.Parameters.Add("phiDichVu", OleDbType.BigInt).Value = phiDichVu;
            cmd.Parameters.Add("giamGia", OleDbType.BigInt).Value = giamGia;

            return ds.ExecuteNoneQuery(cmd) > 0;
        }

        public bool UpdatePhieuBan(string id, long tongTien, long daTra,
            long conNo, long phiDichVu, long giamGia)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand(
                @"UPDATE PHIEU_BAN 
                  SET TONG_TIEN = @tongTien, 
                      DA_TRA = @daTra, 
                      CON_NO = @conNo, 
                      PHI_DICH_VU = @phiDichVu, 
                      GIAM_GIA = @giamGia
                  WHERE ID = @id");

            cmd.Parameters.Add("tongTien", OleDbType.BigInt).Value = tongTien;
            cmd.Parameters.Add("daTra", OleDbType.BigInt).Value = daTra;
            cmd.Parameters.Add("conNo", OleDbType.BigInt).Value = conNo;
            cmd.Parameters.Add("phiDichVu", OleDbType.BigInt).Value = phiDichVu;
            cmd.Parameters.Add("giamGia", OleDbType.BigInt).Value = giamGia;
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;

            return ds.ExecuteNoneQuery(cmd) > 0;
        }

        public bool DeletePhieuBan(string id)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM PHIEU_BAN WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
            return ds.ExecuteNoneQuery(cmd) > 0;
        }

>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        public DataRow NewRow()
        {
            return m_Ds.NewRow();
        }
<<<<<<< HEAD
=======

>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        public void Add(DataRow row)
        {
            m_Ds.Rows.Add(row);
        }
<<<<<<< HEAD
       public bool Save()
        {
           
=======

        public bool Save()
        {
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            return m_Ds.ExecuteNoneQuery() > 0;
        }
    }
}
