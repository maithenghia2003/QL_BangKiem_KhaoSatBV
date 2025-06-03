using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class XacDinhNguoiBenhController : Controller
    {
        public IActionResult Index()
        {
        var viewModel = new XacDinhNguoiBenh
        {
            CacYeuTo = new List<YeuToXacDinh>
            {
                new YeuToXacDinh { STT = 1, NoiDung = "Họ tên người bệnh" },
                new YeuToXacDinh { STT = 2, NoiDung = "Năm sinh/ tuổi" },
                new YeuToXacDinh { STT = 3, NoiDung = "Địa chỉ" },
                new YeuToXacDinh { STT = 4, NoiDung = "Giới tính" },
                new YeuToXacDinh { STT = 5, NoiDung = "Mã số người bệnh" },
                new YeuToXacDinh { STT = 6, NoiDung = "Vòng tay định danh" }
            },
            // Khởi tạo các thuộc tính thời điểm đánh giá với giá trị mặc định (false)
            ThoiDiemDanhGia_TiepNhan = false,
            ThoiDiemDanhGia_TuVan = false,
            ThoiDiemDanhGia_ThanhToan = false,
            ThoiDiemDanhGia_ThuPhiCLS = false,
            ThoiDiemDanhGia_CapPhatThuoc = false,
            ThoiDiemDanhGia_CapPhatToaThuoc = false,
            ThoiDiemDanhGia_CapPhieuHen = false,
            ThoiDiemDanhGia_ThucHienCLS = false,
            ThoiDiemDanhGia_CapPhatChiDinhCLS = false,
            ThoiDiemDanhGia_TraKetQuaCLS = false,
            ThoiDiemDanhGia_ThucHienKyThuat = false,
            ThoiDiemDanhGia_ThucHienThuThuat = false,
            ThoiDiemDanhGia_ThucHienPhauThuat = false,
            ThoiDiemDanhGia_ThucHienCLSKhac = false,
            ThoiDiemDanhGia_NhapVien = false,
            ThoiDiemDanhGia_ChuyenKhoa = false,
            ThoiDiemDanhGia_ChuyenVien = false,
            ThoiDiemDanhGia_XuatVien = false
        };
        return View(viewModel);
    }

    [HttpPost]
        public IActionResult LuuKetQua(XacDinhNguoiBenh model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý dữ liệu model.ThoiDiemDanhGia_... (các checkbox được chọn sẽ là true)
                // Xử lý dữ liệu model.TenNVYT1 và model.TenNVYT2
                // Xử lý dữ liệu model.CacYeuTo (lưu KetQuaNVYT1 và KetQuaNVYT2 cho từng yếu tố)
                // Xử lý dữ liệu model.KetLuanNVYT1 và model.KetLuanNVYT2

                // Ví dụ: Lưu vào database
                // var bangKiem = new XacDinhNguoiBenh
                // {
                //    TenNVYT1 = model.TenNVYT1,
                //    TenNVYT2 = model.TenNVYT2,
                //    // ... các thuộc tính khác ...
                // };
                // _dbContext.XacDinhNguoiBenhs.Add(bangKiem);
                // _dbContext.YeuToXacDinhs.AddRange(model.CacYeuTo); // Nếu lưu riêng
                // _dbContext.SaveChanges();

                return RedirectToAction("Index"); // Hoặc trang thành công
            }
            // Nếu model không hợp lệ, trả về view với lỗi
            return View(model);
        }
    }
}
