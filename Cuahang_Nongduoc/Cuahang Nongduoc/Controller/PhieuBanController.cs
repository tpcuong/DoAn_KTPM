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
        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }
        public void Update()
        {
            bs.MoveNext();
            factory.Save();
        }
        public void Save()
        {
            int n = PhieuBanFactory.LaySoPhieu();
            if (n >= 50)
            {
                MessageBox.Show("Đây là bản dùng thử! Chỉ lưu được 50 phiếu bán!", "Phieu Ban", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Đây là bản dùng thử! Chỉ lưu được thêm " + Convert.ToString(50 - n) + " phiếu bán!", "Phieu Ban", MessageBoxButtons.OK, MessageBoxIcon.Information);
                factory.Save();
            }

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

        public void HienthiPhieuBan(BindingNavigator bn, ComboBox cmb, TextBox txt, DateTimePicker dt, NumericUpDown numPhiDichVu, NumericUpDown numGiamGia, NumericUpDown numTongTien, NumericUpDown numDatra, NumericUpDown numConNo)
        {
            bn.BindingSource = bs;

            txt.DataBindings.Clear();
            txt.DataBindings.Add("Text", bs, "ID");

            cmb.DataBindings.Clear();
            cmb.DataBindings.Add("SelectedValue", bs, "ID_KHACH_HANG");

            dt.DataBindings.Clear();
            dt.DataBindings.Add("Value", bs, "NGAY_BAN");

            numPhiDichVu.DataBindings.Clear();
            numPhiDichVu.DataBindings.Add("Value", bs, "PHI_DICH_VU");

            numGiamGia.DataBindings.Clear();
            numGiamGia.DataBindings.Add("Value", bs, "GIAM_GIA");

            numTongTien.DataBindings.Clear();
            numTongTien.DataBindings.Add("Value", bs, "TONG_TIEN");
            numDatra.DataBindings.Clear();
            numDatra.DataBindings.Add("Value", bs, "DA_TRA");

            numConNo.DataBindings.Clear();
            numConNo.DataBindings.Add("Value", bs, "CON_NO");
        }


        public PhieuBan LayPhieuBan(String id)
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
                ph.PhiDichVu = row["PHI_DICH_VU"] == DBNull.Value ? 0 : Convert.ToInt64(row["PHI_DICH_VU"]);
                ph.GiamGia = row["GIAM_GIA"] == DBNull.Value ? 0 : Convert.ToInt64(row["GIAM_GIA"]);

                KhachHangController ctrlKH = new KhachHangController();
                ph.KhachHang = ctrlKH.LayKhachHang(row["ID_KHACH_HANG"].ToString());

                ChiTietPhieuBanController ctrlCT = new ChiTietPhieuBanController();
                ph.ChiTiet = ctrlCT.ChiTietPhieuBan(ph.Id);
            }

            return ph;
        }



        public void TimPhieuBan(String maKH, DateTime dt)
        {
            factory.TimPhieuBan(maKH, dt);

        }

    }
}
