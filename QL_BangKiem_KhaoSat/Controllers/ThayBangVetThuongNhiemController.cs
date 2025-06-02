using Microsoft.AspNetCore.Mvc;
using QL_BangKiem_KhaoSat.Models;

namespace QL_BangKiem_KhaoSat.Controllers
{
    public class ThayBangVetThuongNhiemController : Controller
    {
        public IActionResult Index()
        {
            var cacBuocTienHanh = new List<BuocTienHanh>
        {
            new BuocTienHanh { STT = 1, MoTa = "Xác định chính xác người bệnh lần thứ 2 (Chú ý 5 đúng)" },
            new BuocTienHanh { STT = 2, MoTa = "Chuẩn bị tư thế bệnh nhân thích hợp" },
            new BuocTienHanh { STT = 3, MoTa = "Để mâm nơi thuận tiện, gần vết thương" },
            new BuocTienHanh { STT = 4, MoTa = "Phơi bày vết thương" },
            new BuocTienHanh { STT = 5, MoTa = "Gỡ băng keo" },
            new BuocTienHanh { STT = 6, MoTa = "Sát khuẩn tay nhanh" },
            new BuocTienHanh { STT = 7, MoTa = "Gỡ khăn vô khuẩn đậy mâm ra" },
            new BuocTienHanh { STT = 8, MoTa = "Mang găng tay" },
            new BuocTienHanh { STT = 9, MoTa = "Tháo băng dơ (kềm, găng,...)" },
            new BuocTienHanh { STT = 10, MoTa = "Dùng kềm gấp gòn viên thấm dung dịch sát khuẩn vừa đi rửa từ trong ra ngoài" },
            new BuocTienHanh { STT = 11, MoTa = "Rửa bờ vết thương" },
            new BuocTienHanh { STT = 12, MoTa = "Rửa vùng da xung quanh vết thương 5cm ( chú ý tiếp liệu theo nguyên tắc vô khuẩn )" },
            new BuocTienHanh { STT = 13, MoTa = "Dùng gạc chặm khô mặt trong vết thương" },
            new BuocTienHanh { STT = 14, MoTa = "Dùng gòn viên khô lau vùng da xung quanh vết thương (nếu da ròm lở thì dùng gạc)" },
            new BuocTienHanh { STT = 15, MoTa = "Sát khuẩn vùng da xung quanh vết thương bằng iodine (nếu da không bị rơm lở)/bôi trơn khi vết thương rơm lở." },
            new BuocTienHanh { STT = 16, MoTa = "Đặt gạc miếng, gòn bao che kín vết thương (chú ý phải che kín vết thương và ra xung quanh khoảng 3cm)" },
            new BuocTienHanh { STT = 17, MoTa = "Tháo găng tay" },
            new BuocTienHanh { STT = 18, MoTa = "Dán băng keo lên vết thương(chú ý dán kín mép gạc, tránh để hở)" },
            new BuocTienHanh { STT = 19, MoTa = "Báo cáo và giải thích cho người bệnh việc đã xong, giúp người bệnh tiện nghi." },
            new BuocTienHanh { STT = 20, MoTa = "Phân loại chất thải y tế theo quy định" },
            new BuocTienHanh { STT = 21, MoTa = "Thu dọn dụng cụ mang về phòng" }
        };

            return View(cacBuocTienHanh); // Giả sử bạn dùng chung View hoặc có View tương tự
        }

        [HttpPost]
        public IActionResult LuuKetQua(List<KetQuaBuocTienHanh> ketQua)
        {
            // Logic lưu kết quả cho bảng kiểm thay băng vết thương nhiễm
            // ...
            return Json(new { success = true });
        }
    }
}
