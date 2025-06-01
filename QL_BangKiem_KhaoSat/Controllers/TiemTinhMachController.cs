using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class TiemTinhMachController : Controller
    {
        public IActionResult Index()
        {
            var cacBuocTienHanh = new List<BuocTienHanh>
        {
            new BuocTienHanh { STT = 1, MoTa = "Mang mâm đến giường" },
            new BuocTienHanh { STT = 2, MoTa = "Xác định chính xác người bệnh lần thứ 2" },
            new BuocTienHanh { STT = 3, MoTa = "Đặt người bệnh ở tư thế thích hợp" },
            new BuocTienHanh { STT = 4, MoTa = "Phơi bày vị trí tiêm, chọn vị trí tiêm" },
            new BuocTienHanh { STT = 5, MoTa = "Chọn tĩnh mạnh to, rõ, thẳng, ít di động" },
            new BuocTienHanh { STT = 6, MoTa = "Lót tấm cao su nơi tiêm ( nếu cần )" },
            new BuocTienHanh { STT = 7, MoTa = "Kê gối dưới chỗ tiêm ( nếu cần )" },
            new BuocTienHanh { STT = 8, MoTa = "Sát khuẩn tay bằng dung dịch rửa tay nhanh" },
            new BuocTienHanh { STT = 9, MoTa = "Mang găng tay" },
            new BuocTienHanh { STT = 10, MoTa = "Cột dây garo" },
            new BuocTienHanh { STT = 11, MoTa = "Bảo người bệnh nắm tay lại" },
            new BuocTienHanh { STT = 12, MoTa = "Sát khuẩn vị trí tiêm" },
            new BuocTienHanh { STT = 13, MoTa = "Đuổi khí trong ông tiêm" },
            new BuocTienHanh { STT = 14, MoTa = "Căng da phía dưới chỗ tĩnh mạch chọn tiêm, ngửa mặt vát của kim lên trên" },
            new BuocTienHanh { STT = 15, MoTa = "Đưa kim góc 15 - 30 so với mặt da, luồn vào tĩnh mạch 2/3 kim" },
            new BuocTienHanh { STT = 16, MoTa = "Kéo nhẹ nòng kiểm tra" },
            new BuocTienHanh { STT = 17, MoTa = "Mở dây garo và cho người bệnh buông tay ra" },
            new BuocTienHanh { STT = 18, MoTa = "Bơm thuốc từ từ và quan sát nét mặt người bệnh" },
            new BuocTienHanh { STT = 19, MoTa = "Hết thuốc rút kim ra" },
            new BuocTienHanh { STT = 20, MoTa = "Giúp người bệnh lại tiện nghi" },
            new BuocTienHanh { STT = 21, MoTa = "Tháo găng" },
            new BuocTienHanh { STT = 22, MoTa = "Dọn dẹp dụng cụ" }
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
