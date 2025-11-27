using System;
using System.Collections.Generic;
using System.Text;
using CuahangNongduoc.DataLayer;
using CuahangNongduoc.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace CuahangNongduoc.Controller
{

    public class PhieuBanController
    {
        PhieuBanFactory factory = new PhieuBanFactory();

        BindingSource bs = new BindingSource();


        public PhieuBanController()
        {

            bs.DataSource = factory.LayPhieuBan("-1");
        }

        //public DataRow NewRow()
        //{
        //    return factory.NewRow(); 
        //}
        //public void Add(DataRow row)
        //{
        //    factory.Add(row);
        //}
        //public void Update()
        //{
        //    bs.MoveNext();
        //    factory.Save();
        //}
        //public void Save()
        //{
        //    // ... (Toàn bộ logic "Bản dùng thử" đã bị xóa) ...
        //}



        public bool LuuPhieuBanMoi(DataRow row)
        {
            return factory.InsertPhieuBan(row);
        }

        public bool CapNhatPhieuBan(DataRow row)
        {
            return factory.UpdatePhieuBan(row);
        }


        public void HienthiPhieuBanLe(BindingNavigator bn, DataGridView dg)
        {
            
            bs.DataSource = factory.DanhsachPhieuBanLe();
            bn.BindingSource = bs;
            dg.DataSource = bs;
        }

        public void HienthiPhieuBanSi(BindingNavigator bn, DataGridView dg)
        {
           
            bs.DataSource = factory.DanhsachPhieuBanSi();
            bn.BindingSource = bs;
            dg.DataSource = bs;
        }

        public void HienthiPhieuBan(BindingNavigator bn,ComboBox cmbNV, ComboBox cmbKhachHang, TextBox txtID,
            DateTimePicker dtNgayBan, ComboBox cmbDichVu, NumericUpDown numPhiDichVu,
            NumericUpDown numPhiVanChuyen, NumericUpDown numGiamGia, NumericUpDown numTongTien,
            NumericUpDown numDatra, NumericUpDown numConNo)
        {

            bn.BindingSource = bs;

            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", bs, "ID");

            cmbNV.DataBindings.Clear();
            cmbNV.DataBindings.Add("SelectedValue", bs, "ID_NGUOI_DUNG");

            cmbKhachHang.DataBindings.Clear();
            cmbKhachHang.DataBindings.Add("SelectedValue", bs, "ID_KHACH_HANG");

            dtNgayBan.DataBindings.Clear();
            dtNgayBan.DataBindings.Add("Value", bs, "NGAY_BAN");

            // Thêm binding cho ComboBox Dịch Vụ
            cmbDichVu.DataBindings.Clear();
            cmbDichVu.DataBindings.Add("SelectedValue", bs, "ID_DICH_VU");

            // Thêm binding cho Phí Dịch Vụ
            numPhiDichVu.DataBindings.Clear();
            numPhiDichVu.DataBindings.Add("Value", bs, "PHI_DICH_VU");

            // Thêm binding cho Phí Vận Chuyển
            numPhiVanChuyen.DataBindings.Clear();
            numPhiVanChuyen.DataBindings.Add("Value", bs, "PHI_VAN_CHUYEN");

            // Thêm binding cho Giảm Giá
            numGiamGia.DataBindings.Clear();
            numGiamGia.DataBindings.Add("Value", bs, "GIAM_GIA");

            numTongTien.DataBindings.Clear();
            numTongTien.DataBindings.Add("Value", bs, "TONG_TIEN");

            numDatra.DataBindings.Clear();
            numDatra.DataBindings.Add("Value", bs, "DA_TRA");

            numConNo.DataBindings.Clear();
            numConNo.DataBindings.Add("Value", bs, "CON_NO");
        }

        public PhieuBan LayPhieuBan(DateTime value, String id)
        {
            DataTable tbl = factory.LayPhieuBan(id);
            PhieuBan ph = null;
            if (tbl.Rows.Count > 0)
            {

                DataRow row = tbl.Rows[0];
                ph = new PhieuBan();
                ph.Id = row["ID"].ToString();

                ph.NgayBan = row["NGAY_BAN"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["NGAY_BAN"]);
                ph.TongTien = row["TONG_TIEN"] == DBNull.Value ? 0 : Convert.ToInt64(row["TONG_TIEN"]);
                ph.DaTra = row["DA_TRA"] == DBNull.Value ? 0 : Convert.ToInt64(row["DA_TRA"]);
                ph.ConNo = row["CON_NO"] == DBNull.Value ? 0 : Convert.ToInt64(row["CON_NO"]);

                ph.GiamGia = row["GIAM_GIA"] == DBNull.Value ? 0 : Convert.ToInt64(row["GIAM_GIA"]);
                ph.PhiDichVu = row["PHI_DICH_VU"] == DBNull.Value ? 0 : Convert.ToInt64(row["PHI_DICH_VU"]);
                ph.PhiVanChuyen = row["PHI_VAN_CHUYEN"] == DBNull.Value ? 0 : Convert.ToInt64(row["PHI_VAN_CHUYEN"]);
                ph.IdDichVu = row["ID_DICH_VU"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_DICH_VU"]);


                KhachHangController ctrlKH = new KhachHangController();
                ph.KhachHang = ctrlKH.LayKhachHang(row["ID_KHACH_HANG"].ToString());
                ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                ph.ChiTiet = ctrl.ChiTietPhieuBan(ph.Id);
                NguoiDungController ctrlND = new NguoiDungController();
                ph.NgDung = ctrlND.LayTenNguoiDung(row["ID_NGUOI_DUNG"].ToString());
            }
            return ph;
        }

        public void TimPhieuBan(String maKH, DateTime dt)
        {

            bs.DataSource = factory.TimPhieuBan(maKH, dt);
        }
        //thêm
        public List<PhieuBan> LayPhieuBan(DateTime tuNgay, DateTime denNgay)
        {
            DataTable tbl = factory.LayBaoCaoPhieuBanTheoNgay(tuNgay, denNgay);
            List<PhieuBan> danhSach = new List<PhieuBan>();

            KhachHangController ctrlKH = new KhachHangController();
            ChiTietPhieuBanController ctrlCT = new ChiTietPhieuBanController();
            NguoiDungController ctrlND = new NguoiDungController();
            foreach (DataRow row in tbl.Rows)
            {
                PhieuBan ph = new PhieuBan();
                ph.Id = row["ID"].ToString();

                ph.NgayBan = row["NGAY_BAN"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["NGAY_BAN"]);
                ph.TongTien = row["TONG_TIEN"] == DBNull.Value ? 0 : Convert.ToInt64(row["TONG_TIEN"]);
                ph.DaTra = row["DA_TRA"] == DBNull.Value ? 0 : Convert.ToInt64(row["DA_TRA"]);
                ph.ConNo = row["CON_NO"] == DBNull.Value ? 0 : Convert.ToInt64(row["CON_NO"]);
                ph.GiamGia = row["GIAM_GIA"] == DBNull.Value ? 0 : Convert.ToInt64(row["GIAM_GIA"]);
                ph.PhiDichVu = row["PHI_DICH_VU"] == DBNull.Value ? 0 : Convert.ToInt64(row["PHI_DICH_VU"]);
                ph.PhiVanChuyen = row["PHI_VAN_CHUYEN"] == DBNull.Value ? 0 : Convert.ToInt64(row["PHI_VAN_CHUYEN"]);
                ph.IdDichVu = row["ID_DICH_VU"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_DICH_VU"]);
                ph.NgDung = ctrlND.LayTenNguoiDung(row["ID_NGUOI_DUNG"].ToString());
                ph.KhachHang = ctrlKH.LayKhachHang(row["ID_KHACH_HANG"].ToString());
                ph.ChiTiet = ctrlCT.ChiTietPhieuBan(ph.Id);

                danhSach.Add(ph);
            }
            return danhSach;
        }

        public List<PhieuBan> LayPhieuBan(DateTime tuNgay, DateTime denNgay, string idNgDung)
        {
            DataTable tbl = factory.LayPhieuBanNguoiDungTheoNgay(tuNgay, denNgay, idNgDung);
            List<PhieuBan> danhSach = new List<PhieuBan>();

            KhachHangController ctrlKH = new KhachHangController();
            ChiTietPhieuBanController ctrlCT = new ChiTietPhieuBanController();
            NguoiDungController ctrlND = new NguoiDungController();
            foreach (DataRow row in tbl.Rows)
            {
                PhieuBan ph = new PhieuBan();
                ph.Id = row["ID"].ToString();

                ph.NgayBan = row["NGAY_BAN"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["NGAY_BAN"]);
                ph.TongTien = row["TONG_TIEN"] == DBNull.Value ? 0 : Convert.ToInt64(row["TONG_TIEN"]);
                ph.DaTra = row["DA_TRA"] == DBNull.Value ? 0 : Convert.ToInt64(row["DA_TRA"]);
                ph.ConNo = row["CON_NO"] == DBNull.Value ? 0 : Convert.ToInt64(row["CON_NO"]);
                ph.GiamGia = row["GIAM_GIA"] == DBNull.Value ? 0 : Convert.ToInt64(row["GIAM_GIA"]);
                ph.PhiDichVu = row["PHI_DICH_VU"] == DBNull.Value ? 0 : Convert.ToInt64(row["PHI_DICH_VU"]);
                ph.PhiVanChuyen = row["PHI_VAN_CHUYEN"] == DBNull.Value ? 0 : Convert.ToInt64(row["PHI_VAN_CHUYEN"]);
                ph.IdDichVu = row["ID_DICH_VU"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID_DICH_VU"]);
                ph.NgDung = ctrlND.LayTenNguoiDung(row["ID_NGUOI_DUNG"].ToString());
                ph.KhachHang = ctrlKH.LayKhachHang(row["ID_KHACH_HANG"].ToString());
                ph.ChiTiet = ctrlCT.ChiTietPhieuBan(ph.Id);

                danhSach.Add(ph);
            }
            return danhSach;
        }
        // thêm
        public DoanhThu LayDoanhThuTheoThang(int thang, int nam)
        {
            DataTable tbl = factory.LayDoanhThuTheoThang(thang, nam);
            DoanhThu dt = null;
            if(tbl.Rows.Count>0)
            {
                dt = new DoanhThu();
                dt.TongDoanhThu = Convert.ToInt32(tbl.Rows[0]["TONG_DOANH_THU"]);
                dt.TongGiamGia = Convert.ToInt32(tbl.Rows[0]["TONG_GIAM_GIA"]);
                dt.TongDichVu = Convert.ToInt32(tbl.Rows[0]["TONG_DICH_VU"]);
                dt.TongTienNhap = Convert.ToInt32(tbl.Rows[0]["TONG_TIEN_NHAP"]);
                dt.TongTienChi = Convert.ToInt32(tbl.Rows[0]["TONG_CHI"]);
                dt.TongThuKH = Convert.ToInt32(tbl.Rows[0]["TONG_THU_KH"]);
                dt.LoiNhuan = Convert.ToInt32(tbl.Rows[0]["LOI_NHUAN"]);
            }
            return dt;
        }
        //thêm
        public List<DoanhThu> LayDoanhThuTheoNam(int nam)
        {
            List<DoanhThu> list_dt = new List<DoanhThu>();
            DoanhThu dt = null;
            for (int i = 1; i<=12;i++)
            {
                DataTable tbl = new DataTable();
                tbl = factory.LayDoanhThuTheoThang(i, nam);
                if (tbl.Rows.Count>0)
                {
                    dt = new DoanhThu();
                    dt.TongDoanhThu = Convert.ToInt32(tbl.Rows[0]["TONG_DOANH_THU"]);
                    dt.TongGiamGia = Convert.ToInt32(tbl.Rows[0]["TONG_GIAM_GIA"]);
                    dt.TongDichVu = Convert.ToInt32(tbl.Rows[0]["TONG_DICH_VU"]);
                    dt.TongTienNhap = Convert.ToInt32(tbl.Rows[0]["TONG_TIEN_NHAP"]);
                    dt.TongTienChi = Convert.ToInt32(tbl.Rows[0]["TONG_CHI"]);
                    dt.TongThuKH = Convert.ToInt32(tbl.Rows[0]["TONG_THU_KH"]);
                    dt.LoiNhuan = Convert.ToInt32(tbl.Rows[0]["LOI_NHUAN"]);
                list_dt.Add(dt);
                } 
                else
                {
                    list_dt.Add(new DoanhThu
                    {
                        TongDoanhThu = 0,
                        TongDichVu = 0,
                        TongGiamGia = 0,
                        TongThuKH = 0,
                        TongTienChi = 0,
                        TongTienNhap = 0
                    });
                }    
                
            }    
            return list_dt;
        }
        //thêm
        public DoanhThu LayDoanhThuTheoNgay(DateTime ngay)
        {
            DataTable tbl = factory.LayDoanhThuTheoNgay(ngay);
            DoanhThu dt = null;
            if (tbl.Rows.Count > 0)
            {
                dt = new DoanhThu();
                dt.TongDoanhThu = Convert.ToInt32(tbl.Rows[0]["TONG_DOANH_THU"]);
                dt.TongGiamGia = Convert.ToInt32(tbl.Rows[0]["TONG_GIAM_GIA"]);
                dt.TongDichVu = Convert.ToInt32(tbl.Rows[0]["TONG_DICH_VU"]);
                dt.TongTienNhap = Convert.ToInt32(tbl.Rows[0]["TONG_TIEN_NHAP"]);
                dt.TongTienChi = Convert.ToInt32(tbl.Rows[0]["TONG_CHI"]);
                dt.TongThuKH = Convert.ToInt32(tbl.Rows[0]["TONG_THU_KH"]);
                dt.LoiNhuan = Convert.ToInt32(tbl.Rows[0]["LOI_NHUAN"]);
            }
            return dt;
        }
    }
}