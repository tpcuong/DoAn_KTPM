using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.DataLayer;


namespace CuahangNongduoc.Controller
{
    public class SanPhamController
    {
        SanPhamFactory factory = new SanPhamFactory();
        ChiTietPhieuBanController ctrChiTiet = new ChiTietPhieuBanController();
        MaSanPhamController ctrMaSanPham = new MaSanPhamController();
        PhieuBanFactory factoryPhieuBan = new PhieuBanFactory();
        PhieuNhapFactory factoryPhieuNhap = new PhieuNhapFactory();
        public void HienthiAutoComboBox(System.Windows.Forms.ComboBox cmb)
        {
            DataTable tbl = factory.DanhsachSanPham();
            cmb.DataSource = tbl;
            // Tạo một bản sao độc lập của DataTable
            DataTable tblCopy = tbl.Copy();

            // Gán DataSource bằng bản sao
            cmb.DataSource = tblCopy; // Thay vì gán 'tbl'
            cmb.DisplayMember = "TEN_SAN_PHAM";
            cmb.ValueMember = "ID";
            //cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            //cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public bool CapNhatGiaBinhQuan(string id, decimal giaBinhQuan)
        {
            return factory.CapNhatGiaBinhQuan(id, giaBinhQuan);
        }
        public DataTable LaySanPhamTheoID(string id)
        {
            return factory.LaySanPham(id);
        }
        public List<SanPham> DanhSachSanPham()
        {
            DataTable tbl = factory.DanhsachSanPham();
            List<SanPham> ds = new List<SanPham>();
            DonViTinhController ctrlDVT = new DonViTinhController();
            foreach (DataRow row in tbl.Rows)
            {
                SanPham sp = new SanPham();
                sp.Id = Convert.ToString(row["ID"]);
                sp.TenSanPham = Convert.ToString(row["TEN_SAN_PHAM"]);
                sp.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
                sp.DonGiaNhap = Convert.ToInt64(row["DON_GIA_NHAP"]);
                sp.GiaBanLe = Convert.ToInt64(row["GIA_BAN_LE"]);
                sp.GiaBanSi = Convert.ToInt64(row["GIA_BAN_SI"]);
                sp.DonViTinh = ctrlDVT.LayDVT(Convert.ToInt32(row["ID_DON_VI_TINH"]));
                ds.Add(sp);
            }
            return ds;
        }
        public void HienthiDataGridViewComboBoxColumn(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = factory.DanhsachSanPham();
            cmb.DisplayMember = "TEN_SAN_PHAM";
            cmb.ValueMember = "ID";
            cmb.AutoComplete = true;
        }
        public void TimMaSanPham(String ma)
        {
            factory.TimMaSanPham(ma);
        }
        public void TimTenSanPham(String ten)
        {
            factory.TimTenSanPham(ten);
        }

        public void HienthiDataGridview(System.Windows.Forms.DataGridView dg, System.Windows.Forms.BindingNavigator bn,
            TextBox txtMaSp, TextBox txtTenSp, ComboBox cmbDVT, NumericUpDown numSoLuong, NumericUpDown numDonGiaNhap, NumericUpDown numGiaBanSi, NumericUpDown numGiaBanLe)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            bs.DataSource = factory.DanhsachSanPham();

            txtMaSp.DataBindings.Clear();
            txtMaSp.DataBindings.Add("Text", bs, "ID");

            txtTenSp.DataBindings.Clear();
            txtTenSp.DataBindings.Add("Text", bs, "TEN_SAN_PHAM");

            cmbDVT.DataBindings.Clear();
            cmbDVT.DataBindings.Add("SelectedValue", bs, "ID_DON_VI_TINH");

            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bs, "DON_GIA_NHAP");

            numDonGiaNhap.DataBindings.Clear();
            numDonGiaNhap.DataBindings.Add("Value", bs, "DON_GIA_NHAP");

            numGiaBanSi.DataBindings.Clear();
            numGiaBanSi.DataBindings.Add("Value", bs, "GIA_BAN_SI");

            numGiaBanLe.DataBindings.Clear();
            numGiaBanLe.DataBindings.Add("Value", bs, "GIA_BAN_LE");
            bn.BindingSource = bs;
            dg.DataSource = bs;


        }
        public void CapNhatGiaNhap(String id, long gia_moi, long so_luong)
        {
            DataTable tbl = factory.LaySanPham(id);
            if (tbl.Rows.Count > 0)
            {
                long tong_so = Convert.ToInt32(tbl.Rows[0]["SO_LUONG"]);
                long tong_gia = Convert.ToInt64(tbl.Rows[0]["DON_GIA_NHAP"]);
                if (tong_gia != gia_moi)
                {
                    long thanh_tien = gia_moi * so_luong + tong_gia * tong_so;
                    tong_so += so_luong;
                    tbl.Rows[0]["DON_GIA_NHAP"] = thanh_tien / tong_so;
                    tbl.Rows[0]["SO_LUONG"] = tong_so;
                }
                factory.Save();
            }

        }

