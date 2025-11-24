Phần mềm Cửa hàng Nông dược — Hướng dẫn sử dụng

Mục đích: Tài liệu này hướng dẫn cách sử dụng các chức năng chính của module "Cửa hàng Nông dược" (quản trị viên, nhân viên bán hàng, quản lý kho) và mô tả nhanh cách cài đặt, cấu hình để chạy ứng dụng.

Tổng quan chức năng chính
- Quản lý sản phẩm: thêm/sửa/xóa sản phẩm, quản lý danh mục, hình ảnh, đơn vị tính, giá bán/giá nhập.
- Quản lý nhà cung cấp: lưu thông tin nhà cung cấp và lịch sử nhập hàng.
- Quản lý khách hàng: thông tin khách hàng, theo dõi công nợ.
- Quản lý kho / tồn kho: theo dõi tồn kho, cảnh báo tồn kho thấp, điều chỉnh tồn kho.
- Nhập hàng: tạo và xác nhận phiếu nhập, cập nhật tồn kho, ghi nhận chi phí.
- Bán hàng: tạo đơn/hóa đơn, tính tiền, VAT, áp mã giảm giá, in hóa đơn, quản lý thu/chi.
- Báo cáo: doanh thu, tồn kho, lợi nhuận theo khoảng thời gian, bộ lọc theo sản phẩm/nhà cung cấp/nhân viên.
- Tìm kiếm & lọc: tìm nhanh sản phẩm theo mã/tên, lọc theo danh mục/nhà cung cấp/giá/trạng thái.
- Quản lý người dùng & phân quyền: tạo tài khoản nhân viên, gán vai trò (Admin, Quản lý kho, Thu ngân, Kế toán).

Hướng dẫn sử dụng (User manual)
LƯU Ý: Tên menu/label có thể khác tuỳ theo giao diện cài đặt. Dưới đây là các thao tác phổ biến:

1. Đăng nhập / Đăng xuất
- Mở ứng dụng, truy cập trang đăng nhập.
- Nhập tài khoản (username/email) và mật khẩu.
- Sau khi đăng nhập, vào Dashboard/tổng quan.

2. Dashboard (Tổng quan)
- Hiển thị doanh thu hôm nay/tuần/tháng, số đơn hàng mới, cảnh báo tồn kho thấp.
- Điều hướng nhanh tới Sản phẩm, Nhập hàng, Bán hàng, Báo cáo.

3. Quản lý sản phẩm
- Thêm sản phẩm: nhập mã, tên, danh mục, đơn vị, giá nhập, giá bán, mô tả, hình ảnh, tồn kho ban đầu.
- Sửa/Xóa: chọn sản phẩm trong danh sách → Chỉnh sửa hoặc Xóa.
- Quản lý danh mục: tạo/điều chỉnh danh mục để tổ chức sản phẩm.

4. Quản lý nhà cung cấp
- Thêm nhà cung cấp: tên, địa chỉ, điện thoại, email, ghi chú.
- Theo dõi lịch sử nhập hàng theo nhà cung cấp.

5. Nhập hàng (Phiếu nhập)
- Tạo phiếu nhập: chọn nhà cung cấp, thêm sản phẩm, số lượng, giá nhập, ghi chú.
- Xác nhận phiếu nhập để cập nhật tồn kho và chi phí.
- Lưu trữ và tra cứu lịch sử phiếu nhập.

6. Bán hàng (Tạo đơn / Hóa đơn)
- Tạo đơn bán: chọn/khởi tạo khách hàng, thêm sản phẩm, điều chỉnh số lượng.
- Hệ thống tính tổng, VAT, áp mã giảm giá, xử lý thu/ghi nợ.
- In hoặc lưu hóa đơn, xem lịch sử đơn hàng.

7. Quản lý tồn kho
- Xem tồn kho hiện tại theo sản phẩm/danh mục.
- Thiết lập ngưỡng tồn tối thiểu để nhận cảnh báo.
- Điều chỉnh tồn kho (nhập/xuất điều chỉnh) kèm lý do và ghi chú.

