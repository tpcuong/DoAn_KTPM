using System;
using System.Collections.Generic;
using System.Text;
using CuahangNongduoc.DataLayer;
using CuahangNongduoc.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace CuahangNongduoc.Controller
{
<<<<<<< HEAD
    
=======

>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
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
<<<<<<< HEAD
                MessageBox.Show("Đây là bản dùng thử! Chỉ lưu được thêm " + Convert.ToString(50-n) + " phiếu bán!", "Phieu Ban", MessageBoxButtons.OK, MessageBoxIcon.Information);
                factory.Save();
            }
            
=======
                MessageBox.Show("Đây là bản dùng thử! Chỉ lưu được thêm " + Convert.ToString(50 - n) + " phiếu bán!", "Phieu Ban", MessageBoxButtons.OK, MessageBoxIcon.Information);
                factory.Save();
            }

>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
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

<<<<<<< HEAD
        public void HienthiPhieuBan(BindingNavigator bn,ComboBox cmb, TextBox txt, DateTimePicker dt, NumericUpDown numTongTien, NumericUpDown numDatra, NumericUpDown numConNo)
        {

=======
        public void HienthiPhieuBan(BindingNavigator bn, ComboBox cmb, TextBox txt, DateTimePicker dt, NumericUpDown numPhiDichVu, NumericUpDown numGiamGia, NumericUpDown numTongTien, NumericUpDown numDatra, NumericUpDown numConNo)
        {
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            bn.BindingSource = bs;

            txt.DataBindings.Clear();
            txt.DataBindings.Add("Text", bs, "ID");

            cmb.DataBindings.Clear();
            cmb.DataBindings.Add("SelectedValue", bs, "ID_KHACH_HANG");

            dt.DataBindings.Clear();
            dt.DataBindings.Add("Value", bs, "NGAY_BAN");

<<<<<<< HEAD
            numTongTien.DataBindings.Clear();
            numTongTien.DataBindings.Add("Value", bs, "TONG_TIEN");

=======
            numPhiDichVu.DataBindings.Clear();
            numPhiDichVu.DataBindings.Add("Value", bs, "PHI_DICH_VU");

            numGiamGia.DataBindings.Clear();
            numGiamGia.DataBindings.Add("Value", bs, "GIAM_GIA");

            numTongTien.DataBindings.Clear();
            numTongTien.DataBindings.Add("Value", bs, "TONG_TIEN");
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            numDatra.DataBindings.Clear();
            numDatra.DataBindings.Add("Value", bs, "DA_TRA");

            numConNo.DataBindings.Clear();
            numConNo.DataBindings.Add("Value", bs, "CON_NO");
<<<<<<< HEAD


        }

=======
        }


>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        public PhieuBan LayPhieuBan(String id)
        {
            DataTable tbl = factory.LayPhieuBan(id);
            PhieuBan ph = null;
            if (tbl.Rows.Count > 0)
            {
<<<<<<< HEAD

                ph = new PhieuBan();
                ph.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                
                ph.NgayBan = Convert.ToDateTime(tbl.Rows[0]["NGAY_BAN"]);
                ph.TongTien = Convert.ToInt64(tbl.Rows[0]["TONG_TIEN"]);
                ph.DaTra = Convert.ToInt64(tbl.Rows[0]["DA_TRA"]);
                ph.ConNo = Convert.ToInt64(tbl.Rows[0]["CON_NO"]);
                KhachHangController ctrlKH = new KhachHangController();
                ph.KhachHang = ctrlKH.LayKhachHang(Convert.ToString(tbl.Rows[0]["ID_KHACH_HANG"]));
                ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                ph.ChiTiet = ctrl.ChiTietPhieuBan(ph.Id);
            }
            return ph;
        }

=======
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



>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        public void TimPhieuBan(String maKH, DateTime dt)
        {
            factory.TimPhieuBan(maKH, dt);

        }

    }
}
