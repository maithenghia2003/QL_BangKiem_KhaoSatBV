using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class TiemDuoiBapController : Controller
    {
        public IActionResult Index()
        {
            var cacBuocTienHanh = new List<BuocTienHanh>
        {
            new BuocTienHanh { STT = 1, MoTa = "Mang mâm đến giường" },
            new BuocTienHanh { STT = 2, MoTa = "Xác định chính xác người bệnh lần thứ 2" },
            new BuocTienHanh { STT = 3, MoTa = "Đặt người bệnh ở tư thế thích hợp" },
            new BuocTienHanh { STT = 4, MoTa = "Phơi bày vị trí tiêm, chọn vị trí tiêm" },
            new BuocTienHanh { STT = 5, MoTa = "Sát khuẩn tay bằng dung dịch rửa tay nhanh" },
            new BuocTienHanh { STT = 6, MoTa = "Sát khuẩn vị trí tiêm" },
            new BuocTienHanh { STT = 7, MoTa = "Đuổi khí trong ông tiêm" },
            new BuocTienHanh { STT = 8, MoTa = "Căng da nơi tiêm" },
            new BuocTienHanh { STT = 9, MoTa = "Đưa kim góc 45 - 60 tiêm bắp nông " +
                                               "Góc 90 tiêm bắp sâu" },
            new BuocTienHanh { STT = 10, MoTa = "Kéo nhẹ nòng kiểm tra" },
            new BuocTienHanh { STT = 11, MoTa = "Bơm thuốc từ từ và quan sát nét mặt người bệnh" },
            new BuocTienHanh { STT = 12, MoTa = "Hết thuốc rút kim ra" },
            new BuocTienHanh { STT = 13, MoTa = "Giúp người bệnh lại tiện nghi" },
            new BuocTienHanh { STT = 14, MoTa = "Dọn dẹp dụng cụ" }
        };

            // Truyền danh sách các bước đến View
            return View(cacBuocTienHanh);
        }
        [HttpPost]
        public IActionResult LuuKetQua(List<KetQuaBuocTienHanh> ketQua)
        {
            // Xử lý việc lưu kết quả vào database hoặc nơi lưu trữ khác
            // ...

            return Json(new { success = true }); // Trả về JSON thông báo thành công
        }
    }
}
