# Phần mềm "Cửa hàng Nông dược" — Hướng dẫn sử dụng

Phiên bản: README tạm thời cho module "Cửa hàng Nông dược"  
Thư mục liên quan trong repo: https://github.com/tpcuong/DoAn_KTPM/tree/main/Cuahang_Nongduoc/Cuahang%20Nongduoc

Mục đích của tài liệu này là hướng dẫn người dùng (quản trị viên, nhân viên bán hàng, người quản lý kho) cách sử dụng các chức năng chính của phần mềm quản lý cửa hàng nông dược. Tài liệu cũng bao gồm các chỉ dẫn cơ bản để khởi chạy ứng dụng — phần “Cài đặt & Khởi chạy” mang tính tổng quát; nếu bạn biết stack cụ thể (ví dụ Node.js, PHP, Java, v.v.) hãy bổ sung lệnh tương ứng trong phần cấu hình.

---

## Tổng quan chức năng chính
Phần mềm hỗ trợ các nghiệp vụ chính cho cửa hàng nông dược, thường bao gồm:
- Quản lý sản phẩm (thêm, sửa, xóa, quản lý danh mục)
- Quản lý nhà cung cấp
- Quản lý khách hàng
- Quản lý kho / tồn kho
- Nhập hàng (ghi nhận phiếu nhập, cập nhật tồn kho)
- Bán hàng (tạo đơn/bill, tính tiền, in hóa đơn)
- Báo cáo (doanh thu theo ngày/tháng, tồn kho, lãi lỗ)
- Tìm kiếm & lọc sản phẩm, đơn hàng, nhà cung cấp
- Quản lý người dùng & phân quyền

---

## Hướng dẫn sử dụng (User manual)

LƯU Ý: Tên menu/label có thể khác tuỳ theo hiện thực trong giao diện — dưới đây là hướng dẫn chung theo các thao tác phổ biến.

1. Đăng nhập / Đăng xuất
   - Mở ứng dụng và truy cập trang đăng nhập.
   - Nhập tài khoản đã được cấp (username/email và mật khẩu).
   - Sau khi đăng nhập thành công, bạn sẽ thấy Dashboard/tổng quan.

2. Dashboard (Tổng quan)
   - Hiển thị thông tin nhanh: doanh thu hôm nay/tuần/tháng, số đơn mới, cảnh báo tồn kho thấp.
   - Từ Dashboard bạn có thể điều hướng tới các chức năng chính (Sản phẩm, Nhập hàng, Bán hàng, Báo cáo).

3. Quản lý sản phẩm
   - Thêm sản phẩm mới: chọn “Thêm sản phẩm”, nhập mã, tên, danh mục, đơn vị, giá bán, giá nhập, mô tả, hình ảnh (nếu có), số lượng tồn ban đầu.
   - Sửa/Xóa: chọn sản phẩm trong danh sách -> Chỉnh sửa hoặc Xoá.
   - Danh mục: tạo/chi tiết hóa danh mục sản phẩm để dễ quản lý.

4. Quản lý nhà cung cấp
   - Thêm nhà cung cấp: tên, địa chỉ, số điện thoại, email, ghi chú.
   - Lưu trữ lịch sử nhập hàng liên quan đến nhà cung cấp.

5. Nhập hàng (Phiếu nhập)
   - Tạo phiếu nhập mới: chọn nhà cung cấp, chọn sản phẩm kèm số lượng, giá nhập, ghi chú.
   - Xác nhận phiếu nhập sẽ tăng tồn kho tương ứng.
   - Hỗ trợ theo dõi chi phí nhập hàng.

6. Bán hàng (Tạo đơn / Hóa đơn)
   - Tạo đơn bán: chọn khách hàng (hoặc khách vãng lai), thêm sản phẩm, điều chỉnh số lượng, áp mã giảm giá (nếu có).
   - Hệ thống tính tổng, VAT (nếu có), nợ/thu tiền.
   - In hóa đơn hoặc lưu lại lịch sử đơn.

7. Quản lý tồn kho
   - Xem tồn kho hiện tại theo sản phẩm/danh mục.
   - Cảnh báo sản phẩm tồn dưới ngưỡng tối thiểu.
   - Điều chỉnh tồn kho (nhập/xuất điều chỉnh) với lý do.

8. Báo cáo
   - Báo cáo doanh thu theo ngày/tuần/tháng.
   - Báo cáo tồn kho, hàng sắp hết.
   - Báo cáo lợi nhuận (doanh thu - giá vốn).
   - Lọc báo cáo theo khoảng thời gian, sản phẩm, nhà cung cấp, nhân viên bán hàng.

9. Tìm kiếm & Lọc
   - Sử dụng thanh tìm kiếm để tìm sản phẩm theo mã, tên.
   - Sử dụng bộ lọc để lọc theo danh mục, nhà cung cấp, khoảng giá, trạng thái tồn kho.

10. Quản trị & Phân quyền
    - Tạo tài khoản nhân viên với vai trò (Admin, Quản lý kho, Thu ngân, Kế toán).
    - Gán quyền truy cập phần mềm theo vai trò: ai được phép nhập hàng, ai được phép xóa đơn, v.v.

---

## Cài đặt & Khởi chạy (hướng dẫn chung)
Vì cấu trúc cụ thể (ngôn ngữ, framework) có thể khác nhau, dưới đây là các bước tổng quát để thiết lập môi trường. Vui lòng kiểm tra file cấu hình trong repo (ví dụ: package.json, composer.json, requirements.txt, pom.xml, Readme hiện có trong thư mục) để biết chính xác stack.

1. Lấy mã nguồn
   - git clone https://github.com/tpcuong/DoAn_KTPM.git
   - Đi tới thư mục module: `Cuahang_Nongduoc/Cuahang Nongduoc`

2. Kiểm tra stack và cài đặt phụ thuộc
   - Node.js: nếu có file package.json
     - cài Node.js, sau đó: `npm install` hoặc `yarn install`
   - PHP: nếu có file composer.json
     - cài Composer, sau đó: `composer install`
   - Python: nếu có requirements.txt
     - tạo virtualenv, `pip install -r requirements.txt`
   - Java (Maven/Gradle): check pom.xml hoặc build.gradle

3. Cấu hình cơ sở dữ liệu
   - Tạo database (MySQL/Postgres/SQLite tuỳ dự án).
   - Tìm file cấu hình (ví dụ .env, config.php, application.properties) và cập nhật thông tin DB (host, user, password, dbname).
   - Nếu có file migration hoặc script SQL, chạy để tạo bảng:
     - ví dụ: `php artisan migrate` (Laravel) hoặc `npm run migrate` hoặc chạy file .sql trong MySQL.

4. Khởi động ứng dụng


5. Truy cập giao diện
   - Mở trình duyệt, truy cập: http://localhost:PORT (PORT tuỳ cấu hình, mặc định thường 3000/8000/8080)

6. Thiết lập ban đầu
   - Tạo tài khoản admin đầu tiên (thông qua seed, script hoặc form đăng ký).
   - Nhập danh mục và một số sản phẩm mẫu để kiểm tra.



---

## Tài liệu thêm & Liên hệ
- Tham khảo mã nguồn trong thư mục: Cuahang_Nongduoc/Cuahang Nongduoc
  - Link: https://github.com/tpcuong/DoAn_KTPM/tree/main/Cuahang_Nongduoc/Cuahang%20Nongduoc


Cảm ơn bạn — nếu muốn mình chuyển nội dung README này thành file thực tế trong repo (README.md), gửi yêu cầu rõ ràng và cho biết nơi muốn đặt (root repo hoặc trong thư mục module).
