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
<<<<<<< HEAD
    public partial class frmBanLe: Form
=======
    public partial class frmBanLe : Form
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
    {
        SanPhamController ctrlSanPham = new SanPhamController();
        KhachHangController ctrlKhachHang = new KhachHangController();
        MaSanPhamController ctrlMaSanPham = new MaSanPhamController();
        PhieuBanController ctrlPhieuBan = new PhieuBanController();
        ChiTietPhieuBanController ctrlChiTiet = new ChiTietPhieuBanController();
        IList<MaSanPham> deleted = new List<MaSanPham>();
        Controll status = Controll.Normal;
<<<<<<< HEAD
=======
        // Vị trí lô hiện tại của từng sản phẩm
        Dictionary<string, int> viTriLo = new Dictionary<string, int>();
        // Số lượng còn lại trong lô hiện tại (nên dùng decimal để khớp với NumericUpDown)
        Dictionary<string, decimal> soLuongLo = new Dictionary<string, decimal>();
        Decimal bqgq;
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8

        public frmBanLe()
        {
            InitializeComponent();
            status = Controll.AddNew;
        }

<<<<<<< HEAD
     
=======

>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        public frmBanLe(PhieuBanController ctrlPB)
            : this()
        {
            this.ctrlPhieuBan = ctrlPB;
            status = Controll.Normal;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD

            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
            ctrlMaSanPham.HienThiDataGridViewComboBox(colMaSanPham);

=======
            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
            dgvDanhsachSP.AutoGenerateColumns = false; ;
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            cmbSanPham.SelectedIndexChanged += new EventHandler(cmbSanPham_SelectedIndexChanged);

            ctrlKhachHang.HienthiAutoComboBox(cmbKhachHang, false);

<<<<<<< HEAD
            ctrlPhieuBan.HienthiPhieuBan(bindingNavigator,cmbKhachHang, txtMaPhieu, dtNgayLapPhieu, numTongTien, numDaTra, numConNo);

            bindingNavigator.BindingSource.CurrentChanged -= new EventHandler(BindingSource_CurrentChanged);
            bindingNavigator.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);
            
            ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);

=======
            // CẬP NHẬT: Thêm các control phí, giảm giá, đã trả, còn nợ vào binding
            ctrlPhieuBan.HienthiPhieuBan(bindingNavigator, cmbKhachHang, txtMaPhieu, dtNgayLapPhieu, numPhiDichVu, numGiamGia, numTongTien, numDaTra, numConNo);

            bindingNavigator.BindingSource.CurrentChanged -= new EventHandler(BindingSource_CurrentChanged);
            bindingNavigator.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);

            ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);

            // CẬP NHẬT: Gán sự kiện ValueChanged để tự động tính toán lại
            numPhiDichVu.ValueChanged += new EventHandler(RecalculateTotal);
            numGiamGia.ValueChanged += new EventHandler(RecalculateTotal);
            numDaTra.ValueChanged += new EventHandler(RecalculateTotal);

>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8

            if (status == Controll.AddNew)
            {
                txtMaPhieu.Text = ThamSo.LayMaPhieuBan().ToString();
            }
            else
            {
                this.Allow(false);
            }
<<<<<<< HEAD


        }

=======
        }
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (status == Controll.Normal)
            {
                ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);
            }
        }

<<<<<<< HEAD

=======
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSanPham.SelectedValue != null)
            {
<<<<<<< HEAD
                MaSanPhamController ctrlMSP = new MaSanPhamController();

                cmbMaSanPham.SelectedIndexChanged -= new EventHandler(cmbMaSanPham_SelectedIndexChanged);
                ctrlMSP.HienThiAutoComboBox(cmbSanPham.SelectedValue.ToString(), cmbMaSanPham);
                cmbMaSanPham.SelectedIndexChanged += new EventHandler(cmbMaSanPham_SelectedIndexChanged);
            }
        }

        void cmbMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaSanPhamController ctrl = new MaSanPhamController();
            MaSanPham masp = ctrl.LayMaSanPham(cmbMaSanPham.SelectedValue.ToString());
            numDonGia.Value = masp.SanPham.GiaBanLe;
            txtGiaNhap.Text = masp.GiaNhap.ToString("#,###0");
            txtGiaBanSi.Text = masp.SanPham.GiaBanSi.ToString("#,###0");
            txtGiaBanLe.Text = masp.SanPham.GiaBanLe.ToString("#,###0");
            txtGiaBQGQ.Text = masp.SanPham.DonGiaNhap.ToString("#,###0");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (cmbMaSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Mã sản phẩm !", "Phieu Nhap", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng !", "Phieu Nhap", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numDonGia.Value * numSoLuong.Value != numThanhTien.Value)
            {
                MessageBox.Show("Thành tiền sai!", "Phieu Nhap", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                numTongTien.Value += numThanhTien.Value;
                DataRow row = ctrlChiTiet.NewRow();
                row["ID_MA_SAN_PHAM"] = cmbMaSanPham.SelectedValue;
                row["ID_PHIEU_BAN"] = txtMaPhieu.Text;
                row["DON_GIA"] = numDonGia.Value;
                row["SO_LUONG"] = numSoLuong.Value;
                row["THANH_TIEN"] = numThanhTien.Value;
                ctrlChiTiet.Add(row);

            }

        }

