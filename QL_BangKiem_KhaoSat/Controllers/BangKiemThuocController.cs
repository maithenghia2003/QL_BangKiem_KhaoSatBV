using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class BangKiemThuocController : Controller
    {
        public IActionResult Index()
        {
        var viewModel = new XacDinhBangKiem
        {
            CacYeuTo = new List<YeuToXacDinh>
            {
                new YeuToXacDinh { STT = 1, NoiDung = "Đúng người bệnh" },
                new YeuToXacDinh { STT = 2, NoiDung = "Đúng thuốc" },
                new YeuToXacDinh { STT = 3, NoiDung = "Đúng liều dùng" },
                new YeuToXacDinh { STT = 4, NoiDung = "Đúng đường dùng" },
                new YeuToXacDinh { STT = 5, NoiDung = "Đúng thời gian" }
            },
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
                // var bangKiem = new CapPhatThuoc
                // {
                //    TenNVYT1 = model.TenNVYT1,
                //    TenNVYT2 = model.TenNVYT2,
                //    // ... các thuộc tính khác ...
                // };
                // _dbContext.CapPhatThuocs.Add(bangKiem);
                // _dbContext.YeuToCapPhatThuocs.AddRange(model.CacYeuTo); // Nếu lưu riêng
                // _dbContext.SaveChanges();

                return RedirectToAction("Index"); // Hoặc trang thành công
            }
            return View(model);
        }
    }
}
