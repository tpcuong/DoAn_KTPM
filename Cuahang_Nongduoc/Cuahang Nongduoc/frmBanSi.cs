using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.Controller;
using CuahangNongduoc.BusinessObject;

namespace CuahangNongduoc
{
    public partial class frmBanSi : Form
    {
        SanPhamController ctrlSanPham = new SanPhamController();
        KhachHangController ctrlKhachHang = new KhachHangController();
        MaSanPhamController ctrlMaSanPham = new MaSanPhamController();
        PhieuBanController ctrlPhieuBan = new PhieuBanController();
        ChiTietPhieuBanController ctrlChiTiet = new ChiTietPhieuBanController();
        IList<MaSanPham> deleted = new List<MaSanPham>();
        Dictionary<string, int> viTriLo = new Dictionary<string, int>();
        Dictionary<string, decimal> soLuongLo = new Dictionary<string, decimal>();
        Decimal bqgq;
        Controll status = Controll.Normal;

        public frmBanSi()
        {
            InitializeComponent();
            status = Controll.AddNew;
        }

        public frmBanSi(PhieuBanController ctrlPB)
            : this()
        {
            this.ctrlPhieuBan = ctrlPB;
            status = Controll.Normal;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            dgvDanhsachSP.AutoGenerateColumns = false;
            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
            cmbSanPham.SelectedIndexChanged += new EventHandler(cmbSanPham_SelectedIndexChanged);
            ctrlKhachHang.HienthiAutoComboBox(cmbKhachHang, true);

            ctrlPhieuBan.HienthiPhieuBan(bindingNavigator, cmbKhachHang, txtMaPhieu, dtNgayLapPhieu, numPhiDichVu, numGiamGia, numTongTien, numDaTra, numConNo);
            bindingNavigator.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);

            ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);

            // CẬP NHẬT: Gán sự kiện để tự động tính toán lại tổng tiền
            numPhiDichVu.ValueChanged += new EventHandler(RecalculateTotal);
            numGiamGia.ValueChanged += new EventHandler(RecalculateTotal);
            numDaTra.ValueChanged += new EventHandler(RecalculateTotal);