=======
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
                    numDonGia.Value = bqgq;
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
                    row["DON_GIA"] = bqgq;
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

            // CẬP NHẬT: Gọi hàm tính tổng tiền thay vì gán trực tiếp
            CapNhatTongTienVaCongNo();

            numSoLuong.Value = 0;
            numThanhTien.Value = 0;
            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
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

            // Cập nhật vào UI mà không gây ra vòng lặp sự kiện
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

            if (tongSoLuong == 0)
                return 0;
            decimal giaBinhQuan = tongGiaTri / tongSoLuong;
            return giaBinhQuan;
        }

        public void KTraDongTrung()
        {
            DataTable tbl = null;

            if (dgvDanhsachSP.DataSource is BindingSource)
            {
                BindingSource bs = (BindingSource)dgvDanhsachSP.DataSource;
                tbl = bs.DataSource as DataTable;
            }
            else if (dgvDanhsachSP.DataSource is DataTable)
            {
                tbl = (DataTable)dgvDanhsachSP.DataSource;
            }

            if (tbl == null || tbl.Rows.Count == 0)
                return;

            for (int i = 0; i < tbl.Rows.Count - 1; i++)
            {
                for (int j = i + 1; j < tbl.Rows.Count; j++)
                {
                    if (tbl.Rows[i]["ID_MA_SAN_PHAM"].ToString() == tbl.Rows[j]["ID_MA_SAN_PHAM"].ToString())
                    {

                        decimal sl1 = Convert.ToDecimal(tbl.Rows[i]["SO_LUONG"]);
                        decimal sl2 = Convert.ToDecimal(tbl.Rows[j]["SO_LUONG"]);
                        tbl.Rows[i]["SO_LUONG"] = sl1 + sl2;


                        decimal tt1 = Convert.ToDecimal(tbl.Rows[i]["THANH_TIEN"]);
                        decimal tt2 = Convert.ToDecimal(tbl.Rows[j]["THANH_TIEN"]);
                        tbl.Rows[i]["THANH_TIEN"] = tt1 + tt2;


                        tbl.Rows.RemoveAt(j);
                        j--;
                    }
                }
            }

            dgvDanhsachSP.DataSource = tbl;
            dgvDanhsachSP.Refresh();
        }
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        private void numDonGia_ValueChanged(object sender, EventArgs e)
        {
            numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
        }

<<<<<<< HEAD
        private void numTongTien_ValueChanged(object sender, EventArgs e)
        {
            numConNo.Value = numTongTien.Value - numDaTra.Value;
        }
=======
        // BỎ: Hàm này không cần thiết vì đã có RecalculateTotal xử lý
        // private void numTongTien_ValueChanged(object sender, EventArgs e)
        // {
        //     numConNo.Value = numTongTien.Value - numDaTra.Value;
        // }
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8

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

