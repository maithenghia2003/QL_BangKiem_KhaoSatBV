using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class GiamSatController : Controller
    {
        public IActionResult Index()
        {
            var cacBuocTienHanh = new List<BuocTienHanh>
        {
            new BuocTienHanh { STT = 1, MoTa = "Điều dưỡng trình bày được quy định về chỉ định và thực hiện y lệnh miệng" },
            new BuocTienHanh { STT = 2, MoTa = "Điều dưỡng hỏi tiền sử dị ứng ngay trước khi dùng thuốc kháng sinh lần đầu cho NB và ghi vào HSBA" },
            new BuocTienHanh { STT = 3, MoTa = "Trên xe tiêm của điều dưỡng luôn có sẵn hộp thuốc chống sốc" },
            new BuocTienHanh { STT = 4, MoTa = "Điều dưỡng chuẩn bị đủ các túi đựng thuốc uống theo giờ cho người bệnh. (có ghi rõ ngày giờ và định danh người bệnh theo ba yếu tố)." },
            new BuocTienHanh { STT = 5, MoTa = "Người bệnh đúng dùng thuốc theo chỉ định của bác sĩ" },
            new BuocTienHanh { STT = 6, MoTa = "Người bệnh được dùng thuốc đúng liều theo chỉ định của bác sĩ" },
            new BuocTienHanh { STT = 7, MoTa = "Người bệnh chậm sốc cấp II, III được dùng thuốc đúng thời gian theo chỉ định của bác sĩ." },
            new BuocTienHanh { STT = 8, MoTa = "Người bệnh được uống thuốc trước sự chứng kiến của điều dưỡng" },
            new BuocTienHanh { STT = 9, MoTa = "Điều dưỡng có công khai thuốc cho người bệnh ký tên khi dùng thuốc" }
        };

            // Truyền model chứa danh sách các bước và có thể cả GhiChu (nếu bạn muốn hiển thị lại ghi chú đã lưu)
            var model = new GiamSat
            {
                CacBuocTienHanh = cacBuocTienHanh,
                GhiChu = "" // Khởi tạo ghi chú trống
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult LuuKetQua(List<KetQuaBuocTienHanh> ketQua, string ghiChu)
        {
            // Logic lưu kết quả đánh giá và ghi chú
            // Lưu danh sách ketQua vào database hoặc nơi lưu trữ
            // Lưu chuỗi ghiChu vào database hoặc nơi lưu trữ

            // Ví dụ:
            // _dbContext.KetQuaGiamSatNguoiBenh.AddRange(ketQua);
            // var giamSat = new GiamSatNguoiBenh { GhiChu = ghiChu, /* Các thông tin khác */ };
            // _dbContext.GiamSatNguoiBenhs.Add(giamSat);
            // _dbContext.SaveChanges();

            return Json(new { success = true });
        }
    }
}
