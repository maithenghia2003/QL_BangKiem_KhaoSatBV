using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class ThayBangOngDanRutOngController : Controller
    {
        public IActionResult Index()
        {
            var cacBuocTienHanh = new List<BuocTienHanh>
        {
            new BuocTienHanh { STT = 1, MoTa = "Xác định chính xác người bệnh lần thứ 2 (Chú ý 5 đúng)" },
            new BuocTienHanh { STT = 2, MoTa = "Chuẩn bị tư thế bệnh nhân thích hợp" },
            new BuocTienHanh { STT = 3, MoTa = "Để mâm nơi thuận tiện, gần vết thương" },
            new BuocTienHanh { STT = 4, MoTa = "Phơi bày vết thương, tháo băng keo" },
            new BuocTienHanh { STT = 5, MoTa = "Đặt tấm lót dưới vết thương(nếu cần)" },
            new BuocTienHanh { STT = 6, MoTa = "Gỡ băng keo phần còn lại" },
            new BuocTienHanh { STT = 7, MoTa = "Sát khuẩn tay nhanh" },
            new BuocTienHanh { STT = 8, MoTa = "Mở khăn vô khuẩn đậy mâm ra" },
            new BuocTienHanh { STT = 9, MoTa = "Mang găng tay" },
            new BuocTienHanh { STT = 10, MoTa = "Gỡ bỏ băng dơ bằng kềm sạch" },
            new BuocTienHanh { STT = 11, MoTa = "Rửa ống dẫn lưu: chân ống → thân ống → miệng ống → vùng da xung quanh ống dẫn lưu rộng ra 5cm (chú ý tiếp liệu theo nguyên tắc vô khuẩn)" },
            new BuocTienHanh { STT = 12, MoTa = "Cắt mối may" },
            new BuocTienHanh { STT = 13, MoTa = "Xoay ống qua lại cho ống không còn dính chặt vào da. Sau đó vừa xoay vừa rút lên từ từ cho đến hết." },
            new BuocTienHanh { STT = 14, MoTa = "Rửa ngay miệng vết thương nặn dịch" },
            new BuocTienHanh { STT = 15, MoTa = "Rửa bên trong vết thương bằng tăm vịch" },
            new BuocTienHanh { STT = 16, MoTa = "Rửa ngay miệng vết thương và vùng da xung quanh miệng vết thương 5cm" },
            new BuocTienHanh { STT = 17, MoTa = "Lau khô vùng da xung quanh ống ống còn cồn iode 0,1%" },
            new BuocTienHanh { STT = 18, MoTa = "Nhét dẫn lưu bằng tim vải (nếu cần)" },
            new BuocTienHanh { STT = 19, MoTa = "Đắp gòn bao che kín vết thương và bao quanh thân ống (chú ý gạc phải che kín vết thương và ra xung quanh khoảng 3cm)" },
            new BuocTienHanh { STT = 20, MoTa = "Tháo găng tay" },
            new BuocTienHanh { STT = 21, MoTa = "Dán băng keo lên vết thương (chú ý dán kín các mép gạc, tránh để hở)" },
            new BuocTienHanh { STT = 22, MoTa = "Quan sát người bệnh trong suốt thời gian thay băng" },
            new BuocTienHanh { STT = 23, MoTa = "Báo và giải thích cho người bệnh việc đã xong, giúp người bệnh tiện nghi." },
            new BuocTienHanh { STT = 24, MoTa = "Phân loại chất thải y tế theo quy định" },
            new BuocTienHanh { STT = 25, MoTa = "Thu dọn dụng cụ mang về phòng" }
        };

            return View(cacBuocTienHanh); // Giả sử bạn dùng chung View hoặc có View tương tự
        }

        [HttpPost]
        public IActionResult LuuKetQua(List<KetQuaBuocTienHanh> ketQua)
        {
            // Logic lưu kết quả cho bảng kiểm thay băng ống dẫn lưu có rút ống
            // ...
            return Json(new { success = true });
        }
    }
}
