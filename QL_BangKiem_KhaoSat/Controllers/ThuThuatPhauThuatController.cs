using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class ThuThuatPhauThuatController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new XacDinhBangKiem
            {
                CacYeuTo = new List<YeuToXacDinh>
            {
                new YeuToXacDinh { STT = 1, NoiDung = "Đúng người bệnh" },
                // Các mục con cho "Đúng người bệnh" sẽ được xử lý logic trong View
                new YeuToXacDinh { STT = 0, NoiDung = "a. Họ tên người bệnh" }, // STT 0 để phân biệt với mục chính và không hiển thị STT trong bảng
                new YeuToXacDinh { STT = 0, NoiDung = "b. Năm sinh / tuổi" },
                new YeuToXacDinh { STT = 0, NoiDung = "c. Địa chỉ" },
                new YeuToXacDinh { STT = 0, NoiDung = "d. Giới tính" },
                new YeuToXacDinh { STT = 0, NoiDung = "e. Mã số người bệnh" },
                new YeuToXacDinh { STT = 2, NoiDung = "Đúng vị trí" },
                new YeuToXacDinh { STT = 3, NoiDung = "Đúng phương pháp" }
            }
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult LuuKetQua(XacDinhBangKiem model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý dữ liệu model.TenNVYT1 và model.TenNVYT2
                // Xử lý dữ liệu model.CacYeuTo (lưu KetQuaNVYT1 và KetQuaNVYT2 cho từng yếu tố)
                // Xử lý dữ liệu model.KetLuanDungNguoiBenhNVYT1 và model.KetLuanDungNguoiBenhNVYT2

                // Ví dụ: Lưu vào database
                // var bangKiem = new ThuThuatPhauThuat
                // {
                //    TenNVYT1 = model.TenNVYT1,
                //    TenNVYT2 = model.TenNVYT2,
                //    // ... ánh xạ các thuộc tính khác từ model ...
                // };
                // _dbContext.ThuThuatPhauThuats.Add(bangKiem);
                // _dbContext.ItemDanhGias.AddRange(model.CacYeuTo); // Nếu lưu riêng
                // _dbContext.SaveChanges();

                return RedirectToAction("Index"); // Hoặc trang thành công
            }
            return View(model);
        }
    }
}
