# Hướng dẫn sử dụng — Module "Cửa hàng Nông dược"

LƯU Ý QUAN TRỌNG
- Nội dung trong README này được soạn dựa trên mã nguồn hiện có trong thư mục `Cuahang_Nongduoc/Cuahang Nongduoc` của repo. Mình chỉ ghi những gì thực sự tồn tại trong mã (tên file, cấu trúc thư mục, form, các phần chính). Mình không thêm thông tin chức năng chi tiết nếu không thể xác minh từ mã.
- Danh sách file và thư mục được thu thập từ kho — có khả năng danh sách này không hoàn toàn đầy đủ do giới hạn truy vấn. Để xem toàn bộ mã nguồn, mở link repo trực tiếp:
  https://github.com/tpcuong/DoAn_KTPM/tree/main/Cuahang_Nongduoc/Cuahang%20Nongduoc

1) Tổng quan kỹ thuật nhanh (những gì nhìn thấy trong repo)
- Ngôn ngữ chính: C# (nhiều file .cs, .csproj, .sln).
- Dự án: WinForms (nhiều file `*.Designer.cs`, `*.resx` → giao diện Forms).
- Solution / Project:
  - CuahangNongDuoc.sln
  - CuahangNongduoc.csproj
- Cấu hình: có file `app.config`.
- Thư mục mã tổ chức theo chức năng:
  - BusinessObject
  - Controller
  - DataLayer
  - DataSet
  - Report, Resources, SqlServerTypes
- Một số file nguồn/Forms chính (đặt tên theo file thực tế trong repo):
  - frmMain, frmDangNhap (đăng nhập), frmNguoiDung (quản lý người dùng)
  - frmSanPham (sản phẩm), frmNhaCungCap (nhà cung cấp), frmKhachHang (khách hàng)
  - frmNhapHang (phiếu nhập), frmDanhsachPhieuNhap (danh sách phiếu nhập)
  - frmBanLe, frmBanSi (bán lẻ / bán sỉ), frmDanhsachPhieuBanLe, frmDanhsachPhieuBanSi
  - frmThanhToan, frmPhieuChi, frmDunoKhachhang
  - frmDoanhThu (báo cáo doanh thu), nhiều form in/Report: frmInPhieuBan, frmInPhieuNhap, ...
  - frmSoLuongTon, frmSoLuongBan, frmSanphamHethan (hàng hết hạn)
- Các file hỗ trợ/tiện ích: DataService.cs (xử lý dữ liệu), Num2Str.cs, ThamSo.cs, Settings.cs.
- Có `packages.config` và thư mục `packages` → dùng NuGet (dự án .NET Framework).

2) Yêu cầu môi trường (dựa trên mã hiện có)
- Visual Studio (phiên bản hỗ trợ dự án .sln/.csproj — Visual Studio 2015/2017/2019/2022 đều có thể mở .sln; đảm bảo hỗ trợ .NET Framework/WinForms).
- SQL Server (hoặc SQL Server Express / LocalDB) — trong repo có thư mục `SqlServerTypes` và tên file/structure cho thấy sử dụng SQL Server.
- NuGet để khôi phục packages (dự án có packages.config).

3) Cài đặt, cấu hình và chạy (chỉ ghi những bước cần làm; không thêm script DB nếu không có)
- Bước 1 — Lấy mã nguồn:
  - git clone https://github.com/tpcuong/DoAn_KTPM.git
  - Mở thư mục: `Cuahang_Nongduoc/Cuahang Nongduoc`
- Bước 2 — Mở solution:
  - Mở file `CuahangNongDuoc.sln` bằng Visual Studio.
- Bước 3 — Khôi phục NuGet packages:
  - Trong Visual Studio: chuột phải solution → Restore NuGet Packages (hoặc Tools → NuGet Package Manager → Restore).
- Bước 4 — Cấu hình kết nối cơ sở dữ liệu:
  - Mở file `app.config` trong project để tìm và sửa connection string (nếu có). Nếu không thấy connection string rõ ràng, mở file `DataService.cs` (nằm ở gốc project) để xem cách chương trình lấy chuỗi kết nối — sửa tương ứng để trỏ tới SQL Server của bạn.
  - Tạo cơ sở dữ liệu SQL Server mới để dùng cho ứng dụng (tên/structure phụ thuộc vào schema chương trình). Trong repo mình không tìm thấy file `.sql` chứa script tạo schema (nếu bạn có script riêng, import vào DB).
  - Nếu dự án sử dụng DataSet/Tables trong thư mục `DataSet`, bạn có thể kiểm tra các DataTable để biết bảng/cột nhưng có thể cần script SQL để tạo bảng thực sự.
- Bước 5 — Build:
  - Chọn chế độ Debug hoặc Release → Build Solution.
- Bước 6 — Chạy:
  - Chạy project (F5). Ứng dụng dạng WinForms sẽ khởi chạy. Đăng nhập bằng tài khoản có sẵn (nếu DB đã có dữ liệu) hoặc thực hiện seed/đăng ký nếu ứng dụng cung cấp.

4) Hướng dẫn người dùng (dựa trên các form thực tế trong mã)
Phần này mô tả các chức năng *có khả năng* tương ứng với tên form — mình trình bày theo tên form để bạn đối chiếu trực tiếp trong giao diện:

- Đăng nhập:
  - Form: frmDangNhap
  - Mục đích: xác thực người dùng trước khi vào hệ thống (nhìn thấy form đăng nhập trong mã).