        public SanPham LaySanPham(String id)
        {
            DataTable tbl = factory.LaySanPham(id);
            SanPham sp = new SanPham();
            DonViTinhController ctrlDVT = new DonViTinhController();
            if (tbl.Rows.Count > 0)
            {
                sp.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                sp.TenSanPham = Convert.ToString(tbl.Rows[0]["TEN_SAN_PHAM"]);
                sp.SoLuong = Convert.ToInt32(tbl.Rows[0]["SO_LUONG"]);
                sp.DonGiaNhap = Convert.ToInt64(tbl.Rows[0]["DON_GIA_NHAP"]);
                sp.GiaBanLe = Convert.ToInt64(tbl.Rows[0]["GIA_BAN_LE"]);
                sp.GiaBanSi = Convert.ToInt64(tbl.Rows[0]["GIA_BAN_SI"]);
                sp.DonViTinh = ctrlDVT.LayDVT(Convert.ToInt32(tbl.Rows[0]["ID_DON_VI_TINH"]));
                sp.GiaBinhQuan = Convert.ToDecimal(tbl.Rows[0]["GIA_BINH_QUAN"]);
            }
            return sp;

        }

        public static IList<SoLuongTon> LaySoLuongTon()
        {
            SanPhamFactory f = new SanPhamFactory();
            DataTable tbl = f.LaySoLuongTon();

            IList<SoLuongTon> ds = new List<SoLuongTon>();


            DonViTinhController ctrlDVT = new DonViTinhController();
            foreach (DataRow row in tbl.Rows)
            {
                SoLuongTon slt = new SoLuongTon();
                SanPham sp = new SanPham();
                sp.Id = Convert.ToString(row["ID"]);
                sp.TenSanPham = Convert.ToString(row["TEN_SAN_PHAM"]);
                sp.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
                sp.DonGiaNhap = Convert.ToInt64(row["DON_GIA_NHAP"]);
                sp.GiaBanLe = Convert.ToInt64(row["GIA_BAN_LE"]);
                sp.GiaBanSi = Convert.ToInt64(row["GIA_BAN_SI"]);
                sp.DonViTinh = ctrlDVT.LayDVT(Convert.ToInt32(row["ID_DON_VI_TINH"]));
                slt.SanPham = sp;
                slt.SoLuong = Convert.ToInt32(row["SO_LUONG_TON"]);
                ds.Add(slt);
            }
            return ds;
        }

        // thêm
        public static IList<SoLuongTon> LaySoLuongTon(DateTime tuNgay, DateTime denNgay)
        {
            SanPhamFactory f = new SanPhamFactory();
            DataTable tbl = f.LaySoLuongTon(tuNgay, denNgay);

            IList<SoLuongTon> ds = new List<SoLuongTon>();

            DonViTinhController ctrlDVT = new DonViTinhController();
            foreach (DataRow row in tbl.Rows)
            {
                SoLuongTon slt = new SoLuongTon();
                SanPham sp = new SanPham();
                sp.Id = Convert.ToString(row["ID"]);
                sp.TenSanPham = Convert.ToString(row["TEN_SAN_PHAM"]);
                //sp.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
                sp.DonGiaNhap = Convert.ToInt64(row["TON_DAU"]);
                sp.GiaBanLe = Convert.ToInt64(row["NHAP_TRONG_KY"]);
                sp.GiaBanSi = Convert.ToInt64(row["XUAT_TRONG_KY"]);
                sp.DonViTinh = ctrlDVT.LayDVT(Convert.ToInt32(row["ID_DON_VI_TINH"]));
                slt.SanPham = sp;
                slt.SoLuong = Convert.ToInt32(row["TON_CUOI"]);
                ds.Add(slt);
            }
            return ds;

        }
        public bool UpdateSoLuong(string id, long so_luong)
        {
            return factory.UpdateSoLuong(id, so_luong);
        }
        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }
        public bool Save()
        {
            return factory.Save();
        }
        public void CapNhatSoLuong(String masp)
        {
            IList<ChiTietPhieuBan> ct = ctrChiTiet.ChiTietPhieuBan(masp);
            foreach (ChiTietPhieuBan item in ct)
            {
                int soLuongBan = Convert.ToInt32(item.SoLuong);
                if (soLuongBan <= 0) continue;
                string idMaLo = item.MaSanPham.Id;
                MaSanPham msp = ctrMaSanPham.LayMaSanPham(idMaLo);
                if (msp == null)
                {
                    continue;
                }

                string idSanPham = msp.SanPham.Id;
                factory.CapNhatSoLuong(idSanPham, -soLuongBan);
            }

        }

    }
}