            if (status == Controll.AddNew)
            {
                txtMaPhieu.Text = ThamSo.LayMaPhieuBan().ToString();
            }
            else
            {
                this.Allow(false);
            }
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (status == Controll.Normal)
            {
                ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);
            }
        }

        void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSanPham.SelectedValue != null)
            {
                bqgq = BinhQuanGiaQuyen(cmbSanPham.SelectedValue.ToString());
                string idSP = cmbSanPham.SelectedValue.ToString();

                if (!viTriLo.ContainsKey(idSP))
                {
                    viTriLo[idSP] = 0;
                }

                MaSanPhamController ctrl = new MaSanPhamController();
                List<MaSanPham> masp = ctrl.LayDanhSachMaSanPham(idSP);
                int index = viTriLo[idSP];

                if (masp.Count > 0 && index < masp.Count)
                {
                    numDonGia.Value = masp[index].SanPham.GiaBanSi; // Giá sỉ
                    txtGiaNhap.Text = masp[index].GiaNhap.ToString("#,###0");
                    txtGiaBanSi.Text = masp[index].SanPham.GiaBanSi.ToString("#,###0");
                    txtGiaBanLe.Text = masp[index].SanPham.GiaBanLe.ToString("#,###0");
                    txtGiaBQGQ.Text = bqgq.ToString("#,###0");
                }

                if (viTriLo.ContainsKey(idSP))
                    viTriLo[idSP] = 0;

                if (soLuongLo.ContainsKey(idSP))
                    soLuongLo[idSP] = masp.Count > 0 ? masp[0].SoLuong : 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng!", "Phiếu bán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string idSP = cmbSanPham.SelectedValue.ToString();
            List<MaSanPham> danhSachLo = ctrlMaSanPham.LayDanhSachMaSanPham(idSP);
            decimal soLuongCanXuat = numSoLuong.Value;

            if (!viTriLo.ContainsKey(idSP))
                viTriLo.Add(idSP, 0);

            foreach (MaSanPham lo in danhSachLo)
            {
                if (!soLuongLo.ContainsKey(lo.Id))
                    soLuongLo.Add(lo.Id, lo.SoLuong);
            }

            while (soLuongCanXuat > 0 && viTriLo[idSP] < danhSachLo.Count)
            {
                int viTriHienTai = viTriLo[idSP];
                MaSanPham loHienTai = danhSachLo[viTriHienTai];
                string idLo = loHienTai.Id;
                decimal tonHienTai = soLuongLo[idLo];
                decimal soLuongXuat = Math.Min(soLuongCanXuat, tonHienTai);

                if (soLuongXuat > 0)
                {
                    soLuongLo[idLo] -= soLuongXuat;
                    soLuongCanXuat -= soLuongXuat;

                    decimal thanhTien = numDonGia.Value * soLuongXuat;

                    DataRow row = ctrlChiTiet.NewRow();
                    row["ID_MA_SAN_PHAM"] = idLo;
                    row["ID_PHIEU_BAN"] = txtMaPhieu.Text;
                    row["DON_GIA"] = numDonGia.Value; // Lấy đơn giá sỉ từ numDonGia
                    row["SO_LUONG"] = soLuongXuat;
                    row["THANH_TIEN"] = thanhTien;
                    row["NGAY_HET_HAN"] = loHienTai.NgayHetHan;

                    ctrlChiTiet.Add(row);
                    KTraDongTrung();
                }

                if (soLuongLo[idLo] == 0)
                {
                    viTriLo[idSP]++;
                }
            }

            // CẬP NHẬT: Gọi hàm tính toán tập trung
            CapNhatTongTienVaCongNo();

            numSoLuong.Value = 0;
            numThanhTien.Value = 0;
        }

        // MỚI: Hàm tính toán tổng tiền tập trung
        private void CapNhatTongTienVaCongNo()
        {
            decimal tongTienSP = 0;
            DataTable tbl = null;

            if (dgvDanhsachSP.DataSource is BindingSource)
            {
                tbl = (DataTable)((BindingSource)dgvDanhsachSP.DataSource).DataSource;
            }
            else
            {
                tbl = (DataTable)dgvDanhsachSP.DataSource;
            }
            if (tbl != null)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        tongTienSP += Convert.ToDecimal(row["THANH_TIEN"]);
                    }
                }
            }

            decimal phiDichVu = numPhiDichVu.Value;
            decimal giamGia = numGiamGia.Value;
            decimal daTra = numDaTra.Value;

            decimal tongTienCuoiCung = tongTienSP + phiDichVu - giamGia;

            if (numTongTien.Value != tongTienCuoiCung)
                numTongTien.Value = tongTienCuoiCung;

            numConNo.Value = tongTienCuoiCung - daTra;
        }

        // MỚI: Hàm xử lý sự kiện khi giá trị thay đổi
        private void RecalculateTotal(object sender, EventArgs e)
        {
            CapNhatTongTienVaCongNo();
        }

        public decimal BinhQuanGiaQuyen(string idSP)
        {
            decimal tongGiaTri = 0;
            decimal tongSoLuong = 0;
            List<MaSanPham> danhSachLo = ctrlMaSanPham.LayDanhSachMaSanPham(idSP);

            foreach (MaSanPham lo in danhSachLo)
            {
                tongGiaTri += lo.GiaNhap * lo.SoLuong;
                tongSoLuong += lo.SoLuong;
            }

            if (tongSoLuong == 0) return 0;
            return tongGiaTri / tongSoLuong;
        }

        public void KTraDongTrung()
        {
            DataTable tbl = null;

            if (dgvDanhsachSP.DataSource is BindingSource)
            {
                tbl = (dgvDanhsachSP.DataSource as BindingSource).DataSource as DataTable;
            }
            else if (dgvDanhsachSP.DataSource is DataTable)
            {
                tbl = (DataTable)dgvDanhsachSP.DataSource;
            }

            if (tbl == null || tbl.Rows.Count < 2) return;

            for (int i = 0; i < tbl.Rows.Count - 1; i++)
            {
                for (int j = i + 1; j < tbl.Rows.Count; j++)
                {
                    if (tbl.Rows[i]["ID_MA_SAN_PHAM"].ToString() == tbl.Rows[j]["ID_MA_SAN_PHAM"].ToString())
                    {
                        tbl.Rows[i]["SO_LUONG"] = Convert.ToDecimal(tbl.Rows[i]["SO_LUONG"]) + Convert.ToDecimal(tbl.Rows[j]["SO_LUONG"]);
                        tbl.Rows[i]["THANH_TIEN"] = Convert.ToDecimal(tbl.Rows[i]["THANH_TIEN"]) + Convert.ToDecimal(tbl.Rows[j]["THANH_TIEN"]);
                        tbl.Rows.RemoveAt(j);
                        j--;
                    }
                }
            }
            dgvDanhsachSP.Refresh();
        }

        private void numDonGia_ValueChanged(object sender, EventArgs e)
        {
            numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
        }

        // BỎ: Hàm này không còn cần thiết, đã được xử lý bởi RecalculateTotal
        // private void numTongTien_ValueChanged(object sender, EventArgs e)
        // {
        //    numConNo.Value = numTongTien.Value - numDaTra.Value;
        // }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            this.Luu();
            status = Controll.Normal;
            this.Allow(false);
        }

        void Luu()
        {
            if (status == Controll.AddNew)
            {
                ThemMoi();
            }
            else
            {
                CapNhat();
            }
        }

        // CẬP NHẬT: Hàm Cập nhật
        void CapNhat()
        {
            foreach (MaSanPham masp in deleted)
            {
                CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(masp.Id, Convert.ToInt32(masp.SoLuong));
            }
            deleted.Clear();

            ctrlChiTiet.Save();

            DataRowView currentRow = (DataRowView)bindingNavigator.BindingSource.Current;
            currentRow["TONG_TIEN"] = numTongTien.Value;
            currentRow["DA_TRA"] = numDaTra.Value;
            currentRow["CON_NO"] = numConNo.Value;
            currentRow["PHI_DICH_VU"] = numPhiDichVu.Value;
            currentRow["GIAM_GIA"] = numGiamGia.Value;

            ctrlPhieuBan.Update();
        }

        // CẬP NHẬT: Hàm Thêm mới
        void ThemMoi()
        {
            DataRow row = ctrlPhieuBan.NewRow();
            row["ID"] = txtMaPhieu.Text;
            row["ID_KHACH_HANG"] = cmbKhachHang.SelectedValue;
            row["NGAY_BAN"] = dtNgayLapPhieu.Value.Date;

            CapNhatTongTienVaCongNo(); // Đảm bảo các giá trị là mới nhất

            row["TONG_TIEN"] = numTongTien.Value;
            row["DA_TRA"] = numDaTra.Value;
            row["CON_NO"] = numConNo.Value;
            row["PHI_DICH_VU"] = numPhiDichVu.Value;
            row["GIAM_GIA"] = numGiamGia.Value;

            ctrlPhieuBan.Add(row);

            PhieuBanController ctrl = new PhieuBanController();
            if (ctrl.LayPhieuBan(txtMaPhieu.Text) != null)
            {
                MessageBox.Show("Mã Phiếu bán này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ThamSo.LaSoNguyen(txtMaPhieu.Text))
            {
                long so = Convert.ToInt64(txtMaPhieu.Text);
                if (so >= ThamSo.LayMaPhieuBan())
                {
                    ThamSo.GanMaPhieuBan(so + 1);
                }
            }

            ctrlPhieuBan.Save();
            ctrlChiTiet.Save();
            MessageBox.Show("Lưu phiếu bán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolLuu_Them_Click(object sender, EventArgs e)
        {
            Luu(); // Lưu phiếu hiện tại
            ctrlPhieuBan = new PhieuBanController();
            status = Controll.AddNew;
            txtMaPhieu.Text = ThamSo.LayMaPhieuBan().ToString();
            numTongTien.Value = 0;
            ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);
            this.Allow(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachSP.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idLo = dgvDanhsachSP.SelectedRows[0].Cells["colMaSanPham"].Value.ToString();
                    decimal soLuongXoa = Convert.ToDecimal(dgvDanhsachSP.SelectedRows[0].Cells["colSoLuong"].Value);

                    if (soLuongLo.ContainsKey(idLo))
                    {
                        soLuongLo[idLo] += soLuongXoa;
                    }

                    dgvDanhsachSP.Rows.Remove(dgvDanhsachSP.SelectedRows[0]);

                    // CẬP NHẬT: Gọi hàm tính toán tập trung
                    CapNhatTongTienVaCongNo();

                    if (cmbSanPham.SelectedValue != null)
                    {
                        string idSP = cmbSanPham.SelectedValue.ToString();
                        viTriLo[idSP] = 0;
                    }
                }
            }
        }

        // CẬP NHẬT: Hàm `Allow`
        void Allow(bool val)
        {
            cmbKhachHang.Enabled = val;
            dtNgayLapPhieu.Enabled = val;
            numPhiDichVu.Enabled = val;
            numGiamGia.Enabled = val;
            numDaTra.Enabled = val;
            btnAdd.Enabled = val;
            btnRemove.Enabled = val;
            dgvDanhsachSP.Enabled = val;
            cmbSanPham.Enabled = val;
            numSoLuong.Enabled = val;
            numDonGia.Enabled = val;
        }

        // Các hàm còn lại giữ nguyên
        #region Các hàm không đổi
        private void dgvDanhsachSP_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Si", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                BindingSource bs = ((BindingSource)dgvDanhsachSP.DataSource);
                DataRowView row = (DataRowView)bs.Current;
                CapNhatTongTienVaCongNo(); // Gọi hàm tính lại
                deleted.Add(new MaSanPham(Convert.ToString(row["ID_MA_SAN_PHAM"]), Convert.ToInt32(row["SO_LUONG"])));
            }
        }

        private void toolLuuIn_Click(object sender, EventArgs e)
        {
            if (status != Controll.Normal)
            {
                MessageBox.Show("Vui lòng lưu lại Phiếu bán hiện tại!", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                String ma_phieu = txtMaPhieu.Text;
                PhieuBanController ctrlPB = new PhieuBanController();
                CuahangNongduoc.BusinessObject.PhieuBan ph = ctrlPB.LayPhieuBan(ma_phieu);
                frmInPhieuBan InPhieuBan = new frmInPhieuBan(ph);
                InPhieuBan.Show();
            }
        }

        private void dgvDanhsachSP_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolChinhSua_Click(object sender, EventArgs e)
        {
            status = Controll.Edit;
            this.Allow(true);
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            if (status != Controll.Normal)
            {
                if (MessageBox.Show("Bạn có muốn lưu lại Phiếu bán này không?", "Phieu Ban Si", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Luu();
                }
            }
            this.Close();
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
            DataRowView view = (DataRowView)bindingNavigator.BindingSource.Current;
            if (view != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Si", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                    IList<ChiTietPhieuBan> ds = ctrl.ChiTietPhieuBan(view["ID"].ToString());
                    foreach (ChiTietPhieuBan ct in ds)
                    {
                        CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(ct.MaSanPham.Id, Convert.ToInt32(ct.SoLuong));
                    }
                    bindingNavigator.BindingSource.RemoveCurrent();
                    ctrlPhieuBan.Save();
                }
            }
        }

        private void btnThemDaiLy_Click(object sender, EventArgs e)
        {
            frmDaiLy DaiLy = new frmDaiLy();
            DaiLy.ShowDialog();
            ctrlKhachHang.HienthiAutoComboBox(cmbKhachHang, true);
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham SanPham = new frmSanPham();
            SanPham.ShowDialog();
            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
        }
        #endregion
    }
}