<<<<<<< HEAD
=======
        // CẬP NHẬT: Sửa lại hàm Cập nhật
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        void CapNhat()
        {
            foreach (MaSanPham masp in deleted)
            {
<<<<<<< HEAD
                CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(masp.Id, masp.SoLuong);
=======
                CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(masp.Id, Convert.ToInt32(masp.SoLuong));
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            }
            deleted.Clear();

            ctrlChiTiet.Save();

<<<<<<< HEAD
            ctrlPhieuBan.Update();

        }
        void ThemMoi()
        {

=======
            // Cập nhật lại các giá trị tiền vào DataRow trước khi lưu
            DataRowView currentRow = (DataRowView)bindingNavigator.BindingSource.Current;
            currentRow["TONG_TIEN"] = numTongTien.Value;
            currentRow["DA_TRA"] = numDaTra.Value;
            currentRow["CON_NO"] = numConNo.Value;
            currentRow["PHI_DICH_VU"] = numPhiDichVu.Value;
            currentRow["GIAM_GIA"] = numGiamGia.Value;

            ctrlPhieuBan.Update();
        }

        // CẬP NHẬT: Sửa lại hàm Thêm mới
        void ThemMoi()
        {
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            DataRow row = ctrlPhieuBan.NewRow();
            row["ID"] = txtMaPhieu.Text;
            row["ID_KHACH_HANG"] = cmbKhachHang.SelectedValue;
            row["NGAY_BAN"] = dtNgayLapPhieu.Value.Date;
<<<<<<< HEAD
            row["TONG_TIEN"] = numTongTien.Value;
            row["DA_TRA"] = numDaTra.Value;
            row["CON_NO"] = numConNo.Value;
            ctrlPhieuBan.Add(row);

            PhieuBanController ctrl = new PhieuBanController();

            if (ctrl.LayPhieuBan(txtMaPhieu.Text) != null)
            {
                MessageBox.Show("Mã Phiếu bán này đã tồn tại !", "Phieu Nhap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
=======

            // --- Lấy các giá trị từ form ---
            decimal tongTienSP = 0;
            // Tính lại tổng tiền sản phẩm một lần nữa cho chắc chắn
            foreach (DataGridViewRow dgvRow in dgvDanhsachSP.Rows)
            {
                if (dgvRow.Cells["colThanhTien"].Value != null)
                {
                    tongTienSP += Convert.ToDecimal(dgvRow.Cells["colThanhTien"].Value);
                }
            }

            decimal phiDichVu = numPhiDichVu.Value;
            decimal giamGia = numGiamGia.Value;
            decimal daTra = numDaTra.Value;

            // --- Tính lại tổng tiền và công nợ ---
            decimal tongTienSauDieuChinh = tongTienSP + phiDichVu - giamGia;
            decimal conNo = tongTienSauDieuChinh - daTra;

            // --- Gán toàn bộ các cột cho DataRow ---
            row["TONG_TIEN"] = tongTienSauDieuChinh;
            row["DA_TRA"] = daTra;
            row["CON_NO"] = conNo;
            row["PHI_DICH_VU"] = phiDichVu;
            row["GIAM_GIA"] = giamGia;

            // --- Thêm vào DataSet ---
            ctrlPhieuBan.Add(row);

            // --- Kiểm tra trùng mã phiếu ---
            PhieuBanController ctrl = new PhieuBanController();
            if (ctrl.LayPhieuBan(txtMaPhieu.Text) != null)
            {
                MessageBox.Show("Mã Phiếu bán này đã tồn tại!", "Phiếu bán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Cập nhật số thứ tự phiếu ---
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            if (ThamSo.LaSoNguyen(txtMaPhieu.Text))
            {
                long so = Convert.ToInt64(txtMaPhieu.Text);
                if (so >= ThamSo.LayMaPhieuBan())
                {
                    ThamSo.GanMaPhieuBan(so + 1);
                }
            }

<<<<<<< HEAD
            ctrlPhieuBan.Save();

            ctrlChiTiet.Save();

=======
            // --- Lưu về CSDL ---
            ctrlPhieuBan.Save();
            ctrlChiTiet.Save();

            MessageBox.Show("Lưu phiếu bán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        }

        private void toolLuu_Them_Click(object sender, EventArgs e)
        {
            ctrlPhieuBan = new PhieuBanController();
            status = Controll.AddNew;
            txtMaPhieu.Text = ThamSo.LayMaPhieuBan().ToString();
            numTongTien.Value = 0;
            ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);
            this.Allow(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Le", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BindingSource bs = ((BindingSource)dgvDanhsachSP.DataSource);
                DataRowView row = (DataRowView)bs.Current;
                numTongTien.Value -= Convert.ToInt64(row["THANH_TIEN"]);
                deleted.Add(new MaSanPham(Convert.ToString(row["ID_MA_SAN_PHAM"]), Convert.ToInt32(row["SO_LUONG"])));
                bs.RemoveCurrent();
            }
           
=======
            string idSP = cmbSanPham.SelectedValue != null ? cmbSanPham.SelectedValue.ToString() : "";

            if (dgvDanhsachSP.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phiếu Bán Lẻ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idLo = dgvDanhsachSP.SelectedRows[0].Cells["colMaSanPham"].Value.ToString();
                    decimal soLuongXoa = Convert.ToDecimal(dgvDanhsachSP.SelectedRows[0].Cells["colSoLuong"].Value);

                    if (soLuongLo.ContainsKey(idLo))
                    {
                        soLuongLo[idLo] += soLuongXoa;
                    }

                    dgvDanhsachSP.Rows.Remove(dgvDanhsachSP.SelectedRows[0]);

                    // CẬP NHẬT: Gọi hàm tính tổng tiền
                    CapNhatTongTienVaCongNo();

                    if (!string.IsNullOrEmpty(idSP))
                    {
                        viTriLo[idSP] = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo");
            }
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        }

        private void dgvDanhsachSP_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Le", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                BindingSource bs = ((BindingSource)dgvDanhsachSP.DataSource);
                DataRowView row = (DataRowView)bs.Current;
<<<<<<< HEAD
                numTongTien.Value -= Convert.ToInt64(row["THANH_TIEN"]);
                deleted.Add(new MaSanPham(Convert.ToString(row["ID_MA_SAN_PHAM"]), Convert.ToInt32(row["SO_LUONG"])));

            }
        }

=======
                // CẬP NHẬT: Trừ tiền khỏi tổng
                numTongTien.Value -= Convert.ToDecimal(row["THANH_TIEN"]);
                deleted.Add(new MaSanPham(Convert.ToString(row["ID_MA_SAN_PHAM"]), Convert.ToInt32(row["SO_LUONG"])));
            }
        }

        // ... Các hàm khác giữ nguyên ...

        // CẬP NHẬT: Sửa lại hàm Allow
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

        // ... Các hàm còn lại giữ nguyên như cũ ...
        #region Các hàm không đổi
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        private void toolLuuIn_Click(object sender, EventArgs e)
        {
            if (status != Controll.Normal)
            {
                MessageBox.Show("Vui lòng lưu lại Phiếu bán hiện tại!", "Phieu Ban Le", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void toolChinhSua_Click(object sender, EventArgs e)
        {
            status = Controll.Edit;
            this.Allow(true);
        }

<<<<<<< HEAD
        void Allow(bool val)
        {
            txtMaPhieu.Enabled = val;
            dtNgayLapPhieu.Enabled = val;
            numTongTien.Enabled = val;
            btnAdd.Enabled = val;
            btnRemove.Enabled = val;
            dgvDanhsachSP.Enabled = val;
        }

=======
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
        private void toolThoat_Click(object sender, EventArgs e)
        {
            if (status != Controll.Normal)
            {
                if (MessageBox.Show("Bạn có muốn lưu lại Phiếu bán này không?", "Phieu Ban Le", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Luu();
                }
            }
            this.Close();
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            DataRowView view =  (DataRowView)bindingNavigator.BindingSource.Current;
=======
            DataRowView view = (DataRowView)bindingNavigator.BindingSource.Current;
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
            if (view != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Le", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                    IList<ChiTietPhieuBan> ds = ctrl.ChiTietPhieuBan(view["ID"].ToString());
                    foreach (ChiTietPhieuBan ct in ds)
                    {
<<<<<<< HEAD
                        CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(ct.MaSanPham.Id, ct.SoLuong);
=======
                        CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(ct.MaSanPham.Id, Convert.ToInt32(ct.SoLuong));
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
                    }
                    bindingNavigator.BindingSource.RemoveCurrent();
                    ctrlPhieuBan.Save();
                }
            }
        }

        private void btnThemDaiLy_Click(object sender, EventArgs e)
        {
            frmKhachHang KhachHang = new frmKhachHang();
            KhachHang.ShowDialog();
            ctrlKhachHang.HienthiAutoComboBox(cmbKhachHang, false);
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham SanPham = new frmSanPham();
            SanPham.ShowDialog();
            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
        }
<<<<<<< HEAD


     }
}
=======
        #endregion
    }
}
>>>>>>> 9fc2dac0940c4391e02e0d6a8da1c6c9eb2fc1c8