8. Báo cáo
- Các báo cáo cơ bản: doanh thu theo ngày/tuần/tháng, tồn kho, lợi nhuận.
- Lọc báo cáo theo khoảng thời gian, sản phẩm, nhà cung cấp, nhân viên bán hàng.

9. Tìm kiếm & Lọc
- Tìm nhanh theo mã, tên sản phẩm.
- Lọc theo danh mục, nhà cung cấp, khoảng giá, trạng thái tồn kho.

10. Quản trị & Phân quyền
- Tạo tài khoản nhân viên với vai trò khác nhau.
- Gán quyền: ai được phép nhập hàng, tạo/xóa đơn, xem báo cáo tài chính, v.v.

Cài đặt & Khởi chạy (hướng dẫn tổng quát)
Lưu ý: Hướng dẫn dưới đây mang tính chung; dự án cụ thể có thể sử dụng Node/PHP/Python/Java. Xem thư mục Cuahang_Nongduoc để biết chi tiết cài đặt của module.

1. Lấy mã nguồn
- git clone https://github.com/tpcuong/DoAn_KTPM.git
- Chuyển tới thư mục module: Cuahang_Nongduoc/Cuahang Nongduoc

2. Kiểm tra stack và cài đặt phụ thuộc
- Node.js: nếu có package.json → npm install hoặc yarn install
- PHP (Laravel): nếu có composer.json → composer install
- Python: nếu có requirements.txt → pip install -r requirements.txt (tốt nhất dùng virtualenv)
- Java: kiểm tra pom.xml hoặc build.gradle và thực hiện build tương ứng

3. Cấu hình cơ sở dữ liệu
- Tạo database (MySQL/Postgres/SQLite tuỳ dự án).
- Tìm file cấu hình (.env, config.php, application.properties, v.v.) và chỉnh host, user, password, dbname.
- Chạy migration hoặc import file SQL nếu có:
  - Ví dụ Laravel: php artisan migrate --seed
  - Hoặc chạy file .sql trong MySQL.

4. Khởi động ứng dụng
- Node: npm run start / npm run dev
- PHP: php artisan serve hoặc triển khai trên Apache/Nginx
- Python: flask run / uvicorn / django runserver
- Java: mvn spring-boot:run hoặc build jar và chạy

5. Truy cập giao diện
- Mở trình duyệt và truy cập http://localhost:PORT (PORT tham chiếu trong cấu hình, ví dụ 3000/8000/8080).

6. Thiết lập ban đầu
- Tạo tài khoản admin (thông qua seed hoặc form đăng ký).
- Nhập danh mục và vài sản phẩm mẫu để kiểm tra tính năng.

Bảo trì, sao lưu và khôi phục
- Sao lưu định kỳ cơ sở dữ liệu (dump SQL).
- Sao lưu file cấu hình quan trọng (.env) và file media (hình ảnh sản phẩm).
- Trước khi nâng cấp hoặc chạy migration, thực hiện backup để khả năng rollback.

Vấn đề thường gặp & Khắc phục nhanh
- Lỗi kết nối DB: kiểm tra thông tin trong file cấu hình (.env), đảm bảo DB server đang chạy và cổng đúng.
- Thiếu dependencies: kiểm tra file lock (package-lock.json / composer.lock) và chạy lại lệnh cài đặt.
- Lỗi migration: kiểm tra phiên bản migration đã chạy, rollback nếu cần và chạy lại.

Tham khảo mã nguồn
- Thư mục module liên quan: Cuahang_Nongduoc/Cuahang Nongduoc
- Link: https://github.com/tpcuong/DoAn_KTPM/tree/main/Cuahang_Nongduoc/Cuahang%20Nongduoc

Liên hệ & Hỗ trợ
- Nếu cần cập nhật README trực tiếp trong repo hoặc muốn tôi tạo file README.md thay thế nội dung hiện tại, vui lòng xác nhận rõ vị trí (root hoặc trong thư mục module) và nội dung cụ thể cần thay đổi.

Cảm ơn — chúc bạn triển khai và sử dụng phần mềm hiệu quả.