- Màn hình chính:
  - Form: frmMain
  - Chứa menu điều hướng đến các chức năng: Sản phẩm, Nhập hàng, Bán hàng, Báo cáo, Người dùng, v.v.
- Quản lý sản phẩm:
  - Form: frmSanPham
  - Chức năng thường có: Thêm / Sửa / Xoá sản phẩm, quản lý danh mục, đơn vị tính (có frmDonViTinh).
- Nhập hàng:
  - Form: frmNhapHang, frmDanhsachPhieuNhap
  - Tạo phiếu nhập mới, chọn nhà cung cấp (frmNhaCungCap), cập nhật tồn kho.
- Bán hàng:
  - Form: frmBanLe (bán lẻ), frmBanSi (bán sỉ), frmDanhsachPhieuBanLe / frmDanhsachPhieuBanSi
  - Tạo hóa đơn, thêm sản phẩm vào hóa đơn, xử lý thanh toán (frmThanhToan), in hóa đơn (frmInPhieuBan).
- Khách hàng / Nhà cung cấp:
  - Form: frmKhachHang, frmNhaCungCap
  - Quản lý thông tin, nợ (frmDunoKhachhang), in nợ (frmInDunoKhachHang)
- Kho / Tồn kho:
  - Form: frmSoLuongTon (xem tồn), frmSoLuongBan (báo cáo số lượng bán), frmSanphamHethan (sản phẩm hết hạn)
- Báo cáo & Doanh thu:
  - Form: frmDoanhThu và nhiều form in/Report trong thư mục `Report` hoặc `frmIn*` để xuất/chuẩn bị in báo cáo/hóa đơn.
- Người dùng và phân quyền:
  - Form: frmNguoiDung
  - Quản lý tài khoản người dùng (tạo, sửa, phân quyền).
- Thông tin cửa hàng:
  - Form: frmThongtinCuahang
  - Lưu cấu hình thông tin cửa hàng (tên, địa chỉ, điện thoại).
- Các tiện ích khác:
  - frmPhieuChi (ghi nhận chi), frmTimPhieu* (tìm phiếu), frmLyDoChi (lý do chi) — hỗ trợ nghiệp vụ kế toán/thu chi.

Ghi chú: Các bước thao tác cụ thể (nút bấm, label chính xác, luồng dữ liệu) phụ thuộc vào giao diện thực tế khi chạy ứng dụng; vì vậy phần hướng dẫn thao tác chi tiết trên từng màn hình bạn nên kiểm tra trực tiếp giao diện khi ứng dụng chạy.

5) Kiểm tra mã nguồn để biết chi tiết kỹ thuật (nên làm)
- Mở `DataService.cs` để xem cách ứng dụng kết nối và thực hiện truy vấn với SQL Server. Đây là nơi bạn sẽ biết:
  - Tên chuỗi kết nối mà chương trình sử dụng.
  - Kiểu truy vấn (Stored Procedure hay trực tiếp ADO.NET).
- Kiểm tra thư mục `DataLayer` và `BusinessObject` để hiểu cấu trúc lớp, cách thao tác với dữ liệu (DAO/BLL).
- Nếu cần phục hồi schema DB: tìm trong `DataSet` các .xsd hoặc DataTable để tham khảo cấu trúc bảng; nếu không có script .sql thì bạn phải tạo DB thủ công theo cấu trúc ứng dụng hoặc cung cấp file SQL nếu bạn có.

6) Triển khai (ghi ngắn)
- Để đưa ứng dụng lên máy khác: build ở chế độ Release, copy file exe + thư mục bin kèm các DLL, đảm bảo máy đích có .NET Framework tương thích và quyền truy cập tới SQL Server.
- Bạn cũng có thể tạo installer (không có sẵn trong repo).

7) Khắc phục lỗi thường gặp
- Lỗi kết nối DB:
  - Kiểm tra `app.config` / `DataService.cs` để biết chuỗi kết nối hiện tại, đảm bảo SQL Server đang chạy và user/password đúng.
- Thiếu NuGet package:
  - Restore package từ Visual Studio.
- Lỗi khi build:
  - Kiểm tra phiên bản .NET Framework mục tiêu trong `.csproj` — nếu máy bạn thiếu version, cài đặt hoặc chỉnh mục tiêu framework.

8) Những chỗ cần bạn bổ sung để README hoàn chỉnh
Để mình có thể hoàn thiện README với các hướng dẫn chính xác (không suy đoán), bạn vui lòng cung cấp / hoặc cập nhật:
- Nội dung của file `app.config` (hoặc ít nhất tên của chuỗi kết nối hiện dùng).
- Nếu có file SQL tạo schema (tệp .sql), upload hoặc chỉ vị trí file đó trong repo.
- Phiên bản .NET Framework mục tiêu (mở `.csproj` để đọc thông tin này hoặc gửi nội dung).
- Nếu muốn mình tạo README tại root hay trong thư mục module, cho biết vị trí mong muốn.

---

Nếu bạn muốn, mình sẽ:
- Soạn README chi tiết và chính xác (bằng tiếng Việt) đặt vào `Cuahang_Nongduoc/Cuahang Nongduoc/README.md` dựa trên file `app.config` và (nếu có) script SQL mà bạn cung cấp. Mình sẽ chỉ ghi thông tin có thực trong repo và những hướng dẫn cấu hình/khởi chạy chính xác dựa trên dữ liệu bạn gửi.
